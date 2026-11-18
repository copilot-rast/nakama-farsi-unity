using System;
using System.Linq;
using PolicePatrol.Sdk;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Economy;
using PolicePatrol.Sdk.FairPlay;
using PolicePatrol.Sdk.Inventory;
using PolicePatrol.Sdk.Ledger;
using PolicePatrol.Sdk.Payments;
using PolicePatrol.Sdk.Prizes;
using PolicePatrol.Sdk.Shop;
using PolicePatrol.Sdk.Stages;
using PolicePatrol.Sdk.Unity;
using PolicePatrol.Sdk.Users;
using UnityEngine;

namespace PolicePatrol.Sdk.GuideChecks
{
    public sealed class GuideSamples
    {
        private const string NoConnectionText = "no connection";
        private const string TryAgainText = "try again";
        private ProductIAP shop;

        private static void ShowError(string text) => Debug.Log(text);

        private static void StartGame() { }

        private string ErrorText(ApiError error)
        {
            if (error.IsNetworkError) return NoConnectionText;
            if (error.Status == 0
                || error.Status >= 500
                || error.Code == ApiError.InvalidResponseCode
                || error.Code.StartsWith("HTTP_")
                || string.IsNullOrEmpty(error.Message))
            {
                return TryAgainText;
            }
            return error.Message;
        }

        public void Login()
        {
            if (!AuthProvider.IsLoggedIn)
            {
                AuthProvider.DeviceIdLogin(SystemInfo.deviceUniqueIdentifier, result =>
                {
                    if (result.IsSuccess)
                    {
                    }
                    else
                    {
                        ShowError(ErrorText(result.Error));
                    }
                });
            }

            PolicePatrolSdk.Client.SessionExpired += () =>
                AuthProvider.DeviceIdLogin(SystemInfo.deviceUniqueIdentifier, null);
            AuthProvider.Logout(result => { });
            AuthProvider.Logout();
            PolicePatrolSdk.SetLanguage("en");
            ProfileProvider.GetMe(result =>
            {
                if (result.IsSuccess)
                {
                    Debug.Log(result.Data.Id + " guest=" + result.Data.IsGuest);
                    var phone = result.Data.PhoneNumber + result.Data.PhoneNumberVerified + result.Data.DeviceId + result.Data.HasUsername;
                }
            });
            ProfileProvider.AccountRules(r =>
            {
                if (r.IsSuccess)
                {
                    var sum = r.Data.UsernameMinLength + r.Data.UsernameMaxLength + r.Data.PasswordMinLength + r.Data.PasswordMaxLength;
                }
            });
            ProfileProvider.SetUsername("name", r =>
            {
                if (r.IsSuccess)
                {
                    return;
                }
                ShowError(ErrorText(r.Error));
            });
            var codes = UserErrorCodes.PasswordLength + UserErrorCodes.PasswordCharacters;
            ApiResult<LoginResponse> typed = null;
            var retry = typed?.Error.RetryAfterSeconds;
        }

        public void Phone(string phone, string code)
        {
            ProfileProvider.GetMe(result =>
            {
                if (result.IsSuccess && !result.Data.PhoneNumberVerified)
                {
                }
            });
            AuthProvider.RequestPhoneChange(phone, result =>
            {
                if (result.IsSuccess)
                {
                    var wait = result.Data.WaitBeforeResend(DateTimeOffset.UtcNow);
                    return;
                }
            });
            AuthProvider.VerifyPhoneChange(code, result =>
            {
                if (result.IsSuccess)
                {
                    var verified = result.Data.PhoneNumberVerified;
                    return;
                }
            });
            AuthProvider.RequestPhoneOtp(phone, result =>
            {
            });
            AuthProvider.VerifyOtp(code, OtpChannel.Phone, result =>
            {
                if (result.IsSuccess)
                {
                }
            }, SystemInfo.deviceUniqueIdentifier);
            AuthProvider.ResendOtp(OtpChannel.Phone, r => { });
        }

