# Nakama Farsi for Unity

This package is the official Nakama Unity client (Heroic Labs, `Packages/Nakama`) with the nakama-farsi layer built in under `Farsi/`. One package, one install. Heroic's files are not changed, so new upstream releases merge cleanly.

Package name: `com.nakamafarsi.unity`. Unity 2022.3 or newer. Newtonsoft.Json comes in through `com.unity.nuget.newtonsoft-json`.

## Install

Until the package is on our registry, add it from git in `Packages/manifest.json`:

```json
"com.nakamafarsi.unity": "<repository url>?path=/Packages/Nakama#dev"
```

Do not also install `com.heroiclabs.nakama-unity`; this package already contains it.

## Set up

1. Tools > Nakama Farsi > Create SDK Config. This makes `Assets/Resources/NakamaFarsiConfig.asset`.
2. Fill in the server URL (for example `https://api.example.com:443`), the server key, the language (`fa`) and, if the game uses ZarinPal or Zibal, the payment deep link (for example `mygame://payment`).
3. In code:

```csharp
var client = NakamaFarsiRunner.Initialize(NakamaFarsiConfig.Load());
await client.LoginWithDeviceAsync(SystemInfo.deviceUniqueIdentifier);
```

The session is saved and refreshed by itself. The socket connects after sign-in and reconnects when it drops.

## Calling the server

Every nakama-farsi RPC has a typed wrapper, grouped by module:

```csharp
var account = await client.Rpcs.Base.AccountGetAsync();
var boards  = await client.Rpcs.Leaderboardx.ListAsync();
var tasks   = await client.Rpcs.Economy.TasksListAsync();
var claim   = await client.Rpcs.Economy.TaskClaimAsync(new EconomyTaskClaimRequest { Key = "flickkick_daily_wins" });
```

- Calls go over the socket and fall back to HTTP when the socket is down. Reads are resent after a network error; writes are not.
- Payment calls always go over HTTP.
- `lang` is filled from the client language when the RPC takes it.
- Every response keeps the server JSON in `Raw`. A field whose shape differs from the generated type is left null and the rest still loads, so use `Raw` when a typed field is empty.
- A server error is an `ApiException` with `Error.Code`, `Error.Status`, `Error.Message` (already translated when the server sends text) and `Error.Meta`.

`client.CallRpcAsync(id, json)` calls any RPC by name.

## Phone (SMS) login

```csharp
var status = await client.Phone.StatusAsync();          // OtpEnabled, Phone, CodeLength
var sent   = await client.Phone.RequestCodeAsync("09121234567");
var result = await client.Phone.VerifyAsync(sent.Phone, code);
if (result.NeedsProfile) { /* ask for a display name, then base_account_update */ }
```

The player signs in with the device first. `VerifyAsync` links the number to that guest account (progress stays) or signs in to the account that already has the number, then swaps to a refreshable session. The one-time login key is never stored.

## Payments

```csharp
var catalog = await client.Payments.CatalogAsync();

var coins = await client.Payments.BuyAsync(productId, PaymentMethods.Coins);

await NakamaFarsiStore.SetupAsync(client);               // once, after sign-in
var store = await NakamaFarsiStore.BuyAsync(productId);   // Cafe Bazaar or Myket

var web = await NakamaFarsiGateway.BuyAsync(productId, PaymentMethods.ZarinPal);
```

- Store purchases: the SDK starts the payment, buys the SKU with the payment id as developer payload, sends the token, and consumes the purchase only after the server accepts it. While the store is down it retries for `SubmitTimeout`. `SetupAsync` also sends purchases that were made but never reached the server (`economy_purchase_review`).
- Store choice: when the server's store config is in sandbox, or the game is not running on an Android device, a test store is used that makes sandbox tokens the server accepts. A real build needs the store plugin: Tools > Nakama Farsi > Store > Install Poolakey (Cafe Bazaar), or Build for Myket. Build for Bazaar / Build for Myket switch the `NAKAMAFARSI_STORE_*` define and the Android libraries.
- Gateways: the SDK opens the payment page and waits until the player comes back (deep link or app focus), then reads the payment status.
- `client.Payments.Completed` fires for every finished purchase.

