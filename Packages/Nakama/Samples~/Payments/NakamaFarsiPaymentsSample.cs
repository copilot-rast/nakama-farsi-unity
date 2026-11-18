using NakamaFarsi.Sdk;
using NakamaFarsi.Sdk.Payments;
using NakamaFarsi.Sdk.Unity;
using UnityEngine;

public sealed class NakamaFarsiPaymentsSample : MonoBehaviour
{
    [SerializeField] private string productId = "";

    private NakamaFarsiClient _client;

    private async void Start()
    {
        _client = NakamaFarsiRunner.IsInitialized ? NakamaFarsiRunner.Client : NakamaFarsiRunner.Initialize(NakamaFarsiConfig.Load());
        _client.Payments.Completed += r => Debug.Log("Payment " + r.PaymentId + ": " + r.Outcome + " " + r.Message);
        try
        {
            if (!_client.IsLoggedIn)
            {
                await _client.LoginWithDeviceAsync(SystemInfo.deviceUniqueIdentifier);
            }

            var catalog = await _client.Payments.CatalogAsync();
            foreach (var p in catalog["products"])
            {
                Debug.Log(p["id"] + " " + p["name"] + " methods: " + p["paymentMethods"]);
            }

            await NakamaFarsiStore.SetupAsync(_client);
            Debug.Log("Store ready: " + NakamaFarsiStore.Method + (NakamaFarsiStore.Config.Sandbox ? " (sandbox, test store)" : string.Empty));
        }
        catch (ApiException e)
        {
            Debug.LogWarning(e.Error.Code + ": " + e.Error.Message);
        }
    }

    [ContextMenu("Buy with coins")]
    public async void BuyWithCoins() => Show(await _client.Payments.BuyAsync(productId, PaymentMethods.Coins));

    [ContextMenu("Buy in the store (Bazaar or Myket)")]
    public async void BuyInStore() => Show(await NakamaFarsiStore.BuyAsync(productId, _client));

    [ContextMenu("Buy with ZarinPal")]
    public async void BuyWithGateway() => Show(await NakamaFarsiGateway.BuyAsync(productId, PaymentMethods.ZarinPal, null, _client));

    private static void Show(PurchaseResult r)
    {
        if (r.IsSuccess)
        {
            Debug.Log("Bought. " + r.Message + " rewards: " + r.Rewards);
        }
        else if (r.IsRewardPending)
        {
            Debug.Log("Paid; the reward (" + r.ServerError + ") is still being granted by the server. Show \"your purchase is on its way\".");
        }
        else
        {
            Debug.LogWarning("Purchase " + r.Outcome + ": " + r.Error);
        }
    }
}
