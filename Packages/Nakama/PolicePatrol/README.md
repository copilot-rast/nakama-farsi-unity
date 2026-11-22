# PolicePatrol SDK (`com.policepatrol.sdk`) 0.7

Police Patrol client on the nakama-farsi server. The public API of SDK 0.5.21 (namespaces, classes, methods,
`ApiResult<T>`, error codes) is kept; underneath, every call goes through `com.nakamafarsi.sdk` (Nakama session,
socket-first RPC with HTTP fallback, devkit errors, analytics). Architecture and the provider → RPC table:
`docs/sdk/spec.md` in the server repository. Unity team guide (Persian): `handoff/sdk-guide-fa.md`.

## Install

From git only; there is no registry package. One line in `Packages/manifest.json`:

```json
"dependencies": {
  "com.nakamafarsi.unity": "https://github.com/copilot-rast/nakama-farsi-unity.git?path=/Packages/Nakama#dev"
}
```

Then add `POLICEPATROL_SDK` to Player › Scripting Define Symbols to turn on the Police Patrol layer.
Updates: Package Manager › the package › Update, or pin a commit instead of `#dev`.

`PolicePatrolSdkConfig` (Tools › PolicePatrol › Create SDK Config) gained `Server Key`, `Use Socket` and
`Analytics Sessions`; `Base Url` is the game server (Nakama HTTP port).

## Kept from 0.5.x

Guide sections 1–8: `AuthProvider` (device login, logout, phone OTP / recovery, phone change, phone + password login, password reset / set / change), `ProfileProvider`,
`CurrencyProvider`, `MetaProvider`, `InventoryProvider`, `StageProvider`, `LedgerProvider`, `FairPlayProvider`,
`StatsProvider`, `ShopProvider`, `PaymentProvider`, `ProductIAP`, `PolicePatrolStore` (Bazaar / Myket / test store),
`PolicePatrolSprites`, `IShopProductCard`, `PolicePatrolStats`, `IStatCard`, `IGoalCard`, `PolicePatrolAssets`,
`PolicePatrolAssetRegistry`, `PolicePatrolContent`, the store installers and the editor windows (Asset Sync, Shop Cards,
Stat Cards, Content Publish) with API keys from «ابزار توسعه › کلیدهای API».

New: `PolicePatrolAnalytics` (design / progression / resource / business / error events, context, dimensions).

New in 0.7 (guide sections 10–12): stage settings, star rules, criteria and milestone ids (`StageProvider`), the start with a car (`StageProvider.Start(stageKey, vehicleKey, ...)`), the trophy page, claim and the 1501 notification (`StatsProvider.Trophies`, `Claim`, `TrophyStepUnlocked`), split stats (`StatsProvider.Mine(keys, ...)`), design event helpers (`PolicePatrolEvents`), car and part profiles (`InventoryProvider.Get(type, withProfile, ...)`), equip / unequip (`InventoryProvider.Equip`, `Unequip`), and the routing table plus dry run in the Asset Sync window.

## Payments: reward pending and consume

- `ProductIAP.Buy`, `PaymentPoller.SubmitBilling` / `WaitForResult` and `PolicePatrolPayments.PayWithZarrinpal` answer `PAYMENT_REWARD_PENDING` (not success) when the payment succeeded but the reward is not granted yet. `ApiError.ServerCode` keeps the server code (`REWARD_PENDING`, `PRODUCT_ALREADY_BOUGHT`, `PRIZE_ALREADY_OWNED`) and `Meta["paymentId"]` the payment. The server retries the grant; `PaymentPoller.WaitForReward(paymentId)` and `ProductIAP.RecheckPending` follow it (`RecheckResult.RewardPendingPaymentIds`).
- The store purchase is consumed only after the server verified the receipt (status `success`, with or without the reward). Network errors, `STORE_UNAVAILABLE`, `STORE_MODE_CHANGED` and every answer that is not final keep it in the store, so `RecheckPending` sends it again. If you call `SubmitBilling` yourself, consume when `PaymentPoller.IsVerified(result)` is true.
- New codes in `PaymentErrorCodes`: `RewardPending`, `InProgress` (`PAYMENT_IN_PROGRESS`), `Expired`, `Closed`, `StoreModeChanged`, `SubscriptionNotSupported`.

## Develop

- `dotnet test "sdk/unity-pp/Tests~/PolicePatrol.Sdk.Tests"` (with `NF_IT_URL=http://127.0.0.1:7350` it also runs the guide flows against a server).
- `dotnet build "sdk/unity-pp/Tests~/UnityCheck"` compiles the Unity-only code of both packages against stubs.
- `python3 sdk/tools/write_meta.py sdk/unity-pp` after adding or moving files (GUIDs follow the 0.5.x scheme).
