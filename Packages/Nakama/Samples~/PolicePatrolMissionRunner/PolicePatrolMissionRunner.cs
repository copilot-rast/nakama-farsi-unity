using System;
using System.Globalization;
using PolicePatrol.Sdk.Stages;
using UnityEngine;

public sealed class PolicePatrolMissionRunner : MonoBehaviour
{
    private const string SavedKey = "mission.pending";

    [SerializeField] private string stageKey = "stage-1";

    private string _stageKey;
    private string _attemptId;
    private bool _sending;

    private void OnEnable() => SendSavedResult(null);

    [ContextMenu("Begin")]
    public void Begin() => Begin(stageKey);

    public void Begin(string key) => SendSavedResult(() => StartAttempt(key));

    [ContextMenu("Finish (won)")]
    public void FinishWon() => Finish(true, 95, 80);

    public void Finish(bool success, double elapsedSeconds, double? healthPercent)
    {
        if (_attemptId == null)
        {
            return;
        }

        var inv = CultureInfo.InvariantCulture;
        var saved = string.Join("|", _stageKey, _attemptId, success ? "1" : "0",
            elapsedSeconds.ToString(inv),
            healthPercent.HasValue ? healthPercent.Value.ToString(inv) : string.Empty);
        PlayerPrefs.SetString(SavedKey, saved);
        PlayerPrefs.Save();
        _attemptId = null;
        SendSavedResult(null);
    }

    private void StartAttempt(string key)
    {
        _stageKey = key;
        _attemptId = null;
        StageProvider.Start(key, r =>
        {
            if (r.IsSuccess)
            {
                _attemptId = r.Data.AttemptId;
            }
            else if (r.Error.Code == StageErrorCodes.Locked)
            {
                Debug.Log("This stage is locked");
                return;
            }
            else if (r.Error.IsNetworkError)
            {
                Debug.Log("No connection: this run will not pay");
            }

            Debug.Log("Mission started: " + key);
        });
    }

    private void SendSavedResult(Action then)
    {
        var saved = PlayerPrefs.GetString(SavedKey, string.Empty);
        if (saved.Length == 0)
        {
            then?.Invoke();
            return;
        }

        if (_sending)
        {
            Debug.Log("The last result is still being sent; try again in a moment");
            return;
        }

        var p = saved.Split('|');
        if (p.Length < 5)
        {
            Forget();
            then?.Invoke();
            return;
        }

        var inv = CultureInfo.InvariantCulture;
        double? health = p[4].Length == 0 ? (double?)null : double.Parse(p[4], inv);
        _sending = true;
        StageProvider.Complete(p[0], p[1], p[2] == "1", double.Parse(p[3], inv), health, r =>
        {
            _sending = false;
            if (!r.IsSuccess && (r.Error.IsNetworkError || r.Error.Code == StageErrorCodes.Busy || r.Error.Status >= 500))
            {
                Debug.Log("Could not send the last result. Show \"Try again\"; a new attempt would close the saved one");
                return;
            }

            if (!r.IsSuccess && r.Error.Code == StageErrorCodes.ServerOwned)
            {
                Debug.Log("The server owns the result of " + p[0] + "; the saved result is kept aside, not sent again");
                PlayerPrefs.SetString(SavedKey + ".serverOwned", saved);
                Forget();
                then?.Invoke();
                return;
            }

            Forget();
            if (r.IsSuccess)
            {
                ShowResult(r.Data);
            }
            else
            {
                Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
            }

            then?.Invoke();
        });
    }

    private static void Forget()
    {
        PlayerPrefs.DeleteKey(SavedKey);
        PlayerPrefs.Save();
    }

    private static void ShowResult(StageResult result)
    {
        Debug.Log("Stars " + result.Stars + ", xp +" + result.XpGained + (result.LeveledUp ? ", level up!" : string.Empty));
        if (result.IsRewardLimited)
        {
            Debug.Log("Come back " + (result.NextRewardAt.HasValue ? "after " + result.NextRewardAt.Value.ToLocalTime().ToString("t", CultureInfo.CurrentCulture) : "later") + " for more rewards");
        }
    }
}
