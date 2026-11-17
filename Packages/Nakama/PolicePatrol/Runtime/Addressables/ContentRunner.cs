using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    internal sealed class ContentRunner : MonoBehaviour
    {
        private static ContentRunner _instance;

        public static ContentRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    var host = new GameObject("PolicePatrol Content") { hideFlags = HideFlags.HideAndDontSave };
                    DontDestroyOnLoad(host);
                    _instance = host.AddComponent<ContentRunner>();
                }

                return _instance;
            }
        }
    }
}
