using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ShopCardSyncWindow : EditorWindow
    {
        private const string Path = "/v2/shopx/editor/cards";

        private AssetSyncSettings _settings;
        private ShopCardScan _scan;
        private ShopCardRow[] _rows = Array.Empty<ShopCardRow>();
        private string _message;
        private MessageType _messageType;
        private bool _compared;
        private bool _busy;
        private Vector2 _scroll;

        [MenuItem("Tools/PolicePatrol/Shop Cards")]
        public static void Open() => GetWindow<ShopCardSyncWindow>("Shop Cards");

        private void OnEnable() => _settings = AssetSyncSettings.Load();

        private void OnGUI()
        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);
            EditorGUILayout.LabelField("Server", _settings.ServerUrl + " (" + _settings.Workspace + ")");
            var problem = _settings.ServerProblem;
            if (problem != null)
            {
                EditorGUILayout.HelpBox(problem, MessageType.Warning);
            }

            GUI.enabled = !_busy && problem == null;
            if (GUILayout.Button("Compare with server"))
            {
                Run(() => CompareAsync());
            }

            GUI.enabled = !_busy && problem == null && _compared;
            if (GUILayout.Button("Upload"))
            {
                Run(() => UploadAsync());
            }

            GUI.enabled = true;
            if (!string.IsNullOrEmpty(_message))
            {
                EditorGUILayout.HelpBox(_message, _messageType);
            }

            DrawList(_scan?.Problems, MessageType.Error);
            DrawList(_scan?.Warnings, MessageType.Warning);
            foreach (var row in _rows)
            {
                EditorGUILayout.LabelField(row.Key, row.ErrorCode == null ? row.Action : row.Action + ": " + row.ErrorCode);
            }

            EditorGUILayout.EndScrollView();
        }

        private static void DrawList(List<string> lines, MessageType type)
        {
            if (lines == null)
            {
                return;
            }

            foreach (var line in lines)
            {
                EditorGUILayout.HelpBox(line, type);
            }
        }

        private async void Run(Func<Task> work)
        {
            _busy = true;
            _message = null;
            try
            {
                await work();
            }
            catch (Exception error)
            {
                _compared = false;
                _message = error.Message;
                _messageType = MessageType.Error;
            }
            finally
            {
                _busy = false;
                Repaint();
            }
        }

        private async Task CompareAsync()
        {
            _compared = false;
            _rows = Array.Empty<ShopCardRow>();
            _scan = ShopCardScanner.Scan();
            if (_scan.Problems.Count > 0)
            {
                _message = "Fix these cards first.";
                _messageType = MessageType.Error;
                return;
            }

            if (_scan.Items.Count == 0)
            {
                _message = "No ScriptableObject implements IShopProductCard, so nothing was sent.";
                _messageType = MessageType.Warning;
                return;
            }

            _rows = await SendAsync(true);
            _compared = true;
            _message = Summary("Compared");
            _messageType = MessageType.Info;
        }

        private async Task UploadAsync()
        {
            var removed = _rows.Count(row => row.Action == "deactivated");
            if (removed > 0 && !EditorUtility.DisplayDialog(
                "Shop Cards",
                removed + " product(s) have no card here any more and will be deactivated on the server.",
                "Upload",
                "Cancel"))
            {
                return;
            }

            _rows = await SendAsync(false);
            _compared = false;
            _message = Summary("Uploaded");
            _messageType = _rows.Any(row => row.Action == "failed") ? MessageType.Warning : MessageType.Info;
        }

        private async Task<ShopCardRow[]> SendAsync(bool dryRun)
        {
            var body = new JObject { ["items"] = _scan.Items, ["dryRun"] = dryRun };
            var result = await EditorApiClient.SendJsonAsync<ShopCardSyncResult>(_settings, HttpMethod.Post, Path, body);
            return result.Rows;
        }

        private string Summary(string verb) =>
            verb + ": " + string.Join(", ", _rows.GroupBy(row => row.Action).Select(group => group.Count() + " " + group.Key));
    }
}
