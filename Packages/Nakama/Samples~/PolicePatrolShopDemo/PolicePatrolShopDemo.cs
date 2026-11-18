using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PolicePatrol.Sdk;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Economy;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Shop;
using PolicePatrol.Sdk.Unity;
using UnityEngine;

public class PolicePatrolShopDemo : MonoBehaviour
{
    private const int MaxLogLines = 60;

    [SerializeField] private int fontSize = 18;
    [SerializeField] private float iconSize = 64f;

    private readonly List<string> _log = new List<string>();
    private readonly Dictionary<string, Texture2D> _icons = new Dictionary<string, Texture2D>();
    private IReadOnlyList<ShopItem> _items = Array.Empty<ShopItem>();
    private IReadOnlyList<UserCurrency> _balances = Array.Empty<UserCurrency>();
    private ProductIAP _shop;
    private TestStoreBilling _testStore;
    private bool _busy;
    private Vector2 _pageScroll;
    private Vector2 _logScroll;

    private void Start()
    {
        Log("Logging in with the device id");
        AuthProvider.DeviceIdLogin(SystemInfo.deviceUniqueIdentifier, login =>
        {
            if (!login.IsSuccess)
            {
                LogError("Login", login.Error);
                return;
            }

            Log("Logged in");
            SetupStore();
        });
    }

    private void SetupStore()
    {
        if (PolicePatrolStore.Billing != null)
        {
            Log("Using the store adapter registered before: " + PolicePatrolStore.Billing.GetType().Name);
            StartShop();
            return;
        }

        Log("Asking the server which store to use for " + PolicePatrolStore.Method);
        PolicePatrolStore.Setup(result =>
        {
            if (!result.IsSuccess)
            {
                LogError("Store", result.Error);
                return;
            }

            Log("Store: " + result.Data.GetType().Name);
            StartShop();
        });
    }

    private void StartShop()
    {
        _testStore = PolicePatrolStore.Billing as TestStoreBilling;
        _shop = PolicePatrolStore.CreateShop();
        Recheck(Reload);
    }

    private void Recheck(Action then = null)
    {
        _busy = true;
        Log("Rechecking unfinished purchases");
        _shop.RecheckPending(result =>
        {
            _busy = false;
            Log($"Recheck: confirmed {result.Confirmed}, already done {result.AlreadyDone}, still pending {result.StillPending}"
                + (result.StillPending > 0 ? " (" + string.Join(", ", result.PendingErrorCodes) + ")" : string.Empty)
                + (result.RewardPendingPaymentIds.Count > 0 ? $", {result.RewardPendingPaymentIds.Count} paid and waiting for the reward" : string.Empty));
            if (result.HasRecovered)
            {
                LoadBalances();
            }

            then?.Invoke();
        });
    }

    private void Reload()
    {
        LoadBalances();
        _busy = true;
        Log("Loading the shop");
        _shop.Load(result =>
        {
            _busy = false;
            if (!result.IsSuccess)
            {
                LogError("Shop", result.Error);
                return;
            }

            _items = result.Data;
            Log($"Shop has {_items.Count} product(s) for {_shop.Method}");
            foreach (var item in _items)
            {
                if (_testStore != null)
                {
                    _testStore.Prices[item.StoreSku] = Money(item.FinalPrice);
                }

                PolicePatrolSprites.LoadIcon(item, sprite =>
                {
                    if (sprite != null)
                    {
                        _icons[item.Id] = sprite.texture;
                    }
                });
            }
        });
    }

    private void LoadBalances()
    {
        CurrencyProvider.List(1, 50, result =>
        {
            if (!result.IsSuccess)
            {
                LogError("Balances", result.Error);
                return;
            }

            _balances = result.Data.Items;
        });
    }

