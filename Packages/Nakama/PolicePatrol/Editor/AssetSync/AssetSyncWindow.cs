using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PolicePatrol.Sdk.Assets;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetSyncWindow : EditorWindow
    {
        private const int RowsPerGroup = 200;

        private static readonly AssetSyncStatus[] Groups =
        {
            AssetSyncStatus.New, AssetSyncStatus.Changed, AssetSyncStatus.ServerNewer, AssetSyncStatus.Conflict,
            AssetSyncStatus.Differs, AssetSyncStatus.OtherFile, AssetSyncStatus.ServerOnly, AssetSyncStatus.Same,
        };

        private static readonly string[] RouteGroups =
        {
            AssetRoutingActions.Error, AssetRoutingActions.Pending, AssetRoutingActions.Skipped, AssetRoutingActions.Deactivated, AssetRoutingActions.Created,
            AssetRoutingActions.Updated, AssetRoutingActions.Linked, AssetRoutingActions.Unchanged, AssetRoutingActions.Dependency, AssetRoutingActions.Stored,
        };

        private readonly Dictionary<AssetSyncStatus, bool> _open = new Dictionary<AssetSyncStatus, bool>();
        private readonly Dictionary<string, bool> _routeOpen = new Dictionary<string, bool>();
        private bool _dryRun;
        private AssetPushReport _lastPush;
        private AssetSyncSettings _settings;
        private AssetSyncSession _session;
        private string _apiKey;
        private string _idFields;
        private string _message;
        private MessageType _messageType;
        private bool _busy;
        private Vector2 _scroll;

        [MenuItem("Tools/PolicePatrol/Asset Sync")]
        public static void Open() => GetWindow<AssetSyncWindow>("Asset Sync");

        private void OnEnable()
        {
            _settings = AssetSyncSettings.Load();
            _apiKey = _settings.ApiKey;
            _idFields = string.Join(", ", _settings.IdFields);
        }

        private void OnGUI()
        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);
            GUI.enabled = !_busy;
            DrawSettings();
            EditorGUILayout.Space();
            DrawActions();
            GUI.enabled = true;
            if (!string.IsNullOrEmpty(_message))
            {
                EditorGUILayout.HelpBox(_message, _messageType);
            }

            DrawScanProblems();
            DrawRouting();
            DrawDiff();
            EditorGUILayout.EndScrollView();
        }

        private void DrawSettings()
        {
            EditorGUILayout.LabelField("Server", EditorStyles.boldLabel);
            _settings.ServerUrl = EditorGUILayout.TextField("Server URL", _settings.ServerUrl);
            _settings.Workspace = EditorGUILayout.TextField("Workspace", _settings.Workspace);
            _apiKey = EditorGUILayout.PasswordField("API key", _apiKey);
            _idFields = EditorGUILayout.TextField("ID field names", _idFields);

            EditorGUILayout.LabelField("Folders to sync", EditorStyles.boldLabel);
            foreach (var folder in _settings.Folders.ToList())
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(folder);
                if (GUILayout.Button("Remove", GUILayout.Width(70)))
                {
                    _settings.Folders.Remove(folder);
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Add selected folder"))
            {
                var path = Selection.activeObject != null ? AssetDatabase.GetAssetPath(Selection.activeObject) : null;
                if (path != null && AssetDatabase.IsValidFolder(path) && !_settings.Folders.Contains(path))
                {
                    _settings.Folders.Add(path);
                }
                else
                {
                    Show("Select a folder in the Project window first.", MessageType.Info);
                }
            }

            if (GUILayout.Button("Save settings"))
            {
                SaveSettings();
                Show("Settings saved. The API key is kept on this computer only.", MessageType.Info);
            }

            EditorGUILayout.EndHorizontal();
        }

        private void DrawActions()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Compare with server"))
            {
                Run(async () =>
                {
                    _session = await AssetSyncRunner.CompareAsync(_settings);
                    return Summary(_session);
                });
            }

            if (GUILayout.Button("Build registry only"))
            {
                Run(() =>
                {
                    var scan = AssetScanner.Scan(_settings);
                    AssetRegistryBuilder.Build(scan);
                    return Task.FromResult("Registry saved with " + scan.Assets.Count + " assets at " + AssetSyncSettings.RegistryPath + ".");
                }, needsServer: false);
            }

            EditorGUILayout.EndHorizontal();

            if (_session == null)
            {
                return;
            }

            var push = _session.With(AssetSyncStatus.New, AssetSyncStatus.Changed);
            var pull = _session.With(AssetSyncStatus.ServerNewer);
            var serverOnly = _session.With(AssetSyncStatus.ServerOnly);
            _dryRun = EditorGUILayout.ToggleLeft("Dry run: show where each card would go, save nothing", _dryRun);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button($"Push {push.Length} (new + changed)") && push.Length > 0)
            {
                Run(() => PushFresh(AssetSyncStatus.New, AssetSyncStatus.Changed));
            }

            if (GUILayout.Button($"Pull {pull.Length} (newer on server)") && pull.Length > 0)
            {
                Run(() => PullFresh(_session.With(AssetSyncStatus.ServerNewer)));
            }

            if (GUILayout.Button($"Delete {serverOnly.Length} server-only") && serverOnly.Length > 0
                && EditorUtility.DisplayDialog("Delete on server", $"Delete {serverOnly.Length} asset(s) that are on the server but not in these folders? The game will stop receiving them.", "Delete", "Cancel"))
            {
                Run(() => Push(Array.Empty<AssetDiffEntry>(), serverOnly));
            }

            EditorGUILayout.EndHorizontal();
        }

        private void DrawScanProblems()
        {
            var scan = _session?.Scan;
            if (scan == null)
            {
                return;
            }

            if (scan.Duplicates.Count > 0)
            {
                EditorGUILayout.HelpBox("These files share an id (upper and lower case count as the same). Give one of each pair a new id before syncing:\n" + string.Join("\n",
                    scan.Duplicates.Select(pair => "• \"" + pair.Key + "\": " + string.Join("  and  ", pair.Value))), MessageType.Error);
            }

            if (scan.InvalidIds.Count > 0)
            {
                EditorGUILayout.HelpBox("These ids may only use English letters, digits and _ - . : (at most 128):\n" + string.Join("\n",
                    scan.InvalidIds.Select(asset => "• \"" + asset.AssetId + "\": " + asset.Path)), MessageType.Error);
            }

            if (scan.EmptyIds.Count > 0)
            {
                EditorGUILayout.HelpBox("These files have an id field but it is empty:\n" + string.Join("\n", scan.EmptyIds.Select(path => "• " + path)), MessageType.Error);
            }

            if (scan.Unreadable.Count > 0)
            {
                EditorGUILayout.HelpBox("Skipped (missing script):\n" + string.Join("\n", scan.Unreadable.Take(20).Select(path => "• " + path)), MessageType.Warning);
            }
        }

        private void DrawDiff()
        {
            if (_session == null)
            {
                return;
            }

            foreach (var status in Groups)
            {
                var entries = _session.With(status);
                if (entries.Length == 0)
                {
                    continue;
                }

                _open.TryGetValue(status, out var open);
                _open[status] = EditorGUILayout.Foldout(open, $"{Label(status)} ({entries.Length})");
                if (!_open[status])
                {
                    continue;
                }

                foreach (var entry in entries.Take(RowsPerGroup))
                {
                    DrawRow(entry);
                }

                if (entries.Length > RowsPerGroup)
                {
                    EditorGUILayout.LabelField($"… and {entries.Length - RowsPerGroup} more");
                }
            }
        }

        private void DrawRow(AssetDiffEntry entry)
        {
            EditorGUILayout.BeginHorizontal();
            var local = entry.Local;
            EditorGUILayout.LabelField(local != null ? local.Name : entry.Server.Name, local != null ? local.Folder : entry.Server.Folder);
            if (entry.Status == AssetSyncStatus.Differs || entry.Status == AssetSyncStatus.Conflict)
            {
                if (GUILayout.Button("Use mine", GUILayout.Width(80)))
                {
                    Run(() => Push(new[] { entry }, Array.Empty<AssetDiffEntry>()));
                }

                if (GUILayout.Button("Use server", GUILayout.Width(80)))
                {
                    Run(() => AssetSyncRunner.PullAsync(_settings, _session, new[] { entry }));
                }
            }

            if (local != null && GUILayout.Button("Select", GUILayout.Width(60)))
            {
                Selection.activeObject = _session.Scan.Find(entry.AssetId)?.Asset;
            }

            EditorGUILayout.EndHorizontal();
            if (entry.Status == AssetSyncStatus.OtherFile)
            {
                EditorGUILayout.HelpBox($"The server has this id for another file: {entry.Server.Folder}/{entry.Server.Name}. Change the id of one of them.", MessageType.Warning);
            }
        }

        private async Task<string> PushFresh(params AssetSyncStatus[] statuses)
        {
            _session = await AssetSyncRunner.CompareAsync(_settings);
            var message = await Push(_session.With(statuses), Array.Empty<AssetDiffEntry>());
            _session = await AssetSyncRunner.CompareAsync(_settings);
            return message;
        }

        private async Task<string> Push(IReadOnlyList<AssetDiffEntry> push, IReadOnlyList<AssetDiffEntry> delete)
        {
            _lastPush = await AssetSyncRunner.PushReportAsync(_settings, _session, push, delete, _dryRun);
            return _lastPush.Message;
        }

        private void DrawRouting()
        {
            if (_lastPush == null)
            {
                return;
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField(_lastPush.DryRun ? "Routing of the last dry run" : "Routing of the last push", EditorStyles.boldLabel);
            var routing = _lastPush.Routing;
            if (routing == null)
            {
                EditorGUILayout.HelpBox("The server did not route these cards to items: item routing is switched off, or nothing changed.", MessageType.Info);
                return;
            }

            EditorGUILayout.LabelField(routing.Describe(), EditorStyles.wordWrappedLabel);
            if (routing.Pending.Length > 0)
            {
                EditorGUILayout.HelpBox(routing.Pending.Length + " card(s) are pending: the entry they need has not arrived yet. They are routed again when it does.", MessageType.Warning);
            }

            if (routing.Errors.Length > 0)
            {
                EditorGUILayout.HelpBox(routing.Errors.Length + " card(s) could not be routed. Open the error group below.", MessageType.Error);
            }

            foreach (var action in RouteGroups.Concat((routing.Rows ?? Array.Empty<AssetRoutingRow>()).Select(r => r.Action).Where(a => !RouteGroups.Contains(a)).Distinct()))
            {
                var rows = routing.With(action);
                if (rows.Length == 0)
                {
                    continue;
                }

                _routeOpen.TryGetValue(action, out var open);
                _routeOpen[action] = EditorGUILayout.Foldout(open, $"{action} ({rows.Length})");
                if (!_routeOpen[action])
                {
                    continue;
                }

                foreach (var row in rows.Take(RowsPerGroup))
                {
                    var target = string.IsNullOrEmpty(row.Kind) ? (row.Type ?? string.Empty) : row.Kind + (string.IsNullOrEmpty(row.ItemKey) ? string.Empty : " / " + row.ItemKey);
                    var detail = row.Reason ?? row.Code ?? (row.Changes != null && row.Changes.Length > 0 ? string.Join(", ", row.Changes.Select(c => c.Field)) : string.Empty);
                    EditorGUILayout.LabelField(row.AssetId, string.IsNullOrEmpty(detail) ? target : target + "  ·  " + detail);
                }

                if (rows.Length > RowsPerGroup)
                {
                    EditorGUILayout.LabelField($"… and {rows.Length - RowsPerGroup} more");
                }
            }
        }

        private async Task<string> PullFresh(IReadOnlyList<AssetDiffEntry> entries)
        {
            var message = await AssetSyncRunner.PullAsync(_settings, _session, entries);
            _session = await AssetSyncRunner.CompareAsync(_settings);
            return message;
        }

        private async void Run(Func<Task<string>> work, bool needsServer = true)
        {
            SaveSettings();
            var problem = needsServer ? _settings.Problem : null;
            if (problem != null)
            {
                Show(problem, MessageType.Warning);
                return;
            }

            _busy = true;
            Show("Working…", MessageType.None);
            try
            {
                Show(await work(), MessageType.Info);
            }
            catch (AssetSyncException error)
            {
                Show(error.Message, MessageType.Error);
            }
            catch (HttpRequestException error)
            {
                Show("Could not reach the server: " + error.Message, MessageType.Error);
            }
            catch (TaskCanceledException)
            {
                Show("The server did not answer in time.", MessageType.Error);
            }
            catch (InvalidOperationException error)
            {
                Show(error.Message, MessageType.Error);
            }
            catch (Exception error)
            {
                Debug.LogException(error);
                Show("Something went wrong: " + error.Message, MessageType.Error);
            }
            finally
            {
                _busy = false;
                Repaint();
            }
        }

        private void SaveSettings()
        {
            _settings.ApiKey = _apiKey;
            _settings.IdFields = (_idFields ?? string.Empty).Split(',').Select(name => name.Trim()).Where(name => name.Length > 0).Distinct().ToList();
            _settings.Save();
        }

        private void Show(string message, MessageType type)
        {
            _message = message;
            _messageType = type;
            Repaint();
        }

        private static string Summary(AssetSyncSession session)
        {
            var parts = Groups.Select(status => (status, count: session.With(status).Length)).Where(p => p.count > 0).Select(p => $"{p.count} {Label(p.status).ToLowerInvariant()}");
            return $"Scanned {session.Scan.Assets.Count} assets: " + string.Join(", ", parts) + "." + (session.Scan.CanSync ? string.Empty : " Fix the id problems below before pushing.");
        }

        private static string Label(AssetSyncStatus status)
        {
            switch (status)
            {
                case AssetSyncStatus.New: return "New";
                case AssetSyncStatus.Changed: return "Changed here";
                case AssetSyncStatus.ServerNewer: return "Newer on server";
                case AssetSyncStatus.Conflict: return "Changed on both sides";
                case AssetSyncStatus.Differs: return "Different, never synced here";
                case AssetSyncStatus.OtherFile: return "Same id as another file on the server";
                case AssetSyncStatus.ServerOnly: return "Only on server";
                default: return "Same";
            }
        }
    }
}
