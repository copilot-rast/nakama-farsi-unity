# PolicePatrol SDK (`com.policepatrol.sdk`) 0.6

Police Patrol client on the nakama-farsi server. The public API of SDK 0.5.21 (namespaces, classes, methods,
`ApiResult<T>`, error codes) is kept; underneath, every call goes through `com.nakamafarsi.sdk` (Nakama session,
socket-first RPC with HTTP fallback, devkit errors, analytics). Architecture and the provider → RPC table:
`docs/sdk/spec.md` in the server repository. Unity team guide (Persian): `handoff/sdk-guide-fa.md`.

## Install

From the Police Patrol registry, as with 0.5.x (`<API url>/upm`): an API key with `upm:read` («ابزار توسعه › کلیدهای API») in
`~/.upmconfig.toml` (outside the project), then `Packages/manifest.json` — the scope list now also has `com.nakamafarsi`,
and the Nakama client is a Git package that must be listed in the project:

```toml
[npmAuth."https://<API url>/upm"]
token = "<API key>"
alwaysAuth = true
```

```json
"scopedRegistries": [
  { "name": "PolicePatrol", "url": "https://<API url>/upm", "scopes": ["com.policepatrol", "com.nakamafarsi"] }
],
"dependencies": {
  "com.heroiclabs.nakama-unity": "https://github.com/heroiclabs/nakama-unity.git?path=/Packages/Nakama#v3.23.0",
  "com.nakamafarsi.sdk": "0.1.0",
  "com.policepatrol.sdk": "0.6.0"
}
```

Updates: Window › Package Manager › My Registries › PolicePatrol › Update. «ابزار توسعه › پکیج‌های یونیتی» in the console
shows the published versions and these snippets with the right address.

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

## Payments: reward pending and consume

- `ProductIAP.Buy`, `PaymentPoller.SubmitBilling` / `WaitForResult` and `PolicePatrolPayments.PayWithZarrinpal` answer `PAYMENT_REWARD_PENDING` (not success) when the payment succeeded but the reward is not granted yet. `ApiError.ServerCode` keeps the server code (`REWARD_PENDING`, `PRODUCT_ALREADY_BOUGHT`, `PRIZE_ALREADY_OWNED`) and `Meta["paymentId"]` the payment. The server retries the grant; `PaymentPoller.WaitForReward(paymentId)` and `ProductIAP.RecheckPending` follow it (`RecheckResult.RewardPendingPaymentIds`).
- The store purchase is consumed only after the server verified the receipt (status `success`, with or without the reward). Network errors, `STORE_UNAVAILABLE`, `STORE_MODE_CHANGED` and every answer that is not final keep it in the store, so `RecheckPending` sends it again. If you call `SubmitBilling` yourself, consume when `PaymentPoller.IsVerified(result)` is true.
- New codes in `PaymentErrorCodes`: `RewardPending`, `InProgress` (`PAYMENT_IN_PROGRESS`), `Expired`, `Closed`, `StoreModeChanged`, `SubscriptionNotSupported`.

## Develop

- `dotnet test "sdk/unity-pp/Tests~/PolicePatrol.Sdk.Tests"` (with `NF_IT_URL=http://127.0.0.1:7350` it also runs the guide flows against a server).
- `dotnet build "sdk/unity-pp/Tests~/UnityCheck"` compiles the Unity-only code of both packages against stubs.
- `python3 sdk/tools/write_meta.py sdk/unity-pp` after adding or moving files (GUIDs follow the 0.5.x scheme).