    private void Buy(ShopItem item)
    {
        _busy = true;
        Log("Buying " + item.Name);
        _shop.Buy(item, result =>
        {
            _busy = false;
            if (!result.IsSuccess)
            {
                if (result.Error.Code == PaymentErrorCodes.RewardPending)
                {
                    Log("Paid; the reward is still being granted by the server. \"Recheck purchases\" follows it.");
                    return;
                }

                LogError("Buy", result.Error);
                if (result.Error.Code == ProductIAP.PurchaseFailedCode && _testStore != null && _testStore.UnconsumedCount > 0)
                {
                    Log("The purchase is paid but not confirmed. Press \"Recheck purchases\" to finish it.");
                }

                return;
            }

            Log($"Payment {result.Data.Id} is {result.Data.Status}");
            Log(item.PurchaseMessage ?? item.Title);
            LoadBalances();
        });
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;
        GUI.skin.button.fontSize = fontSize;
        GUI.skin.toggle.fontSize = fontSize;
        GUI.skin.label.wordWrap = true;

        GUILayout.BeginArea(new Rect(16f, 16f, Screen.width - 32f, Screen.height - 32f));
        _pageScroll = GUILayout.BeginScrollView(_pageScroll, GUILayout.Height((Screen.height - 32f) * 0.65f));
        DrawBalances();
        DrawActions();
        DrawProducts();
        GUILayout.EndScrollView();
        DrawLog();
        GUILayout.EndArea();
    }

    private void DrawBalances()
    {
        GUILayout.Label("Balances");
        if (_balances.Count == 0)
        {
            GUILayout.Label("  (no currency yet)");
        }

        foreach (var balance in _balances)
        {
            GUILayout.Label($"  {CurrencyName(balance.CurrencyId)}: {Number(balance.Value)}");
        }
    }

    private void DrawActions()
    {
        GUI.enabled = _shop != null && !_busy;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Recheck purchases", GUILayout.Height(40f)))
        {
            Recheck();
        }

        if (GUILayout.Button("Reload", GUILayout.Height(40f)))
        {
            Reload();
        }

        GUILayout.EndHorizontal();
        if (_testStore != null)
        {
            _testStore.SimulateAppClosedBeforeServerAnswer = GUILayout.Toggle(
                _testStore.SimulateAppClosedBeforeServerAnswer,
                "Simulate: app closed before the server answered");
        }

        GUI.enabled = true;
    }

    private void DrawProducts()
    {
        GUILayout.Label("Products");
        foreach (var item in _items)
        {
            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.BeginHorizontal();
            if (_icons.TryGetValue(item.Id, out var icon) && icon != null)
            {
                GUILayout.Label(icon, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
            }

            GUILayout.BeginVertical();
            GUILayout.Label(item.Name + (item.IsSubscription ? "  [subscription]" : string.Empty));
            GUILayout.Label(PriceLine(item));
            GUILayout.Label("Gives: " + PrizeSummary(item));
            if (item.MinLevel > 0)
            {
                GUILayout.Label("Min level: " + item.MinLevel.ToString(CultureInfo.InvariantCulture));
            }

            GUILayout.EndVertical();
            GUI.enabled = !_busy;
            if (GUILayout.Button("Buy", GUILayout.Width(100f), GUILayout.Height(44f)))
            {
                Buy(item);
            }

            GUI.enabled = true;
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }

    private void DrawLog()
    {
        GUILayout.Label("Status");
        _logScroll = GUILayout.BeginScrollView(_logScroll);
        for (var i = _log.Count - 1; i >= 0; i--)
        {
            GUILayout.Label(_log[i]);
        }

        GUILayout.EndScrollView();
    }

    private string PriceLine(ShopItem item)
    {
        if (!item.HasDiscount)
        {
            return "Price: " + Money(item.FinalPrice);
        }

        return $"Price: {Money(item.FinalPrice)}  (was {Money(item.OriginalPrice)}, -{Number(item.DiscountPercent)}%)";
    }

    private string PrizeSummary(ShopItem item)
    {
        var parts = item.Prize?.PrizeItems?
            .Select(prize => $"{prize.Action} {prize.Value} {(prize.Type == "currency" ? CurrencyName(prize.ItemId) : prize.Type)}")
            .ToList();
        return parts == null || parts.Count == 0 ? "nothing" : string.Join(", ", parts);
    }

    private string CurrencyName(string currencyId)
    {
        var currency = _balances.FirstOrDefault(balance => balance.CurrencyId == currencyId)?.Currency;
        return currency?.Name ?? currency?.Key ?? currencyId;
    }

    private static string Money(double value) => value.ToString("#,0.##", CultureInfo.InvariantCulture);

    private static string Number(double value) => value.ToString("0.##", CultureInfo.InvariantCulture);

    private void LogError(string step, ApiError error) => Log($"{step} failed: {error?.Code} {error?.Message}");

    private void Log(string line)
    {
        _log.Add(DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "  " + line);
        if (_log.Count > MaxLogLines)
        {
            _log.RemoveAt(0);
        }

        Debug.Log("[ShopDemo] " + line);
    }
}