        public void Shop()
        {
            PolicePatrolStore.Setup(result =>
            {
                if (!result.IsSuccess)
                {
                    ShowError(ErrorText(result.Error));
                    return;
                }
                shop = PolicePatrolStore.CreateShop();
                shop.RecheckPending(_ => { });
            });
            shop.Load(result =>
            {
                if (!result.IsSuccess)
                {
                    return;
                }
                foreach (var item in result.Data)
                {
                    var text = item.Name + item.FinalPrice + item.Prize.PrizeItems.Count() + item.Id + item.Title + item.TitleFor("fa") + item.Description + item.DescriptionFor("fa")
                        + item.OriginalPrice + item.HasDiscount + item.DiscountPercent + item.IconUrl + item.CoverUrl + item.UsesAddressableMedia + item.IconAddress + item.CoverAddress
                        + item.MinLevel + item.MaxLevel + item.LevelLocked + item.IsOneTime + item.Owned + item.PurchaseMessage + item.PurchaseMessageFor("fa") + item.IsSubscription + item.Product.Key
                        + item.AssetIds;
                    var p = item.Prize.PrizeItems.First();
                    var parts = p.Type + p.ItemId + p.Action + p.Value;
                    PolicePatrolSprites.LoadIcon(item, sprite => { });
                    PolicePatrolSprites.LoadCover(item, sprite => { });
                }
            });
            ShopProvider.Purchases(result =>
            {
                if (!result.IsSuccess)
                {
                    return;
                }
                foreach (var row in result.Data)
                {
                    var r = row.ProductId + row.ProductKey + row.Count + row.LastPurchasedAt;
                }
            });
            ShopItem picked = null;
            shop.Buy(picked, result =>
            {
                if (result.IsSuccess)
                {
                    return;
                }
                if (result.Error.Code == ProductIAP.PurchaseCancelledCode)
                {
                    return;
                }
                ShowError(ErrorText(result.Error));
            });
            shop.RecheckPending(result =>
            {
                if (result.HasRecovered)
                {
                }
                if (result.StillPending > 0)
                {
                    Debug.Log(string.Join(",", result.PendingErrorCodes));
                }
                var counts = result.Confirmed + result.AlreadyDone;
            });
            CurrencyProvider.GetByKey("coin", result =>
            {
                if (result.IsSuccess)
                {
                    Debug.Log("coins: " + result.Data.Value);
                    var id = result.Data.CurrencyId;
                }
            });
            CurrencyProvider.List(1, 20, r => { });
            CurrencyProvider.Use("id", 1, r => { });
            CurrencyProvider.Add("id", 1, r => { });
            var codes = PaymentErrorCodes.PrizeAlreadyOwned + PaymentErrorCodes.PrizeRequiresAnotherItem + PolicePatrolStore.PluginMissingCode + PolicePatrolStore.NotSupportedCode;
        }

        public void Assets(ShopItem shopItem, string soId)
        {
            PolicePatrolAssets.LoadAndApply("Common/Config/Shop", result =>
            {
                if (!result.IsSuccess)
                {
                    Debug.LogWarning(result.Error.Code);
                }
                else if (result.Data.Missing.Length > 0)
                {
                    Debug.LogWarning(string.Join(", ", result.Data.Missing));
                }
                StartGame();
            });
            InventoryProvider.Buy(soId, r =>
            {
                if (r.IsSuccess)
                {
                    var key = r.Data.Item.Key;
                }
            });
            var itemKey = shopItem.Prize?.PrizeItems?
                .FirstOrDefault(p => p.Type == PrizeItemTypes.InventoryItem)?.ItemId;
            MetaProvider.List(1, 100, result =>
            {
                if (!result.IsSuccess)
                {
                    return;
                }
                foreach (var meta in result.Data.Items)
                {
                    var m = meta.Meta.Key + meta.MetaId + meta.Value;
                }
            });
            ApiResult<object> last = null;
            if (last.Error.Code == PaymentErrorCodes.PrizeAlreadyOwned)
            {
                ShowError(ErrorText(last.Error));
            }
        }

