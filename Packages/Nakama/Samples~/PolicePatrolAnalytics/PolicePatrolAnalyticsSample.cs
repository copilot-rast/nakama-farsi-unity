using NakamaFarsi.Sdk.Analytics;
using PolicePatrol.Sdk.Analytics;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Unity;
using UnityEngine;

public sealed class PolicePatrolAnalyticsSample : MonoBehaviour
{
    private float _metres;

    private void Start()
    {
        PolicePatrolStats.TrophiesReceived += trophies =>
        {
            foreach (var trophy in trophies)
            {
                Debug.Log("Trophy: " + trophy.Name);
            }
        };
        PolicePatrolStats.Begin();

        if (!AuthProvider.IsLoggedIn)
        {
            AuthProvider.DeviceIdLogin(SystemInfo.deviceUniqueIdentifier, _ => { });
        }

        PolicePatrolAnalytics.SetCustomDimension("storeBuild", "bazaar");
        PolicePatrolAnalytics.SetContext("mode", "story");
        PolicePatrolAnalytics.SetContext("chapter", "Chapter1");
        PolicePatrolAnalytics.SetContext("stage", "Stage3");
        PolicePatrolAnalytics.SetContext("vehicleClass", "SUV");
        PolicePatrolAnalytics.SetContext("vehicle", "SantaFe");
        PolicePatrolAnalytics.SetContext("weather", "rain");
        PolicePatrolAnalytics.SetContext("attemptId", System.Guid.NewGuid().ToString("N"));
        PolicePatrolAnalytics.AddProgressionEvent(ProgressionStatus.Start, "Chapter1", "Stage3");
    }

    private void Update()
    {
        _metres += 10f * Time.deltaTime;
        if (_metres >= 100f)
        {
            PolicePatrolAnalytics.AddDesignEvent("Vehicle:Distance:SUV:SantaFe", _metres / 1000f);
            PolicePatrolStats.Add("distance_km", _metres / 1000f);
            _metres = 0f;
        }
    }

    public void OnCrash(string what) => PolicePatrolAnalytics.AddDesignEvent("Vehicle:Crash:" + what, 1);

    public void OnFinished(bool won, int score)
    {
        PolicePatrolAnalytics.AddProgressionEvent(won ? ProgressionStatus.Complete : ProgressionStatus.Fail, "Chapter1", "Stage3", null, score);
        if (won)
        {
            PolicePatrolAnalytics.AddResourceEvent(ResourceFlow.Source, "coin", 50, "Stage", "Stage3");
        }

        PolicePatrolAnalytics.Flush();
    }
}