## Chat and notifications

```csharp
var room = await client.Chat.JoinRoomAsync("lobby");
client.Chat.MessageReceived += m => Show(m.IsSticker ? m.StickerUrl : m.Text);
await client.Chat.SendTextAsync(room.Id, "salam");
await client.Chat.SendStickerAsync(room.Id, "happy/smile");
client.Notifications.Received += n => Debug.Log(n.Subject);
```

A message refused by the server (daily quota, sticker not owned or not allowed in this chat) throws `ApiException` with the server's code and text.

## Analytics

`client.Analytics` works with servers that have the analytics module. nakama-farsi does not have it yet, so the config's analytics session is off by default.

## Police Patrol layer

`PolicePatrol/` holds the Police Patrol API (`PolicePatrol.Sdk`, the same namespaces, classes and methods as `com.policepatrol.sdk` 0.5.x and 0.6.0) on top of this layer. Its assemblies compile only with the scripting symbol `POLICEPATROL_SDK`. The editor turns it on by itself when the project has `Resources/PolicePatrolSdkConfig.asset`, or from **Tools > Nakama Farsi > Police Patrol > Turn on**. Other games never see it.

```sh
cd Packages/Nakama/PolicePatrol/Tests~/PolicePatrol.Sdk.Tests && dotnet test   # NF_IT_URL=… for the guide flows on a server
cd ../UnityCheck && dotnet build                                              # Unity code, editor tools, samples and the legacy guide samples (Guide/)
```

## Regenerating the wrappers

After RPCs change on the server:

```sh
tools/generate.sh                      # reads the committed nakama-farsi dev branch next to this repository
NF=../pp/backend REV=nakama MODULES="combatrace=integrations/combatrace,devkit=integrations/devkit,analytics=integrations/analytics,account=integrations/account,shopx=integrations/shopx,inventoryx=integrations/inventoryx,ledger=integrations/ledger,campaign=integrations/campaign,assets=integrations/assets,social=integrations/social,fairplay=integrations/fairplay,pp=integrations/pp" EXTRA="../combatrace/backend:dev:integrations/combatrace" tools/generate.sh   # what is committed: Police Patrol and CombatRace RPCs
NF=../path/to/nakama-farsi REV=dev MODULES="flickkick=integrations/flickkick" tools/generate.sh
python3 tools/write_meta.py Packages/Nakama Farsi
```

`MODULES` adds game plugins (for example a fork's own plugins).

## Tests

```sh
cd Packages/Nakama/Farsi/Tests~/NakamaFarsi.Sdk.Tests && dotnet test
NF_IT_URL=http://127.0.0.1:7450 NF_IT_KEY=<server key> NF_IT_CONSOLE_URL=http://127.0.0.1:7451 CONSOLE_USER=… CONSOLE_PASSWORD=… NF_IT_SERVER_LOG=<server log> dotnet test
cd ../UnityCompileCheck && dotnet build          # Unity runtime code and samples against UnityEngine reference assemblies
cd ../UnityEditorCompileCheck && dotnet build    # editor tools
```

## Layout

| Path | What |
| --- | --- |
| `Runtime/`, `Editor/`, `Runtime/Plugins` | Heroic's Nakama Unity client, unchanged |
| `Farsi/Runtime/Core` | options, session, socket, RPC client, errors |
| `Farsi/Runtime/Generated` | typed RPC wrappers (generated) |
| `Farsi/Runtime/Auth` | phone login |
| `Farsi/Runtime/Payments` | purchase flow, store selection, test store |
| `Farsi/Runtime/Social` | chat, notifications |
| `Farsi/Runtime/Unity` | config asset, runner, Cafe Bazaar and Myket bridges, gateway return |
| `PolicePatrol/` | Police Patrol layer (`POLICEPATROL_SDK`) |
| `Farsi/Editor` | config menu, store install and switch tools |
| `Samples~` | Quick Start, Payments |
| `tools/` (repository root) | RPC schema scanner, wrapper generator, meta writer |
