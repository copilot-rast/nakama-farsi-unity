using PolicePatrol.Sdk;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Economy;
using UnityEngine;

public class PolicePatrolQuickStart : MonoBehaviour
{
    private void Start()
    {
        PolicePatrolSdk.Client.SessionExpired += OnSessionExpired;

        if (AuthProvider.IsLoggedIn)
        {
            LoadCurrencies();
            return;
        }

        AuthProvider.DeviceIdLogin(SystemInfo.deviceUniqueIdentifier, result =>
        {
            if (!result.IsSuccess)
            {
                Debug.LogWarning($"Login failed: {result.Error.Code}");
                return;
            }

            LoadCurrencies();
        });
    }

    private void OnDestroy()
    {
        if (PolicePatrolSdk.IsInitialized)
        {
            PolicePatrolSdk.Client.SessionExpired -= OnSessionExpired;
        }
    }

    private static void LoadCurrencies()
    {
        CurrencyProvider.List(1, 20, result =>
        {
            if (!result.IsSuccess)
            {
                Debug.LogWarning($"Currencies failed: {result.Error.Code}");
                return;
            }

            Debug.Log($"Currencies: {result.Data.Total}");
        });
    }

    private static void OnSessionExpired()
    {
        AuthProvider.DeviceIdLogin(SystemInfo.deviceUniqueIdentifier, null);
    }
}
