# Changelog

## Unreleased

- Payments: a successful payment whose reward is not granted yet answers `PAYMENT_REWARD_PENDING` (server code in `ApiError.ServerCode`); the store purchase is consumed only after the server verified the receipt; `RecheckPending` follows payments whose reward is pending; `Payment.RewardGranted`, `PaymentPoller.WaitForReward`, `PaymentPoller.IsVerified`.
- Myket: subscription products are left out of `ProductIAP.Load`, and `Buy` answers `SUBSCRIPTION_NOT_SUPPORTED` before Myket opens (`ProductIAP.SupportsSubscriptions`).
- Inventory: `Buy`, `Unlock`, `Upgrade` take an optional `requestId`; without one the SDK keeps the same id for retries of the same action until it succeeds or fails with a final error (network, 429, 5xx and `INVENTORY_BUSY_TRY_AGAIN` keep it), so a retry never charges twice. `Service` does the same when `requestId` is null. `InventoryProvider.IsRetryable`.
- Currencies: `CurrencyProvider.List` / `GetByKey` always read `economy_balances.wallet`; the storage `items` list no longer replaces it (coins showed 0 after the first storage reward).
- Prices: `PlayerItem.FinalPrices` (from `economy_inventory` `finalPrice`, tag discount applied; falls back to `Prices`), `PlayerItem.DiscountPercent`, `PlayerItem.HasDiscount`. Show `FinalPrices` on buy buttons: it is what `Buy` charges. Shop products already had `Product.FinalPrice` / `ShopItem.FinalPrice` (`finalToman`).
- Security: `Http Key` is gone (`PolicePatrolSdkConfig.httpKey`, `SdkOptions.HttpKey`, `NakamaFarsiConfig.httpKey`, `NakamaFarsiOptions.HttpKey`). Phone + password login, forgot / reset password and the sign-up OTP (`publication_otp_*`) now sign in silently with the device first when there is no session (`SystemInfo.deviceUniqueIdentifier`, or a stored id), then call the RPC with that session; a password or OTP login replaces the device session as before. Old config assets keep loading (the old field is ignored). New: `SdkOptions.DeviceId`, `NakamaFarsiOptions.DeviceId`, `NakamaFarsiClient.DeviceId`, `NakamaFarsiClient.EnsureDeviceSessionAsync`. Rotate any runtime http_key that was ever put in a build.
- Errors: fields the server sends next to `code` (the suspension notice `kind`, `until`, `reason`) are copied into `ApiError.Meta` when `meta` does not have them; date strings in error JSON stay as sent.
- Chat (Farsi layer): `JoinRoomAsync` keeps history by default (`persistence = true`); joined channels are joined again after the socket reconnects (`ChatClient.Rejoined`, `JoinedChannelIds`, `RejoinAsync`, `ForgetChannels`; logout forgets them).
- Stages: `StageErrorCodes.ServerOwned` (`STAGE_SERVER_OWNED`, the server owns this stage's result, for example a cup match; do not retry and do not drop a saved result because of it).
- Free ride: `campaign_freeride_claim` answering `REWARD_LIMITED` comes back as a `StageResult` with `RewardLimited` = the reason (`cooldown` / `daily_limit`), `IsRewardLimited`, `NextRewardAt` and `RewardsLeftToday`, not as an error. Paid claims carry `XpGained`, `Xp`, `Level`, `NextRewardAt` and `RewardsLeftToday`. `StageProvider.Start` for a free-ride stage still makes a local id without a server call; the server limits rewards by the group cooldown and the daily limit, not by the attempt time.
- Ledger: `LedgerKinds` match the server kinds (`Purchase`, `Gift`, `Asset`, `Stage`, `Prize`, `Admin`, `Initial`, `Other`). `GiftCode` (now `gift`), `AdminAdd` and `AdminUse` (now `admin`) are `[Obsolete]` aliases; `CheatCode` is `[Obsolete]` because the server has no such kind.
- Content Publish: a "Make live after upload" toggle (on by default, as before). Off sends `activate: false`, so a key with only `content:write` uploads a ready pack without `PACK_ACTIVATE_DENIED`; `ContentApi.PublishAsync(..., activate)` already had the parameter.

## 0.6.0 — 2026-11-15

- Runs on the nakama-farsi server through `com.nakamafarsi.sdk`; the 0.5.21 public API of guide sections 1–8 is unchanged.
- Item keys: the server keeps keys lower case (`tiggo8`) with the Unity id in `metadata.gameId`; the providers translate both ways, so game code keeps `Tiggo8`.
- Error codes the server renamed come back with their 0.5.x names (`ApiError.ServerCode` has the new one).
- Phone + password sign-in (`LoginWithPhone`), password reset by SMS (`ForgotPassword` / `ResetPassword`, `ResendOtp`), `SetPassword` and `UpdatePassword` work as in 0.5.x (account plugin RPCs); `Login` with a wrong username or password answers `AUTH_INVALID_CREDENTIALS`.
- Sign-ins that return a session token (phone code, recovery, password) switch to a refreshable session through the number's login key.
- Config: optional `Http Key` for these calls before any device login.
- `PolicePatrolStats.Add` reports design events (id = stat key); `PolicePatrolAnalytics` is new.
- Editor tools use the new editor endpoints (assets, shop cards, stat cards, content packs) with devkit API keys.
- Not in 0.6.0: providers outside the guide (news, FAQ, quizzes, social, support chat, tasks, chance games, leaderboards, gifts, avatars, catalog lists).
