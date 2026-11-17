using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Shop
{
    public sealed class TestStoreLedger
    {
        public const string SimulatedNetworkFailure = "Simulated network failure: the app closed before the server answered";

        private readonly List<StorePurchase> _unconsumed = new List<StorePurchase>();
        private readonly Action<string> _save;

        public TestStoreLedger(string saved = null, Action<string> save = null)
        {
            _save = save;
            Restore(saved);
        }

        public IReadOnlyList<StorePurchase> Unconsumed => _unconsumed.ToArray();

        public StorePurchaseResult Pay(string sku, string developerPayload, bool appClosesBeforeServerAnswers = false)
        {
            var token = SandboxPurchaseToken.Create(developerPayload);
            _unconsumed.Add(new StorePurchase(sku, token, developerPayload));
            Save();
            return appClosesBeforeServerAnswers ? StorePurchaseResult.Failed(SimulatedNetworkFailure) : StorePurchaseResult.Success(token);
        }

        public bool Consume(string purchaseToken)
        {
            _unconsumed.RemoveAll(purchase => purchase.PurchaseToken == purchaseToken);
            Save();
            return true;
        }

        public void Clear()
        {
            _unconsumed.Clear();
            Save();
        }

        private void Save()
        {
            var rows = new JArray(_unconsumed.Select(purchase => new JObject
            {
                ["sku"] = purchase.Sku,
                ["purchaseToken"] = purchase.PurchaseToken,
                ["developerPayload"] = purchase.DeveloperPayload,
            }));
            _save?.Invoke(rows.ToString(Newtonsoft.Json.Formatting.None));
        }

        private void Restore(string saved)
        {
            if (string.IsNullOrWhiteSpace(saved))
            {
                return;
            }

            try
            {
                foreach (var row in JArray.Parse(saved).OfType<JObject>())
                {
                    var token = (string)row["purchaseToken"];
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        _unconsumed.Add(new StorePurchase((string)row["sku"], token, (string)row["developerPayload"]));
                    }
                }
            }
            catch (Newtonsoft.Json.JsonException)
            {
                _unconsumed.Clear();
            }
        }
    }
}
