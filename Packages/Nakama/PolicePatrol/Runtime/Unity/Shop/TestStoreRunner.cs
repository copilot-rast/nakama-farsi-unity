using System;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    internal sealed class TestStoreRunner : MonoBehaviour
    {
        private const float PanelWidth = 440f;
        private const float PanelHeight = 260f;

        private static TestStoreRunner _instance;

        private string _sku;
        private string _price;
        private Action<bool> _onChoice;

        public static TestStoreRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    var host = new GameObject("PolicePatrol Test Store") { hideFlags = HideFlags.HideAndDontSave };
                    DontDestroyOnLoad(host);
                    _instance = host.AddComponent<TestStoreRunner>();
                }

                return _instance;
            }
        }

        public bool IsOpen => _onChoice != null;

        public void Show(string sku, string price, Action<bool> onChoice)
        {
            _sku = sku;
            _price = price;
            _onChoice = onChoice;
        }

        private void OnGUI()
        {
            if (_onChoice == null)
            {
                return;
            }

            GUI.depth = -1000;
            var screen = new Rect(0f, 0f, Screen.width, Screen.height);
            GUI.Box(screen, string.Empty);
            GUI.Box(screen, string.Empty);

            var width = Math.Min(PanelWidth, Screen.width - 32f);
            var panel = new Rect((Screen.width - width) / 2f, (Screen.height - PanelHeight) / 2f, width, PanelHeight);
            GUI.Box(panel, string.Empty);
            GUILayout.BeginArea(new Rect(panel.x + 16f, panel.y + 16f, panel.width - 32f, panel.height - 32f));
            GUILayout.Label("Test store");
            GUILayout.Label("SKU: " + _sku);
            if (!string.IsNullOrEmpty(_price))
            {
                GUILayout.Label("Price: " + _price);
            }

            GUILayout.Label("No real money is taken. The server accepts this purchase only while store sandbox is on.");
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Pay", GUILayout.Height(44f)))
            {
                Choose(true);
            }

            if (GUILayout.Button("Cancel", GUILayout.Height(44f)))
            {
                Choose(false);
            }

            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void Choose(bool paid)
        {
            var onChoice = _onChoice;
            _onChoice = null;
            onChoice?.Invoke(paid);
        }
    }
}
