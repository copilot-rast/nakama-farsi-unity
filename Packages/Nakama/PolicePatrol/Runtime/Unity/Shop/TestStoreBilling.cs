using System;
using System.Collections.Generic;
using PolicePatrol.Sdk.Shop;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public sealed class TestStoreBilling : IStoreBilling
    {
        public const string PrefsKey = "policepatrol.teststore.purchases";
        public const string BusyError = "The test store is already showing a purchase";

        private readonly TestStoreLedger _ledger;

        public TestStoreBilling()
        {
            _ledger = new TestStoreLedger(PlayerPrefs.GetString(PrefsKey, null), Save);
        }

        public string Method => PolicePatrolStore.Method;

        public bool SimulateAppClosedBeforeServerAnswer { get; set; }

        public IDictionary<string, string> Prices { get; } = new Dictionary<string, string>();

        public int UnconsumedCount => _ledger.Unconsumed.Count;

        public void Purchase(string sku, string developerPayload, Action<StorePurchaseResult> onComplete)
        {
            var runner = TestStoreRunner.Instance;
            if (runner.IsOpen)
            {
                onComplete?.Invoke(StorePurchaseResult.Failed(BusyError));
                return;
            }

            Prices.TryGetValue(sku ?? string.Empty, out var price);
            runner.Show(sku, price, paid => onComplete?.Invoke(paid
                ? _ledger.Pay(sku, developerPayload, SimulateAppClosedBeforeServerAnswer)
                : StorePurchaseResult.Cancelled()));
        }

        public void Consume(string purchaseToken, Action<bool> onComplete) => onComplete?.Invoke(_ledger.Consume(purchaseToken));

        public void GetPurchases(Action<IReadOnlyList<StorePurchase>> onComplete) => onComplete?.Invoke(_ledger.Unconsumed);

        public void ClearPurchases() => _ledger.Clear();

        private static void Save(string json)
        {
            PlayerPrefs.SetString(PrefsKey, json);
            PlayerPrefs.Save();
        }
    }
}