        public void Economy(string stageKey, string attemptId, int currentLevel, int missingPercent, int localCoins, int localGems, string[] ownedKeys)
        {
            StageProvider.Get(r =>
            {
                if (!r.IsSuccess)
                {
                    return;
                }
                var progress = r.Data;
                var head = progress.Xp + progress.Level + progress.NextLevelXp;
                foreach (var chapter in progress.Chapters)
                {
                    var c = chapter.Key + chapter.Unlocked + chapter.StarPercent + chapter.Milestones;
                    foreach (var stage in chapter.Stages)
                    {
                        var s = stage.Key + stage.Unlocked + stage.BestStars + stage.Rewards + stage.Xp + stage.TimeLimitSeconds + stage.Mode
                            + stage.NextRewardAt + stage.RewardsLeftToday + stage.CooldownSeconds + stage.DailyRewardLimit + stage.RewardGroup;
                    }
                }
            });
            StageProvider.Start(stageKey, r =>
            {
                if (r.IsSuccess)
                {
                    var id = r.Data.AttemptId;
                    return;
                }
                if (r.Error.Code == StageErrorCodes.Locked)
                {
                }
                else if (r.Error.IsNetworkError)
                {
                }
            });
            StageProvider.Complete(
                stageKey,
                attemptId,
                success: true,
                elapsedSeconds: 74.2,
                healthPercent: 81,
                r =>
                {
                    if (!r.IsSuccess)
                    {
                        return;
                    }
                    var result = r.Data;
                    var all = result.Stars + result.BestStars + result.Rewards.Count() + result.MilestoneRewards.Count() + result.Rewards.First().CurrencyKey + result.Rewards.First().Amount
                        + result.XpGained + result.Xp + result.Level + result.LeveledUp + result.RewardLimited;
                });
            StageProvider.Complete(stageKey, attemptId, success: false, elapsedSeconds: 10, healthPercent: null, r => { });
            InventoryProvider.Get(r =>
            {
                if (!r.IsSuccess)
                {
                    return;
                }
                foreach (var item in r.Data.Items)
                {
                    var t = item.Key + item.Type + item.Owned + item.Unlocked + item.CanBuy + item.Prices + item.UnlockLevel + item.UnlockPrices + item.ParentKey + item.RequiresKey;
                    foreach (var u in item.Upgrades)
                    {
                        var x = u.Key + u.Level + u.MaxLevel + u.NextPrice;
                    }
                    foreach (var s in item.Services)
                    {
                        var y = s.Key + s.UnitPrice;
                    }
                }
            });
            InventoryProvider.Unlock("ToyotaHilux", r =>
            {
                var x = r.Data.Item.Key + r.Data.Paid;
            });
            InventoryProvider.Buy("ToyotaHilux", r =>
            {
                var x = r.Data.Item.Owned + "" + r.Data.Paid;
            });
            ApiResult<object> last = null;
            if (last.Error.Code == InventoryErrorCodes.LevelTooLow)
            {
                var unlockLevel = (int)last.Error.Meta["unlockLevel"];
            }
            InventoryProvider.Upgrade("gun-handgun-bereta92", "Power", fromLevel: currentLevel, r =>
            {
                var x = r.Data.Level + "" + r.Data.Paid + r.Data.Item.Upgrades;
            });
            var requestId = Guid.NewGuid().ToString();
            InventoryProvider.Service("AudiQ2", "fuel-garage", missingPercent, requestId, r =>
            {
                if (r.IsSuccess)
                {
                    var paid = r.Data.Paid;
                }
            });
            LedgerProvider.List(1, 20, r =>
            {
                foreach (var e in r.Data.Items)
                {
                    var x = e.Kind + e.RefId + e.Title + e.Amount + e.Unit + e.CreatedAt;
                }
            }, kinds: new[] { LedgerKinds.Stage, LedgerKinds.Asset });
            FairPlayProvider.ReportLocalState(
                new[] { new LocalBalance("coin", localCoins), new LocalBalance("gem", localGems) },
                ownedKeys,
                _ => { });
            if (last.Error.Code == UserErrorCodes.Suspended)
            {
                var message = (string)last.Error.Meta["message"];
                var expireAt = (string)last.Error.Meta["expireAt"];
            }
            if (last.Error.IsNetworkError)
            {
            }
        }
    }
}
