# Change Log
All notable changes to this project are documented below.

The format is based on [keep a changelog](http://keepachangelog.com/) and this project uses [semantic versioning](http://semver.org/).

## [3.23.0-nf.7] - 2026-11-25
### Changed
- Farsi layer: store setup errors stop the purchase flow at once. `PaymentClient.IsRetryable` and `ApiError.IsRetryable` no longer match `STORE_CONFIGURATION_REJECTED`, `METHOD_UNAVAILABLE` or `STORE_MODE_CHANGED` (by code, also when an older server still answers 503 / gRPC 14); `STORE_UNAVAILABLE` and network errors stay retryable. `SubmitAsync`, `ReviewAsync`, `BuyAsync` and `RecoverAsync` return `PurchaseOutcome.Pending` with `PurchaseResult.IsStoreNotReady = true` and the code in `Error`; the store purchase is not consumed, so `RecoverAsync` delivers it on a later start. Servers from nakama-farsi 2026-11-25 answer these codes with gRPC 9 (FAILED_PRECONDITION).
- Police Patrol layer 0.9.1: `PaymentPoller.IsRetryable` no longer retries `STORE_CONFIGURATION_REJECTED`, `METHOD_UNAVAILABLE` or `STORE_MODE_CHANGED`.

### Added
- `PurchaseErrors.StoreConfigurationRejected`, `MethodUnavailable`, `PurchaseInvalid`, `TokenAlreadyUsed`, `PaymentAlreadySettled`, `PurchaseErrors.IsStoreNotReady(code)`, `PurchaseResult.IsStoreNotReady`, `ApiError.NotRetryableCodes`, `ApiError.IsNotRetryableCode`; Police Patrol `PaymentErrorCodes.MethodUnavailable`.

## [3.23.0-nf.6] - 2026-11-23
### Added
- Police Patrol layer 0.9.0: server data that requires a connection (`ASSETS_ONLINE_REQUIRED`, `ASSETS_CACHE_TOO_OLD`), car condition and services (`CarProvider`), car wear on stage results. See `PolicePatrol/CHANGELOG.md`.

## [3.23.0-nf.5] - 2026-11-23
### Added
- Farsi layer: wrappers regenerated from every server (339 RPCs); new `pp_backup_list`, `pp_backup_use`, `pp_backup_refund` from the Police Patrol server (`nakama` @ d9c3469d1).
- Police Patrol layer 0.8.0: backup units (`BackupProvider`), see `PolicePatrol/CHANGELOG.md`.

## [3.23.0-nf.4] - 2026-11-23
### Added
- Farsi layer: wrappers generated from every game server at once (nakama-farsi, Police Patrol, CombatRace, Rakhtkan, Soltan, Finteen, ViralVanguard, Machine Irani, Mench), 336 RPCs (300 before). New: `combatrace_profile`, `combatrace_missions`, `combatrace_events`, `combatrace_task_claim`; `combatrace_match_end` takes `kills`, `zombies`, `finished`, `weapons` and answers the pits split, XP, level, level-up and league fields; `flickkick_*`, `prediction_*`, `soltan_*`, `blockworld_*` (player RPCs only); new optional fields on existing answers (for example `displayName` in `economy_referral_me`). All of them sit in the shared generated layer with no define, so no project needs a new symbol.
- `tools/generate-all.sh` with `tools/projects.txt` (one line per server) and `tools/rpc-exclude.txt` (server-only RPCs). `tools/generate.sh` forwards to it and refuses the old single-repository variables.
- Generation gates: every RPC registered in any listed project must get a wrapper; every public member of the committed `Rpcs.g.cs` must stay with the same type, JSON name and signature (`tools/apicompat`, override only with `--allow-breaking` and a major or minor version bump); value fields stay nullable and every answer class keeps `Extra`.
- `Farsi/Tests~/ApiCompatCheck`: compiles a usage of every old public member and the Road Storm handoff snippets against the new code (and the snippets against the old code with `-p:OldRpcs=`). `JsonCompatTests`: old answers parse in the new SDK, unknown fields land in `Extra`, a changed field type is skipped and the rest loads.

### Changed
- `tools/rpcschema` keeps the committed type of every existing field (the value stays in `Raw` if a server changes it), reads RPC maps written inline in `InitModule` or in functions named `rpcs`, joins every definition of a local variable, and widens integer plus number to number (for example `leagueMultiplier` is `double?`).

## [3.23.0-nf.3] - 2026-11-22
### Added
- Farsi layer: typed wrappers regenerated from the Police Patrol server (`nakama` @ e12ac90cc), 300 RPCs (new: `base_comm_*`, `base_friend_suggestions`, `base_my_code`, `base_player_codes`, `base_user_by_code`, `base_username_change`, `base_username_quote`, `comms_user_token`, `economy_boosters`, `economy_chance_ack`, `economy_game_active`, `economy_game_bot`, `economy_game_friend_*`, `economy_game_queue`, `economy_game_stats`, `economy_player_card`, `economy_regen_*`, `insights_send`); new request fields such as `withProfile` and `type` on `economy_inventory`. `tools/rpcschema -keep` keeps response shapes the scan no longer resolves, so no generated type loses a member.
- Police Patrol layer 0.7.0: see `PolicePatrol/CHANGELOG.md`.

### Changed
- Farsi layer: the socket reads messages up to `NakamaFarsiOptions.SocketMaxMessageBytes` (4 MB). The Nakama default (256 KB) silently dropped larger answers, so the call timed out and went over HTTP.

## [3.23.0] - 2026-11-08
### Changed
- Update to use Nakama and Satori .NET 3.23.0 release.

### Fixed
- Attach a download handler to DELETE requests in UnityWebRequestAdapter.

## [3.22.1] - 2026-10-02
### Changed
- Update to use Nakama and Satori .NET 3.22.1 release.

## [3.22.0] - 2026-09-18
### Changed
- Update to use Nakama and Satori .NET 3.22.0 release.

## [3.21.1] - 2026-02-13
### Changed
- Update to use Nakama and Satori .NET 3.21.2 release.
- Improve how HTTP requests are logged in the "UnityWebRequestAdapter" type.

## [3.21.0] - 2025-12-21
### Changed
- Update to use Nakama and Satori .NET 3.21.1 release.
- Pass socket close reason into JavaScript shim.

## [3.20.0] - 2025-12-07
### Changed
- Update to use Nakama and Satori .NET 3.21.0 release.

## [3.19.0] - 2025-10-02
### Changed
- Update to use Nakama and Satori .NET 3.20.0 release.
- Update code snippets to use new Close reason with Socket.

### Fixed
- Fix code snippet for Satori example.

## [3.18.0] - 2025-09-10
### Changed
- Update to use Nakama and Satori .NET 3.18.0 release.

## [3.17.0] - 2025-07-17
### Added
- Add request logging to the "UnityWebRequestAdapter" type. Thanks @epishev-m

### Changed
- Update to use Nakama and Satori .NET 3.17.0 release.
- Set the minimum supported version of Unity engine to be on 2022.3 LTS release.

## [3.16.0] - 2025-02-13
### Changed
- Update to use Nakama and Satori .NET 3.16.0 release.

## [3.15.0] - 2025-01-29
### Changed
- Update to use Nakama and Satori .NET 3.15.0 release.

### Fixed
- Fix compatibility with WebGL builds in Unity 6.

## [3.14.0] - 2024-11-05
### Changed
- Update to use Nakama and Satori .NET 3.14.0 release.

## [3.13.0] - 2024-07-10
### Changed
- Updated to use the Nakama and Satori .NET 3.13.0 release.

## [3.12.1] - 2024-05-30
### Changed
- Updated to use the Nakama and Satori .NET 3.12.1 release.

## [3.12.0] - 2024-04-08
### Changed
- Updated to use the Nakama and Satori .NET 3.12.0 release.

### Fixed
- Removed unnecessary reference to old Nakama Unity version in Demo scene.

## [3.11.0] - 2024-03-08
### Changed
- Default socket adapter changed from `WebSocketAdapter` to `WebSocketStdlibAdapter`. This was done to utilize the native .NET Websocket library for improved stability and maintenance.
- Updated to use the Nakama and Satori .NET 3.11.0 release.

## [3.10.1] - 2023-12-12
### Changed
- Retry functionality restored for `UnityWebRequest.Result.ConnectionError`.

## [3.10.0] - 2023-11-21
### Changed
- Updated to use the Nakama and Satori .NET 3.10.0 release.
- Restricted retry attempts to more specific 500-level error codes from the server.

## [3.9.0] - 2023-08-11
### Changed
- Updated to use the Nakama and Satori .NET 3.9.0 release.

## [3.8.0] - 2023-06-09
### Changed
- Updated to use the Nakama and Satori .NET 3.8.0 release.

## [3.7.0] - 2023-03-10
### Changed
- Updated to use the Nakama and Satori .NET 3.7.0 release.
### Fixed
- Fixed an issue where the OnClose event would not fire in Unity WebGL.

## [3.6.0] - 2023-02-7
### Changed
- Update to use the Nakama and Satori .NET 3.6.0 release.
### Fixed
- Fixed multiple race conditions that could occur when Unity web requests were cancelled.

## [3.5.0] - 2022-09-18
### Changed
- Update to use Nakama .NET 3.5.0 release.
### Fixed
- Don't parse response messages on 500 responses from the server.

## [3.4.1] - 2022-05-13
### Fixed
- Updated to correct Nakama .NET 3.4.0 release binary.

## [3.4.0] - 2022-05-02
### Changed
- Update to use Nakama .NET 3.4.0 release.

## [3.3.0] - 2022-01-25
### Changed
- Update to use Nakama .NET 3.3.0 release.
- Use Task objects with the WebGL export.

## [3.2.0] - 2021-10-11
### Added
- Add additional group listing filters.
- Add ability to overwrite leaderboard/tournament ranking operators from the client.

### Fixed
- Fix url-safe encoding of query params that were passed to the client as arrays of strings.

## [3.1.1] - 2021-08-11
### Changed
- Remove `autoRefreshSession` from overloaded `Client` constructors. This can still be customized with the base `Client` constructor. This is a workaround for an internal compiler error in Unity's WebGL toolchain.

### Fixed
- Remove use of deprecated WWW fields in newer versions of Unity.

## [3.1.0] - 2021-08-11
### Added
- Add ability for user to retry requests if they fail due to a transient network error.
- Add ability for user to cancel requests that are in-flight.

## [3.0.0] - 2021-07-14
### Added
- The language tag for the user can be configured with the socket on connect.

### Changed
- An `IPartyMatchmakerTicket` is now received by the party leader when they add their party to the matchmaker via `AddMatchmakerPartyAsync`.
- Renamed `PromotePartyMember` to `PromotePartyMemberAsync`.

## [2.9.5] - 06-18-21
### Fixed
- Fix issue where UnityLogger did not implement a Debug log method.

## [2.9.4] - 06-17-21
### Fixed
- Fix issue where refreshing a session with metadata threw an exception due to the key already existing.

## [2.9.3] - 05-21-21
### Fixed
- Fix issue where `IUserPresence` objects were not being deserialized properly by the client as part of the `IParty` object.

## [2.9.2] 05-19-21
### Added
- The `Socket.ReceivedParty` event can now be subscribed to in order to listen for acceptance events from the leader of a closed party.

## [2.9.1] 05-18-21
### Fixed
- Fix incorrect .DLL version being pulled in from nakama-dotnet.

## [2.9.0] 05-17-21

### Added
- A session can be refreshed on demand with "SessionRefreshAsync" method.
- Session and/or refresh tokens can now be disabled with a client logout.
- The client now supports session auto-refresh using refresh tokens. This is enabled by default.
- New socket RPC and MatchSend methods using ArraySegment to allow developers to manage memory re-use.
- Add IAP validation APIs for purchase receipts with Apple App Store, Google Play Store, and Huawei AppGallery.
- Add Realtime Parties feature.

### Changed
- Use lock object with socket operations instead of ConcurrentDictionary as a workaround for a Unity engine WebGL regression.
- Avoid use of extension methods as a workaround for a Unity engine WebGL regression.
- Unity sockets now dispatch events on Unity's main thread by default. If you have been using code to move socket message to the main thread (e.g., UnityMainThreadDispatcher) you may now remove that code. This new default behavior can overridden by passing `useMainThread: false` to `client.NewSocket`. When passed this way, sockets default to their pre-2.9 behavior by dispatching messages in a separate thread.

### Fixed
- Parse HTTP responses defensively in case of bad load balancer configurations.

## [2.8.1] - 2021-03-16
### Fixed
- Fixed a bug with parsing error responses that did not contain a message or grpc code.
### Changed
- Made names of asmdef files more specific for easier searching inside the Unity editor.

## [2.8.0] - 2021-02-19
### Changed
- Listing tournaments can now be done without providing start or end time filters.
- Can now import Steam friends after authenticating or linking to a Steam account.

## [2.7.1] - 2021-02-18
### Fixed
- HTTP Client now properly reads off timeout value.

## [2.7.0] - 2020-10-19
### Changed
Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.7.0.
Added namespace to JavaScript web socket adapter internals.

## [2.6.0] - 2020-09-21
### Changed
Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.6.0.

## [2.5.0] - 2020-08-14
### Added
- Add support for the Unity Package Manager. See the README for usage.

### Changed
- Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.5.0.
- Update minimum required Unity version to 2018.4.26f1 LTS. While older releases may work YMMV.

## [2.4.0] - 2020-05-04 :star:
### Added
- Add new scene as an example for WebGL basics. Thanks @humbertodias.

### Changed
- Add a default error handler to the socket adapter to make common errors more visible.
- Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.4.0.

### Fixed
- UnityWebRequest downloadHandler is null on DELETE methods. Thanks @hasbean.

## [2.3.2] - 2019-10-23
### Fixed
- Update interface impl signatures with JS socket adapter.

## [2.3.1] - 2019-09-21
### Changed
- Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.3.1.

## [2.3.0] - 2019-09-02
### Changed
- Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.3.0.

## [2.2.2] - 2019-07-02
### Changed
- Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.2.2.

## [2.2.1] - 2019-06-21
### Added
- New example on how to manage the client/socket/session as a singleton.
- Various improvements to existing code examples.

### Changed
- Update Nakama .NET dependency. See release notes: heroiclabs/nakama-dotnet@2.2.1.

## [2.2.0] - 2019-06-12
### Added
- Support WebGL builds.
- Add new Leaderboard and Tournament API methods.

### Changed
- Use new socket library instead of WebSocketListener.
- Update socket event names to match csharp style guide.
- Update TinyJson dependency.

### Fixed
- Socket logger must not disable the socket events.
- Deserialize data in stream messages correctly.

## [2.1.0] - 2018-08-17
### Added
- Linker instructions to preserve code in dependent DLLs.
- New code snippets for multiplayer and matchmaker examples.

### Changed
- Update dependent DLLs for lowlevel websocket driver and .NET client.

## [2.0.0] - 2018-06-18
### Added
- New documentation on the client.
- Many new features and APIs.
- Support for Nakama 2 release.

### Changed
- Rewrite client with async/await sockets.
- New project structure for simpler Unity builds.

---

## [0.10.2] - 2017-11-27
### Fixed
- Use correct JS transport listener bindings.
- Correctly calculate session expiry client-side.

### Changed
- MatchmakeAddMessage correctly follows C# naming scheme.
- Improve memory allocation profile when using UDP transport.

## [0.10.1] - 2017-11-11
### Fixed
- Build system now includes `BCCrypto.dll` in `.unitypackage`.

## [0.10.0] - 2017-11-06
### Added
- New experimental rUDP socket protocol option.

### Changed
- Use string identifiers instead of byte arrays for compatibility across Lua, JSON, and client representations.

## [0.9.0] - 2017-10-17
### Added
- Advanced Matchmaking with custom filters and user properties.
- Expose Collation ID when client operations result in an error.

## [0.8.0] - 2017-08-01
### Added
- A paging cursor can now be serialized and restored.
- New storage partial update feature.
- New storage list feature.
- A new Unity code example which shows how to dispatch actions on the main thread.
- A session now exposes `.ExpiresAt` and `.Handle` from the token.

### Changed
- Add default builder for notification list and remove messages.
- A group self list operation now return the user's membership state with each group.
- A group leave operation now return a specific error code when the last admin attempts to leave.
- The client interface now uses action delegates instead of event handlers to support a proxy pattern.

## [0.7.0] - 2017-07-18
### Added
- A new Unity example scene which shows how to matchmake users.
- New `NIds` helper class and extension methods to compare byte arrays.
- Add new In-App Notification feature.
- Add new In-App Purchase Validation feature.

### Changed
- Update client to support the new batch-orientated server protocol.

### Fixed
- Accept SSL certificates.
- Improve handling transport errors.
- Improve fetching global storage records.

## [0.6.1] - 2017-05-30
### Changed
- Remove unnecessary headers from HTTP requests.
- Update user fetch add handle method name to avoid a type cast.

### Fixed
- Accept SSL certificates on Android devices.
- Improve leaderboard list message to handle multiple filters.

## [0.6.0] - 2017-05-29
### Added
- New matchmaking feature.
- Optionally send match data to a subset of match participants.
- Expose a way to toggle `TCP_NODELAY` socket option.
- Send RPC messages to run custom code.
- Fetch users by handle.
- Add friend by handle.
- Filter by IDs in leaderboard list message.
- Storage messages can now set records with public read permission.

### Fixed
- Dispatch callbacks when sending match data.

## [0.5.1] - 2017-03-28
### Added
- Support for fetching groups by name.

## [0.5.0] - 2017-03-19
### Added
- Add support for dynamic leaderboards.
- Add error codes for error messages in server protocol.

### Changed
- Use preprocessor directive to skip WebGL specific code with other build profiles.
- Update session token parse code for user's handle.
- Update user presence protocol message to contain user handles.

## [0.4.2] - 2017-02-27
### Added
- Repackage client with Unity 5.4.0 support.

### Changed
- Setup logger in client transport.

## [0.4.1] - 2017-02-26
### Fixed
- Add '.jslib' files to Unity package builds.

## [0.4.0] - 2017-02-26
### Added
- Add WebGL support.

### Changed
- Update the package structure generated by the build system for simpler Asset Store submissions.

## [0.3.0] - 2017-02-18
### Added
- Add new impl of realtime match entities.

### Changed
- Merge match entities into single `INMatch`.

### Fixed
- Incoming realtime messages do not need collation.
- Add event handlers to `INClient` interface.

## [0.2.0] - 2017-02-12
### Added
- Add new impl and test cases for storage, friends, and groups.
- Add new impl for realtime and chat messages.

### Changed
- Do not close the connection on logout. It will be closed by the server.
- Update client usages for friend messages due to changes in server protocol.

### Fixed
- Fix various small test cases caused by changes in the server.

## [0.1.0] - 2017-01-14
### Added
- Initial public release.
