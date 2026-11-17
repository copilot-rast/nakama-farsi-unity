using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ContentPublishWindow : EditorWindow
    {
        private AssetSyncSettings _settings;
        private ContentTarget _target;
        private string _note = string.Empty;
        private string _message;
        private MessageType _messageType;
        private bool _busy;

        [MenuItem("Tools/PolicePatrol/Content Publish")]
        public static void Open() => GetWindow<ContentPublishWindow>("Content Publish");

        private void OnEnable() => _settings = AssetSyncSettings.Load();

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Server", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Server URL", _settings.ServerUrl);
            EditorGUILayout.LabelField("Workspace", _settings.Workspace);
            EditorGUILayout.LabelField("Build target", EditorUserBuildSettings.activeBuildTarget.ToString());
            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
            {
                EditorGUILayout.HelpBox("Content is built for the active platform. Players need Android: switch to Android (File > Build Profiles) and publish again. Each platform keeps its own folder on the server.", MessageType.Warning);
            }
            EditorGUILayout.HelpBox("Server, workspace and API key come from Tools > PolicePatrol > Asset Sync. The key needs the Content feature (view, create, edit).", MessageType.None);

            GUI.enabled = !_busy;
            _settings.ContentKey = EditorGUILayout.TextField("Content key", _settings.ContentKey);
            EditorGUILayout.LabelField("Key for this build", _settings.ResolvedContentKey);
            EditorGUILayout.HelpBox("Put {version} in the key (for example game-content-{version}) to give every app version its own content. Old app versions then keep working after you publish a new one.", MessageType.None);
            _note = EditorGUILayout.TextField("Release note", _note);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("1. Set up"))
            {
                Run(async () =>
                {
                    _target = await ContentApi.FindOrCreateTargetAsync(_settings);
                    return AddressablesSetup.Configure(PolicePatrol.Sdk.Unity.PolicePatrolContentUrls.RuntimeVariable);
                });
            }

            if (GUILayout.Button("2. Build and publish"))
            {
                Run(async () =>
                {
                    var folder = ContentBuilder.Build();
                    var files = ContentBuilder.Describe(folder);
                    var plan = await ContentApi.PlanAsync(_settings, null, files);
                    var zip = ContentBuilder.Zip(folder, new HashSet<string>(plan.Missing));
                    _target = await ContentApi.PublishAsync(_settings, plan, zip, _note);
                    return $"Published pack {_target.VersionName}: uploaded {plan.Missing.Count} changed files, kept {plan.ReusedCount} unchanged ({plan.ReusedBytes / 1024f / 1024f:0.0} MB not sent). {_target.FileCount} files, {_target.TotalBytes / 1024f / 1024f:0.0} MB at {_target.Url}";
                });
            }

            if (GUILayout.Button("Check download access"))
            {
                Run(async () =>
                {
                    _target = await ContentApi.FindOrCreateTargetAsync(_settings);
                    var access = await ContentApi.CheckAccessAsync(_settings, _target.ContentId);
                    return (bool?)access["reachable"] == true
                        ? "Players can download from " + access["url"]
                        : "Players cannot download yet: " + access["error"];
                });
            }

            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;

            if (_target != null)
            {
                EditorGUILayout.LabelField("Live pack", _target.Version == 0 ? "nothing published yet" : _target.VersionName);
                EditorGUILayout.LabelField("Address", _target.Url);
            }

            if (!string.IsNullOrEmpty(_message))
            {
                EditorGUILayout.HelpBox(_message, _messageType);
            }
        }

        private async void Run(Func<Task<string>> work)
        {
            _settings.Save();
            var problem = _settings.ServerProblem;
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
                Show(error.Status == 403 ? "This API key has no access to content. Give it the content:write scope (and content:publish to make packs live) in the panel (Developer tools › API keys)." : error.Message, MessageType.Error);
            }
            catch (HttpRequestException error)
            {
                Show("Could not reach the server: " + error.Message, MessageType.Error);
            }
            catch (TaskCanceledException)
            {
                Show("The server did not answer in time.", MessageType.Error);
            }
            catch (Exception error)
            {
                Debug.LogException(error);
                Show(error.Message, MessageType.Error);
            }
            finally
            {
                _busy = false;
                Repaint();
            }
        }

        private void Show(string message, MessageType type)
        {
            _message = message;
            _messageType = type;
            Repaint();
        }
    }
}
