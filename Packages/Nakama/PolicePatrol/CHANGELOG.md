# Changelog

## Unreleased

- Payments: a successful payment whose reward is not granted yet answers `PAYMENT_REWARD_PENDING` (server code in `ApiError.ServerCode`); the store purchase is consumed only after the server verified the receipt; `RecheckPending` follows payments whose reward is pending; `Payment.RewardGranted`, `PaymentPoller.WaitForReward`, `PaymentPoller.IsVerified`.
- Myket: subscription products are left out of `ProductIAP.Load`, and `Buy` answers `SUBSCRIPTION_NOT_SUPPORTED` before Myket opens (`ProductIAP.SupportsSubscriptions`).

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
