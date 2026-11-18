using System;
using NakamaFarsi.Sdk;
using NakamaFarsi.Sdk.Unity;
using UnityEngine;

public sealed class NakamaFarsiQuickStart : MonoBehaviour
{
    [SerializeField] private string phone = "";
    [SerializeField] private string code = "";

    private NakamaFarsiClient _client;

    private async void Start()
    {
        _client = NakamaFarsiRunner.IsInitialized ? NakamaFarsiRunner.Client : NakamaFarsiRunner.Initialize(NakamaFarsiConfig.Load());
        _client.Session.SessionExpired += () => Debug.LogWarning("Session expired; sign in again");
        _client.Notifications.Received += n => Debug.Log("Notification: " + n.Subject);
        try
        {
            if (!_client.IsLoggedIn)
            {
                await _client.LoginWithDeviceAsync(SystemInfo.deviceUniqueIdentifier);
            }

            var account = await _client.Rpcs.Base.AccountGetAsync();
            Debug.Log("Signed in as " + account.Raw["user"]?["username"] + ", socket: " + _client.Socket.IsConnected);
            var boards = await _client.Rpcs.Leaderboardx.ListAsync();
            Debug.Log("Leaderboards: " + boards.Raw["boards"]);
            var tasks = await _client.Rpcs.Economy.TasksListAsync();
            Debug.Log("Tasks: " + tasks.Raw["items"]);
            var phoneStatus = await _client.Phone.StatusAsync();
            Debug.Log("Phone: " + phoneStatus.Phone + ", SMS login on: " + phoneStatus.OtpEnabled);
        }
        catch (ApiException e)
        {
            Debug.LogWarning(e.Error.Code + ": " + e.Error.Message);
        }
    }

    [ContextMenu("Send SMS code")]
    public async void SendCode()
    {
        try
        {
            var sent = await _client.Phone.RequestCodeAsync(phone);
            Debug.Log("Code sent to " + sent.Phone + "; it has " + sent.CodeLength + " digits");
        }
        catch (ApiException e)
        {
            Debug.LogWarning(e.Error.Code + ": " + e.Error.Message);
        }
    }

    [ContextMenu("Verify SMS code")]
    public async void Verify()
    {
        try
        {
            var result = await _client.Phone.VerifyAsync(phone, code);
            Debug.Log("Phone login done for " + result.UserId + (result.NeedsProfile ? "; ask for a display name" : string.Empty));
        }
        catch (ApiException e)
        {
            Debug.LogWarning(e.Error.Code + ": " + e.Error.Message);
        }
    }
}
