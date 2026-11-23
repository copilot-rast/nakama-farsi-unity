#pragma warning disable 1591
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk.Generated
{
    public sealed partial class NakamaFarsiRpcs
    {
        public NakamaFarsiRpcs(IRpcCaller caller)
        {
            Account = new AccountRpcs(caller);
            Analytics = new AnalyticsRpcs(caller);
            Assets = new AssetsRpcs(caller);
            Base = new BaseRpcs(caller);
            Blockworld = new BlockworldRpcs(caller);
            Campaign = new CampaignRpcs(caller);
            Clan = new ClanRpcs(caller);
            Combatrace = new CombatraceRpcs(caller);
            Content = new ContentRpcs(caller);
            Cup = new CupRpcs(caller);
            Devkit = new DevkitRpcs(caller);
            Economy = new EconomyRpcs(caller);
            Flickkick = new FlickkickRpcs(caller);
            Insights = new InsightsRpcs(caller);
            Inventoryx = new InventoryxRpcs(caller);
            Leaderboardx = new LeaderboardxRpcs(caller);
            Ledger = new LedgerRpcs(caller);
            Pp = new PpRpcs(caller);
            Prediction = new PredictionRpcs(caller);
            Publication = new PublicationRpcs(caller);
            Quiz = new QuizRpcs(caller);
            Shopx = new ShopxRpcs(caller);
            Social = new SocialRpcs(caller);
            Soltan = new SoltanRpcs(caller);
            Trophy = new TrophyRpcs(caller);
        }

        public AccountRpcs Account { get; }

        public AnalyticsRpcs Analytics { get; }

        public AssetsRpcs Assets { get; }

        public BaseRpcs Base { get; }

        public BlockworldRpcs Blockworld { get; }

        public CampaignRpcs Campaign { get; }

        public ClanRpcs Clan { get; }

        public CombatraceRpcs Combatrace { get; }

        public ContentRpcs Content { get; }

        public CupRpcs Cup { get; }

        public DevkitRpcs Devkit { get; }

        public EconomyRpcs Economy { get; }

        public FlickkickRpcs Flickkick { get; }

        public InsightsRpcs Insights { get; }

        public InventoryxRpcs Inventoryx { get; }

        public LeaderboardxRpcs Leaderboardx { get; }

        public LedgerRpcs Ledger { get; }

        public PpRpcs Pp { get; }

        public PredictionRpcs Prediction { get; }

        public PublicationRpcs Publication { get; }

        public QuizRpcs Quiz { get; }

        public ShopxRpcs Shopx { get; }

        public SocialRpcs Social { get; }

        public SoltanRpcs Soltan { get; }

        public TrophyRpcs Trophy { get; }
    }

    public static class RpcIds
    {
        public const string AccountMe = "account_me";
        public const string AccountPasswordChange = "account_password_change";
        public const string AccountPasswordForgot = "account_password_forgot";
        public const string AccountPasswordLogin = "account_password_login";
        public const string AccountPasswordReset = "account_password_reset";
        public const string AccountPasswordSet = "account_password_set";
        public const string AccountPhoneCancel = "account_phone_cancel";
        public const string AccountPhoneRecoverRequest = "account_phone_recover_request";
        public const string AccountPhoneRecoverVerify = "account_phone_recover_verify";
        public const string AccountPhoneRequest = "account_phone_request";
        public const string AccountPhoneVerify = "account_phone_verify";
        public const string AccountRules = "account_rules";
        public const string AccountUsernameCheck = "account_username_check";
        public const string AnalyticsConfig = "analytics_config";
        public const string AnalyticsStats = "analytics_stats";
        public const string AnalyticsTrack = "analytics_track";
        public const string AnalyticsTrophies = "analytics_trophies";
        public const string AnalyticsTrophyClaim = "analytics_trophy_claim";
        public const string AssetsContentIndex = "assets_content_index";
        public const string AssetsFetch = "assets_fetch";
        public const string AssetsManifest = "assets_manifest";
        public const string BaseAccountDelete = "base_account_delete";
        public const string BaseAccountDeleteCancel = "base_account_delete_cancel";
        public const string BaseAccountGet = "base_account_get";
        public const string BaseAccountRules = "base_account_rules";
        public const string BaseAccountUpdate = "base_account_update";
        public const string BaseAppVersion = "base_app_version";
        public const string BaseAvatar = "base_avatar";
        public const string BaseAvatarGet = "base_avatar_get";
        public const string BaseAvatarSave = "base_avatar_save";
        public const string BaseBrand = "base_brand";
        public const string BaseCategories = "base_categories";
        public const string BaseChatQuota = "base_chat_quota";
        public const string BaseCommFavorite = "base_comm_favorite";
        public const string BaseCommFavorites = "base_comm_favorites";
        public const string BaseCommPacks = "base_comm_packs";
        public const string BaseCountries = "base_countries";
        public const string BaseFriendRules = "base_friend_rules";
        public const string BaseFriendSuggestions = "base_friend_suggestions";
        public const string BaseFriendsAdd = "base_friends_add";
        public const string BaseFriendsBlock = "base_friends_block";
        public const string BaseFriendsList = "base_friends_list";
        public const string BaseFriendsRemove = "base_friends_remove";
        public const string BaseLanguages = "base_languages";
        public const string BaseMyActivity = "base_my_activity";
        public const string BaseMyCode = "base_my_code";
        public const string BaseMyReports = "base_my_reports";
        public const string BaseMyStatus = "base_my_status";
        public const string BaseMyTags = "base_my_tags";
        public const string BasePlayerCodes = "base_player_codes";
        public const string BaseRemoteConfig = "base_remote_config";
        public const string BaseReportMessage = "base_report_message";
        public const string BaseReportPlayer = "base_report_player";
        public const string BaseReportTitles = "base_report_titles";
        public const string BaseServerStatus = "base_server_status";
        public const string BaseSetCountry = "base_set_country";
        public const string BaseSetLanguage = "base_set_language";
        public const string BaseStickers = "base_stickers";
        public const string BaseSupportChatClose = "base_support_chat_close";
        public const string BaseSupportChatGet = "base_support_chat_get";
        public const string BaseSupportChatOpen = "base_support_chat_open";
        public const string BaseSupportChatRate = "base_support_chat_rate";
        public const string BaseSupportChatSend = "base_support_chat_send";
        public const string BaseSupportChatTyping = "base_support_chat_typing";
        public const string BaseSupportInfo = "base_support_info";
        public const string BaseSupportTicketCreate = "base_support_ticket_create";
        public const string BaseSupportTicketGet = "base_support_ticket_get";
        public const string BaseSupportTicketRate = "base_support_ticket_rate";
        public const string BaseSupportTicketReply = "base_support_ticket_reply";
        public const string BaseSupportTicketResolve = "base_support_ticket_resolve";
        public const string BaseSupportTickets = "base_support_tickets";
        public const string BaseSupportUploadBegin = "base_support_upload_begin";
        public const string BaseSupportUploadFinish = "base_support_upload_finish";
        public const string BaseSupportUploadPart = "base_support_upload_part";
        public const string BaseTags = "base_tags";
        public const string BaseUserByCode = "base_user_by_code";
        public const string BaseUsernameChange = "base_username_change";
        public const string BaseUsernameQuote = "base_username_quote";
        public const string BaseUsersGet = "base_users_get";
        public const string BlockworldBuyBlock = "blockworld_buy_block";
        public const string BlockworldToken = "blockworld_token";
        public const string BlockworldWallet = "blockworld_wallet";
        public const string CampaignAttemptComplete = "campaign_attempt_complete";
        public const string CampaignAttemptStart = "campaign_attempt_start";
        public const string CampaignChapters = "campaign_chapters";
        public const string CampaignFreerideClaim = "campaign_freeride_claim";
        public const string ClanCreate = "clan_create";
        public const string ClanDemote = "clan_demote";
        public const string ClanGet = "clan_get";
        public const string ClanImageUpload = "clan_image_upload";
        public const string ClanInvite = "clan_invite";
        public const string ClanInviteAccept = "clan_invite_accept";
        public const string ClanInviteDecline = "clan_invite_decline";
        public const string ClanInvites = "clan_invites";
        public const string ClanJoin = "clan_join";
        public const string ClanKick = "clan_kick";
        public const string ClanLeave = "clan_leave";
        public const string ClanLevels = "clan_levels";
        public const string ClanMine = "clan_mine";
        public const string ClanOptions = "clan_options";
        public const string ClanPromote = "clan_promote";
        public const string ClanRequestAccept = "clan_request_accept";
        public const string ClanRequestReject = "clan_request_reject";
        public const string ClanRequests = "clan_requests";
        public const string ClanSearch = "clan_search";
        public const string ClanTransfer = "clan_transfer";
        public const string ClanUpdate = "clan_update";
        public const string ClanWarCurrent = "clan_war_current";
        public const string ClanWarHistory = "clan_war_history";
        public const string ClanWarOpponents = "clan_war_opponents";
        public const string ClanWarSignup = "clan_war_signup";
        public const string ClanXpHistory = "clan_xp_history";
        public const string CombatraceConfig = "combatrace_config";
        public const string CombatraceEvents = "combatrace_events";
        public const string CombatraceHistory = "combatrace_history";
        public const string CombatraceMatchBegin = "combatrace_match_begin";
        public const string CombatraceMatchEnd = "combatrace_match_end";
        public const string CombatraceMissions = "combatrace_missions";
        public const string CombatraceProfile = "combatrace_profile";
        public const string CombatraceTaskClaim = "combatrace_task_claim";
        public const string CommsUserToken = "comms_user_token";
        public const string ContentCatalog = "content_catalog";
        public const string CupGet = "cup_get";
        public const string CupHistory = "cup_history";
        public const string CupList = "cup_list";
        public const string CupMyMatch = "cup_my_match";
        public const string CupReady = "cup_ready";
        public const string CupSignup = "cup_signup";
        public const string CupStart = "cup_start";
        public const string CupWithdraw = "cup_withdraw";
        public const string DevkitErrorCatalog = "devkit_error_catalog";
        public const string DevkitRpcSchema = "devkit_rpc_schema";
        public const string EconomyAchievementClaim = "economy_achievement_claim";
        public const string EconomyAchievements = "economy_achievements";
        public const string EconomyAchievementsProfile = "economy_achievements_profile";
        public const string EconomyAvatarBuy = "economy_avatar_buy";
        public const string EconomyAvatarCatalog = "economy_avatar_catalog";
        public const string EconomyAvatarCreate = "economy_avatar_create";
        public const string EconomyAvatarDelete = "economy_avatar_delete";
        public const string EconomyAvatarEquip = "economy_avatar_equip";
        public const string EconomyAvatarList = "economy_avatar_list";
        public const string EconomyAvatarLooks = "economy_avatar_looks";
        public const string EconomyAvatarRename = "economy_avatar_rename";
        public const string EconomyAvatarSetActive = "economy_avatar_set_active";
        public const string EconomyAvatarUnequip = "economy_avatar_unequip";
        public const string EconomyBalances = "economy_balances";
        public const string EconomyBoosters = "economy_boosters";
        public const string EconomyCatalog = "economy_catalog";
        public const string EconomyChanceAck = "economy_chance_ack";
        public const string EconomyChanceCanPlay = "economy_chance_can_play";
        public const string EconomyChanceGame = "economy_chance_game";
        public const string EconomyChanceGames = "economy_chance_games";
        public const string EconomyChanceHistory = "economy_chance_history";
        public const string EconomyChanceNextPlayTime = "economy_chance_next_play_time";
        public const string EconomyChancePlay = "economy_chance_play";
        public const string EconomyChancePlayWithTicket = "economy_chance_play_with_ticket";
        public const string EconomyEventRecord = "economy_event_record";
        public const string EconomyEventsProgress = "economy_events_progress";
        public const string EconomyFriendGiftAccept = "economy_friend_gift_accept";
        public const string EconomyFriendGiftCancel = "economy_friend_gift_cancel";
        public const string EconomyFriendGiftDecline = "economy_friend_gift_decline";
        public const string EconomyFriendGiftOptions = "economy_friend_gift_options";
        public const string EconomyFriendGiftSend = "economy_friend_gift_send";
        public const string EconomyFriendGifts = "economy_friend_gifts";
        public const string EconomyGame = "economy_game";
        public const string EconomyGameActive = "economy_game_active";
        public const string EconomyGameBot = "economy_game_bot";
        public const string EconomyGameFriendCancel = "economy_game_friend_cancel";
        public const string EconomyGameFriendCreate = "economy_game_friend_create";
        public const string EconomyGameFriendDecline = "economy_game_friend_decline";
        public const string EconomyGameFriendJoin = "economy_game_friend_join";
        public const string EconomyGameJoin = "economy_game_join";
        public const string EconomyGameQueue = "economy_game_queue";
        public const string EconomyGameStats = "economy_game_stats";
        public const string EconomyGames = "economy_games";
        public const string EconomyGiftRedeem = "economy_gift_redeem";
        public const string EconomyInventory = "economy_inventory";
        public const string EconomyItemBuy = "economy_item_buy";
        public const string EconomyItemEquip = "economy_item_equip";
        public const string EconomyItemUnequip = "economy_item_unequip";
        public const string EconomyItemUnlock = "economy_item_unlock";
        public const string EconomyItemUpgrade = "economy_item_upgrade";
        public const string EconomyItemUse = "economy_item_use";
        public const string EconomyLevels = "economy_levels";
        public const string EconomyMetaRelations = "economy_meta_relations";
        public const string EconomyOfferBuy = "economy_offer_buy";
        public const string EconomyOfferSeen = "economy_offer_seen";
        public const string EconomyOffers = "economy_offers";
        public const string EconomyOffersReroll = "economy_offers_reroll";
        public const string EconomyPaymentsMine = "economy_payments_mine";
        public const string EconomyPlayerCard = "economy_player_card";
        public const string EconomyPurchaseReview = "economy_purchase_review";
        public const string EconomyPurchaseStart = "economy_purchase_start";
        public const string EconomyPurchaseStatus = "economy_purchase_status";
        public const string EconomyPurchaseSubmit = "economy_purchase_submit";
        public const string EconomyPurchasesMine = "economy_purchases_mine";
        public const string EconomyReferralEnter = "economy_referral_enter";
        public const string EconomyReferralMe = "economy_referral_me";
        public const string EconomyRegenRefill = "economy_regen_refill";
        public const string EconomyRegenState = "economy_regen_state";
        public const string EconomyRewardClaim = "economy_reward_claim";
        public const string EconomyRewardsMine = "economy_rewards_mine";
        public const string EconomyStoreConfig = "economy_store_config";
        public const string EconomyStreaks = "economy_streaks";
        public const string EconomyTaskClaim = "economy_task_claim";
        public const string EconomyTaskGroupCurrent = "economy_task_group_current";
        public const string EconomyTaskGroupNext = "economy_task_group_next";
        public const string EconomyTasksList = "economy_tasks_list";
        public const string FlickkickBotMatch = "flickkick_bot_match";
        public const string FlickkickConfig = "flickkick_config";
        public const string FlickkickFormations = "flickkick_formations";
        public const string FlickkickFriendCancel = "flickkick_friend_cancel";
        public const string FlickkickFriendCreate = "flickkick_friend_create";
        public const string FlickkickFriendJoin = "flickkick_friend_join";
        public const string InsightsConfig = "insights_config";
        public const string InsightsHeatmap = "insights_heatmap";
        public const string InsightsSend = "insights_send";
        public const string InsightsSession = "insights_session";
        public const string InventoryxItems = "inventoryx_items";
        public const string InventoryxUnlock = "inventoryx_unlock";
        public const string InventoryxUpgrade = "inventoryx_upgrade";
        public const string LeaderboardxBoard = "leaderboardx_board";
        public const string LeaderboardxClaim = "leaderboardx_claim";
        public const string LeaderboardxHistory = "leaderboardx_history";
        public const string LeaderboardxList = "leaderboardx_list";
        public const string LeaderboardxSubmit = "leaderboardx_submit";
        public const string LeaderboardxWinners = "leaderboardx_winners";
        public const string LedgerKinds = "ledger_kinds";
        public const string LedgerList = "ledger_list";
        public const string PpLocalState = "pp_local_state";
        public const string PredictionAnswerUpdate = "prediction_answer_update";
        public const string PredictionConfig = "prediction_config";
        public const string PredictionEvent = "prediction_event";
        public const string PredictionEvents = "prediction_events";
        public const string PredictionHistory = "prediction_history";
        public const string PredictionLeaderboard = "prediction_leaderboard";
        public const string PredictionLeague = "prediction_league";
        public const string PredictionLeagues = "prediction_leagues";
        public const string PredictionMyAnswers = "prediction_my_answers";
        public const string PredictionMyStats = "prediction_my_stats";
        public const string PredictionQuestionEvents = "prediction_question_events";
        public const string PredictionResults = "prediction_results";
        public const string PredictionSubmit = "prediction_submit";
        public const string PublicationBannerClick = "publication_banner_click";
        public const string PublicationBannerView = "publication_banner_view";
        public const string PublicationBanners = "publication_banners";
        public const string PublicationFaqList = "publication_faq_list";
        public const string PublicationInbox = "publication_inbox";
        public const string PublicationInboxClaim = "publication_inbox_claim";
        public const string PublicationInboxSeen = "publication_inbox_seen";
        public const string PublicationNewsBySlug = "publication_news_by_slug";
        public const string PublicationNewsComment = "publication_news_comment";
        public const string PublicationNewsCommentDelete = "publication_news_comment_delete";
        public const string PublicationNewsComments = "publication_news_comments";
        public const string PublicationNewsGet = "publication_news_get";
        public const string PublicationNewsList = "publication_news_list";
        public const string PublicationNewsReact = "publication_news_react";
        public const string PublicationNewsReactionTypes = "publication_news_reaction_types";
        public const string PublicationNewsSeen = "publication_news_seen";
        public const string PublicationNewsUnread = "publication_news_unread";
        public const string PublicationNotificationOpened = "publication_notification_opened";
        public const string PublicationNotifyPrefs = "publication_notify_prefs";
        public const string PublicationNotifyPrefsSet = "publication_notify_prefs_set";
        public const string PublicationOtpRequest = "publication_otp_request";
        public const string PublicationOtpVerify = "publication_otp_verify";
        public const string PublicationPhone = "publication_phone";
        public const string PublicationPushDevices = "publication_push_devices";
        public const string PublicationPushRegister = "publication_push_register";
        public const string PublicationPushUnregister = "publication_push_unregister";
        public const string PublicationSponsorClick = "publication_sponsor_click";
        public const string PublicationSponsorView = "publication_sponsor_view";
        public const string PublicationSponsors = "publication_sponsors";
        public const string QuizAnswer = "quiz_answer";
        public const string QuizAnswerAll = "quiz_answer_all";
        public const string QuizDuelAccept = "quiz_duel_accept";
        public const string QuizDuelAnswer = "quiz_duel_answer";
        public const string QuizDuelCategories = "quiz_duel_categories";
        public const string QuizDuelDecline = "quiz_duel_decline";
        public const string QuizDuelForfeit = "quiz_duel_forfeit";
        public const string QuizDuelGet = "quiz_duel_get";
        public const string QuizDuelList = "quiz_duel_list";
        public const string QuizDuelPickCategory = "quiz_duel_pick_category";
        public const string QuizDuelQuestion = "quiz_duel_question";
        public const string QuizDuelStart = "quiz_duel_start";
        public const string QuizDuelStats = "quiz_duel_stats";
        public const string QuizFinish = "quiz_finish";
        public const string QuizHintBuy = "quiz_hint_buy";
        public const string QuizMissionStart = "quiz_mission_start";
        public const string QuizMissions = "quiz_missions";
        public const string QuizPackRandom = "quiz_pack_random";
        public const string QuizPacks = "quiz_packs";
        public const string QuizPlay = "quiz_play";
        public const string QuizReportQuestion = "quiz_report_question";
        public const string QuizReportReasons = "quiz_report_reasons";
        public const string QuizResultReport = "quiz_result_report";
        public const string QuizSession = "quiz_session";
        public const string QuizStats = "quiz_stats";
        public const string ShopxPurchaseCheck = "shopx_purchase_check";
        public const string ShopxPurchaseRules = "shopx_purchase_rules";
        public const string SocialAvatar = "social_avatar";
        public const string SocialCommentDelete = "social_comment_delete";
        public const string SocialCommentEdit = "social_comment_edit";
        public const string SocialCommentPost = "social_comment_post";
        public const string SocialCommentReport = "social_comment_report";
        public const string SocialComments = "social_comments";
        public const string SocialConfig = "social_config";
        public const string SocialFavorite = "social_favorite";
        public const string SocialFollow = "social_follow";
        public const string SocialFollowRequests = "social_follow_requests";
        public const string SocialFollowRespond = "social_follow_respond";
        public const string SocialFollowerRemove = "social_follower_remove";
        public const string SocialFollowers = "social_followers";
        public const string SocialFollowing = "social_following";
        public const string SocialMine = "social_mine";
        public const string SocialPrivacyGet = "social_privacy_get";
        public const string SocialPrivacySet = "social_privacy_set";
        public const string SocialProfile = "social_profile";
        public const string SocialRate = "social_rate";
        public const string SocialReact = "social_react";
        public const string SocialSummary = "social_summary";
        public const string SocialUnfollow = "social_unfollow";
        public const string SoltanBootstrap = "soltan_bootstrap";
        public const string SoltanDailyState = "soltan_daily_state";
        public const string SoltanDuelHistory = "soltan_duel_history";
        public const string SoltanDuelInfo = "soltan_duel_info";
        public const string SoltanHint = "soltan_hint";
        public const string SoltanLevelComplete = "soltan_level_complete";
        public const string SoltanLevelStart = "soltan_level_start";
        public const string SoltanMapSeen = "soltan_map_seen";
        public const string SoltanPrefs = "soltan_prefs";
        public const string SoltanRocket = "soltan_rocket";
        public const string TrophyHistory = "trophy_history";
        public const string TrophyLeagues = "trophy_leagues";
        public const string TrophyMe = "trophy_me";
        public const string TrophyPlayers = "trophy_players";
        public const string VoiceToken = "voice_token";
    }

    public sealed partial class AccountRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public AccountRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<AccountMeResponse> MeAsync(AccountMeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountMeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountMeResponse>(_c, RpcIds.AccountMe, request, ReadCall, ct);
        }

        public Task<AccountPasswordChangeResponse> PasswordChangeAsync(AccountPasswordChangeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPasswordChangeRequest();
            return RpcInvoke.CallAsync<AccountPasswordChangeResponse>(_c, RpcIds.AccountPasswordChange, request, WriteCall, ct);
        }

        public Task<AccountPasswordForgotResponse> PasswordForgotAsync(AccountPasswordForgotRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPasswordForgotRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountPasswordForgotResponse>(_c, RpcIds.AccountPasswordForgot, request, WriteCall, ct);
        }

        public Task<AccountPasswordLoginResponse> PasswordLoginAsync(AccountPasswordLoginRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPasswordLoginRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountPasswordLoginResponse>(_c, RpcIds.AccountPasswordLogin, request, WriteCall, ct);
        }

        public Task<AccountPasswordResetResponse> PasswordResetAsync(AccountPasswordResetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPasswordResetRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountPasswordResetResponse>(_c, RpcIds.AccountPasswordReset, request, WriteCall, ct);
        }

        public Task<AccountPasswordSetResponse> PasswordSetAsync(AccountPasswordSetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPasswordSetRequest();
            return RpcInvoke.CallAsync<AccountPasswordSetResponse>(_c, RpcIds.AccountPasswordSet, request, WriteCall, ct);
        }

        public Task<AccountPhoneCancelResponse> PhoneCancelAsync(AccountPhoneCancelRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPhoneCancelRequest();
            return RpcInvoke.CallAsync<AccountPhoneCancelResponse>(_c, RpcIds.AccountPhoneCancel, request, WriteCall, ct);
        }

        public Task<AccountPhoneRecoverRequestResponse> PhoneRecoverRequestAsync(AccountPhoneRecoverRequestRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPhoneRecoverRequestRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountPhoneRecoverRequestResponse>(_c, RpcIds.AccountPhoneRecoverRequest, request, WriteCall, ct);
        }

        public Task<AccountPhoneRecoverVerifyResponse> PhoneRecoverVerifyAsync(AccountPhoneRecoverVerifyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPhoneRecoverVerifyRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountPhoneRecoverVerifyResponse>(_c, RpcIds.AccountPhoneRecoverVerify, request, WriteCall, ct);
        }

        public Task<AccountPhoneRequestResponse> PhoneRequestAsync(AccountPhoneRequestRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPhoneRequestRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountPhoneRequestResponse>(_c, RpcIds.AccountPhoneRequest, request, WriteCall, ct);
        }

        public Task<AccountPhoneVerifyResponse> PhoneVerifyAsync(AccountPhoneVerifyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountPhoneVerifyRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AccountPhoneVerifyResponse>(_c, RpcIds.AccountPhoneVerify, request, WriteCall, ct);
        }

        public Task<AccountRulesResponse> RulesAsync(AccountRulesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountRulesRequest();
            return RpcInvoke.CallAsync<AccountRulesResponse>(_c, RpcIds.AccountRules, request, ReadCall, ct);
        }

        public Task<AccountUsernameCheckResponse> UsernameCheckAsync(AccountUsernameCheckRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AccountUsernameCheckRequest();
            return RpcInvoke.CallAsync<AccountUsernameCheckResponse>(_c, RpcIds.AccountUsernameCheck, request, WriteCall, ct);
        }
    }

    public sealed partial class AnalyticsRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public AnalyticsRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<AnalyticsConfigResponse> ConfigAsync(AnalyticsConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AnalyticsConfigRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AnalyticsConfigResponse>(_c, RpcIds.AnalyticsConfig, request, ReadCall, ct);
        }

        public Task<AnalyticsStatsResponse> StatsAsync(AnalyticsStatsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AnalyticsStatsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AnalyticsStatsResponse>(_c, RpcIds.AnalyticsStats, request, ReadCall, ct);
        }

        public Task<AnalyticsTrackResponse> TrackAsync(AnalyticsTrackRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AnalyticsTrackRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AnalyticsTrackResponse>(_c, RpcIds.AnalyticsTrack, request, WriteCall, ct);
        }

        public Task<AnalyticsTrophiesResponse> TrophiesAsync(AnalyticsTrophiesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AnalyticsTrophiesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AnalyticsTrophiesResponse>(_c, RpcIds.AnalyticsTrophies, request, ReadCall, ct);
        }

        public Task<AnalyticsTrophyClaimResponse> TrophyClaimAsync(AnalyticsTrophyClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AnalyticsTrophyClaimRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<AnalyticsTrophyClaimResponse>(_c, RpcIds.AnalyticsTrophyClaim, request, WriteCall, ct);
        }
    }

    public sealed partial class AssetsRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public AssetsRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<AssetsContentIndexResponse> ContentIndexAsync(AssetsContentIndexRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AssetsContentIndexRequest();
            return RpcInvoke.CallAsync<AssetsContentIndexResponse>(_c, RpcIds.AssetsContentIndex, request, ReadCall, ct);
        }

        public Task<AssetsFetchResponse> FetchAsync(AssetsFetchRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AssetsFetchRequest();
            return RpcInvoke.CallAsync<AssetsFetchResponse>(_c, RpcIds.AssetsFetch, request, ReadCall, ct);
        }

        public Task<AssetsManifestResponse> ManifestAsync(AssetsManifestRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new AssetsManifestRequest();
            return RpcInvoke.CallAsync<AssetsManifestResponse>(_c, RpcIds.AssetsManifest, request, ReadCall, ct);
        }
    }

    public sealed partial class BaseRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public BaseRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<BaseAccountDeleteResponse> AccountDeleteAsync(BaseAccountDeleteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAccountDeleteRequest();
            return RpcInvoke.CallAsync<BaseAccountDeleteResponse>(_c, RpcIds.BaseAccountDelete, request, WriteCall, ct);
        }

        public Task<BaseAccountDeleteCancelResponse> AccountDeleteCancelAsync(BaseAccountDeleteCancelRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAccountDeleteCancelRequest();
            return RpcInvoke.CallAsync<BaseAccountDeleteCancelResponse>(_c, RpcIds.BaseAccountDeleteCancel, request, WriteCall, ct);
        }

        public Task<BaseAccountGetResponse> AccountGetAsync(BaseAccountGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAccountGetRequest();
            return RpcInvoke.CallAsync<BaseAccountGetResponse>(_c, RpcIds.BaseAccountGet, request, ReadCall, ct);
        }

        public Task<BaseAccountRulesResponse> AccountRulesAsync(BaseAccountRulesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAccountRulesRequest();
            return RpcInvoke.CallAsync<BaseAccountRulesResponse>(_c, RpcIds.BaseAccountRules, request, ReadCall, ct);
        }

        public Task<BaseAccountUpdateResponse> AccountUpdateAsync(BaseAccountUpdateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAccountUpdateRequest();
            return RpcInvoke.CallAsync<BaseAccountUpdateResponse>(_c, RpcIds.BaseAccountUpdate, request, WriteCall, ct);
        }

        public Task<BaseAppVersionResponse> AppVersionAsync(BaseAppVersionRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAppVersionRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseAppVersionResponse>(_c, RpcIds.BaseAppVersion, request, ReadCall, ct);
        }

        public Task<BaseBrandResponse> BrandAsync(BaseBrandRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseBrandRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseBrandResponse>(_c, RpcIds.BaseBrand, request, ReadCall, ct);
        }

        public Task<BaseCategoriesResponse> CategoriesAsync(BaseCategoriesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseCategoriesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseCategoriesResponse>(_c, RpcIds.BaseCategories, request, ReadCall, ct);
        }

        public Task<BaseChatQuotaResponse> ChatQuotaAsync(BaseChatQuotaRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseChatQuotaRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseChatQuotaResponse>(_c, RpcIds.BaseChatQuota, request, ReadCall, ct);
        }

        public Task<BaseCommFavoriteResponse> CommFavoriteAsync(BaseCommFavoriteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseCommFavoriteRequest();
            return RpcInvoke.CallAsync<BaseCommFavoriteResponse>(_c, RpcIds.BaseCommFavorite, request, WriteCall, ct);
        }

        public Task<BaseCommFavoritesResponse> CommFavoritesAsync(BaseCommFavoritesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseCommFavoritesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseCommFavoritesResponse>(_c, RpcIds.BaseCommFavorites, request, WriteCall, ct);
        }

        public Task<BaseCommPacksResponse> CommPacksAsync(BaseCommPacksRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseCommPacksRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseCommPacksResponse>(_c, RpcIds.BaseCommPacks, request, WriteCall, ct);
        }

        public Task<BaseCountriesResponse> CountriesAsync(BaseCountriesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseCountriesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseCountriesResponse>(_c, RpcIds.BaseCountries, request, ReadCall, ct);
        }

        public Task<BaseFriendRulesResponse> FriendRulesAsync(BaseFriendRulesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseFriendRulesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseFriendRulesResponse>(_c, RpcIds.BaseFriendRules, request, ReadCall, ct);
        }

        public Task<BaseFriendSuggestionsResponse> FriendSuggestionsAsync(BaseFriendSuggestionsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseFriendSuggestionsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseFriendSuggestionsResponse>(_c, RpcIds.BaseFriendSuggestions, request, WriteCall, ct);
        }

        public Task<BaseFriendsAddResponse> FriendsAddAsync(BaseFriendsAddRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseFriendsAddRequest();
            return RpcInvoke.CallAsync<BaseFriendsAddResponse>(_c, RpcIds.BaseFriendsAdd, request, WriteCall, ct);
        }

        public Task<BaseFriendsBlockResponse> FriendsBlockAsync(BaseFriendsBlockRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseFriendsBlockRequest();
            return RpcInvoke.CallAsync<BaseFriendsBlockResponse>(_c, RpcIds.BaseFriendsBlock, request, WriteCall, ct);
        }

        public Task<BaseFriendsListResponse> FriendsListAsync(BaseFriendsListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseFriendsListRequest();
            return RpcInvoke.CallAsync<BaseFriendsListResponse>(_c, RpcIds.BaseFriendsList, request, ReadCall, ct);
        }

        public Task<BaseFriendsRemoveResponse> FriendsRemoveAsync(BaseFriendsRemoveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseFriendsRemoveRequest();
            return RpcInvoke.CallAsync<BaseFriendsRemoveResponse>(_c, RpcIds.BaseFriendsRemove, request, WriteCall, ct);
        }

        public Task<BaseLanguagesResponse> LanguagesAsync(BaseLanguagesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseLanguagesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseLanguagesResponse>(_c, RpcIds.BaseLanguages, request, ReadCall, ct);
        }

        public Task<BaseMyActivityResponse> MyActivityAsync(BaseMyActivityRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseMyActivityRequest();
            return RpcInvoke.CallAsync<BaseMyActivityResponse>(_c, RpcIds.BaseMyActivity, request, ReadCall, ct);
        }

        public Task<BaseMyCodeResponse> MyCodeAsync(BaseMyCodeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseMyCodeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseMyCodeResponse>(_c, RpcIds.BaseMyCode, request, WriteCall, ct);
        }

        public Task<BaseMyReportsResponse> MyReportsAsync(BaseMyReportsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseMyReportsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseMyReportsResponse>(_c, RpcIds.BaseMyReports, request, ReadCall, ct);
        }

        public Task<BaseMyStatusResponse> MyStatusAsync(BaseMyStatusRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseMyStatusRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseMyStatusResponse>(_c, RpcIds.BaseMyStatus, request, ReadCall, ct);
        }

        public Task<BaseMyTagsResponse> MyTagsAsync(BaseMyTagsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseMyTagsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseMyTagsResponse>(_c, RpcIds.BaseMyTags, request, ReadCall, ct);
        }

        public Task<BasePlayerCodesResponse> PlayerCodesAsync(BasePlayerCodesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BasePlayerCodesRequest();
            return RpcInvoke.CallAsync<BasePlayerCodesResponse>(_c, RpcIds.BasePlayerCodes, request, WriteCall, ct);
        }

        public Task<BaseRemoteConfigResponse> RemoteConfigAsync(BaseRemoteConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseRemoteConfigRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseRemoteConfigResponse>(_c, RpcIds.BaseRemoteConfig, request, ReadCall, ct);
        }

        public Task<BaseReportMessageResponse> ReportMessageAsync(BaseReportMessageRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseReportMessageRequest();
            return RpcInvoke.CallAsync<BaseReportMessageResponse>(_c, RpcIds.BaseReportMessage, request, WriteCall, ct);
        }

        public Task<BaseReportPlayerResponse> ReportPlayerAsync(BaseReportPlayerRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseReportPlayerRequest();
            return RpcInvoke.CallAsync<BaseReportPlayerResponse>(_c, RpcIds.BaseReportPlayer, request, WriteCall, ct);
        }

        public Task<BaseReportTitlesResponse> ReportTitlesAsync(BaseReportTitlesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseReportTitlesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseReportTitlesResponse>(_c, RpcIds.BaseReportTitles, request, WriteCall, ct);
        }

        public Task<BaseServerStatusResponse> ServerStatusAsync(BaseServerStatusRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseServerStatusRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseServerStatusResponse>(_c, RpcIds.BaseServerStatus, request, ReadCall, ct);
        }

        public Task<BaseSetCountryResponse> SetCountryAsync(BaseSetCountryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSetCountryRequest();
            return RpcInvoke.CallAsync<BaseSetCountryResponse>(_c, RpcIds.BaseSetCountry, request, WriteCall, ct);
        }

        public Task<BaseSetLanguageResponse> SetLanguageAsync(BaseSetLanguageRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSetLanguageRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSetLanguageResponse>(_c, RpcIds.BaseSetLanguage, request, WriteCall, ct);
        }

        public Task<BaseStickersResponse> StickersAsync(BaseStickersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseStickersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseStickersResponse>(_c, RpcIds.BaseStickers, request, ReadCall, ct);
        }

        public Task<BaseSupportChatCloseResponse> SupportChatCloseAsync(BaseSupportChatCloseRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportChatCloseRequest();
            return RpcInvoke.CallAsync<BaseSupportChatCloseResponse>(_c, RpcIds.BaseSupportChatClose, request, WriteCall, ct);
        }

        public Task<BaseSupportChatGetResponse> SupportChatGetAsync(BaseSupportChatGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportChatGetRequest();
            return RpcInvoke.CallAsync<BaseSupportChatGetResponse>(_c, RpcIds.BaseSupportChatGet, request, ReadCall, ct);
        }

        public Task<BaseSupportChatOpenResponse> SupportChatOpenAsync(BaseSupportChatOpenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportChatOpenRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportChatOpenResponse>(_c, RpcIds.BaseSupportChatOpen, request, WriteCall, ct);
        }

        public Task<BaseSupportChatRateResponse> SupportChatRateAsync(BaseSupportChatRateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportChatRateRequest();
            return RpcInvoke.CallAsync<BaseSupportChatRateResponse>(_c, RpcIds.BaseSupportChatRate, request, WriteCall, ct);
        }

        public Task<BaseSupportChatSendResponse> SupportChatSendAsync(BaseSupportChatSendRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportChatSendRequest();
            return RpcInvoke.CallAsync<BaseSupportChatSendResponse>(_c, RpcIds.BaseSupportChatSend, request, WriteCall, ct);
        }

        public Task<BaseSupportChatTypingResponse> SupportChatTypingAsync(BaseSupportChatTypingRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportChatTypingRequest();
            return RpcInvoke.CallAsync<BaseSupportChatTypingResponse>(_c, RpcIds.BaseSupportChatTyping, request, WriteCall, ct);
        }

        public Task<BaseSupportInfoResponse> SupportInfoAsync(BaseSupportInfoRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportInfoRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportInfoResponse>(_c, RpcIds.BaseSupportInfo, request, ReadCall, ct);
        }

        public Task<BaseSupportTicketCreateResponse> SupportTicketCreateAsync(BaseSupportTicketCreateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportTicketCreateRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportTicketCreateResponse>(_c, RpcIds.BaseSupportTicketCreate, request, WriteCall, ct);
        }

        public Task<BaseSupportTicketGetResponse> SupportTicketGetAsync(BaseSupportTicketGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportTicketGetRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportTicketGetResponse>(_c, RpcIds.BaseSupportTicketGet, request, ReadCall, ct);
        }

        public Task<BaseSupportTicketRateResponse> SupportTicketRateAsync(BaseSupportTicketRateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportTicketRateRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportTicketRateResponse>(_c, RpcIds.BaseSupportTicketRate, request, WriteCall, ct);
        }

        public Task<BaseSupportTicketReplyResponse> SupportTicketReplyAsync(BaseSupportTicketReplyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportTicketReplyRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportTicketReplyResponse>(_c, RpcIds.BaseSupportTicketReply, request, WriteCall, ct);
        }

        public Task<BaseSupportTicketResolveResponse> SupportTicketResolveAsync(BaseSupportTicketResolveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportTicketResolveRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportTicketResolveResponse>(_c, RpcIds.BaseSupportTicketResolve, request, WriteCall, ct);
        }

        public Task<BaseSupportTicketsResponse> SupportTicketsAsync(BaseSupportTicketsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportTicketsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseSupportTicketsResponse>(_c, RpcIds.BaseSupportTickets, request, ReadCall, ct);
        }

        public Task<BaseSupportUploadBeginResponse> SupportUploadBeginAsync(BaseSupportUploadBeginRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportUploadBeginRequest();
            return RpcInvoke.CallAsync<BaseSupportUploadBeginResponse>(_c, RpcIds.BaseSupportUploadBegin, request, WriteCall, ct);
        }

        public Task<BaseSupportUploadFinishResponse> SupportUploadFinishAsync(BaseSupportUploadFinishRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportUploadFinishRequest();
            return RpcInvoke.CallAsync<BaseSupportUploadFinishResponse>(_c, RpcIds.BaseSupportUploadFinish, request, WriteCall, ct);
        }

        public Task<BaseSupportUploadPartResponse> SupportUploadPartAsync(BaseSupportUploadPartRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseSupportUploadPartRequest();
            return RpcInvoke.CallAsync<BaseSupportUploadPartResponse>(_c, RpcIds.BaseSupportUploadPart, request, WriteCall, ct);
        }

        public Task<BaseTagsResponse> TagsAsync(BaseTagsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseTagsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseTagsResponse>(_c, RpcIds.BaseTags, request, ReadCall, ct);
        }

        public Task<BaseUserByCodeResponse> UserByCodeAsync(BaseUserByCodeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseUserByCodeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseUserByCodeResponse>(_c, RpcIds.BaseUserByCode, request, WriteCall, ct);
        }

        public Task<BaseUsernameChangeResponse> UsernameChangeAsync(BaseUsernameChangeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseUsernameChangeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseUsernameChangeResponse>(_c, RpcIds.BaseUsernameChange, request, WriteCall, ct);
        }

        public Task<BaseUsernameQuoteResponse> UsernameQuoteAsync(BaseUsernameQuoteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseUsernameQuoteRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseUsernameQuoteResponse>(_c, RpcIds.BaseUsernameQuote, request, WriteCall, ct);
        }

        public Task<BaseUsersGetResponse> UsersGetAsync(BaseUsersGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseUsersGetRequest();
            return RpcInvoke.CallAsync<BaseUsersGetResponse>(_c, RpcIds.BaseUsersGet, request, ReadCall, ct);
        }

        public Task<CommsUserTokenResponse> CommsUserTokenAsync(CommsUserTokenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CommsUserTokenRequest();
            return RpcInvoke.CallAsync<CommsUserTokenResponse>(_c, RpcIds.CommsUserToken, request, WriteCall, ct);
        }

        public Task<VoiceTokenResponse> VoiceTokenAsync(VoiceTokenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new VoiceTokenRequest();
            return RpcInvoke.CallAsync<VoiceTokenResponse>(_c, RpcIds.VoiceToken, request, WriteCall, ct);
        }
    }

    public sealed partial class BlockworldRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public BlockworldRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<BlockworldBuyBlockResponse> BuyBlockAsync(BlockworldBuyBlockRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BlockworldBuyBlockRequest();
            return RpcInvoke.CallAsync<BlockworldBuyBlockResponse>(_c, RpcIds.BlockworldBuyBlock, request, WriteCall, ct);
        }

        public Task<BlockworldTokenResponse> TokenAsync(BlockworldTokenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BlockworldTokenRequest();
            return RpcInvoke.CallAsync<BlockworldTokenResponse>(_c, RpcIds.BlockworldToken, request, WriteCall, ct);
        }

        public Task<BlockworldWalletResponse> WalletAsync(BlockworldWalletRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BlockworldWalletRequest();
            return RpcInvoke.CallAsync<BlockworldWalletResponse>(_c, RpcIds.BlockworldWallet, request, WriteCall, ct);
        }
    }

    public sealed partial class CampaignRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public CampaignRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<CampaignAttemptCompleteResponse> AttemptCompleteAsync(CampaignAttemptCompleteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CampaignAttemptCompleteRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CampaignAttemptCompleteResponse>(_c, RpcIds.CampaignAttemptComplete, request, WriteCall, ct);
        }

        public Task<CampaignAttemptStartResponse> AttemptStartAsync(CampaignAttemptStartRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CampaignAttemptStartRequest();
            return RpcInvoke.CallAsync<CampaignAttemptStartResponse>(_c, RpcIds.CampaignAttemptStart, request, WriteCall, ct);
        }

        public Task<CampaignChaptersResponse> ChaptersAsync(CampaignChaptersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CampaignChaptersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CampaignChaptersResponse>(_c, RpcIds.CampaignChapters, request, ReadCall, ct);
        }

        public Task<CampaignFreerideClaimResponse> FreerideClaimAsync(CampaignFreerideClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CampaignFreerideClaimRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CampaignFreerideClaimResponse>(_c, RpcIds.CampaignFreerideClaim, request, WriteCall, ct);
        }
    }

    public sealed partial class ClanRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public ClanRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<ClanCreateResponse> CreateAsync(ClanCreateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanCreateRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ClanCreateResponse>(_c, RpcIds.ClanCreate, request, WriteCall, ct);
        }

        public Task<ClanDemoteResponse> DemoteAsync(ClanDemoteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanDemoteRequest();
            return RpcInvoke.CallAsync<ClanDemoteResponse>(_c, RpcIds.ClanDemote, request, WriteCall, ct);
        }

        public Task<ClanGetResponse> GetAsync(ClanGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanGetRequest();
            return RpcInvoke.CallAsync<ClanGetResponse>(_c, RpcIds.ClanGet, request, ReadCall, ct);
        }

        public Task<ClanImageUploadResponse> ImageUploadAsync(ClanImageUploadRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanImageUploadRequest();
            return RpcInvoke.CallAsync<ClanImageUploadResponse>(_c, RpcIds.ClanImageUpload, request, WriteCall, ct);
        }

        public Task<ClanInviteResponse> InviteAsync(ClanInviteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanInviteRequest();
            return RpcInvoke.CallAsync<ClanInviteResponse>(_c, RpcIds.ClanInvite, request, WriteCall, ct);
        }

        public Task<ClanInviteAcceptResponse> InviteAcceptAsync(ClanInviteAcceptRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanInviteAcceptRequest();
            return RpcInvoke.CallAsync<ClanInviteAcceptResponse>(_c, RpcIds.ClanInviteAccept, request, WriteCall, ct);
        }

        public Task<ClanInviteDeclineResponse> InviteDeclineAsync(ClanInviteDeclineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanInviteDeclineRequest();
            return RpcInvoke.CallAsync<ClanInviteDeclineResponse>(_c, RpcIds.ClanInviteDecline, request, WriteCall, ct);
        }

        public Task<ClanInvitesResponse> InvitesAsync(ClanInvitesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanInvitesRequest();
            return RpcInvoke.CallAsync<ClanInvitesResponse>(_c, RpcIds.ClanInvites, request, WriteCall, ct);
        }

        public Task<ClanJoinResponse> JoinAsync(ClanJoinRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanJoinRequest();
            return RpcInvoke.CallAsync<ClanJoinResponse>(_c, RpcIds.ClanJoin, request, WriteCall, ct);
        }

        public Task<ClanKickResponse> KickAsync(ClanKickRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanKickRequest();
            return RpcInvoke.CallAsync<ClanKickResponse>(_c, RpcIds.ClanKick, request, WriteCall, ct);
        }

        public Task<ClanLeaveResponse> LeaveAsync(ClanLeaveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanLeaveRequest();
            return RpcInvoke.CallAsync<ClanLeaveResponse>(_c, RpcIds.ClanLeave, request, WriteCall, ct);
        }

        public Task<ClanLevelsResponse> LevelsAsync(ClanLevelsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanLevelsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ClanLevelsResponse>(_c, RpcIds.ClanLevels, request, ReadCall, ct);
        }

        public Task<ClanMineResponse> MineAsync(ClanMineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanMineRequest();
            return RpcInvoke.CallAsync<ClanMineResponse>(_c, RpcIds.ClanMine, request, ReadCall, ct);
        }

        public Task<ClanOptionsResponse> OptionsAsync(ClanOptionsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanOptionsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ClanOptionsResponse>(_c, RpcIds.ClanOptions, request, ReadCall, ct);
        }

        public Task<ClanPromoteResponse> PromoteAsync(ClanPromoteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanPromoteRequest();
            return RpcInvoke.CallAsync<ClanPromoteResponse>(_c, RpcIds.ClanPromote, request, WriteCall, ct);
        }

        public Task<ClanRequestAcceptResponse> RequestAcceptAsync(ClanRequestAcceptRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanRequestAcceptRequest();
            return RpcInvoke.CallAsync<ClanRequestAcceptResponse>(_c, RpcIds.ClanRequestAccept, request, WriteCall, ct);
        }

        public Task<ClanRequestRejectResponse> RequestRejectAsync(ClanRequestRejectRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanRequestRejectRequest();
            return RpcInvoke.CallAsync<ClanRequestRejectResponse>(_c, RpcIds.ClanRequestReject, request, WriteCall, ct);
        }

        public Task<ClanRequestsResponse> RequestsAsync(ClanRequestsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanRequestsRequest();
            return RpcInvoke.CallAsync<ClanRequestsResponse>(_c, RpcIds.ClanRequests, request, WriteCall, ct);
        }

        public Task<ClanSearchResponse> SearchAsync(ClanSearchRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanSearchRequest();
            return RpcInvoke.CallAsync<ClanSearchResponse>(_c, RpcIds.ClanSearch, request, WriteCall, ct);
        }

        public Task<ClanTransferResponse> TransferAsync(ClanTransferRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanTransferRequest();
            return RpcInvoke.CallAsync<ClanTransferResponse>(_c, RpcIds.ClanTransfer, request, WriteCall, ct);
        }

        public Task<ClanUpdateResponse> UpdateAsync(ClanUpdateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanUpdateRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ClanUpdateResponse>(_c, RpcIds.ClanUpdate, request, WriteCall, ct);
        }

        public Task<ClanWarCurrentResponse> WarCurrentAsync(ClanWarCurrentRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanWarCurrentRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ClanWarCurrentResponse>(_c, RpcIds.ClanWarCurrent, request, ReadCall, ct);
        }

        public Task<ClanWarHistoryResponse> WarHistoryAsync(ClanWarHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanWarHistoryRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ClanWarHistoryResponse>(_c, RpcIds.ClanWarHistory, request, ReadCall, ct);
        }

        public Task<ClanWarOpponentsResponse> WarOpponentsAsync(ClanWarOpponentsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanWarOpponentsRequest();
            return RpcInvoke.CallAsync<ClanWarOpponentsResponse>(_c, RpcIds.ClanWarOpponents, request, WriteCall, ct);
        }

        public Task<ClanWarSignupResponse> WarSignupAsync(ClanWarSignupRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanWarSignupRequest();
            return RpcInvoke.CallAsync<ClanWarSignupResponse>(_c, RpcIds.ClanWarSignup, request, WriteCall, ct);
        }

        public Task<ClanXpHistoryResponse> XpHistoryAsync(ClanXpHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ClanXpHistoryRequest();
            return RpcInvoke.CallAsync<ClanXpHistoryResponse>(_c, RpcIds.ClanXpHistory, request, ReadCall, ct);
        }
    }

    public sealed partial class CombatraceRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public CombatraceRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<CombatraceConfigResponse> ConfigAsync(CombatraceConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceConfigRequest();
            return RpcInvoke.CallAsync<CombatraceConfigResponse>(_c, RpcIds.CombatraceConfig, request, ReadCall, ct);
        }

        public Task<CombatraceEventsResponse> EventsAsync(CombatraceEventsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceEventsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CombatraceEventsResponse>(_c, RpcIds.CombatraceEvents, request, WriteCall, ct);
        }

        public Task<CombatraceHistoryResponse> HistoryAsync(CombatraceHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceHistoryRequest();
            return RpcInvoke.CallAsync<CombatraceHistoryResponse>(_c, RpcIds.CombatraceHistory, request, ReadCall, ct);
        }

        public Task<CombatraceMatchBeginResponse> MatchBeginAsync(CombatraceMatchBeginRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceMatchBeginRequest();
            return RpcInvoke.CallAsync<CombatraceMatchBeginResponse>(_c, RpcIds.CombatraceMatchBegin, request, WriteCall, ct);
        }

        public Task<CombatraceMatchEndResponse> MatchEndAsync(CombatraceMatchEndRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceMatchEndRequest();
            return RpcInvoke.CallAsync<CombatraceMatchEndResponse>(_c, RpcIds.CombatraceMatchEnd, request, WriteCall, ct);
        }

        public Task<CombatraceMissionsResponse> MissionsAsync(CombatraceMissionsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceMissionsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CombatraceMissionsResponse>(_c, RpcIds.CombatraceMissions, request, WriteCall, ct);
        }

        public Task<CombatraceProfileResponse> ProfileAsync(CombatraceProfileRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceProfileRequest();
            return RpcInvoke.CallAsync<CombatraceProfileResponse>(_c, RpcIds.CombatraceProfile, request, ReadCall, ct);
        }

        public Task<CombatraceTaskClaimResponse> TaskClaimAsync(CombatraceTaskClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CombatraceTaskClaimRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CombatraceTaskClaimResponse>(_c, RpcIds.CombatraceTaskClaim, request, WriteCall, ct);
        }
    }

    public sealed partial class ContentRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public ContentRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<ContentCatalogResponse> CatalogAsync(ContentCatalogRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ContentCatalogRequest();
            return RpcInvoke.CallAsync<ContentCatalogResponse>(_c, RpcIds.ContentCatalog, request, ReadCall, ct);
        }
    }

    public sealed partial class CupRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public CupRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<CupGetResponse> GetAsync(CupGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupGetRequest();
            return RpcInvoke.CallAsync<CupGetResponse>(_c, RpcIds.CupGet, request, ReadCall, ct);
        }

        public Task<CupHistoryResponse> HistoryAsync(CupHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupHistoryRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CupHistoryResponse>(_c, RpcIds.CupHistory, request, ReadCall, ct);
        }

        public Task<CupListResponse> ListAsync(CupListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CupListResponse>(_c, RpcIds.CupList, request, ReadCall, ct);
        }

        public Task<CupMyMatchResponse> MyMatchAsync(CupMyMatchRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupMyMatchRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<CupMyMatchResponse>(_c, RpcIds.CupMyMatch, request, WriteCall, ct);
        }

        public Task<CupReadyResponse> ReadyAsync(CupReadyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupReadyRequest();
            return RpcInvoke.CallAsync<CupReadyResponse>(_c, RpcIds.CupReady, request, WriteCall, ct);
        }

        public Task<CupSignupResponse> SignupAsync(CupSignupRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupSignupRequest();
            return RpcInvoke.CallAsync<CupSignupResponse>(_c, RpcIds.CupSignup, request, WriteCall, ct);
        }

        public Task<CupStartResponse> StartAsync(CupStartRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupStartRequest();
            return RpcInvoke.CallAsync<CupStartResponse>(_c, RpcIds.CupStart, request, WriteCall, ct);
        }

        public Task<CupWithdrawResponse> WithdrawAsync(CupWithdrawRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new CupWithdrawRequest();
            return RpcInvoke.CallAsync<CupWithdrawResponse>(_c, RpcIds.CupWithdraw, request, WriteCall, ct);
        }
    }

    public sealed partial class DevkitRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public DevkitRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<DevkitErrorCatalogResponse> ErrorCatalogAsync(DevkitErrorCatalogRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new DevkitErrorCatalogRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<DevkitErrorCatalogResponse>(_c, RpcIds.DevkitErrorCatalog, request, ReadCall, ct);
        }

        public Task<DevkitRpcSchemaResponse> RpcSchemaAsync(DevkitRpcSchemaRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new DevkitRpcSchemaRequest();
            return RpcInvoke.CallAsync<DevkitRpcSchemaResponse>(_c, RpcIds.DevkitRpcSchema, request, ReadCall, ct);
        }
    }

    public sealed partial class EconomyRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public EconomyRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<BaseAvatarResponse> BaseAvatarAsync(BaseAvatarRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAvatarRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseAvatarResponse>(_c, RpcIds.BaseAvatar, request, ReadCall, ct);
        }

        public Task<BaseAvatarGetResponse> BaseAvatarGetAsync(BaseAvatarGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAvatarGetRequest();
            return RpcInvoke.CallAsync<BaseAvatarGetResponse>(_c, RpcIds.BaseAvatarGet, request, ReadCall, ct);
        }

        public Task<BaseAvatarSaveResponse> BaseAvatarSaveAsync(BaseAvatarSaveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAvatarSaveRequest();
            return RpcInvoke.CallAsync<BaseAvatarSaveResponse>(_c, RpcIds.BaseAvatarSave, request, WriteCall, ct);
        }

        public Task<EconomyAchievementClaimResponse> AchievementClaimAsync(EconomyAchievementClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAchievementClaimRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAchievementClaimResponse>(_c, RpcIds.EconomyAchievementClaim, request, WriteCall, ct);
        }

        public Task<EconomyAchievementsResponse> AchievementsAsync(EconomyAchievementsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAchievementsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAchievementsResponse>(_c, RpcIds.EconomyAchievements, request, ReadCall, ct);
        }

        public Task<EconomyAchievementsProfileResponse> AchievementsProfileAsync(EconomyAchievementsProfileRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAchievementsProfileRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAchievementsProfileResponse>(_c, RpcIds.EconomyAchievementsProfile, request, ReadCall, ct);
        }

        public Task<EconomyAvatarBuyResponse> AvatarBuyAsync(EconomyAvatarBuyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarBuyRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarBuyResponse>(_c, RpcIds.EconomyAvatarBuy, request, WriteCall, ct);
        }

        public Task<EconomyAvatarCatalogResponse> AvatarCatalogAsync(EconomyAvatarCatalogRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarCatalogRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarCatalogResponse>(_c, RpcIds.EconomyAvatarCatalog, request, ReadCall, ct);
        }

        public Task<EconomyAvatarCreateResponse> AvatarCreateAsync(EconomyAvatarCreateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarCreateRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarCreateResponse>(_c, RpcIds.EconomyAvatarCreate, request, WriteCall, ct);
        }

        public Task<EconomyAvatarDeleteResponse> AvatarDeleteAsync(EconomyAvatarDeleteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarDeleteRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarDeleteResponse>(_c, RpcIds.EconomyAvatarDelete, request, WriteCall, ct);
        }

        public Task<EconomyAvatarEquipResponse> AvatarEquipAsync(EconomyAvatarEquipRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarEquipRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarEquipResponse>(_c, RpcIds.EconomyAvatarEquip, request, WriteCall, ct);
        }

        public Task<EconomyAvatarListResponse> AvatarListAsync(EconomyAvatarListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarListResponse>(_c, RpcIds.EconomyAvatarList, request, ReadCall, ct);
        }

        public Task<EconomyAvatarLooksResponse> AvatarLooksAsync(EconomyAvatarLooksRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarLooksRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarLooksResponse>(_c, RpcIds.EconomyAvatarLooks, request, WriteCall, ct);
        }

        public Task<EconomyAvatarRenameResponse> AvatarRenameAsync(EconomyAvatarRenameRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarRenameRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarRenameResponse>(_c, RpcIds.EconomyAvatarRename, request, WriteCall, ct);
        }

        public Task<EconomyAvatarSetActiveResponse> AvatarSetActiveAsync(EconomyAvatarSetActiveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarSetActiveRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarSetActiveResponse>(_c, RpcIds.EconomyAvatarSetActive, request, WriteCall, ct);
        }

        public Task<EconomyAvatarUnequipResponse> AvatarUnequipAsync(EconomyAvatarUnequipRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyAvatarUnequipRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyAvatarUnequipResponse>(_c, RpcIds.EconomyAvatarUnequip, request, WriteCall, ct);
        }

        public Task<EconomyBalancesResponse> BalancesAsync(EconomyBalancesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyBalancesRequest();
            return RpcInvoke.CallAsync<EconomyBalancesResponse>(_c, RpcIds.EconomyBalances, request, ReadCall, ct);
        }

        public Task<EconomyBoostersResponse> BoostersAsync(EconomyBoostersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyBoostersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyBoostersResponse>(_c, RpcIds.EconomyBoosters, request, WriteCall, ct);
        }

        public Task<EconomyCatalogResponse> CatalogAsync(EconomyCatalogRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyCatalogRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyCatalogResponse>(_c, RpcIds.EconomyCatalog, request, ReadCall, ct);
        }

        public Task<EconomyChanceAckResponse> ChanceAckAsync(EconomyChanceAckRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceAckRequest();
            return RpcInvoke.CallAsync<EconomyChanceAckResponse>(_c, RpcIds.EconomyChanceAck, request, WriteCall, ct);
        }

        public Task<EconomyChanceCanPlayResponse> ChanceCanPlayAsync(EconomyChanceCanPlayRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceCanPlayRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyChanceCanPlayResponse>(_c, RpcIds.EconomyChanceCanPlay, request, WriteCall, ct);
        }

        public Task<EconomyChanceGameResponse> ChanceGameAsync(EconomyChanceGameRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceGameRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyChanceGameResponse>(_c, RpcIds.EconomyChanceGame, request, ReadCall, ct);
        }

        public Task<EconomyChanceGamesResponse> ChanceGamesAsync(EconomyChanceGamesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceGamesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyChanceGamesResponse>(_c, RpcIds.EconomyChanceGames, request, ReadCall, ct);
        }

        public Task<EconomyChanceHistoryResponse> ChanceHistoryAsync(EconomyChanceHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceHistoryRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyChanceHistoryResponse>(_c, RpcIds.EconomyChanceHistory, request, ReadCall, ct);
        }

        public Task<EconomyChanceNextPlayTimeResponse> ChanceNextPlayTimeAsync(EconomyChanceNextPlayTimeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceNextPlayTimeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyChanceNextPlayTimeResponse>(_c, RpcIds.EconomyChanceNextPlayTime, request, WriteCall, ct);
        }

        public Task<EconomyChancePlayResponse> ChancePlayAsync(EconomyChancePlayRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChancePlayRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyChancePlayResponse>(_c, RpcIds.EconomyChancePlay, request, WriteCall, ct);
        }

        public Task<EconomyChancePlayWithTicketResponse> ChancePlayWithTicketAsync(EconomyChancePlayWithTicketRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChancePlayWithTicketRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyChancePlayWithTicketResponse>(_c, RpcIds.EconomyChancePlayWithTicket, request, WriteCall, ct);
        }

        public Task<EconomyEventRecordResponse> EventRecordAsync(EconomyEventRecordRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyEventRecordRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyEventRecordResponse>(_c, RpcIds.EconomyEventRecord, request, WriteCall, ct);
        }

        public Task<EconomyEventsProgressResponse> EventsProgressAsync(EconomyEventsProgressRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyEventsProgressRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyEventsProgressResponse>(_c, RpcIds.EconomyEventsProgress, request, ReadCall, ct);
        }

        public Task<EconomyFriendGiftAcceptResponse> FriendGiftAcceptAsync(EconomyFriendGiftAcceptRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyFriendGiftAcceptRequest();
            return RpcInvoke.CallAsync<EconomyFriendGiftAcceptResponse>(_c, RpcIds.EconomyFriendGiftAccept, request, WriteCall, ct);
        }

        public Task<EconomyFriendGiftCancelResponse> FriendGiftCancelAsync(EconomyFriendGiftCancelRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyFriendGiftCancelRequest();
            return RpcInvoke.CallAsync<EconomyFriendGiftCancelResponse>(_c, RpcIds.EconomyFriendGiftCancel, request, WriteCall, ct);
        }

        public Task<EconomyFriendGiftDeclineResponse> FriendGiftDeclineAsync(EconomyFriendGiftDeclineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyFriendGiftDeclineRequest();
            return RpcInvoke.CallAsync<EconomyFriendGiftDeclineResponse>(_c, RpcIds.EconomyFriendGiftDecline, request, WriteCall, ct);
        }

        public Task<EconomyFriendGiftOptionsResponse> FriendGiftOptionsAsync(EconomyFriendGiftOptionsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyFriendGiftOptionsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyFriendGiftOptionsResponse>(_c, RpcIds.EconomyFriendGiftOptions, request, ReadCall, ct);
        }

        public Task<EconomyFriendGiftSendResponse> FriendGiftSendAsync(EconomyFriendGiftSendRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyFriendGiftSendRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyFriendGiftSendResponse>(_c, RpcIds.EconomyFriendGiftSend, request, WriteCall, ct);
        }

        public Task<EconomyFriendGiftsResponse> FriendGiftsAsync(EconomyFriendGiftsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyFriendGiftsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyFriendGiftsResponse>(_c, RpcIds.EconomyFriendGifts, request, ReadCall, ct);
        }

        public Task<EconomyGameResponse> GameAsync(EconomyGameRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameResponse>(_c, RpcIds.EconomyGame, request, ReadCall, ct);
        }

        public Task<EconomyGameActiveResponse> GameActiveAsync(EconomyGameActiveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameActiveRequest();
            return RpcInvoke.CallAsync<EconomyGameActiveResponse>(_c, RpcIds.EconomyGameActive, request, WriteCall, ct);
        }

        public Task<EconomyGameBotResponse> GameBotAsync(EconomyGameBotRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameBotRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameBotResponse>(_c, RpcIds.EconomyGameBot, request, WriteCall, ct);
        }

        public Task<EconomyGameFriendCancelResponse> GameFriendCancelAsync(EconomyGameFriendCancelRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameFriendCancelRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameFriendCancelResponse>(_c, RpcIds.EconomyGameFriendCancel, request, WriteCall, ct);
        }

        public Task<EconomyGameFriendCreateResponse> GameFriendCreateAsync(EconomyGameFriendCreateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameFriendCreateRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameFriendCreateResponse>(_c, RpcIds.EconomyGameFriendCreate, request, WriteCall, ct);
        }

        public Task<EconomyGameFriendDeclineResponse> GameFriendDeclineAsync(EconomyGameFriendDeclineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameFriendDeclineRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameFriendDeclineResponse>(_c, RpcIds.EconomyGameFriendDecline, request, WriteCall, ct);
        }

        public Task<EconomyGameFriendJoinResponse> GameFriendJoinAsync(EconomyGameFriendJoinRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameFriendJoinRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameFriendJoinResponse>(_c, RpcIds.EconomyGameFriendJoin, request, WriteCall, ct);
        }

        public Task<EconomyGameJoinResponse> GameJoinAsync(EconomyGameJoinRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameJoinRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameJoinResponse>(_c, RpcIds.EconomyGameJoin, request, WriteCall, ct);
        }

        public Task<EconomyGameQueueResponse> GameQueueAsync(EconomyGameQueueRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameQueueRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameQueueResponse>(_c, RpcIds.EconomyGameQueue, request, WriteCall, ct);
        }

        public Task<EconomyGameStatsResponse> GameStatsAsync(EconomyGameStatsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameStatsRequest();
            return RpcInvoke.CallAsync<EconomyGameStatsResponse>(_c, RpcIds.EconomyGameStats, request, ReadCall, ct);
        }

        public Task<EconomyGamesResponse> GamesAsync(EconomyGamesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGamesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGamesResponse>(_c, RpcIds.EconomyGames, request, ReadCall, ct);
        }

        public Task<EconomyGiftRedeemResponse> GiftRedeemAsync(EconomyGiftRedeemRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGiftRedeemRequest();
            return RpcInvoke.CallAsync<EconomyGiftRedeemResponse>(_c, RpcIds.EconomyGiftRedeem, request, WriteCall, ct);
        }

        public Task<EconomyInventoryResponse> InventoryAsync(EconomyInventoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyInventoryRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyInventoryResponse>(_c, RpcIds.EconomyInventory, request, ReadCall, ct);
        }

        public Task<EconomyItemBuyResponse> ItemBuyAsync(EconomyItemBuyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyItemBuyRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyItemBuyResponse>(_c, RpcIds.EconomyItemBuy, request, WriteCall, ct);
        }

        public Task<EconomyItemEquipResponse> ItemEquipAsync(EconomyItemEquipRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyItemEquipRequest();
            return RpcInvoke.CallAsync<EconomyItemEquipResponse>(_c, RpcIds.EconomyItemEquip, request, WriteCall, ct);
        }

        public Task<EconomyItemUnequipResponse> ItemUnequipAsync(EconomyItemUnequipRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyItemUnequipRequest();
            return RpcInvoke.CallAsync<EconomyItemUnequipResponse>(_c, RpcIds.EconomyItemUnequip, request, WriteCall, ct);
        }

        public Task<EconomyItemUnlockResponse> ItemUnlockAsync(EconomyItemUnlockRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyItemUnlockRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyItemUnlockResponse>(_c, RpcIds.EconomyItemUnlock, request, WriteCall, ct);
        }

        public Task<EconomyItemUpgradeResponse> ItemUpgradeAsync(EconomyItemUpgradeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyItemUpgradeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyItemUpgradeResponse>(_c, RpcIds.EconomyItemUpgrade, request, WriteCall, ct);
        }

        public Task<EconomyItemUseResponse> ItemUseAsync(EconomyItemUseRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyItemUseRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyItemUseResponse>(_c, RpcIds.EconomyItemUse, request, WriteCall, ct);
        }

        public Task<EconomyLevelsResponse> LevelsAsync(EconomyLevelsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyLevelsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyLevelsResponse>(_c, RpcIds.EconomyLevels, request, ReadCall, ct);
        }

        public Task<EconomyMetaRelationsResponse> MetaRelationsAsync(EconomyMetaRelationsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyMetaRelationsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyMetaRelationsResponse>(_c, RpcIds.EconomyMetaRelations, request, WriteCall, ct);
        }

        public Task<EconomyOfferBuyResponse> OfferBuyAsync(EconomyOfferBuyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyOfferBuyRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyOfferBuyResponse>(_c, RpcIds.EconomyOfferBuy, request, WriteCall, ct);
        }

        public Task<EconomyOfferSeenResponse> OfferSeenAsync(EconomyOfferSeenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyOfferSeenRequest();
            return RpcInvoke.CallAsync<EconomyOfferSeenResponse>(_c, RpcIds.EconomyOfferSeen, request, WriteCall, ct);
        }

        public Task<EconomyOffersResponse> OffersAsync(EconomyOffersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyOffersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyOffersResponse>(_c, RpcIds.EconomyOffers, request, ReadCall, ct);
        }

        public Task<EconomyOffersRerollResponse> OffersRerollAsync(EconomyOffersRerollRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyOffersRerollRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyOffersRerollResponse>(_c, RpcIds.EconomyOffersReroll, request, WriteCall, ct);
        }

        public Task<EconomyPaymentsMineResponse> PaymentsMineAsync(EconomyPaymentsMineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyPaymentsMineRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyPaymentsMineResponse>(_c, RpcIds.EconomyPaymentsMine, request, ReadCall, ct);
        }

        public Task<EconomyPlayerCardResponse> PlayerCardAsync(EconomyPlayerCardRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyPlayerCardRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyPlayerCardResponse>(_c, RpcIds.EconomyPlayerCard, request, WriteCall, ct);
        }

        public Task<EconomyPurchaseReviewResponse> PurchaseReviewAsync(EconomyPurchaseReviewRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyPurchaseReviewRequest();
            return RpcInvoke.CallAsync<EconomyPurchaseReviewResponse>(_c, RpcIds.EconomyPurchaseReview, request, WriteCall, ct);
        }

        public Task<EconomyPurchaseStartResponse> PurchaseStartAsync(EconomyPurchaseStartRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyPurchaseStartRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyPurchaseStartResponse>(_c, RpcIds.EconomyPurchaseStart, request, WriteCall, ct);
        }

        public Task<EconomyPurchaseStatusResponse> PurchaseStatusAsync(EconomyPurchaseStatusRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyPurchaseStatusRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyPurchaseStatusResponse>(_c, RpcIds.EconomyPurchaseStatus, request, ReadCall, ct);
        }

        public Task<EconomyPurchaseSubmitResponse> PurchaseSubmitAsync(EconomyPurchaseSubmitRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyPurchaseSubmitRequest();
            return RpcInvoke.CallAsync<EconomyPurchaseSubmitResponse>(_c, RpcIds.EconomyPurchaseSubmit, request, WriteCall, ct);
        }

        public Task<EconomyPurchasesMineResponse> PurchasesMineAsync(EconomyPurchasesMineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyPurchasesMineRequest();
            return RpcInvoke.CallAsync<EconomyPurchasesMineResponse>(_c, RpcIds.EconomyPurchasesMine, request, ReadCall, ct);
        }

        public Task<EconomyReferralEnterResponse> ReferralEnterAsync(EconomyReferralEnterRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyReferralEnterRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyReferralEnterResponse>(_c, RpcIds.EconomyReferralEnter, request, WriteCall, ct);
        }

        public Task<EconomyReferralMeResponse> ReferralMeAsync(EconomyReferralMeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyReferralMeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyReferralMeResponse>(_c, RpcIds.EconomyReferralMe, request, ReadCall, ct);
        }

        public Task<EconomyRegenRefillResponse> RegenRefillAsync(EconomyRegenRefillRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyRegenRefillRequest();
            return RpcInvoke.CallAsync<EconomyRegenRefillResponse>(_c, RpcIds.EconomyRegenRefill, request, WriteCall, ct);
        }

        public Task<EconomyRegenStateResponse> RegenStateAsync(EconomyRegenStateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyRegenStateRequest();
            return RpcInvoke.CallAsync<EconomyRegenStateResponse>(_c, RpcIds.EconomyRegenState, request, WriteCall, ct);
        }

        public Task<EconomyRewardClaimResponse> RewardClaimAsync(EconomyRewardClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyRewardClaimRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyRewardClaimResponse>(_c, RpcIds.EconomyRewardClaim, request, WriteCall, ct);
        }

        public Task<EconomyRewardsMineResponse> RewardsMineAsync(EconomyRewardsMineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyRewardsMineRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyRewardsMineResponse>(_c, RpcIds.EconomyRewardsMine, request, ReadCall, ct);
        }

        public Task<EconomyStoreConfigResponse> StoreConfigAsync(EconomyStoreConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyStoreConfigRequest();
            return RpcInvoke.CallAsync<EconomyStoreConfigResponse>(_c, RpcIds.EconomyStoreConfig, request, ReadCall, ct);
        }

        public Task<EconomyStreaksResponse> StreaksAsync(EconomyStreaksRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyStreaksRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyStreaksResponse>(_c, RpcIds.EconomyStreaks, request, ReadCall, ct);
        }

        public Task<EconomyTaskClaimResponse> TaskClaimAsync(EconomyTaskClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyTaskClaimRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyTaskClaimResponse>(_c, RpcIds.EconomyTaskClaim, request, WriteCall, ct);
        }

        public Task<EconomyTaskGroupCurrentResponse> TaskGroupCurrentAsync(EconomyTaskGroupCurrentRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyTaskGroupCurrentRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyTaskGroupCurrentResponse>(_c, RpcIds.EconomyTaskGroupCurrent, request, ReadCall, ct);
        }

        public Task<EconomyTaskGroupNextResponse> TaskGroupNextAsync(EconomyTaskGroupNextRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyTaskGroupNextRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyTaskGroupNextResponse>(_c, RpcIds.EconomyTaskGroupNext, request, WriteCall, ct);
        }

        public Task<EconomyTasksListResponse> TasksListAsync(EconomyTasksListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyTasksListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyTasksListResponse>(_c, RpcIds.EconomyTasksList, request, ReadCall, ct);
        }
    }

    public sealed partial class FlickkickRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public FlickkickRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<FlickkickBotMatchResponse> BotMatchAsync(FlickkickBotMatchRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new FlickkickBotMatchRequest();
            return RpcInvoke.CallAsync<FlickkickBotMatchResponse>(_c, RpcIds.FlickkickBotMatch, request, WriteCall, ct);
        }

        public Task<FlickkickConfigResponse> ConfigAsync(FlickkickConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new FlickkickConfigRequest();
            return RpcInvoke.CallAsync<FlickkickConfigResponse>(_c, RpcIds.FlickkickConfig, request, ReadCall, ct);
        }

        public Task<FlickkickFormationsResponse> FormationsAsync(FlickkickFormationsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new FlickkickFormationsRequest();
            return RpcInvoke.CallAsync<FlickkickFormationsResponse>(_c, RpcIds.FlickkickFormations, request, WriteCall, ct);
        }

        public Task<FlickkickFriendCancelResponse> FriendCancelAsync(FlickkickFriendCancelRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new FlickkickFriendCancelRequest();
            return RpcInvoke.CallAsync<FlickkickFriendCancelResponse>(_c, RpcIds.FlickkickFriendCancel, request, WriteCall, ct);
        }

        public Task<FlickkickFriendCreateResponse> FriendCreateAsync(FlickkickFriendCreateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new FlickkickFriendCreateRequest();
            return RpcInvoke.CallAsync<FlickkickFriendCreateResponse>(_c, RpcIds.FlickkickFriendCreate, request, WriteCall, ct);
        }

        public Task<FlickkickFriendJoinResponse> FriendJoinAsync(FlickkickFriendJoinRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new FlickkickFriendJoinRequest();
            return RpcInvoke.CallAsync<FlickkickFriendJoinResponse>(_c, RpcIds.FlickkickFriendJoin, request, WriteCall, ct);
        }
    }

    public sealed partial class InsightsRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public InsightsRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<InsightsConfigResponse> ConfigAsync(InsightsConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new InsightsConfigRequest();
            return RpcInvoke.CallAsync<InsightsConfigResponse>(_c, RpcIds.InsightsConfig, request, ReadCall, ct);
        }

        public Task<InsightsHeatmapResponse> HeatmapAsync(InsightsHeatmapRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new InsightsHeatmapRequest();
            return RpcInvoke.CallAsync<InsightsHeatmapResponse>(_c, RpcIds.InsightsHeatmap, request, WriteCall, ct);
        }

        public Task<InsightsSendResponse> SendAsync(InsightsSendRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new InsightsSendRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<InsightsSendResponse>(_c, RpcIds.InsightsSend, request, WriteCall, ct);
        }

        public Task<InsightsSessionResponse> SessionAsync(InsightsSessionRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new InsightsSessionRequest();
            return RpcInvoke.CallAsync<InsightsSessionResponse>(_c, RpcIds.InsightsSession, request, WriteCall, ct);
        }
    }

    public sealed partial class InventoryxRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public InventoryxRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<InventoryxItemsResponse> ItemsAsync(InventoryxItemsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new InventoryxItemsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<InventoryxItemsResponse>(_c, RpcIds.InventoryxItems, request, ReadCall, ct);
        }

        public Task<InventoryxUnlockResponse> UnlockAsync(InventoryxUnlockRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new InventoryxUnlockRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<InventoryxUnlockResponse>(_c, RpcIds.InventoryxUnlock, request, WriteCall, ct);
        }

        public Task<InventoryxUpgradeResponse> UpgradeAsync(InventoryxUpgradeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new InventoryxUpgradeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<InventoryxUpgradeResponse>(_c, RpcIds.InventoryxUpgrade, request, WriteCall, ct);
        }
    }

    public sealed partial class LeaderboardxRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public LeaderboardxRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<LeaderboardxBoardResponse> BoardAsync(LeaderboardxBoardRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LeaderboardxBoardRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<LeaderboardxBoardResponse>(_c, RpcIds.LeaderboardxBoard, request, ReadCall, ct);
        }

        public Task<LeaderboardxClaimResponse> ClaimAsync(LeaderboardxClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LeaderboardxClaimRequest();
            return RpcInvoke.CallAsync<LeaderboardxClaimResponse>(_c, RpcIds.LeaderboardxClaim, request, WriteCall, ct);
        }

        public Task<LeaderboardxHistoryResponse> HistoryAsync(LeaderboardxHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LeaderboardxHistoryRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<LeaderboardxHistoryResponse>(_c, RpcIds.LeaderboardxHistory, request, ReadCall, ct);
        }

        public Task<LeaderboardxListResponse> ListAsync(LeaderboardxListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LeaderboardxListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<LeaderboardxListResponse>(_c, RpcIds.LeaderboardxList, request, ReadCall, ct);
        }

        public Task<LeaderboardxSubmitResponse> SubmitAsync(LeaderboardxSubmitRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LeaderboardxSubmitRequest();
            return RpcInvoke.CallAsync<LeaderboardxSubmitResponse>(_c, RpcIds.LeaderboardxSubmit, request, WriteCall, ct);
        }

        public Task<LeaderboardxWinnersResponse> WinnersAsync(LeaderboardxWinnersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LeaderboardxWinnersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<LeaderboardxWinnersResponse>(_c, RpcIds.LeaderboardxWinners, request, ReadCall, ct);
        }
    }

    public sealed partial class LedgerRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public LedgerRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<LedgerKindsResponse> KindsAsync(LedgerKindsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LedgerKindsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<LedgerKindsResponse>(_c, RpcIds.LedgerKinds, request, ReadCall, ct);
        }

        public Task<LedgerListResponse> ListAsync(LedgerListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new LedgerListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<LedgerListResponse>(_c, RpcIds.LedgerList, request, ReadCall, ct);
        }
    }

    public sealed partial class PpRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public PpRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<PpLocalStateResponse> LocalStateAsync(PpLocalStateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PpLocalStateRequest();
            return RpcInvoke.CallAsync<PpLocalStateResponse>(_c, RpcIds.PpLocalState, request, WriteCall, ct);
        }
    }

    public sealed partial class PredictionRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public PredictionRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<PredictionAnswerUpdateResponse> AnswerUpdateAsync(PredictionAnswerUpdateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionAnswerUpdateRequest();
            return RpcInvoke.CallAsync<PredictionAnswerUpdateResponse>(_c, RpcIds.PredictionAnswerUpdate, request, WriteCall, ct);
        }

        public Task<PredictionConfigResponse> ConfigAsync(PredictionConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionConfigRequest();
            return RpcInvoke.CallAsync<PredictionConfigResponse>(_c, RpcIds.PredictionConfig, request, ReadCall, ct);
        }

        public Task<PredictionEventResponse> EventAsync(PredictionEventRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionEventRequest();
            return RpcInvoke.CallAsync<PredictionEventResponse>(_c, RpcIds.PredictionEvent, request, WriteCall, ct);
        }

        public Task<PredictionEventsResponse> EventsAsync(PredictionEventsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionEventsRequest();
            return RpcInvoke.CallAsync<PredictionEventsResponse>(_c, RpcIds.PredictionEvents, request, WriteCall, ct);
        }

        public Task<PredictionHistoryResponse> HistoryAsync(PredictionHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionHistoryRequest();
            return RpcInvoke.CallAsync<PredictionHistoryResponse>(_c, RpcIds.PredictionHistory, request, ReadCall, ct);
        }

        public Task<PredictionLeaderboardResponse> LeaderboardAsync(PredictionLeaderboardRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionLeaderboardRequest();
            return RpcInvoke.CallAsync<PredictionLeaderboardResponse>(_c, RpcIds.PredictionLeaderboard, request, WriteCall, ct);
        }

        public Task<PredictionLeagueResponse> LeagueAsync(PredictionLeagueRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionLeagueRequest();
            return RpcInvoke.CallAsync<PredictionLeagueResponse>(_c, RpcIds.PredictionLeague, request, WriteCall, ct);
        }

        public Task<PredictionLeaguesResponse> LeaguesAsync(PredictionLeaguesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionLeaguesRequest();
            return RpcInvoke.CallAsync<PredictionLeaguesResponse>(_c, RpcIds.PredictionLeagues, request, WriteCall, ct);
        }

        public Task<PredictionMyAnswersResponse> MyAnswersAsync(PredictionMyAnswersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionMyAnswersRequest();
            return RpcInvoke.CallAsync<PredictionMyAnswersResponse>(_c, RpcIds.PredictionMyAnswers, request, WriteCall, ct);
        }

        public Task<PredictionMyStatsResponse> MyStatsAsync(PredictionMyStatsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionMyStatsRequest();
            return RpcInvoke.CallAsync<PredictionMyStatsResponse>(_c, RpcIds.PredictionMyStats, request, ReadCall, ct);
        }

        public Task<PredictionQuestionEventsResponse> QuestionEventsAsync(PredictionQuestionEventsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionQuestionEventsRequest();
            return RpcInvoke.CallAsync<PredictionQuestionEventsResponse>(_c, RpcIds.PredictionQuestionEvents, request, WriteCall, ct);
        }

        public Task<PredictionResultsResponse> ResultsAsync(PredictionResultsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionResultsRequest();
            return RpcInvoke.CallAsync<PredictionResultsResponse>(_c, RpcIds.PredictionResults, request, WriteCall, ct);
        }

        public Task<PredictionSubmitResponse> SubmitAsync(PredictionSubmitRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PredictionSubmitRequest();
            return RpcInvoke.CallAsync<PredictionSubmitResponse>(_c, RpcIds.PredictionSubmit, request, WriteCall, ct);
        }
    }

    public sealed partial class PublicationRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public PublicationRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<PublicationBannerClickResponse> BannerClickAsync(PublicationBannerClickRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationBannerClickRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationBannerClickResponse>(_c, RpcIds.PublicationBannerClick, request, WriteCall, ct);
        }

        public Task<PublicationBannerViewResponse> BannerViewAsync(PublicationBannerViewRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationBannerViewRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationBannerViewResponse>(_c, RpcIds.PublicationBannerView, request, WriteCall, ct);
        }

        public Task<PublicationBannersResponse> BannersAsync(PublicationBannersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationBannersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationBannersResponse>(_c, RpcIds.PublicationBanners, request, ReadCall, ct);
        }

        public Task<PublicationFaqListResponse> FaqListAsync(PublicationFaqListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationFaqListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationFaqListResponse>(_c, RpcIds.PublicationFaqList, request, ReadCall, ct);
        }

        public Task<PublicationInboxResponse> InboxAsync(PublicationInboxRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationInboxRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationInboxResponse>(_c, RpcIds.PublicationInbox, request, ReadCall, ct);
        }

        public Task<PublicationInboxClaimResponse> InboxClaimAsync(PublicationInboxClaimRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationInboxClaimRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationInboxClaimResponse>(_c, RpcIds.PublicationInboxClaim, request, WriteCall, ct);
        }

        public Task<PublicationInboxSeenResponse> InboxSeenAsync(PublicationInboxSeenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationInboxSeenRequest();
            return RpcInvoke.CallAsync<PublicationInboxSeenResponse>(_c, RpcIds.PublicationInboxSeen, request, WriteCall, ct);
        }

        public Task<PublicationNewsBySlugResponse> NewsBySlugAsync(PublicationNewsBySlugRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsBySlugRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationNewsBySlugResponse>(_c, RpcIds.PublicationNewsBySlug, request, ReadCall, ct);
        }

        public Task<PublicationNewsCommentResponse> NewsCommentAsync(PublicationNewsCommentRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsCommentRequest();
            return RpcInvoke.CallAsync<PublicationNewsCommentResponse>(_c, RpcIds.PublicationNewsComment, request, WriteCall, ct);
        }

        public Task<PublicationNewsCommentDeleteResponse> NewsCommentDeleteAsync(PublicationNewsCommentDeleteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsCommentDeleteRequest();
            return RpcInvoke.CallAsync<PublicationNewsCommentDeleteResponse>(_c, RpcIds.PublicationNewsCommentDelete, request, WriteCall, ct);
        }

        public Task<PublicationNewsCommentsResponse> NewsCommentsAsync(PublicationNewsCommentsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsCommentsRequest();
            return RpcInvoke.CallAsync<PublicationNewsCommentsResponse>(_c, RpcIds.PublicationNewsComments, request, ReadCall, ct);
        }

        public Task<PublicationNewsGetResponse> NewsGetAsync(PublicationNewsGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsGetRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationNewsGetResponse>(_c, RpcIds.PublicationNewsGet, request, ReadCall, ct);
        }

        public Task<PublicationNewsListResponse> NewsListAsync(PublicationNewsListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationNewsListResponse>(_c, RpcIds.PublicationNewsList, request, ReadCall, ct);
        }

        public Task<PublicationNewsReactResponse> NewsReactAsync(PublicationNewsReactRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsReactRequest();
            return RpcInvoke.CallAsync<PublicationNewsReactResponse>(_c, RpcIds.PublicationNewsReact, request, WriteCall, ct);
        }

        public Task<PublicationNewsReactionTypesResponse> NewsReactionTypesAsync(PublicationNewsReactionTypesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsReactionTypesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationNewsReactionTypesResponse>(_c, RpcIds.PublicationNewsReactionTypes, request, ReadCall, ct);
        }

        public Task<PublicationNewsSeenResponse> NewsSeenAsync(PublicationNewsSeenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsSeenRequest();
            return RpcInvoke.CallAsync<PublicationNewsSeenResponse>(_c, RpcIds.PublicationNewsSeen, request, WriteCall, ct);
        }

        public Task<PublicationNewsUnreadResponse> NewsUnreadAsync(PublicationNewsUnreadRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNewsUnreadRequest();
            return RpcInvoke.CallAsync<PublicationNewsUnreadResponse>(_c, RpcIds.PublicationNewsUnread, request, ReadCall, ct);
        }

        public Task<PublicationNotificationOpenedResponse> NotificationOpenedAsync(PublicationNotificationOpenedRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNotificationOpenedRequest();
            return RpcInvoke.CallAsync<PublicationNotificationOpenedResponse>(_c, RpcIds.PublicationNotificationOpened, request, WriteCall, ct);
        }

        public Task<PublicationNotifyPrefsResponse> NotifyPrefsAsync(PublicationNotifyPrefsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNotifyPrefsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationNotifyPrefsResponse>(_c, RpcIds.PublicationNotifyPrefs, request, ReadCall, ct);
        }

        public Task<PublicationNotifyPrefsSetResponse> NotifyPrefsSetAsync(PublicationNotifyPrefsSetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationNotifyPrefsSetRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationNotifyPrefsSetResponse>(_c, RpcIds.PublicationNotifyPrefsSet, request, WriteCall, ct);
        }

        public Task<PublicationOtpRequestResponse> OtpRequestAsync(PublicationOtpRequestRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationOtpRequestRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationOtpRequestResponse>(_c, RpcIds.PublicationOtpRequest, request, WriteCall, ct);
        }

        public Task<PublicationOtpVerifyResponse> OtpVerifyAsync(PublicationOtpVerifyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationOtpVerifyRequest();
            return RpcInvoke.CallAsync<PublicationOtpVerifyResponse>(_c, RpcIds.PublicationOtpVerify, request, WriteCall, ct);
        }

        public Task<PublicationPhoneResponse> PhoneAsync(PublicationPhoneRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationPhoneRequest();
            return RpcInvoke.CallAsync<PublicationPhoneResponse>(_c, RpcIds.PublicationPhone, request, ReadCall, ct);
        }

        public Task<PublicationPushDevicesResponse> PushDevicesAsync(PublicationPushDevicesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationPushDevicesRequest();
            return RpcInvoke.CallAsync<PublicationPushDevicesResponse>(_c, RpcIds.PublicationPushDevices, request, ReadCall, ct);
        }

        public Task<PublicationPushRegisterResponse> PushRegisterAsync(PublicationPushRegisterRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationPushRegisterRequest();
            return RpcInvoke.CallAsync<PublicationPushRegisterResponse>(_c, RpcIds.PublicationPushRegister, request, WriteCall, ct);
        }

        public Task<PublicationPushUnregisterResponse> PushUnregisterAsync(PublicationPushUnregisterRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationPushUnregisterRequest();
            return RpcInvoke.CallAsync<PublicationPushUnregisterResponse>(_c, RpcIds.PublicationPushUnregister, request, WriteCall, ct);
        }

        public Task<PublicationSponsorClickResponse> SponsorClickAsync(PublicationSponsorClickRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationSponsorClickRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationSponsorClickResponse>(_c, RpcIds.PublicationSponsorClick, request, WriteCall, ct);
        }

        public Task<PublicationSponsorViewResponse> SponsorViewAsync(PublicationSponsorViewRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationSponsorViewRequest();
            return RpcInvoke.CallAsync<PublicationSponsorViewResponse>(_c, RpcIds.PublicationSponsorView, request, WriteCall, ct);
        }

        public Task<PublicationSponsorsResponse> SponsorsAsync(PublicationSponsorsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new PublicationSponsorsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<PublicationSponsorsResponse>(_c, RpcIds.PublicationSponsors, request, ReadCall, ct);
        }
    }

    public sealed partial class QuizRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public QuizRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<QuizAnswerResponse> AnswerAsync(QuizAnswerRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizAnswerRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizAnswerResponse>(_c, RpcIds.QuizAnswer, request, WriteCall, ct);
        }

        public Task<QuizAnswerAllResponse> AnswerAllAsync(QuizAnswerAllRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizAnswerAllRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizAnswerAllResponse>(_c, RpcIds.QuizAnswerAll, request, WriteCall, ct);
        }

        public Task<QuizDuelAcceptResponse> DuelAcceptAsync(QuizDuelAcceptRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelAcceptRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelAcceptResponse>(_c, RpcIds.QuizDuelAccept, request, WriteCall, ct);
        }

        public Task<QuizDuelAnswerResponse> DuelAnswerAsync(QuizDuelAnswerRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelAnswerRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelAnswerResponse>(_c, RpcIds.QuizDuelAnswer, request, WriteCall, ct);
        }

        public Task<QuizDuelCategoriesResponse> DuelCategoriesAsync(QuizDuelCategoriesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelCategoriesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelCategoriesResponse>(_c, RpcIds.QuizDuelCategories, request, ReadCall, ct);
        }

        public Task<QuizDuelDeclineResponse> DuelDeclineAsync(QuizDuelDeclineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelDeclineRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelDeclineResponse>(_c, RpcIds.QuizDuelDecline, request, WriteCall, ct);
        }

        public Task<QuizDuelForfeitResponse> DuelForfeitAsync(QuizDuelForfeitRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelForfeitRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelForfeitResponse>(_c, RpcIds.QuizDuelForfeit, request, WriteCall, ct);
        }

        public Task<QuizDuelGetResponse> DuelGetAsync(QuizDuelGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelGetRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelGetResponse>(_c, RpcIds.QuizDuelGet, request, ReadCall, ct);
        }

        public Task<QuizDuelListResponse> DuelListAsync(QuizDuelListRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelListRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelListResponse>(_c, RpcIds.QuizDuelList, request, ReadCall, ct);
        }

        public Task<QuizDuelPickCategoryResponse> DuelPickCategoryAsync(QuizDuelPickCategoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelPickCategoryRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelPickCategoryResponse>(_c, RpcIds.QuizDuelPickCategory, request, WriteCall, ct);
        }

        public Task<QuizDuelQuestionResponse> DuelQuestionAsync(QuizDuelQuestionRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelQuestionRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelQuestionResponse>(_c, RpcIds.QuizDuelQuestion, request, WriteCall, ct);
        }

        public Task<QuizDuelStartResponse> DuelStartAsync(QuizDuelStartRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelStartRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizDuelStartResponse>(_c, RpcIds.QuizDuelStart, request, WriteCall, ct);
        }

        public Task<QuizDuelStatsResponse> DuelStatsAsync(QuizDuelStatsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizDuelStatsRequest();
            return RpcInvoke.CallAsync<QuizDuelStatsResponse>(_c, RpcIds.QuizDuelStats, request, ReadCall, ct);
        }

        public Task<QuizFinishResponse> FinishAsync(QuizFinishRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizFinishRequest();
            return RpcInvoke.CallAsync<QuizFinishResponse>(_c, RpcIds.QuizFinish, request, WriteCall, ct);
        }

        public Task<QuizHintBuyResponse> HintBuyAsync(QuizHintBuyRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizHintBuyRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizHintBuyResponse>(_c, RpcIds.QuizHintBuy, request, WriteCall, ct);
        }

        public Task<QuizMissionStartResponse> MissionStartAsync(QuizMissionStartRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizMissionStartRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizMissionStartResponse>(_c, RpcIds.QuizMissionStart, request, WriteCall, ct);
        }

        public Task<QuizMissionsResponse> MissionsAsync(QuizMissionsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizMissionsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizMissionsResponse>(_c, RpcIds.QuizMissions, request, WriteCall, ct);
        }

        public Task<QuizPackRandomResponse> PackRandomAsync(QuizPackRandomRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizPackRandomRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizPackRandomResponse>(_c, RpcIds.QuizPackRandom, request, WriteCall, ct);
        }

        public Task<QuizPacksResponse> PacksAsync(QuizPacksRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizPacksRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizPacksResponse>(_c, RpcIds.QuizPacks, request, WriteCall, ct);
        }

        public Task<QuizPlayResponse> PlayAsync(QuizPlayRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizPlayRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizPlayResponse>(_c, RpcIds.QuizPlay, request, WriteCall, ct);
        }

        public Task<QuizReportQuestionResponse> ReportQuestionAsync(QuizReportQuestionRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizReportQuestionRequest();
            return RpcInvoke.CallAsync<QuizReportQuestionResponse>(_c, RpcIds.QuizReportQuestion, request, WriteCall, ct);
        }

        public Task<QuizReportReasonsResponse> ReportReasonsAsync(QuizReportReasonsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizReportReasonsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizReportReasonsResponse>(_c, RpcIds.QuizReportReasons, request, WriteCall, ct);
        }

        public Task<QuizResultReportResponse> ResultReportAsync(QuizResultReportRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizResultReportRequest();
            return RpcInvoke.CallAsync<QuizResultReportResponse>(_c, RpcIds.QuizResultReport, request, WriteCall, ct);
        }

        public Task<QuizSessionResponse> SessionAsync(QuizSessionRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizSessionRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<QuizSessionResponse>(_c, RpcIds.QuizSession, request, WriteCall, ct);
        }

        public Task<QuizStatsResponse> StatsAsync(QuizStatsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new QuizStatsRequest();
            return RpcInvoke.CallAsync<QuizStatsResponse>(_c, RpcIds.QuizStats, request, ReadCall, ct);
        }
    }

    public sealed partial class ShopxRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public ShopxRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<ShopxPurchaseCheckResponse> PurchaseCheckAsync(ShopxPurchaseCheckRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ShopxPurchaseCheckRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ShopxPurchaseCheckResponse>(_c, RpcIds.ShopxPurchaseCheck, request, WriteCall, ct);
        }

        public Task<ShopxPurchaseRulesResponse> PurchaseRulesAsync(ShopxPurchaseRulesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new ShopxPurchaseRulesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<ShopxPurchaseRulesResponse>(_c, RpcIds.ShopxPurchaseRules, request, ReadCall, ct);
        }
    }

    public sealed partial class SocialRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public SocialRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<SocialAvatarResponse> AvatarAsync(SocialAvatarRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialAvatarRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialAvatarResponse>(_c, RpcIds.SocialAvatar, request, ReadCall, ct);
        }

        public Task<SocialCommentDeleteResponse> CommentDeleteAsync(SocialCommentDeleteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialCommentDeleteRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialCommentDeleteResponse>(_c, RpcIds.SocialCommentDelete, request, WriteCall, ct);
        }

        public Task<SocialCommentEditResponse> CommentEditAsync(SocialCommentEditRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialCommentEditRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialCommentEditResponse>(_c, RpcIds.SocialCommentEdit, request, WriteCall, ct);
        }

        public Task<SocialCommentPostResponse> CommentPostAsync(SocialCommentPostRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialCommentPostRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialCommentPostResponse>(_c, RpcIds.SocialCommentPost, request, WriteCall, ct);
        }

        public Task<SocialCommentReportResponse> CommentReportAsync(SocialCommentReportRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialCommentReportRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialCommentReportResponse>(_c, RpcIds.SocialCommentReport, request, WriteCall, ct);
        }

        public Task<SocialCommentsResponse> CommentsAsync(SocialCommentsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialCommentsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialCommentsResponse>(_c, RpcIds.SocialComments, request, ReadCall, ct);
        }

        public Task<SocialConfigResponse> ConfigAsync(SocialConfigRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialConfigRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialConfigResponse>(_c, RpcIds.SocialConfig, request, ReadCall, ct);
        }

        public Task<SocialFavoriteResponse> FavoriteAsync(SocialFavoriteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialFavoriteRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialFavoriteResponse>(_c, RpcIds.SocialFavorite, request, WriteCall, ct);
        }

        public Task<SocialFollowResponse> FollowAsync(SocialFollowRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialFollowRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialFollowResponse>(_c, RpcIds.SocialFollow, request, WriteCall, ct);
        }

        public Task<SocialFollowRequestsResponse> FollowRequestsAsync(SocialFollowRequestsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialFollowRequestsRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialFollowRequestsResponse>(_c, RpcIds.SocialFollowRequests, request, WriteCall, ct);
        }

        public Task<SocialFollowRespondResponse> FollowRespondAsync(SocialFollowRespondRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialFollowRespondRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialFollowRespondResponse>(_c, RpcIds.SocialFollowRespond, request, WriteCall, ct);
        }

        public Task<SocialFollowerRemoveResponse> FollowerRemoveAsync(SocialFollowerRemoveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialFollowerRemoveRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialFollowerRemoveResponse>(_c, RpcIds.SocialFollowerRemove, request, WriteCall, ct);
        }

        public Task<SocialFollowersResponse> FollowersAsync(SocialFollowersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialFollowersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialFollowersResponse>(_c, RpcIds.SocialFollowers, request, WriteCall, ct);
        }

        public Task<SocialFollowingResponse> FollowingAsync(SocialFollowingRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialFollowingRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialFollowingResponse>(_c, RpcIds.SocialFollowing, request, WriteCall, ct);
        }

        public Task<SocialMineResponse> MineAsync(SocialMineRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialMineRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialMineResponse>(_c, RpcIds.SocialMine, request, ReadCall, ct);
        }

        public Task<SocialPrivacyGetResponse> PrivacyGetAsync(SocialPrivacyGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialPrivacyGetRequest();
            return RpcInvoke.CallAsync<SocialPrivacyGetResponse>(_c, RpcIds.SocialPrivacyGet, request, ReadCall, ct);
        }

        public Task<SocialPrivacySetResponse> PrivacySetAsync(SocialPrivacySetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialPrivacySetRequest();
            return RpcInvoke.CallAsync<SocialPrivacySetResponse>(_c, RpcIds.SocialPrivacySet, request, WriteCall, ct);
        }

        public Task<SocialProfileResponse> ProfileAsync(SocialProfileRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialProfileRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialProfileResponse>(_c, RpcIds.SocialProfile, request, ReadCall, ct);
        }

        public Task<SocialRateResponse> RateAsync(SocialRateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialRateRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialRateResponse>(_c, RpcIds.SocialRate, request, WriteCall, ct);
        }

        public Task<SocialReactResponse> ReactAsync(SocialReactRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialReactRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialReactResponse>(_c, RpcIds.SocialReact, request, WriteCall, ct);
        }

        public Task<SocialSummaryResponse> SummaryAsync(SocialSummaryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialSummaryRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialSummaryResponse>(_c, RpcIds.SocialSummary, request, WriteCall, ct);
        }

        public Task<SocialUnfollowResponse> UnfollowAsync(SocialUnfollowRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SocialUnfollowRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SocialUnfollowResponse>(_c, RpcIds.SocialUnfollow, request, WriteCall, ct);
        }
    }

    public sealed partial class SoltanRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public SoltanRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<SoltanBootstrapResponse> BootstrapAsync(SoltanBootstrapRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanBootstrapRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SoltanBootstrapResponse>(_c, RpcIds.SoltanBootstrap, request, WriteCall, ct);
        }

        public Task<SoltanDailyStateResponse> DailyStateAsync(SoltanDailyStateRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanDailyStateRequest();
            return RpcInvoke.CallAsync<SoltanDailyStateResponse>(_c, RpcIds.SoltanDailyState, request, WriteCall, ct);
        }

        public Task<SoltanDuelHistoryResponse> DuelHistoryAsync(SoltanDuelHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanDuelHistoryRequest();
            return RpcInvoke.CallAsync<SoltanDuelHistoryResponse>(_c, RpcIds.SoltanDuelHistory, request, ReadCall, ct);
        }

        public Task<SoltanDuelInfoResponse> DuelInfoAsync(SoltanDuelInfoRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanDuelInfoRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<SoltanDuelInfoResponse>(_c, RpcIds.SoltanDuelInfo, request, ReadCall, ct);
        }

        public Task<SoltanHintResponse> HintAsync(SoltanHintRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanHintRequest();
            return RpcInvoke.CallAsync<SoltanHintResponse>(_c, RpcIds.SoltanHint, request, WriteCall, ct);
        }

        public Task<SoltanLevelCompleteResponse> LevelCompleteAsync(SoltanLevelCompleteRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanLevelCompleteRequest();
            return RpcInvoke.CallAsync<SoltanLevelCompleteResponse>(_c, RpcIds.SoltanLevelComplete, request, WriteCall, ct);
        }

        public Task<SoltanLevelStartResponse> LevelStartAsync(SoltanLevelStartRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanLevelStartRequest();
            return RpcInvoke.CallAsync<SoltanLevelStartResponse>(_c, RpcIds.SoltanLevelStart, request, WriteCall, ct);
        }

        public Task<SoltanMapSeenResponse> MapSeenAsync(SoltanMapSeenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanMapSeenRequest();
            return RpcInvoke.CallAsync<SoltanMapSeenResponse>(_c, RpcIds.SoltanMapSeen, request, WriteCall, ct);
        }

        public Task<SoltanPrefsResponse> PrefsAsync(SoltanPrefsRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanPrefsRequest();
            return RpcInvoke.CallAsync<SoltanPrefsResponse>(_c, RpcIds.SoltanPrefs, request, ReadCall, ct);
        }

        public Task<SoltanRocketResponse> RocketAsync(SoltanRocketRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new SoltanRocketRequest();
            return RpcInvoke.CallAsync<SoltanRocketResponse>(_c, RpcIds.SoltanRocket, request, WriteCall, ct);
        }
    }

    public sealed partial class TrophyRpcs
    {
        private static readonly RpcCallOptions ReadCall = new RpcCallOptions { ReadOnly = true };
        private static readonly RpcCallOptions WriteCall = new RpcCallOptions();
        private readonly IRpcCaller _c;

        public TrophyRpcs(IRpcCaller caller)
        {
            _c = caller;
        }

        public Task<TrophyHistoryResponse> HistoryAsync(TrophyHistoryRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new TrophyHistoryRequest();
            return RpcInvoke.CallAsync<TrophyHistoryResponse>(_c, RpcIds.TrophyHistory, request, ReadCall, ct);
        }

        public Task<TrophyLeaguesResponse> LeaguesAsync(TrophyLeaguesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new TrophyLeaguesRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<TrophyLeaguesResponse>(_c, RpcIds.TrophyLeagues, request, WriteCall, ct);
        }

        public Task<TrophyMeResponse> MeAsync(TrophyMeRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new TrophyMeRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<TrophyMeResponse>(_c, RpcIds.TrophyMe, request, ReadCall, ct);
        }

        public Task<TrophyPlayersResponse> PlayersAsync(TrophyPlayersRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new TrophyPlayersRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<TrophyPlayersResponse>(_c, RpcIds.TrophyPlayers, request, WriteCall, ct);
        }
    }

    public sealed class AccountMeRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class AccountMeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("avatarUrl")]
        public JToken AvatarUrl { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("deviceIds")]
        public List<string> DeviceIds { get; set; }

        [JsonProperty("displayName")]
        public JToken DisplayName { get; set; }

        [JsonProperty("hasEmail")]
        public bool? HasEmail { get; set; }

        [JsonProperty("id")]
        public JToken Id { get; set; }

        [JsonProperty("isGuest")]
        public bool? IsGuest { get; set; }

        [JsonProperty("lang")]
        public JToken Lang { get; set; }

        [JsonProperty("linked")]
        public List<string> Linked { get; set; }

        [JsonProperty("location")]
        public JToken Location { get; set; }

        [JsonProperty("mute")]
        public JToken Mute { get; set; }

        [JsonProperty("pendingPhone")]
        public JToken PendingPhone { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("phoneChange")]
        public PhoneChangeData PhoneChange { get; set; }

        [JsonProperty("phoneMasked")]
        public bool? PhoneMasked { get; set; }

        [JsonProperty("phoneVerified")]
        public bool? PhoneVerified { get; set; }

        [JsonProperty("phoneVerifiedAt")]
        public string PhoneVerifiedAt { get; set; }

        [JsonProperty("suspension")]
        public JToken Suspension { get; set; }

        [JsonProperty("timezone")]
        public JToken Timezone { get; set; }

        [JsonProperty("username")]
        public JToken Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PhoneChangeData
        {
            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("nextAt")]
            public string NextAt { get; set; }

            [JsonProperty("requireOldCode")]
            public JToken RequireOldCode { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class AccountPasswordChangeRequest
    {
        [JsonProperty("currentPassword")]
        public string CurrentPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }

    public sealed class AccountPasswordChangeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("ok")]
        public bool? Ok { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPasswordForgotRequest
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public sealed class AccountPasswordForgotResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("codeLength")]
        public JToken CodeLength { get; set; }

        [JsonProperty("expiresIn")]
        public JToken ExpiresIn { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("requestId")]
        public JToken RequestId { get; set; }

        [JsonProperty("resendAfter")]
        public JToken ResendAfter { get; set; }

        [JsonProperty("sandbox")]
        public JToken Sandbox { get; set; }

        [JsonProperty("sent")]
        public bool? Sent { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPasswordLoginRequest
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public sealed class AccountPasswordLoginResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("loginKey")]
        public string LoginKey { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("token")]
        public JToken Token { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPasswordResetRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public sealed class AccountPasswordResetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("loginKey")]
        public string LoginKey { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("token")]
        public JToken Token { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPasswordSetRequest
    {
        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }

    public sealed class AccountPasswordSetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("ok")]
        public bool? Ok { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPhoneCancelRequest
    {
    }

    public sealed class AccountPhoneCancelResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canceled")]
        public bool? Canceled { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPhoneRecoverRequestRequest
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public sealed class AccountPhoneRecoverRequestResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("codeLength")]
        public JToken CodeLength { get; set; }

        [JsonProperty("deviceMode")]
        public JToken DeviceMode { get; set; }

        [JsonProperty("expiresIn")]
        public JToken ExpiresIn { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("requestId")]
        public JToken RequestId { get; set; }

        [JsonProperty("resendAfter")]
        public JToken ResendAfter { get; set; }

        [JsonProperty("sandbox")]
        public JToken Sandbox { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPhoneRecoverVerifyRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class AccountPhoneRecoverVerifyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("abandoned")]
        public JToken Abandoned { get; set; }

        [JsonProperty("deviceAction")]
        public string DeviceAction { get; set; }

        [JsonProperty("devicesMoved")]
        public List<string> DevicesMoved { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("loginKey")]
        public string LoginKey { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("token")]
        public JToken Token { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPhoneRequestRequest
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public sealed class AccountPhoneRequestResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("codeLength")]
        public JToken CodeLength { get; set; }

        [JsonProperty("expiresIn")]
        public JToken ExpiresIn { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("requestId")]
        public JToken RequestId { get; set; }

        [JsonProperty("resendAfter")]
        public JToken ResendAfter { get; set; }

        [JsonProperty("sandbox")]
        public JToken Sandbox { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountPhoneVerifyRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class AccountPhoneVerifyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("codeLength")]
        public JToken CodeLength { get; set; }

        [JsonProperty("done")]
        public bool? Done { get; set; }

        [JsonProperty("expiresIn")]
        public JToken ExpiresIn { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("profile")]
        public ProfileData Profile { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("requestId")]
        public JToken RequestId { get; set; }

        [JsonProperty("resendAfter")]
        public JToken ResendAfter { get; set; }

        [JsonProperty("sandbox")]
        public JToken Sandbox { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ProfileData
        {
            [JsonProperty("avatarUrl")]
            public JToken AvatarUrl { get; set; }

            [JsonProperty("createdAt")]
            public JToken CreatedAt { get; set; }

            [JsonProperty("deviceId")]
            public string DeviceId { get; set; }

            [JsonProperty("deviceIds")]
            public List<string> DeviceIds { get; set; }

            [JsonProperty("displayName")]
            public JToken DisplayName { get; set; }

            [JsonProperty("hasEmail")]
            public bool? HasEmail { get; set; }

            [JsonProperty("id")]
            public JToken Id { get; set; }

            [JsonProperty("isGuest")]
            public JToken IsGuest { get; set; }

            [JsonProperty("lang")]
            public JToken Lang { get; set; }

            [JsonProperty("linked")]
            public JToken Linked { get; set; }

            [JsonProperty("location")]
            public JToken Location { get; set; }

            [JsonProperty("mute")]
            public JToken Mute { get; set; }

            [JsonProperty("pendingPhone")]
            public JToken PendingPhone { get; set; }

            [JsonProperty("phone")]
            public JToken Phone { get; set; }

            [JsonProperty("phoneChange")]
            public PhoneChangeData PhoneChange { get; set; }

            [JsonProperty("phoneMasked")]
            public bool? PhoneMasked { get; set; }

            [JsonProperty("phoneVerified")]
            public bool? PhoneVerified { get; set; }

            [JsonProperty("phoneVerifiedAt")]
            public JToken PhoneVerifiedAt { get; set; }

            [JsonProperty("suspension")]
            public JToken Suspension { get; set; }

            [JsonProperty("timezone")]
            public JToken Timezone { get; set; }

            [JsonProperty("username")]
            public JToken Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PhoneChangeData
            {
                [JsonProperty("enabled")]
                public JToken Enabled { get; set; }

                [JsonProperty("nextAt")]
                public JToken NextAt { get; set; }

                [JsonProperty("requireOldCode")]
                public JToken RequireOldCode { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class AccountRulesRequest
    {
    }

    public sealed class AccountRulesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("displayNameMax")]
        public JToken DisplayNameMax { get; set; }

        [JsonProperty("passwordDigit")]
        public JToken PasswordDigit { get; set; }

        [JsonProperty("passwordLetter")]
        public JToken PasswordLetter { get; set; }

        [JsonProperty("passwordMin")]
        public JToken PasswordMin { get; set; }

        [JsonProperty("usernameCharset")]
        public JToken UsernameCharset { get; set; }

        [JsonProperty("usernameMax")]
        public JToken UsernameMax { get; set; }

        [JsonProperty("usernameMin")]
        public JToken UsernameMin { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AccountUsernameCheckRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class AccountUsernameCheckResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public JToken Code { get; set; }

        [JsonProperty("ok")]
        public bool? Ok { get; set; }

        [JsonProperty("reason")]
        public JToken Reason { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class AnalyticsConfigRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class AnalyticsConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("batchesPerMinute")]
        public JToken BatchesPerMinute { get; set; }

        [JsonProperty("claimMode")]
        public JToken ClaimMode { get; set; }

        [JsonProperty("day")]
        public JToken Day { get; set; }

        [JsonProperty("events")]
        public List<EventsItem> Events { get; set; }

        [JsonProperty("eventsPerMinute")]
        public JToken EventsPerMinute { get; set; }

        [JsonProperty("maxBatch")]
        public JToken MaxBatch { get; set; }

        [JsonProperty("maxFields")]
        public JToken MaxFields { get; set; }

        [JsonProperty("maxStringLength")]
        public JToken MaxStringLength { get; set; }

        [JsonProperty("notificationCode")]
        public JToken NotificationCode { get; set; }

        [JsonProperty("sendIntervalSeconds")]
        public JToken SendIntervalSeconds { get; set; }

        [JsonProperty("stats")]
        public List<StatsItem> Stats { get; set; }

        [JsonProperty("thresholds")]
        public JObject Thresholds { get; set; }

        [JsonProperty("typed")]
        public TypedData Typed { get; set; }

        [JsonProperty("unknownEvents")]
        public JToken UnknownEvents { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class EventsItem
        {
            [JsonProperty("fields")]
            public List<JToken> Fields { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class StatsItem
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("period")]
            public string Period { get; set; }

            [JsonProperty("sendIntervalSeconds")]
            public long? SendIntervalSeconds { get; set; }

            [JsonProperty("splitBy")]
            public List<string> SplitBy { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class TypedData
        {
            [JsonProperty("contextKeys")]
            public List<ContextKeysItem> ContextKeys { get; set; }

            [JsonProperty("designRoots")]
            public List<DesignRootsItem> DesignRoots { get; set; }

            [JsonProperty("dimensions")]
            public List<DimensionsItem> Dimensions { get; set; }

            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("maxContextKeys")]
            public JToken MaxContextKeys { get; set; }

            [JsonProperty("maxDimensions")]
            public JToken MaxDimensions { get; set; }

            [JsonProperty("resourceCurrencies")]
            public List<string> ResourceCurrencies { get; set; }

            [JsonProperty("resourceItemTypes")]
            public List<string> ResourceItemTypes { get; set; }

            [JsonProperty("sessionTimeoutSeconds")]
            public JToken SessionTimeoutSeconds { get; set; }

            [JsonProperty("unknownContext")]
            public JToken UnknownContext { get; set; }

            [JsonProperty("unknownDesign")]
            public JToken UnknownDesign { get; set; }

            [JsonProperty("unknownDimension")]
            public JToken UnknownDimension { get; set; }

            [JsonProperty("unknownResource")]
            public JToken UnknownResource { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ContextKeysItem
            {
                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("values")]
                public List<string> Values { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class DesignRootsItem
            {
                [JsonProperty("levels")]
                public List<LevelsItem> Levels { get; set; }

                [JsonProperty("root")]
                public string Root { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class LevelsItem
                {
                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonProperty("values")]
                    public List<string> Values { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class DimensionsItem
            {
                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("values")]
                public List<string> Values { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class AnalyticsStatsRequest
    {
        [JsonProperty("keys")]
        public List<string> Keys { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class AnalyticsStatsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("day")]
        public JToken Day { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("best")]
            public double? Best { get; set; }

            [JsonProperty("current")]
            public double? Current { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("period")]
            public string Period { get; set; }

            [JsonProperty("splitBy")]
            public List<string> SplitBy { get; set; }

            [JsonProperty("tags")]
            public List<TagsItem> Tags { get; set; }

            [JsonProperty("total")]
            public double? Total { get; set; }

            [JsonProperty("updatedAt")]
            public string UpdatedAt { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class TagsItem
            {
                [JsonProperty("best")]
                public double? Best { get; set; }

                [JsonProperty("current")]
                public double? Current { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("label")]
                public string Label { get; set; }

                [JsonProperty("tag")]
                public string Tag { get; set; }

                [JsonProperty("total")]
                public double? Total { get; set; }

                [JsonProperty("value")]
                public double? Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class AnalyticsTrackRequest
    {
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("batchId")]
        public string BatchId { get; set; }

        [JsonProperty("context")]
        public JObject Context { get; set; }

        [JsonProperty("device")]
        public DeviceData Device { get; set; }

        [JsonProperty("dimensions")]
        public JObject Dimensions { get; set; }

        [JsonProperty("events")]
        public List<EventsItem> Events { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("session")]
        public SessionData Session { get; set; }

        public sealed class DeviceData
        {
            [JsonProperty("build")]
            public string Build { get; set; }

            [JsonProperty("manufacturer")]
            public string Manufacturer { get; set; }

            [JsonProperty("model")]
            public string Model { get; set; }

            [JsonProperty("os")]
            public string Os { get; set; }

            [JsonProperty("platform")]
            public string Platform { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class EventsItem
        {
            [JsonProperty("amount")]
            public JToken Amount { get; set; }

            [JsonProperty("cartType")]
            public string CartType { get; set; }

            [JsonProperty("context")]
            public JToken Context { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("fields")]
            public JObject Fields { get; set; }

            [JsonProperty("flow")]
            public string Flow { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("item")]
            public string Item { get; set; }

            [JsonProperty("itemType")]
            public string ItemType { get; set; }

            [JsonProperty("length")]
            public JToken Length { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("p1")]
            public string P1 { get; set; }

            [JsonProperty("p2")]
            public string P2 { get; set; }

            [JsonProperty("p3")]
            public string P3 { get; set; }

            [JsonProperty("receipt")]
            public string Receipt { get; set; }

            [JsonProperty("score")]
            public JToken Score { get; set; }

            [JsonProperty("severity")]
            public string Severity { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("store")]
            public string Store { get; set; }

            [JsonProperty("time")]
            public JToken Time { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SessionData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("num")]
            public long? Num { get; set; }

            [JsonProperty("start")]
            public JToken Start { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class AnalyticsTrackResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("batchId")]
        public string BatchId { get; set; }

        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }

        [JsonProperty("flagged")]
        public long? Flagged { get; set; }

        [JsonProperty("received")]
        public long? Received { get; set; }

        [JsonProperty("rejected")]
        public long? Rejected { get; set; }

        [JsonProperty("results")]
        public List<ResultsItem> Results { get; set; }

        [JsonProperty("stats")]
        public List<StatsItem> Stats { get; set; }

        [JsonProperty("stored")]
        public long? Stored { get; set; }

        [JsonProperty("unlocked")]
        public List<UnlockedItem> Unlocked { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ResultsItem
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("problems")]
            public List<JToken> Problems { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class StatsItem
        {
            [JsonProperty("accepted")]
            public double? Accepted { get; set; }

            [JsonProperty("current")]
            public double? Current { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("sent")]
            public double? Sent { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class UnlockedItem
        {
            [JsonProperty("claimMode")]
            public string ClaimMode { get; set; }

            [JsonProperty("groupKey")]
            public string GroupKey { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("rewards")]
            public JToken Rewards { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("step")]
            public long? Step { get; set; }

            [JsonProperty("stepCount")]
            public long? StepCount { get; set; }

            [JsonProperty("stepId")]
            public string StepId { get; set; }

            [JsonProperty("stepName")]
            public string StepName { get; set; }

            [JsonProperty("trophyKey")]
            public string TrophyKey { get; set; }

            [JsonProperty("trophyName")]
            public string TrophyName { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class AnalyticsTrophiesRequest
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class AnalyticsTrophiesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimMode")]
        public JToken ClaimMode { get; set; }

        [JsonProperty("groups")]
        public List<GroupsItem> Groups { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("totals")]
        public JObject Totals { get; set; }

        [JsonProperty("unlockOrder")]
        public JToken UnlockOrder { get; set; }

        [JsonProperty("unlocked")]
        public List<UnlockedItem> Unlocked { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GroupsItem
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("stepCount")]
            public long? StepCount { get; set; }

            [JsonProperty("trophies")]
            public List<TrophiesItem> Trophies { get; set; }

            [JsonProperty("unlocked")]
            public long? Unlocked { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class TrophiesItem
            {
                [JsonProperty("completed")]
                public bool? Completed { get; set; }

                [JsonProperty("contextKey")]
                public string ContextKey { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("stepCount")]
                public long? StepCount { get; set; }

                [JsonProperty("steps")]
                public List<JToken> Steps { get; set; }

                [JsonProperty("unlockOrder")]
                public string UnlockOrder { get; set; }

                [JsonProperty("unlocked")]
                public long? Unlocked { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class UnlockedItem
        {
            [JsonProperty("claimMode")]
            public string ClaimMode { get; set; }

            [JsonProperty("groupKey")]
            public string GroupKey { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("rewards")]
            public RewardsData Rewards { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("step")]
            public long? Step { get; set; }

            [JsonProperty("stepCount")]
            public long? StepCount { get; set; }

            [JsonProperty("stepId")]
            public string StepId { get; set; }

            [JsonProperty("stepName")]
            public string StepName { get; set; }

            [JsonProperty("trophyKey")]
            public string TrophyKey { get; set; }

            [JsonProperty("trophyName")]
            public string TrophyName { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardsData
            {
                [JsonProperty("currencies")]
                public JObject Currencies { get; set; }

                [JsonProperty("prizeGroupKey")]
                public string PrizeGroupKey { get; set; }

                [JsonProperty("prizeKey")]
                public string PrizeKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class AnalyticsTrophyClaimRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("step")]
        public long? Step { get; set; }

        [JsonProperty("stepId")]
        public string StepId { get; set; }

        [JsonProperty("trophy")]
        public string Trophy { get; set; }
    }

    public sealed class AnalyticsTrophyClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("rewards")]
        public RewardsData Rewards { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("step")]
        public long? Step { get; set; }

        [JsonProperty("stepId")]
        public string StepId { get; set; }

        [JsonProperty("trophyKey")]
        public string TrophyKey { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardsData
        {
            [JsonProperty("currencies")]
            public JObject Currencies { get; set; }

            [JsonProperty("prize")]
            public JObject Prize { get; set; }

            [JsonProperty("prizeGroupKey")]
            public string PrizeGroupKey { get; set; }

            [JsonProperty("prizeKey")]
            public string PrizeKey { get; set; }

            [JsonProperty("prizes")]
            public List<JObject> Prizes { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class AssetsContentIndexRequest
    {
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }
    }

    public sealed class AssetsContentIndexResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("pack")]
        public PackData Pack { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PackData
        {
            [JsonProperty("activatedAt")]
            public string ActivatedAt { get; set; }

            [JsonProperty("baseUrl")]
            public string BaseUrl { get; set; }

            [JsonProperty("catalogHash")]
            public string CatalogHash { get; set; }

            [JsonProperty("catalogPath")]
            public string CatalogPath { get; set; }

            [JsonProperty("catalogUrl")]
            public string CatalogUrl { get; set; }

            [JsonProperty("fileCount")]
            public long? FileCount { get; set; }

            [JsonProperty("hashUrl")]
            public string HashUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("maxAppVersion")]
            public string MaxAppVersion { get; set; }

            [JsonProperty("minAppVersion")]
            public string MinAppVersion { get; set; }

            [JsonProperty("platform")]
            public string Platform { get; set; }

            [JsonProperty("totalBytes")]
            public long? TotalBytes { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class AssetsFetchRequest
    {
        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("have")]
        public JObject Have { get; set; }

        [JsonProperty("ids")]
        public List<string> Ids { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("recursive")]
        public bool? Recursive { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }

    public sealed class AssetsFetchResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("missing")]
        public List<string> Missing { get; set; }

        [JsonProperty("more")]
        public bool? More { get; set; }

        [JsonProperty("removed")]
        public List<string> Removed { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("unchanged")]
        public long? Unchanged { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("assetId")]
            public string AssetId { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("data")]
            public JToken Data { get; set; }

            [JsonProperty("folder")]
            public string Folder { get; set; }

            [JsonProperty("hash")]
            public string Hash { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("size")]
            public long? Size { get; set; }

            [JsonProperty("sourceGuid")]
            public string SourceGuid { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("updatedAt")]
            public string UpdatedAt { get; set; }

            [JsonProperty("updatedBy")]
            public string UpdatedBy { get; set; }

            [JsonProperty("version")]
            public long? Version { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class AssetsManifestRequest
    {
        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("recursive")]
        public bool? Recursive { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }

    public sealed class AssetsManifestResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("count")]
        public long? Count { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("notModified")]
        public bool? NotModified { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("assetId")]
            public string AssetId { get; set; }

            [JsonProperty("folder")]
            public string Folder { get; set; }

            [JsonProperty("hash")]
            public string Hash { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("sourceGuid")]
            public string SourceGuid { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("version")]
            public long? Version { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseAccountDeleteRequest
    {
        [JsonProperty("confirm")]
        public bool? Confirm { get; set; }
    }

    public sealed class BaseAccountDeleteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("dueAt")]
        public JToken DueAt { get; set; }

        [JsonProperty("graceDays")]
        public JToken GraceDays { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseAccountDeleteCancelRequest
    {
    }

    public sealed class BaseAccountDeleteCancelResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cancelled")]
        public bool? Cancelled { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseAccountGetRequest
    {
    }

    public sealed class BaseAccountGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseAccountRulesRequest
    {
    }

    public sealed class BaseAccountRulesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("displayNameMax")]
        public long? DisplayNameMax { get; set; }

        [JsonProperty("passwordDigit")]
        public bool? PasswordDigit { get; set; }

        [JsonProperty("passwordLetter")]
        public bool? PasswordLetter { get; set; }

        [JsonProperty("passwordMin")]
        public long? PasswordMin { get; set; }

        [JsonProperty("usernameCharset")]
        public string UsernameCharset { get; set; }

        [JsonProperty("usernameMax")]
        public long? UsernameMax { get; set; }

        [JsonProperty("usernameMin")]
        public long? UsernameMin { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseAccountUpdateRequest
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("lang_tag")]
        public string LangTag { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class BaseAccountUpdateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseAppVersionRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("store")]
        public string Store { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class BaseAppVersionResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("current")]
        public JToken Current { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("latest")]
        public string Latest { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("storeUrl")]
        public string StoreUrl { get; set; }

        [JsonProperty("stores")]
        public List<JToken> Stores { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseAvatarRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseAvatarResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("lang")]
        public JToken Lang { get; set; }

        [JsonProperty("look")]
        public LookData Look { get; set; }

        [JsonProperty("parts")]
        public List<PartsItem> Parts { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class LookData
        {
            [JsonProperty("layers")]
            public List<LayersItem> Layers { get; set; }

            [JsonProperty("parts")]
            public JObject Parts { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class LayersItem
            {
                [JsonProperty("imageUrl")]
                public string ImageUrl { get; set; }

                [JsonProperty("layer")]
                public long? Layer { get; set; }

                [JsonProperty("option")]
                public string Option { get; set; }

                [JsonProperty("part")]
                public string Part { get; set; }

                [JsonProperty("value")]
                public string Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class PartsItem
        {
            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("layer")]
            public JToken Layer { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("options")]
            public List<OptionsItem> Options { get; set; }

            [JsonProperty("required")]
            public JToken Required { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class OptionsItem
            {
                [JsonProperty("access")]
                public JToken Access { get; set; }

                [JsonProperty("iconUrl")]
                public JToken IconUrl { get; set; }

                [JsonProperty("imageUrl")]
                public JToken ImageUrl { get; set; }

                [JsonProperty("isDefault")]
                public JToken IsDefault { get; set; }

                [JsonProperty("item")]
                public JToken Item { get; set; }

                [JsonProperty("itemKey")]
                public JToken ItemKey { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("owned")]
                public bool? Owned { get; set; }

                [JsonProperty("price")]
                public JToken Price { get; set; }

                [JsonProperty("product")]
                public JToken Product { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class BaseAvatarGetRequest
    {
        [JsonProperty("userIds")]
        public List<string> UserIds { get; set; }
    }

    public sealed class BaseAvatarGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("looks")]
        public JObject Looks { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseAvatarSaveRequest
    {
        [JsonProperty("look")]
        public JObject Look { get; set; }
    }

    public sealed class BaseAvatarSaveResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("look")]
        public LookData Look { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class LookData
        {
            [JsonProperty("layers")]
            public List<LayersItem> Layers { get; set; }

            [JsonProperty("parts")]
            public JObject Parts { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class LayersItem
            {
                [JsonProperty("imageUrl")]
                public string ImageUrl { get; set; }

                [JsonProperty("layer")]
                public long? Layer { get; set; }

                [JsonProperty("option")]
                public string Option { get; set; }

                [JsonProperty("part")]
                public string Part { get; set; }

                [JsonProperty("value")]
                public string Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class BaseBrandRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseBrandResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accent")]
        public string Accent { get; set; }

        [JsonProperty("custom")]
        public bool? Custom { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("logoDarkUrl")]
        public string LogoDarkUrl { get; set; }

        [JsonProperty("logoUrl")]
        public string LogoUrl { get; set; }

        [JsonProperty("markUrl")]
        public string MarkUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("welcome")]
        public string Welcome { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseCategoriesRequest
    {
        [JsonProperty("keyType")]
        public string KeyType { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseCategoriesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("keyType")]
            public string KeyType { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseChatQuotaRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseChatQuotaResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("bonus")]
        public JToken Bonus { get; set; }

        [JsonProperty("conversations")]
        public ConversationsData Conversations { get; set; }

        [JsonProperty("countMode")]
        public JToken CountMode { get; set; }

        [JsonProperty("counts")]
        public CountsData Counts { get; set; }

        [JsonProperty("day")]
        public JToken Day { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("freeLeft")]
        public JToken FreeLeft { get; set; }

        [JsonProperty("friendPolicy")]
        public JToken FriendPolicy { get; set; }

        [JsonProperty("friends")]
        public FriendsData Friends { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("lots")]
        public List<LotsItem> Lots { get; set; }

        [JsonProperty("messages")]
        public MessagesData Messages { get; set; }

        [JsonProperty("order")]
        public JToken Order { get; set; }

        [JsonProperty("packsExpireAt")]
        public JToken PacksExpireAt { get; set; }

        [JsonProperty("packsLeft")]
        public JToken PacksLeft { get; set; }

        [JsonProperty("productIds")]
        public List<string> ProductIds { get; set; }

        [JsonProperty("products")]
        public JToken Products { get; set; }

        [JsonProperty("replyFree")]
        public JToken ReplyFree { get; set; }

        [JsonProperty("resetsAt")]
        public string ResetsAt { get; set; }

        [JsonProperty("rule")]
        public JToken Rule { get; set; }

        [JsonProperty("timeZone")]
        public JToken TimeZone { get; set; }

        [JsonProperty("today")]
        public TodayData Today { get; set; }

        [JsonProperty("unlimited")]
        public JToken Unlimited { get; set; }

        [JsonProperty("unlimitedBy")]
        public JToken UnlimitedBy { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ConversationsData
        {
            [JsonProperty("left")]
            public JToken Left { get; set; }

            [JsonProperty("limit")]
            public long? Limit { get; set; }

            [JsonProperty("used")]
            public long? Used { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class CountsData
        {
            [JsonProperty("direct")]
            public JToken Direct { get; set; }

            [JsonProperty("groups")]
            public JToken Groups { get; set; }

            [JsonProperty("rooms")]
            public JToken Rooms { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class FriendsData
        {
            [JsonProperty("conversations")]
            public ConversationsData Conversations { get; set; }

            [JsonProperty("messages")]
            public MessagesData Messages { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ConversationsData
            {
                [JsonProperty("left")]
                public JToken Left { get; set; }

                [JsonProperty("limit")]
                public long? Limit { get; set; }

                [JsonProperty("used")]
                public long? Used { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class MessagesData
            {
                [JsonProperty("left")]
                public JToken Left { get; set; }

                [JsonProperty("limit")]
                public long? Limit { get; set; }

                [JsonProperty("used")]
                public long? Used { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class LotsItem
        {
            [JsonProperty("active")]
            public bool? Active { get; set; }

            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("createdBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("expiresAt")]
            public string ExpiresAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("note")]
            public string Note { get; set; }

            [JsonProperty("remaining")]
            public long? Remaining { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class MessagesData
        {
            [JsonProperty("left")]
            public JToken Left { get; set; }

            [JsonProperty("limit")]
            public long? Limit { get; set; }

            [JsonProperty("used")]
            public long? Used { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class TodayData
        {
            [JsonProperty("blocked")]
            public long? Blocked { get; set; }

            [JsonProperty("free")]
            public long? Free { get; set; }

            [JsonProperty("fromPacks")]
            public long? FromPacks { get; set; }

            [JsonProperty("sent")]
            public long? Sent { get; set; }

            [JsonProperty("unlimited")]
            public long? Unlimited { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseCommFavoriteRequest
    {
        [JsonProperty("favorite")]
        public bool? Favorite { get; set; }

        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("pack")]
        public string Pack { get; set; }
    }

    public sealed class BaseCommFavoriteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("favorite")]
        public bool? Favorite { get; set; }

        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("pack")]
        public string Pack { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseCommFavoritesRequest
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("pack")]
        public string Pack { get; set; }
    }

    public sealed class BaseCommFavoritesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("addedAt")]
            public string AddedAt { get; set; }

            [JsonProperty("assetId")]
            public string AssetId { get; set; }

            [JsonProperty("imageUrl")]
            public string ImageUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("pack")]
            public string Pack { get; set; }

            [JsonProperty("packKind")]
            public string PackKind { get; set; }

            [JsonProperty("ref")]
            public string Ref { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseCommPacksRequest
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mine")]
        public bool? Mine { get; set; }
    }

    public sealed class BaseCommPacksResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cooldown")]
        public JToken Cooldown { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("maxFavorites")]
        public JToken MaxFavorites { get; set; }

        [JsonProperty("packs")]
        public List<PacksItem> Packs { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PacksItem
        {
            [JsonProperty("access")]
            public string Access { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("item")]
            public JObject Item { get; set; }

            [JsonProperty("itemKey")]
            public string ItemKey { get; set; }

            [JsonProperty("items")]
            public List<ItemsItem> Items { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("starter")]
            public bool? Starter { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsItem
            {
                [JsonProperty("assetId")]
                public string AssetId { get; set; }

                [JsonProperty("favorite")]
                public bool? Favorite { get; set; }

                [JsonProperty("imageUrl")]
                public string ImageUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("ref")]
                public string Ref { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class BaseCountriesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseCountriesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JToken> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("selected")]
        public string Selected { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseFriendRulesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseFriendRulesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("base")]
        public BaseData Base { get; set; }

        [JsonProperty("bonus")]
        public BonusData Bonus { get; set; }

        [JsonProperty("dailyRequests")]
        public long? DailyRequests { get; set; }

        [JsonProperty("dayStartMinute")]
        public JToken DayStartMinute { get; set; }

        [JsonProperty("dmFriendsOnly")]
        public bool? DmFriendsOnly { get; set; }

        [JsonProperty("expiryDays")]
        public long? ExpiryDays { get; set; }

        [JsonProperty("friendSlotsLeft")]
        public JToken FriendSlotsLeft { get; set; }

        [JsonProperty("friends")]
        public long? Friends { get; set; }

        [JsonProperty("maxFriends")]
        public long? MaxFriends { get; set; }

        [JsonProperty("overLimit")]
        public string OverLimit { get; set; }

        [JsonProperty("presenceFriendsOnly")]
        public bool? PresenceFriendsOnly { get; set; }

        [JsonProperty("rejectCooldownHours")]
        public long? RejectCooldownHours { get; set; }

        [JsonProperty("remainingToday")]
        public JToken RemainingToday { get; set; }

        [JsonProperty("resetsAt")]
        public string ResetsAt { get; set; }

        [JsonProperty("sentToday")]
        public long? SentToday { get; set; }

        [JsonProperty("tier")]
        public JToken Tier { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class BaseData
        {
            [JsonProperty("dailyRequests")]
            public JToken DailyRequests { get; set; }

            [JsonProperty("maxFriends")]
            public JToken MaxFriends { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class BonusData
        {
            [JsonProperty("dailyRequests")]
            public JToken DailyRequests { get; set; }

            [JsonProperty("maxFriends")]
            public JToken MaxFriends { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseFriendSuggestionsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseFriendSuggestionsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cycle")]
        public string Cycle { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("refreshesAt")]
        public string RefreshesAt { get; set; }

        [JsonProperty("suggestions")]
        public List<SuggestionsItem> Suggestions { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class SuggestionsItem
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("lastPlayedAt")]
            public string LastPlayedAt { get; set; }

            [JsonProperty("mutual")]
            public long? Mutual { get; set; }

            [JsonProperty("online")]
            public bool? Online { get; set; }

            [JsonProperty("score")]
            public double? Score { get; set; }

            [JsonProperty("shows")]
            public long? Shows { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseFriendsAddRequest
    {
        [JsonProperty("codes")]
        public List<string> Codes { get; set; }

        [JsonProperty("ids")]
        public List<string> Ids { get; set; }

        [JsonProperty("usernames")]
        public List<string> Usernames { get; set; }
    }

    public sealed class BaseFriendsAddResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseFriendsBlockRequest
    {
        [JsonProperty("codes")]
        public List<string> Codes { get; set; }

        [JsonProperty("ids")]
        public List<string> Ids { get; set; }

        [JsonProperty("usernames")]
        public List<string> Usernames { get; set; }
    }

    public sealed class BaseFriendsBlockResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseFriendsListRequest
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("state")]
        public long? State { get; set; }
    }

    public sealed class BaseFriendsListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseFriendsRemoveRequest
    {
        [JsonProperty("codes")]
        public List<string> Codes { get; set; }

        [JsonProperty("ids")]
        public List<string> Ids { get; set; }

        [JsonProperty("usernames")]
        public List<string> Usernames { get; set; }
    }

    public sealed class BaseFriendsRemoveResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseLanguagesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseLanguagesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("default")]
        public JToken Default { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("direction")]
            public string Direction { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("isDefault")]
            public bool? IsDefault { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nativeName")]
            public string NativeName { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseMyActivityRequest
    {
        [JsonProperty("before")]
        public long? Before { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class BaseMyActivityResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("before")]
        public JToken Before { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("data")]
            public JToken Data { get; set; }

            [JsonProperty("id")]
            public long? Id { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("platform")]
            public string Platform { get; set; }

            [JsonProperty("refId")]
            public string RefId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseMyCodeRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseMyCodeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseMyReportsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }
    }

    public sealed class BaseMyReportsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("limits")]
        public LimitsData Limits { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("closedAt")]
            public string ClosedAt { get; set; }

            [JsonProperty("contentId")]
            public string ContentId { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("gameKey")]
            public string GameKey { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("matchId")]
            public string MatchId { get; set; }

            [JsonProperty("note")]
            public string Note { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("titleKey")]
            public string TitleKey { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LimitsData
        {
            [JsonProperty("duplicateHours")]
            public JToken DuplicateHours { get; set; }

            [JsonProperty("minAccountHours")]
            public JToken MinAccountHours { get; set; }

            [JsonProperty("noteMax")]
            public JToken NoteMax { get; set; }

            [JsonProperty("noteRequired")]
            public JToken NoteRequired { get; set; }

            [JsonProperty("perHour")]
            public JToken PerHour { get; set; }

            [JsonProperty("remaining")]
            public JToken Remaining { get; set; }

            [JsonProperty("trusted")]
            public bool? Trusted { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseMyStatusRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseMyStatusResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mute")]
        public JToken Mute { get; set; }

        [JsonProperty("suspension")]
        public JToken Suspension { get; set; }

        [JsonProperty("warnings")]
        public List<WarningsItem> Warnings { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class WarningsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseMyTagsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseMyTagsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("keyType")]
            public string KeyType { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BasePlayerCodesRequest
    {
        [JsonProperty("ids")]
        public List<string> Ids { get; set; }
    }

    public sealed class BasePlayerCodesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("codes")]
        public JObject Codes { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseRemoteConfigRequest
    {
        [JsonProperty("keys")]
        public List<string> Keys { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class BaseRemoteConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("values")]
        public JObject Values { get; set; }

        [JsonProperty("variants")]
        public JObject Variants { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseReportMessageRequest
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }
    }

    public sealed class BaseReportMessageResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }

        [JsonProperty("reportId")]
        public string ReportId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseReportPlayerRequest
    {
        [JsonProperty("contentId")]
        public string ContentId { get; set; }

        [JsonProperty("gameKey")]
        public string GameKey { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class BaseReportPlayerResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }

        [JsonProperty("reportId")]
        public string ReportId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseReportTitlesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseReportTitlesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseServerStatusRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseServerStatusResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accountDelete")]
        public AccountDeleteData AccountDelete { get; set; }

        [JsonProperty("deletionDueAt")]
        public JToken DeletionDueAt { get; set; }

        [JsonProperty("maintenance")]
        public MaintenanceData Maintenance { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AccountDeleteData
        {
            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("graceDays")]
            public JToken GraceDays { get; set; }

            [JsonProperty("mode")]
            public JToken Mode { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class MaintenanceData
        {
            [JsonProperty("bypass")]
            public bool? Bypass { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("on")]
            public JToken On { get; set; }

            [JsonProperty("until")]
            public JToken Until { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseSetCountryRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public sealed class BaseSetCountryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSetLanguageRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseSetLanguageResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("lang")]
        public JToken Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseStickersRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseStickersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("chats")]
        public ChatsData Chats { get; set; }

        [JsonProperty("countQuota")]
        public JToken CountQuota { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("packs")]
        public List<PacksItem> Packs { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ChatsData
        {
            [JsonProperty("direct")]
            public JToken Direct { get; set; }

            [JsonProperty("groups")]
            public JToken Groups { get; set; }

            [JsonProperty("rooms")]
            public JToken Rooms { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PacksItem
        {
            [JsonProperty("access")]
            public string Access { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("item")]
            public JObject Item { get; set; }

            [JsonProperty("itemKey")]
            public string ItemKey { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("stickers")]
            public List<StickersItem> Stickers { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class StickersItem
            {
                [JsonProperty("assetId")]
                public string AssetId { get; set; }

                [JsonProperty("imageUrl")]
                public string ImageUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("ref")]
                public string Ref { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class BaseSupportChatCloseRequest
    {
        [JsonProperty("chatId")]
        public string ChatId { get; set; }

        [JsonProperty("toTicket")]
        public bool? ToTicket { get; set; }
    }

    public sealed class BaseSupportChatCloseResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("agentsOnline")]
        public bool? AgentsOnline { get; set; }

        [JsonProperty("chat")]
        public JToken Chat { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportChatGetRequest
    {
        [JsonProperty("after")]
        public long? After { get; set; }

        [JsonProperty("chatId")]
        public string ChatId { get; set; }
    }

    public sealed class BaseSupportChatGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("agentsOnline")]
        public bool? AgentsOnline { get; set; }

        [JsonProperty("chat")]
        public JToken Chat { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportChatOpenRequest
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("departmentKey")]
        public string DepartmentKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }
    }

    public sealed class BaseSupportChatOpenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("agentsOnline")]
        public bool? AgentsOnline { get; set; }

        [JsonProperty("chat")]
        public JToken Chat { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportChatRateRequest
    {
        [JsonProperty("chatId")]
        public string ChatId { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("rating")]
        public long? Rating { get; set; }
    }

    public sealed class BaseSupportChatRateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("agentsOnline")]
        public bool? AgentsOnline { get; set; }

        [JsonProperty("chat")]
        public JToken Chat { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportChatSendRequest
    {
        [JsonProperty("after")]
        public long? After { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("chatId")]
        public string ChatId { get; set; }
    }

    public sealed class BaseSupportChatSendResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("agentsOnline")]
        public bool? AgentsOnline { get; set; }

        [JsonProperty("chat")]
        public JToken Chat { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportChatTypingRequest
    {
        [JsonProperty("chatId")]
        public string ChatId { get; set; }
    }

    public sealed class BaseSupportChatTypingResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportInfoRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseSupportInfoResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("agentsOnline")]
        public bool? AgentsOnline { get; set; }

        [JsonProperty("attachments")]
        public bool? Attachments { get; set; }

        [JsonProperty("chatEnabled")]
        public JToken ChatEnabled { get; set; }

        [JsonProperty("chatId")]
        public JToken ChatId { get; set; }

        [JsonProperty("departments")]
        public List<DepartmentsItem> Departments { get; set; }

        [JsonProperty("fileTypes")]
        public List<string> FileTypes { get; set; }

        [JsonProperty("greeting")]
        public string Greeting { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("maxAttachmentKb")]
        public JToken MaxAttachmentKb { get; set; }

        [JsonProperty("maxAttachments")]
        public JToken MaxAttachments { get; set; }

        [JsonProperty("offline")]
        public string Offline { get; set; }

        [JsonProperty("openTickets")]
        public long? OpenTickets { get; set; }

        [JsonProperty("unread")]
        public long? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DepartmentsItem
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseSupportTicketCreateRequest
    {
        [JsonProperty("attachments")]
        public List<string> Attachments { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("departmentId")]
        public string DepartmentId { get; set; }

        [JsonProperty("departmentKey")]
        public string DepartmentKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }
    }

    public sealed class BaseSupportTicketCreateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("messages")]
        public List<JObject> Messages { get; set; }

        [JsonProperty("unread")]
        public bool? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportTicketGetRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseSupportTicketGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("messages")]
        public List<JObject> Messages { get; set; }

        [JsonProperty("unread")]
        public bool? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportTicketRateRequest
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("rating")]
        public long? Rating { get; set; }
    }

    public sealed class BaseSupportTicketRateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("messages")]
        public List<JObject> Messages { get; set; }

        [JsonProperty("unread")]
        public bool? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportTicketReplyRequest
    {
        [JsonProperty("attachments")]
        public List<string> Attachments { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseSupportTicketReplyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("messages")]
        public List<JObject> Messages { get; set; }

        [JsonProperty("unread")]
        public bool? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportTicketResolveRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseSupportTicketResolveResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("messages")]
        public List<JObject> Messages { get; set; }

        [JsonProperty("unread")]
        public bool? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportTicketsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseSupportTicketsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("departmentName")]
            public string DepartmentName { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseSupportUploadBeginRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }
    }

    public sealed class BaseSupportUploadBeginResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("chunkBytes")]
        public JToken ChunkBytes { get; set; }

        [JsonProperty("parts")]
        public long? Parts { get; set; }

        [JsonProperty("uploadId")]
        public string UploadId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportUploadFinishRequest
    {
        [JsonProperty("uploadId")]
        public string UploadId { get; set; }
    }

    public sealed class BaseSupportUploadFinishResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseSupportUploadPartRequest
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("index")]
        public long? Index { get; set; }

        [JsonProperty("uploadId")]
        public string UploadId { get; set; }
    }

    public sealed class BaseSupportUploadPartResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("index")]
        public long? Index { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseTagsRequest
    {
        [JsonProperty("keyType")]
        public string KeyType { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseTagsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("keyType")]
            public string KeyType { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseUserByCodeRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseUserByCodeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("online")]
        public bool? Online { get; set; }

        [JsonProperty("relationship")]
        public JToken Relationship { get; set; }

        [JsonProperty("user")]
        public UserData User { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class UserData
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("code")]
            public JToken Code { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseUsernameChangeRequest
    {
        [JsonProperty("expectedCost")]
        public long? ExpectedCost { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class BaseUsernameChangeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cost")]
        public long? Cost { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("oldUsername")]
        public string OldUsername { get; set; }

        [JsonProperty("quote")]
        public QuoteData Quote { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class QuoteData
        {
            [JsonProperty("cooldownEndsAt")]
            public string CooldownEndsAt { get; set; }

            [JsonProperty("cooldownHours")]
            public long? CooldownHours { get; set; }

            [JsonProperty("cost")]
            public long? Cost { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("free")]
            public bool? Free { get; set; }

            [JsonProperty("paidChanges")]
            public long? PaidChanges { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class BaseUsernameQuoteRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class BaseUsernameQuoteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cooldownEndsAt")]
        public string CooldownEndsAt { get; set; }

        [JsonProperty("cooldownHours")]
        public long? CooldownHours { get; set; }

        [JsonProperty("cost")]
        public long? Cost { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("free")]
        public bool? Free { get; set; }

        [JsonProperty("paidChanges")]
        public long? PaidChanges { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BaseUsersGetRequest
    {
        [JsonProperty("codes")]
        public List<string> Codes { get; set; }

        [JsonProperty("ids")]
        public List<string> Ids { get; set; }

        [JsonProperty("usernames")]
        public List<string> Usernames { get; set; }
    }

    public sealed class BaseUsersGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BlockworldBuyBlockRequest
    {
    }

    public sealed class BlockworldBuyBlockResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("actionIds")]
        public List<long?> ActionIds { get; set; }

        [JsonProperty("blocks")]
        public List<long?> Blocks { get; set; }

        [JsonProperty("coins")]
        public JToken Coins { get; set; }

        [JsonProperty("purchaseId")]
        public string PurchaseId { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BlockworldTokenRequest
    {
    }

    public sealed class BlockworldTokenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("issuer")]
        public JToken Issuer { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subject")]
        public JToken Subject { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("username")]
        public JToken Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class BlockworldWalletRequest
    {
    }

    public sealed class BlockworldWalletResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("coins")]
        public long? Coins { get; set; }

        [JsonProperty("currency")]
        public JToken Currency { get; set; }

        [JsonProperty("owned")]
        public List<long?> Owned { get; set; }

        [JsonProperty("prices")]
        public List<PricesItem> Prices { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PricesItem
        {
            [JsonProperty("id")]
            public long? Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("price")]
            public long? Price { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CampaignAttemptCompleteRequest
    {
        [JsonProperty("attemptId")]
        public string AttemptId { get; set; }

        [JsonProperty("elapsedSeconds")]
        public double? ElapsedSeconds { get; set; }

        [JsonProperty("fields")]
        public JObject Fields { get; set; }

        [JsonProperty("healthPercent")]
        public double? HealthPercent { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("stageKey")]
        public string StageKey { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }
    }

    public sealed class CampaignAttemptCompleteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class CampaignAttemptStartRequest
    {
        [JsonProperty("stageKey")]
        public string StageKey { get; set; }
    }

    public sealed class CampaignAttemptStartResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("attemptId")]
        public string AttemptId { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("item")]
        public Item_ Item { get; set; }

        [JsonProperty("playCost")]
        public PlayCostData PlayCost { get; set; }

        [JsonProperty("regen")]
        public JToken Regen { get; set; }

        [JsonProperty("stageKey")]
        public JToken StageKey { get; set; }

        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }

        [JsonProperty("timeLimitSeconds")]
        public JToken TimeLimitSeconds { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class Item_
        {
            [JsonProperty("itemKey")]
            public JToken ItemKey { get; set; }

            [JsonProperty("itemType")]
            public JToken ItemType { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PlayCostData
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonProperty("free")]
            public bool? Free { get; set; }

            [JsonProperty("spent")]
            public long? Spent { get; set; }

            [JsonProperty("via")]
            public string Via { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CampaignChaptersRequest
    {
        [JsonProperty("chapter")]
        public string Chapter { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class CampaignChaptersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("chapters")]
        public List<ChaptersItem> Chapters { get; set; }

        [JsonProperty("freeride")]
        public List<FreerideItem> Freeride { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("maxStars")]
        public JToken MaxStars { get; set; }

        [JsonProperty("nextLevelXp")]
        public long? NextLevelXp { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("xp")]
        public long? Xp { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ChaptersItem
        {
            [JsonProperty("address")]
            public JToken Address { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("locks")]
            public List<LocksItem> Locks { get; set; }

            [JsonProperty("maxStars")]
            public long? MaxStars { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("milestones")]
            public List<MilestonesItem> Milestones { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("settings")]
            public string Settings { get; set; }

            [JsonProperty("sort")]
            public JToken Sort { get; set; }

            [JsonProperty("stages")]
            public List<StagesItem> Stages { get; set; }

            [JsonProperty("starPercent")]
            public double? StarPercent { get; set; }

            [JsonProperty("stars")]
            public long? Stars { get; set; }

            [JsonProperty("unlocked")]
            public bool? Unlocked { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class LocksItem
            {
                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("table")]
                public string Table { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public double? Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class MilestonesItem
            {
                [JsonProperty("claimed")]
                public bool? Claimed { get; set; }

                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("percent")]
                public JToken Percent { get; set; }

                [JsonProperty("prizeGroupKey")]
                public JToken PrizeGroupKey { get; set; }

                [JsonProperty("prizeKey")]
                public JToken PrizeKey { get; set; }

                [JsonProperty("reached")]
                public bool? Reached { get; set; }

                [JsonProperty("rewards")]
                public List<JObject> Rewards { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class StagesItem
            {
                [JsonProperty("address")]
                public JToken Address { get; set; }

                [JsonProperty("bestSeconds")]
                public JToken BestSeconds { get; set; }

                [JsonProperty("bestStars")]
                public JToken BestStars { get; set; }

                [JsonProperty("claimed")]
                public List<JObject> Claimed { get; set; }

                [JsonProperty("claimedXp")]
                public JToken ClaimedXp { get; set; }

                [JsonProperty("completedBy")]
                public CompletedByData CompletedBy { get; set; }

                [JsonProperty("completions")]
                public JToken Completions { get; set; }

                [JsonProperty("cooldownSeconds")]
                public JToken CooldownSeconds { get; set; }

                [JsonProperty("dailyRewardLimit")]
                public JToken DailyRewardLimit { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public JToken IconUrl { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("locks")]
                public List<LocksItem> Locks { get; set; }

                [JsonProperty("metadata")]
                public JToken Metadata { get; set; }

                [JsonProperty("minSeconds")]
                public double? MinSeconds { get; set; }

                [JsonProperty("mode")]
                public JToken Mode { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("nextRewardAt")]
                public string NextRewardAt { get; set; }

                [JsonProperty("noReplayAfterWin")]
                public JToken NoReplayAfterWin { get; set; }

                [JsonProperty("replayable")]
                public bool? Replayable { get; set; }

                [JsonProperty("rewardGroup")]
                public JToken RewardGroup { get; set; }

                [JsonProperty("rewards")]
                public List<JObject> Rewards { get; set; }

                [JsonProperty("rewardsLeftToday")]
                public long? RewardsLeftToday { get; set; }

                [JsonProperty("settings")]
                public string Settings { get; set; }

                [JsonProperty("sort")]
                public JToken Sort { get; set; }

                [JsonProperty("starMultipliers")]
                public List<double?> StarMultipliers { get; set; }

                [JsonProperty("starRules")]
                public List<JToken> StarRules { get; set; }

                [JsonProperty("starTemplate")]
                public JToken StarTemplate { get; set; }

                [JsonProperty("tierPrizes")]
                public JToken TierPrizes { get; set; }

                [JsonProperty("timeLimitSeconds")]
                public JToken TimeLimitSeconds { get; set; }

                [JsonProperty("unlocked")]
                public bool? Unlocked { get; set; }

                [JsonProperty("wins")]
                public JToken Wins { get; set; }

                [JsonProperty("xp")]
                public JToken Xp { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class CompletedByData
                {
                    [JsonProperty("owner")]
                    public JToken Owner { get; set; }

                    [JsonProperty("ref")]
                    public JToken Ref { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class LocksItem
                {
                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("table")]
                    public string Table { get; set; }

                    [JsonProperty("type")]
                    public string Type { get; set; }

                    [JsonProperty("value")]
                    public double? Value { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }

        public sealed class FreerideItem
        {
            [JsonProperty("cooldownSeconds")]
            public JToken CooldownSeconds { get; set; }

            [JsonProperty("dailyRewardLimit")]
            public JToken DailyRewardLimit { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("minLevel")]
            public JToken MinLevel { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextRewardAt")]
            public string NextRewardAt { get; set; }

            [JsonProperty("prizeGroupKey")]
            public JToken PrizeGroupKey { get; set; }

            [JsonProperty("prizeKey")]
            public JToken PrizeKey { get; set; }

            [JsonProperty("rewardGroup")]
            public JToken RewardGroup { get; set; }

            [JsonProperty("rewards")]
            public List<JObject> Rewards { get; set; }

            [JsonProperty("rewardsLeftToday")]
            public long? RewardsLeftToday { get; set; }

            [JsonProperty("xp")]
            public JToken Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CampaignFreerideClaimRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class CampaignFreerideClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanCreateRequest
    {
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("badge")]
        public JObject Badge { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coverKey")]
        public string CoverKey { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("emblemKey")]
        public string EmblemKey { get; set; }

        [JsonProperty("joinType")]
        public string JoinType { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("minTrophies")]
        public long? MinTrophies { get; set; }

        [JsonProperty("motto")]
        public string Motto { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("tags")]
        public List<JToken> Tags { get; set; }
    }

    public sealed class ClanCreateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clan")]
        public ClanData Clan { get; set; }

        [JsonProperty("role")]
        public JToken Role { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClanData
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("badge")]
            public JObject Badge { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("clanId")]
            public string ClanId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("coverKey")]
            public string CoverKey { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("emblemKey")]
            public string EmblemKey { get; set; }

            [JsonProperty("emblemUrl")]
            public string EmblemUrl { get; set; }

            [JsonProperty("joinType")]
            public string JoinType { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelXp")]
            public long? LevelXp { get; set; }

            [JsonProperty("maxMembers")]
            public long? MaxMembers { get; set; }

            [JsonProperty("members")]
            public long? Members { get; set; }

            [JsonProperty("minTrophies")]
            public long? MinTrophies { get; set; }

            [JsonProperty("motto")]
            public string Motto { get; set; }

            [JsonProperty("myRole")]
            public string MyRole { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextChangeAt")]
            public JToken NextChangeAt { get; set; }

            [JsonProperty("nextLevelXp")]
            public JToken NextLevelXp { get; set; }

            [JsonProperty("pendingUploads")]
            public JToken PendingUploads { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("warDraws")]
            public long? WarDraws { get; set; }

            [JsonProperty("warLosses")]
            public long? WarLosses { get; set; }

            [JsonProperty("warPoints")]
            public long? WarPoints { get; set; }

            [JsonProperty("warWins")]
            public long? WarWins { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanDemoteRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanDemoteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanGetRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }
    }

    public sealed class ClanGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clan")]
        public ClanData Clan { get; set; }

        [JsonProperty("invited")]
        public bool? Invited { get; set; }

        [JsonProperty("members")]
        public List<JObject> Members { get; set; }

        [JsonProperty("requested")]
        public bool? Requested { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClanData
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("badge")]
            public JObject Badge { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("clanId")]
            public string ClanId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("coverKey")]
            public string CoverKey { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("emblemKey")]
            public string EmblemKey { get; set; }

            [JsonProperty("emblemUrl")]
            public string EmblemUrl { get; set; }

            [JsonProperty("joinType")]
            public string JoinType { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelXp")]
            public long? LevelXp { get; set; }

            [JsonProperty("maxMembers")]
            public long? MaxMembers { get; set; }

            [JsonProperty("members")]
            public long? Members { get; set; }

            [JsonProperty("minTrophies")]
            public long? MinTrophies { get; set; }

            [JsonProperty("motto")]
            public string Motto { get; set; }

            [JsonProperty("myRole")]
            public string MyRole { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextChangeAt")]
            public JToken NextChangeAt { get; set; }

            [JsonProperty("nextLevelXp")]
            public JToken NextLevelXp { get; set; }

            [JsonProperty("pendingUploads")]
            public JToken PendingUploads { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("warDraws")]
            public long? WarDraws { get; set; }

            [JsonProperty("warLosses")]
            public long? WarLosses { get; set; }

            [JsonProperty("warPoints")]
            public long? WarPoints { get; set; }

            [JsonProperty("warWins")]
            public long? WarWins { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanImageUploadRequest
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }
    }

    public sealed class ClanImageUploadResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("uploadId")]
        public string UploadId { get; set; }

        [JsonProperty("url")]
        public JToken Url { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanInviteRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanInviteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("invited")]
        public bool? Invited { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanInviteAcceptRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanInviteAcceptResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clan")]
        public ClanData Clan { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClanData
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("badge")]
            public JObject Badge { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("clanId")]
            public string ClanId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("coverKey")]
            public string CoverKey { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("emblemKey")]
            public string EmblemKey { get; set; }

            [JsonProperty("emblemUrl")]
            public string EmblemUrl { get; set; }

            [JsonProperty("joinType")]
            public string JoinType { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelXp")]
            public long? LevelXp { get; set; }

            [JsonProperty("maxMembers")]
            public long? MaxMembers { get; set; }

            [JsonProperty("members")]
            public long? Members { get; set; }

            [JsonProperty("minTrophies")]
            public long? MinTrophies { get; set; }

            [JsonProperty("motto")]
            public string Motto { get; set; }

            [JsonProperty("myRole")]
            public string MyRole { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextChangeAt")]
            public JToken NextChangeAt { get; set; }

            [JsonProperty("nextLevelXp")]
            public JToken NextLevelXp { get; set; }

            [JsonProperty("pendingUploads")]
            public JToken PendingUploads { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("warDraws")]
            public long? WarDraws { get; set; }

            [JsonProperty("warLosses")]
            public long? WarLosses { get; set; }

            [JsonProperty("warPoints")]
            public long? WarPoints { get; set; }

            [JsonProperty("warWins")]
            public long? WarWins { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanInviteDeclineRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanInviteDeclineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("declined")]
        public bool? Declined { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanInvitesRequest
    {
    }

    public sealed class ClanInvitesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("byUserId")]
            public JToken ByUserId { get; set; }

            [JsonProperty("clan")]
            public ClanData Clan { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("invitedAt")]
            public string InvitedAt { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ClanData
            {
                [JsonProperty("avatarUrl")]
                public string AvatarUrl { get; set; }

                [JsonProperty("badge")]
                public JObject Badge { get; set; }

                [JsonProperty("channel")]
                public string Channel { get; set; }

                [JsonProperty("clanId")]
                public string ClanId { get; set; }

                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("country")]
                public string Country { get; set; }

                [JsonProperty("coverKey")]
                public string CoverKey { get; set; }

                [JsonProperty("coverUrl")]
                public string CoverUrl { get; set; }

                [JsonProperty("createdAt")]
                public string CreatedAt { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("emblemKey")]
                public string EmblemKey { get; set; }

                [JsonProperty("emblemUrl")]
                public string EmblemUrl { get; set; }

                [JsonProperty("joinType")]
                public string JoinType { get; set; }

                [JsonProperty("lang")]
                public string Lang { get; set; }

                [JsonProperty("level")]
                public long? Level { get; set; }

                [JsonProperty("levelXp")]
                public long? LevelXp { get; set; }

                [JsonProperty("maxMembers")]
                public long? MaxMembers { get; set; }

                [JsonProperty("members")]
                public long? Members { get; set; }

                [JsonProperty("minTrophies")]
                public long? MinTrophies { get; set; }

                [JsonProperty("motto")]
                public string Motto { get; set; }

                [JsonProperty("myRole")]
                public string MyRole { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("nextChangeAt")]
                public JToken NextChangeAt { get; set; }

                [JsonProperty("nextLevelXp")]
                public JToken NextLevelXp { get; set; }

                [JsonProperty("pendingUploads")]
                public JToken PendingUploads { get; set; }

                [JsonProperty("tag")]
                public string Tag { get; set; }

                [JsonProperty("tags")]
                public List<string> Tags { get; set; }

                [JsonProperty("trophies")]
                public long? Trophies { get; set; }

                [JsonProperty("warDraws")]
                public long? WarDraws { get; set; }

                [JsonProperty("warLosses")]
                public long? WarLosses { get; set; }

                [JsonProperty("warPoints")]
                public long? WarPoints { get; set; }

                [JsonProperty("warWins")]
                public long? WarWins { get; set; }

                [JsonProperty("xp")]
                public long? Xp { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class ClanJoinRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }
    }

    public sealed class ClanJoinResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clan")]
        public ClanData Clan { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClanData
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("badge")]
            public JObject Badge { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("clanId")]
            public string ClanId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("coverKey")]
            public string CoverKey { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("emblemKey")]
            public string EmblemKey { get; set; }

            [JsonProperty("emblemUrl")]
            public string EmblemUrl { get; set; }

            [JsonProperty("joinType")]
            public string JoinType { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelXp")]
            public long? LevelXp { get; set; }

            [JsonProperty("maxMembers")]
            public long? MaxMembers { get; set; }

            [JsonProperty("members")]
            public long? Members { get; set; }

            [JsonProperty("minTrophies")]
            public long? MinTrophies { get; set; }

            [JsonProperty("motto")]
            public string Motto { get; set; }

            [JsonProperty("myRole")]
            public string MyRole { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextChangeAt")]
            public JToken NextChangeAt { get; set; }

            [JsonProperty("nextLevelXp")]
            public JToken NextLevelXp { get; set; }

            [JsonProperty("pendingUploads")]
            public JToken PendingUploads { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("warDraws")]
            public long? WarDraws { get; set; }

            [JsonProperty("warLosses")]
            public long? WarLosses { get; set; }

            [JsonProperty("warPoints")]
            public long? WarPoints { get; set; }

            [JsonProperty("warWins")]
            public long? WarWins { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanKickRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanKickResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("kicked")]
        public bool? Kicked { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanLeaveRequest
    {
    }

    public sealed class ClanLeaveResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("left")]
        public bool? Left { get; set; }

        [JsonProperty("newLeaderId")]
        public string NewLeaderId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanLevelsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class ClanLevelsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clan")]
        public JToken Clan { get; set; }

        [JsonProperty("levels")]
        public List<LevelsItem> Levels { get; set; }

        [JsonProperty("memberDailyCap")]
        public JToken MemberDailyCap { get; set; }

        [JsonProperty("sources")]
        public List<SourcesItem> Sources { get; set; }

        [JsonProperty("war")]
        public WarData War { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class LevelsItem
        {
            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("level")]
            public JToken Level { get; set; }

            [JsonProperty("memberCap")]
            public JToken MemberCap { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("perks")]
            public JToken Perks { get; set; }

            [JsonProperty("prizeKey")]
            public JToken PrizeKey { get; set; }

            [JsonProperty("reached")]
            public bool? Reached { get; set; }

            [JsonProperty("xp")]
            public JToken Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SourcesItem
        {
            [JsonProperty("amount")]
            public JToken Amount { get; set; }

            [JsonProperty("event")]
            public JToken Event { get; set; }

            [JsonProperty("perValue")]
            public JToken PerValue { get; set; }

            [JsonProperty("type")]
            public JToken Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class WarData
        {
            [JsonProperty("draw")]
            public JToken Draw { get; set; }

            [JsonProperty("loss")]
            public JToken Loss { get; set; }

            [JsonProperty("win")]
            public JToken Win { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanMineRequest
    {
    }

    public sealed class ClanMineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clan")]
        public JToken Clan { get; set; }

        [JsonProperty("cooldownSeconds")]
        public long? CooldownSeconds { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("invites")]
        public long? Invites { get; set; }

        [JsonProperty("pendingRequests")]
        public long? PendingRequests { get; set; }

        [JsonProperty("permissions")]
        public PermissionsData Permissions { get; set; }

        [JsonProperty("requestedClanIds")]
        public List<string> RequestedClanIds { get; set; }

        [JsonProperty("role")]
        public JToken Role { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PermissionsData
        {
            [JsonProperty("accept")]
            public bool? Accept { get; set; }

            [JsonProperty("edit")]
            public bool? Edit { get; set; }

            [JsonProperty("invite")]
            public bool? Invite { get; set; }

            [JsonProperty("kick")]
            public bool? Kick { get; set; }

            [JsonProperty("promote")]
            public bool? Promote { get; set; }

            [JsonProperty("transfer")]
            public bool? Transfer { get; set; }

            [JsonProperty("war")]
            public bool? War { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanOptionsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class ClanOptionsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("changeCooldownMinutes")]
        public JToken ChangeCooldownMinutes { get; set; }

        [JsonProperty("colors")]
        public JToken Colors { get; set; }

        [JsonProperty("countries")]
        public List<CountriesItem> Countries { get; set; }

        [JsonProperty("covers")]
        public List<CoversItem> Covers { get; set; }

        [JsonProperty("createCost")]
        public JToken CreateCost { get; set; }

        [JsonProperty("descriptionMax")]
        public JToken DescriptionMax { get; set; }

        [JsonProperty("editRoles")]
        public JToken EditRoles { get; set; }

        [JsonProperty("emblems")]
        public List<EmblemsItem> Emblems { get; set; }

        [JsonProperty("languages")]
        public List<LanguagesItem> Languages { get; set; }

        [JsonProperty("maxMinTrophies")]
        public JToken MaxMinTrophies { get; set; }

        [JsonProperty("maxTags")]
        public JToken MaxTags { get; set; }

        [JsonProperty("mottoMax")]
        public JToken MottoMax { get; set; }

        [JsonProperty("nameMax")]
        public JToken NameMax { get; set; }

        [JsonProperty("nameMin")]
        public JToken NameMin { get; set; }

        [JsonProperty("nextChangeAt")]
        public JToken NextChangeAt { get; set; }

        [JsonProperty("tags")]
        public List<TagsItem> Tags { get; set; }

        [JsonProperty("uploads")]
        public UploadsData Uploads { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CountriesItem
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class CoversItem
        {
            [JsonProperty("imageUrl")]
            public JToken ImageUrl { get; set; }

            [JsonProperty("isDefault")]
            public JToken IsDefault { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("locked")]
            public bool? Locked { get; set; }

            [JsonProperty("minLevel")]
            public JToken MinLevel { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("price")]
            public JToken Price { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class EmblemsItem
        {
            [JsonProperty("imageUrl")]
            public JToken ImageUrl { get; set; }

            [JsonProperty("isDefault")]
            public JToken IsDefault { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("locked")]
            public bool? Locked { get; set; }

            [JsonProperty("minLevel")]
            public JToken MinLevel { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("price")]
            public JToken Price { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LanguagesItem
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class TagsItem
        {
            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class UploadsData
        {
            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("maxBytes")]
            public JToken MaxBytes { get; set; }

            [JsonProperty("needsApproval")]
            public JToken NeedsApproval { get; set; }

            [JsonProperty("types")]
            public JToken Types { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanPromoteRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanPromoteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanRequestAcceptRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanRequestAcceptResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accepted")]
        public bool? Accepted { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanRequestRejectRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanRequestRejectResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("rejected")]
        public bool? Rejected { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanRequestsRequest
    {
    }

    public sealed class ClanRequestsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("requestedAt")]
            public string RequestedAt { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanSearchRequest
    {
        [JsonProperty("joinType")]
        public string JoinType { get; set; }

        [JsonProperty("joinable")]
        public bool? Joinable { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("minMembers")]
        public long? MinMembers { get; set; }

        [JsonProperty("offset")]
        public long? Offset { get; set; }

        [JsonProperty("q")]
        public string Q { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }
    }

    public sealed class ClanSearchResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("more")]
        public bool? More { get; set; }

        [JsonProperty("nextOffset")]
        public long? NextOffset { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("badge")]
            public JObject Badge { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("clanId")]
            public string ClanId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("coverKey")]
            public string CoverKey { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("emblemKey")]
            public string EmblemKey { get; set; }

            [JsonProperty("emblemUrl")]
            public string EmblemUrl { get; set; }

            [JsonProperty("joinType")]
            public string JoinType { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelXp")]
            public long? LevelXp { get; set; }

            [JsonProperty("maxMembers")]
            public long? MaxMembers { get; set; }

            [JsonProperty("members")]
            public long? Members { get; set; }

            [JsonProperty("minTrophies")]
            public long? MinTrophies { get; set; }

            [JsonProperty("motto")]
            public string Motto { get; set; }

            [JsonProperty("myRole")]
            public string MyRole { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextChangeAt")]
            public JToken NextChangeAt { get; set; }

            [JsonProperty("nextLevelXp")]
            public JToken NextLevelXp { get; set; }

            [JsonProperty("pendingUploads")]
            public JToken PendingUploads { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("warDraws")]
            public long? WarDraws { get; set; }

            [JsonProperty("warLosses")]
            public long? WarLosses { get; set; }

            [JsonProperty("warPoints")]
            public long? WarPoints { get; set; }

            [JsonProperty("warWins")]
            public long? WarWins { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanTransferRequest
    {
        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class ClanTransferResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("leaderId")]
        public string LeaderId { get; set; }

        [JsonProperty("role")]
        public JToken Role { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanUpdateRequest
    {
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("badge")]
        public JObject Badge { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coverKey")]
        public string CoverKey { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("emblemKey")]
        public string EmblemKey { get; set; }

        [JsonProperty("joinType")]
        public string JoinType { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("minTrophies")]
        public long? MinTrophies { get; set; }

        [JsonProperty("motto")]
        public string Motto { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }

    public sealed class ClanUpdateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clan")]
        public ClanData Clan { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClanData
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("badge")]
            public JObject Badge { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("clanId")]
            public string ClanId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("coverKey")]
            public string CoverKey { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("emblemKey")]
            public string EmblemKey { get; set; }

            [JsonProperty("emblemUrl")]
            public string EmblemUrl { get; set; }

            [JsonProperty("joinType")]
            public string JoinType { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelXp")]
            public long? LevelXp { get; set; }

            [JsonProperty("maxMembers")]
            public long? MaxMembers { get; set; }

            [JsonProperty("members")]
            public long? Members { get; set; }

            [JsonProperty("minTrophies")]
            public long? MinTrophies { get; set; }

            [JsonProperty("motto")]
            public string Motto { get; set; }

            [JsonProperty("myRole")]
            public string MyRole { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextChangeAt")]
            public JToken NextChangeAt { get; set; }

            [JsonProperty("nextLevelXp")]
            public JToken NextLevelXp { get; set; }

            [JsonProperty("pendingUploads")]
            public JToken PendingUploads { get; set; }

            [JsonProperty("tag")]
            public string Tag { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("warDraws")]
            public long? WarDraws { get; set; }

            [JsonProperty("warLosses")]
            public long? WarLosses { get; set; }

            [JsonProperty("warPoints")]
            public long? WarPoints { get; set; }

            [JsonProperty("warWins")]
            public long? WarWins { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanWarCurrentRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class ClanWarCurrentResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("upcoming")]
        public List<UpcomingItem> Upcoming { get; set; }

        [JsonProperty("wars")]
        public List<WarsItem> Wars { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class UpcomingItem
        {
            [JsonProperty("canSignUp")]
            public bool? CanSignUp { get; set; }

            [JsonProperty("configKey")]
            public string ConfigKey { get; set; }

            [JsonProperty("endsAt")]
            public string EndsAt { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("roundId")]
            public string RoundId { get; set; }

            [JsonProperty("signedUp")]
            public bool? SignedUp { get; set; }

            [JsonProperty("signup")]
            public string Signup { get; set; }

            [JsonProperty("signupAt")]
            public string SignupAt { get; set; }

            [JsonProperty("signupOpen")]
            public bool? SignupOpen { get; set; }

            [JsonProperty("startsAt")]
            public string StartsAt { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class WarsItem
        {
            [JsonProperty("attacksPerMember")]
            public JToken AttacksPerMember { get; set; }

            [JsonProperty("duel")]
            public DuelData Duel { get; set; }

            [JsonProperty("endsAt")]
            public string EndsAt { get; set; }

            [JsonProperty("inWar")]
            public bool? InWar { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("myAttacks")]
            public long? MyAttacks { get; set; }

            [JsonProperty("myAttacksLeft")]
            public JToken MyAttacksLeft { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("outcome")]
            public string Outcome { get; set; }

            [JsonProperty("points")]
            public List<PointsItem> Points { get; set; }

            [JsonProperty("prizes")]
            public PrizesData Prizes { get; set; }

            [JsonProperty("roundId")]
            public string RoundId { get; set; }

            [JsonProperty("settledAt")]
            public JToken SettledAt { get; set; }

            [JsonProperty("startsAt")]
            public string StartsAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("them")]
            public JToken Them { get; set; }

            [JsonProperty("us")]
            public JToken Us { get; set; }

            [JsonProperty("warId")]
            public string WarId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class DuelData
            {
                [JsonProperty("drawPoints")]
                public JToken DrawPoints { get; set; }

                [JsonProperty("winPoints")]
                public JToken WinPoints { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PointsItem
            {
                [JsonProperty("event")]
                public JToken Event { get; set; }

                [JsonProperty("perValue")]
                public JToken PerValue { get; set; }

                [JsonProperty("points")]
                public JToken Points { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizesData
            {
                [JsonProperty("draw")]
                public JToken Draw { get; set; }

                [JsonProperty("lose")]
                public JToken Lose { get; set; }

                [JsonProperty("to")]
                public JToken To { get; set; }

                [JsonProperty("win")]
                public JToken Win { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class ClanWarHistoryRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class ClanWarHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("outcome")]
            public string Outcome { get; set; }

            [JsonProperty("rivalClanId")]
            public string RivalClanId { get; set; }

            [JsonProperty("rivalName")]
            public string RivalName { get; set; }

            [JsonProperty("rivalScore")]
            public long? RivalScore { get; set; }

            [JsonProperty("rivalWins")]
            public long? RivalWins { get; set; }

            [JsonProperty("score")]
            public long? Score { get; set; }

            [JsonProperty("settledAt")]
            public string SettledAt { get; set; }

            [JsonProperty("warId")]
            public string WarId { get; set; }

            [JsonProperty("wins")]
            public long? Wins { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanWarOpponentsRequest
    {
        [JsonProperty("warId")]
        public string WarId { get; set; }
    }

    public sealed class ClanWarOpponentsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("endsAt")]
        public string EndsAt { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("rivalClanId")]
        public string RivalClanId { get; set; }

        [JsonProperty("warId")]
        public string WarId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("attacks")]
            public long? Attacks { get; set; }

            [JsonProperty("attacksLeft")]
            public JToken AttacksLeft { get; set; }

            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("playedByMe")]
            public bool? PlayedByMe { get; set; }

            [JsonProperty("points")]
            public long? Points { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class ClanWarSignupRequest
    {
        [JsonProperty("roundId")]
        public string RoundId { get; set; }
    }

    public sealed class ClanWarSignupResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("roundId")]
        public string RoundId { get; set; }

        [JsonProperty("signedUp")]
        public bool? SignedUp { get; set; }

        [JsonProperty("startsAt")]
        public string StartsAt { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ClanXpHistoryRequest
    {
        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class ClanXpHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CombatraceConfigRequest
    {
    }

    public sealed class CombatraceConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("game")]
        public JToken Game { get; set; }

        [JsonProperty("leaderboardId")]
        public JToken LeaderboardId { get; set; }

        [JsonProperty("rooms")]
        public List<JObject> Rooms { get; set; }

        [JsonProperty("settings")]
        public SettingsData Settings { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class SettingsData
        {
            [JsonProperty("leagueFloors")]
            public List<long?> LeagueFloors { get; set; }

            [JsonProperty("leagueMultipliers")]
            public List<double?> LeagueMultipliers { get; set; }

            [JsonProperty("levelUpPits")]
            public long? LevelUpPits { get; set; }

            [JsonProperty("maxCars")]
            public long? MaxCars { get; set; }

            [JsonProperty("maxKills")]
            public long? MaxKills { get; set; }

            [JsonProperty("maxKmh")]
            public double? MaxKmh { get; set; }

            [JsonProperty("maxLevel")]
            public long? MaxLevel { get; set; }

            [JsonProperty("maxRaceSeconds")]
            public long? MaxRaceSeconds { get; set; }

            [JsonProperty("maxZombies")]
            public long? MaxZombies { get; set; }

            [JsonProperty("minRaceSeconds")]
            public long? MinRaceSeconds { get; set; }

            [JsonProperty("oilForWin")]
            public long? OilForWin { get; set; }

            [JsonProperty("pitsByPosition")]
            public List<long?> PitsByPosition { get; set; }

            [JsonProperty("pitsForFinish")]
            public long? PitsForFinish { get; set; }

            [JsonProperty("pitsPerKill")]
            public long? PitsPerKill { get; set; }

            [JsonProperty("pitsPerZombie")]
            public long? PitsPerZombie { get; set; }

            [JsonProperty("ticketMinutes")]
            public long? TicketMinutes { get; set; }

            [JsonProperty("trophiesByPosition")]
            public List<long?> TrophiesByPosition { get; set; }

            [JsonProperty("xpByPosition")]
            public List<long?> XpByPosition { get; set; }

            [JsonProperty("xpFirstLevel")]
            public long? XpFirstLevel { get; set; }

            [JsonProperty("xpLevelStep")]
            public long? XpLevelStep { get; set; }

            [JsonProperty("xpPerZombie")]
            public long? XpPerZombie { get; set; }

            [JsonProperty("xpZombieCap")]
            public long? XpZombieCap { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CombatraceEventsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class CombatraceEventsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimable")]
        public long? Claimable { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("claimable")]
            public bool? Claimable { get; set; }

            [JsonProperty("claimed")]
            public bool? Claimed { get; set; }

            [JsonProperty("done")]
            public bool? Done { get; set; }

            [JsonProperty("endsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("goal")]
            public double? Goal { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("oil")]
            public long? Oil { get; set; }

            [JsonProperty("perMatch")]
            public bool? PerMatch { get; set; }

            [JsonProperty("pits")]
            public long? Pits { get; set; }

            [JsonProperty("progress")]
            public double? Progress { get; set; }

            [JsonProperty("repeat")]
            public string Repeat { get; set; }

            [JsonProperty("secondsLeft")]
            public long? SecondsLeft { get; set; }

            [JsonProperty("startsAt")]
            public JToken StartsAt { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("weapon")]
            public string Weapon { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CombatraceHistoryRequest
    {
        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class CombatraceHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("trophies")]
        public double? Trophies { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("endedAt")]
            public JToken EndedAt { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("rewards")]
            public JToken Rewards { get; set; }

            [JsonProperty("room")]
            public string Room { get; set; }

            [JsonProperty("startedAt")]
            public JToken StartedAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("ticket")]
            public string Ticket { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CombatraceMatchBeginRequest
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }
    }

    public sealed class CombatraceMatchBeginResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("entry")]
        public JToken Entry { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("resumed")]
        public bool? Resumed { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("settings")]
        public SettingsData Settings { get; set; }

        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class SettingsData
        {
            [JsonProperty("leagueFloors")]
            public List<long?> LeagueFloors { get; set; }

            [JsonProperty("leagueMultipliers")]
            public List<double?> LeagueMultipliers { get; set; }

            [JsonProperty("levelUpPits")]
            public long? LevelUpPits { get; set; }

            [JsonProperty("maxCars")]
            public long? MaxCars { get; set; }

            [JsonProperty("maxKills")]
            public long? MaxKills { get; set; }

            [JsonProperty("maxKmh")]
            public double? MaxKmh { get; set; }

            [JsonProperty("maxLevel")]
            public long? MaxLevel { get; set; }

            [JsonProperty("maxRaceSeconds")]
            public long? MaxRaceSeconds { get; set; }

            [JsonProperty("maxZombies")]
            public long? MaxZombies { get; set; }

            [JsonProperty("minRaceSeconds")]
            public long? MinRaceSeconds { get; set; }

            [JsonProperty("oilForWin")]
            public long? OilForWin { get; set; }

            [JsonProperty("pitsByPosition")]
            public List<long?> PitsByPosition { get; set; }

            [JsonProperty("pitsForFinish")]
            public long? PitsForFinish { get; set; }

            [JsonProperty("pitsPerKill")]
            public long? PitsPerKill { get; set; }

            [JsonProperty("pitsPerZombie")]
            public long? PitsPerZombie { get; set; }

            [JsonProperty("ticketMinutes")]
            public long? TicketMinutes { get; set; }

            [JsonProperty("trophiesByPosition")]
            public List<long?> TrophiesByPosition { get; set; }

            [JsonProperty("xpByPosition")]
            public List<long?> XpByPosition { get; set; }

            [JsonProperty("xpFirstLevel")]
            public long? XpFirstLevel { get; set; }

            [JsonProperty("xpLevelStep")]
            public long? XpLevelStep { get; set; }

            [JsonProperty("xpPerZombie")]
            public long? XpPerZombie { get; set; }

            [JsonProperty("xpZombieCap")]
            public long? XpZombieCap { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CombatraceMatchEndRequest
    {
        [JsonProperty("cars")]
        public long? Cars { get; set; }

        [JsonProperty("finished")]
        public bool? Finished { get; set; }

        [JsonProperty("kills")]
        public long? Kills { get; set; }

        [JsonProperty("maxKmh")]
        public double? MaxKmh { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }

        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonProperty("timeMs")]
        public long? TimeMs { get; set; }

        [JsonProperty("weapons")]
        public JObject Weapons { get; set; }

        [JsonProperty("zombies")]
        public long? Zombies { get; set; }
    }

    public sealed class CombatraceMatchEndResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accepted")]
        public bool? Accepted { get; set; }

        [JsonProperty("clamped")]
        public bool? Clamped { get; set; }

        [JsonProperty("finishPits")]
        public long? FinishPits { get; set; }

        [JsonProperty("imported")]
        public bool? Imported { get; set; }

        [JsonProperty("killPits")]
        public long? KillPits { get; set; }

        [JsonProperty("kills")]
        public long? Kills { get; set; }

        [JsonProperty("league")]
        public long? League { get; set; }

        [JsonProperty("leagueBefore")]
        public long? LeagueBefore { get; set; }

        [JsonProperty("leagueFloor")]
        public double? LeagueFloor { get; set; }

        [JsonProperty("leagueMultiplier")]
        public double? LeagueMultiplier { get; set; }

        [JsonProperty("leagueName")]
        public JToken LeagueName { get; set; }

        [JsonProperty("leagueStart")]
        public double? LeagueStart { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("levelUpPits")]
        public long? LevelUpPits { get; set; }

        [JsonProperty("levelUpPrizes")]
        public List<string> LevelUpPrizes { get; set; }

        [JsonProperty("levelUps")]
        public List<long?> LevelUps { get; set; }

        [JsonProperty("maxLevel")]
        public long? MaxLevel { get; set; }

        [JsonProperty("nextLeagueAt")]
        public double? NextLeagueAt { get; set; }

        [JsonProperty("payouts")]
        public JToken Payouts { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }

        [JsonProperty("positionPits")]
        public long? PositionPits { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("rewards")]
        public RewardsData Rewards { get; set; }

        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonProperty("trophies")]
        public double? Trophies { get; set; }

        [JsonProperty("xp")]
        public long? Xp { get; set; }

        [JsonProperty("xpForNext")]
        public long? XpForNext { get; set; }

        [JsonProperty("xpGained")]
        public double? XpGained { get; set; }

        [JsonProperty("xpIntoLevel")]
        public long? XpIntoLevel { get; set; }

        [JsonProperty("zombiePits")]
        public long? ZombiePits { get; set; }

        [JsonProperty("zombies")]
        public long? Zombies { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardsData
        {
            [JsonProperty("finishPits")]
            public long? FinishPits { get; set; }

            [JsonProperty("killPits")]
            public double? KillPits { get; set; }

            [JsonProperty("kills")]
            public JToken Kills { get; set; }

            [JsonProperty("leagueMultiplier")]
            public double? LeagueMultiplier { get; set; }

            [JsonProperty("oil")]
            public long? Oil { get; set; }

            [JsonProperty("pits")]
            public long? Pits { get; set; }

            [JsonProperty("positionPits")]
            public long? PositionPits { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("xp")]
            public double? Xp { get; set; }

            [JsonProperty("zombiePits")]
            public double? ZombiePits { get; set; }

            [JsonProperty("zombies")]
            public JToken Zombies { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CombatraceMissionsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class CombatraceMissionsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimable")]
        public long? Claimable { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("claimable")]
            public bool? Claimable { get; set; }

            [JsonProperty("claimed")]
            public bool? Claimed { get; set; }

            [JsonProperty("done")]
            public bool? Done { get; set; }

            [JsonProperty("endsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("goal")]
            public double? Goal { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("oil")]
            public long? Oil { get; set; }

            [JsonProperty("perMatch")]
            public bool? PerMatch { get; set; }

            [JsonProperty("pits")]
            public long? Pits { get; set; }

            [JsonProperty("progress")]
            public double? Progress { get; set; }

            [JsonProperty("repeat")]
            public string Repeat { get; set; }

            [JsonProperty("secondsLeft")]
            public long? SecondsLeft { get; set; }

            [JsonProperty("startsAt")]
            public JToken StartsAt { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("weapon")]
            public string Weapon { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CombatraceProfileRequest
    {
    }

    public sealed class CombatraceProfileResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("imported")]
        public bool? Imported { get; set; }

        [JsonProperty("league")]
        public long? League { get; set; }

        [JsonProperty("leagueFloor")]
        public double? LeagueFloor { get; set; }

        [JsonProperty("leagueName")]
        public JToken LeagueName { get; set; }

        [JsonProperty("leagueStart")]
        public double? LeagueStart { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("levelUpPits")]
        public long? LevelUpPits { get; set; }

        [JsonProperty("levelUpPrizes")]
        public List<string> LevelUpPrizes { get; set; }

        [JsonProperty("levelUps")]
        public List<long?> LevelUps { get; set; }

        [JsonProperty("maxLevel")]
        public long? MaxLevel { get; set; }

        [JsonProperty("nextLeagueAt")]
        public double? NextLeagueAt { get; set; }

        [JsonProperty("trophies")]
        public double? Trophies { get; set; }

        [JsonProperty("xp")]
        public long? Xp { get; set; }

        [JsonProperty("xpForNext")]
        public long? XpForNext { get; set; }

        [JsonProperty("xpIntoLevel")]
        public long? XpIntoLevel { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class CombatraceTaskClaimRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class CombatraceTaskClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimId")]
        public JToken ClaimId { get; set; }

        [JsonProperty("claimed")]
        public bool? Claimed { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("imported")]
        public bool? Imported { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("levelUpPits")]
        public long? LevelUpPits { get; set; }

        [JsonProperty("levelUpPrizes")]
        public List<string> LevelUpPrizes { get; set; }

        [JsonProperty("levelUps")]
        public List<long?> LevelUps { get; set; }

        [JsonProperty("maxLevel")]
        public long? MaxLevel { get; set; }

        [JsonProperty("oil")]
        public long? Oil { get; set; }

        [JsonProperty("pits")]
        public long? Pits { get; set; }

        [JsonProperty("rewards")]
        public JToken Rewards { get; set; }

        [JsonProperty("xp")]
        public long? Xp { get; set; }

        [JsonProperty("xpForNext")]
        public long? XpForNext { get; set; }

        [JsonProperty("xpIntoLevel")]
        public long? XpIntoLevel { get; set; }

        [JsonProperty("xpReward")]
        public long? XpReward { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class CommsUserTokenRequest
    {
    }

    public sealed class CommsUserTokenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("appId")]
        public JToken AppId { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("token")]
        public JToken Token { get; set; }

        [JsonProperty("url")]
        public JToken Url { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ContentCatalogRequest
    {
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }
    }

    public sealed class ContentCatalogResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("pack")]
        public PackData Pack { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PackData
        {
            [JsonProperty("activatedAt")]
            public string ActivatedAt { get; set; }

            [JsonProperty("baseUrl")]
            public string BaseUrl { get; set; }

            [JsonProperty("catalogHash")]
            public string CatalogHash { get; set; }

            [JsonProperty("catalogPath")]
            public string CatalogPath { get; set; }

            [JsonProperty("catalogUrl")]
            public string CatalogUrl { get; set; }

            [JsonProperty("fileCount")]
            public long? FileCount { get; set; }

            [JsonProperty("hashUrl")]
            public string HashUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("kind")]
            public JToken Kind { get; set; }

            [JsonProperty("maxAppVersion")]
            public string MaxAppVersion { get; set; }

            [JsonProperty("minAppVersion")]
            public string MinAppVersion { get; set; }

            [JsonProperty("platform")]
            public string Platform { get; set; }

            [JsonProperty("totalBytes")]
            public long? TotalBytes { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CupGetRequest
    {
        [JsonProperty("cupId")]
        public string CupId { get; set; }
    }

    public sealed class CupGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("bracket")]
        public BracketData Bracket { get; set; }

        [JsonProperty("champion")]
        public JObject Champion { get; set; }

        [JsonProperty("cup")]
        public CupData Cup { get; set; }

        [JsonProperty("myMatch")]
        public JObject MyMatch { get; set; }

        [JsonProperty("standings")]
        public List<StandingsItem> Standings { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class BracketData
        {
            [JsonProperty("rounds")]
            public List<RoundsItem> Rounds { get; set; }

            [JsonProperty("size")]
            public long? Size { get; set; }

            [JsonProperty("third")]
            public JObject Third { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RoundsItem
            {
                [JsonProperty("bestOf")]
                public JToken BestOf { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("matches")]
                public List<MatchesItem> Matches { get; set; }

                [JsonProperty("players")]
                public JToken Players { get; set; }

                [JsonProperty("round")]
                public long? Round { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class MatchesItem
                {
                    [JsonProperty("a")]
                    public AData A { get; set; }

                    [JsonProperty("b")]
                    public BData B { get; set; }

                    [JsonProperty("bestOf")]
                    public long? BestOf { get; set; }

                    [JsonProperty("closesAt")]
                    public string ClosesAt { get; set; }

                    [JsonProperty("draws")]
                    public long? Draws { get; set; }

                    [JsonProperty("finishedAt")]
                    public string FinishedAt { get; set; }

                    [JsonProperty("gameMatchId")]
                    public string GameMatchId { get; set; }

                    [JsonProperty("gameNo")]
                    public long? GameNo { get; set; }

                    [JsonProperty("games")]
                    public List<GamesItem> Games { get; set; }

                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("kind")]
                    public string Kind { get; set; }

                    [JsonProperty("loserId")]
                    public string LoserId { get; set; }

                    [JsonProperty("next")]
                    public JObject Next { get; set; }

                    [JsonProperty("opensAt")]
                    public string OpensAt { get; set; }

                    [JsonProperty("reason")]
                    public string Reason { get; set; }

                    [JsonProperty("round")]
                    public long? Round { get; set; }

                    [JsonProperty("roundKey")]
                    public string RoundKey { get; set; }

                    [JsonProperty("slot")]
                    public long? Slot { get; set; }

                    [JsonProperty("startsAt")]
                    public string StartsAt { get; set; }

                    [JsonProperty("status")]
                    public string Status { get; set; }

                    [JsonProperty("winnerId")]
                    public string WinnerId { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class AData
                    {
                        [JsonProperty("avatarUrl")]
                        public JToken AvatarUrl { get; set; }

                        [JsonProperty("displayName")]
                        public JToken DisplayName { get; set; }

                        [JsonProperty("ready")]
                        public JToken Ready { get; set; }

                        [JsonProperty("seed")]
                        public long? Seed { get; set; }

                        [JsonProperty("showed")]
                        public bool? Showed { get; set; }

                        [JsonProperty("status")]
                        public string Status { get; set; }

                        [JsonProperty("userId")]
                        public string UserId { get; set; }

                        [JsonProperty("username")]
                        public JToken Username { get; set; }

                        [JsonProperty("wins")]
                        public long? Wins { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }

                    public sealed class BData
                    {
                        [JsonProperty("avatarUrl")]
                        public JToken AvatarUrl { get; set; }

                        [JsonProperty("displayName")]
                        public JToken DisplayName { get; set; }

                        [JsonProperty("ready")]
                        public JToken Ready { get; set; }

                        [JsonProperty("seed")]
                        public long? Seed { get; set; }

                        [JsonProperty("showed")]
                        public bool? Showed { get; set; }

                        [JsonProperty("status")]
                        public string Status { get; set; }

                        [JsonProperty("userId")]
                        public string UserId { get; set; }

                        [JsonProperty("username")]
                        public JToken Username { get; set; }

                        [JsonProperty("wins")]
                        public long? Wins { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }

                    public sealed class GamesItem
                    {
                        [JsonProperty("createdAt")]
                        public string CreatedAt { get; set; }

                        [JsonProperty("draw")]
                        public JToken Draw { get; set; }

                        [JsonProperty("finishedAt")]
                        public string FinishedAt { get; set; }

                        [JsonProperty("no")]
                        public JToken No { get; set; }

                        [JsonProperty("reason")]
                        public JToken Reason { get; set; }

                        [JsonProperty("score")]
                        public JToken Score { get; set; }

                        [JsonProperty("status")]
                        public JToken Status { get; set; }

                        [JsonProperty("winnerId")]
                        public JToken WinnerId { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }
            }
        }

        public sealed class CupData
        {
            [JsonProperty("bestOf")]
            public JToken BestOf { get; set; }

            [JsonProperty("cancelReason")]
            public string CancelReason { get; set; }

            [JsonProperty("capacity")]
            public JToken Capacity { get; set; }

            [JsonProperty("championId")]
            public string ChampionId { get; set; }

            [JsonProperty("currentRound")]
            public long? CurrentRound { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("fee")]
            public FeeData Fee { get; set; }

            [JsonProperty("finishedAt")]
            public string FinishedAt { get; set; }

            [JsonProperty("game")]
            public JToken Game { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("me")]
            public MeData Me { get; set; }

            [JsonProperty("minPlayers")]
            public JToken MinPlayers { get; set; }

            [JsonProperty("mode")]
            public JToken Mode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("players")]
            public long? Players { get; set; }

            [JsonProperty("prizes")]
            public PrizesData Prizes { get; set; }

            [JsonProperty("rated")]
            public JToken Rated { get; set; }

            [JsonProperty("requirements")]
            public RequirementsData Requirements { get; set; }

            [JsonProperty("rounds")]
            public long? Rounds { get; set; }

            [JsonProperty("seeding")]
            public JToken Seeding { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("signupAt")]
            public string SignupAt { get; set; }

            [JsonProperty("size")]
            public long? Size { get; set; }

            [JsonProperty("startedAt")]
            public string StartedAt { get; set; }

            [JsonProperty("startsAt")]
            public string StartsAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("templateKey")]
            public string TemplateKey { get; set; }

            [JsonProperty("thirdPlace")]
            public JToken ThirdPlace { get; set; }

            [JsonProperty("timing")]
            public TimingData Timing { get; set; }

            [JsonProperty("withdrawRefundPercent")]
            public JToken WithdrawRefundPercent { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class FeeData
            {
                [JsonProperty("amount")]
                public JToken Amount { get; set; }

                [JsonProperty("currencyKey")]
                public JToken CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class MeData
            {
                [JsonProperty("canSignUp")]
                public bool? CanSignUp { get; set; }

                [JsonProperty("canWithdraw")]
                public bool? CanWithdraw { get; set; }

                [JsonProperty("place")]
                public long? Place { get; set; }

                [JsonProperty("reached")]
                public long? Reached { get; set; }

                [JsonProperty("registered")]
                public bool? Registered { get; set; }

                [JsonProperty("seed")]
                public long? Seed { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizesData
            {
                [JsonProperty("champion")]
                public JToken Champion { get; set; }

                [JsonProperty("fourth")]
                public JToken Fourth { get; set; }

                [JsonProperty("pool")]
                public PoolData Pool { get; set; }

                [JsonProperty("reached")]
                public List<ReachedItem> Reached { get; set; }

                [JsonProperty("runnerUp")]
                public JToken RunnerUp { get; set; }

                [JsonProperty("semi")]
                public JToken Semi { get; set; }

                [JsonProperty("third")]
                public JToken Third { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class PoolData
                {
                    [JsonProperty("amount")]
                    public JToken Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public JToken CurrencyKey { get; set; }

                    [JsonProperty("percent")]
                    public JToken Percent { get; set; }

                    [JsonProperty("shares")]
                    public SharesData Shares { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class SharesData
                    {
                        [JsonProperty("champion")]
                        public JToken Champion { get; set; }

                        [JsonProperty("fourth")]
                        public JToken Fourth { get; set; }

                        [JsonProperty("runnerUp")]
                        public JToken RunnerUp { get; set; }

                        [JsonProperty("semi")]
                        public JToken Semi { get; set; }

                        [JsonProperty("third")]
                        public JToken Third { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class ReachedItem
                {
                    [JsonProperty("prizeKey")]
                    public JToken PrizeKey { get; set; }

                    [JsonProperty("round")]
                    public JToken Round { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class RequirementsData
            {
                [JsonProperty("excludeTagIds")]
                public JToken ExcludeTagIds { get; set; }

                [JsonProperty("leagues")]
                public JToken Leagues { get; set; }

                [JsonProperty("maxTrophies")]
                public JToken MaxTrophies { get; set; }

                [JsonProperty("minTrophies")]
                public JToken MinTrophies { get; set; }

                [JsonProperty("tagIds")]
                public JToken TagIds { get; set; }

                [JsonProperty("tagsMode")]
                public JToken TagsMode { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class TimingData
            {
                [JsonProperty("checkInMinutes")]
                public JToken CheckInMinutes { get; set; }

                [JsonProperty("mode")]
                public JToken Mode { get; set; }

                [JsonProperty("readySeconds")]
                public JToken ReadySeconds { get; set; }

                [JsonProperty("roundMinutes")]
                public JToken RoundMinutes { get; set; }

                [JsonProperty("windowMinutes")]
                public JToken WindowMinutes { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StandingsItem
        {
            [JsonProperty("displayName")]
            public JToken DisplayName { get; set; }

            [JsonProperty("place")]
            public JToken Place { get; set; }

            [JsonProperty("seed")]
            public JToken Seed { get; set; }

            [JsonProperty("userId")]
            public JToken UserId { get; set; }

            [JsonProperty("username")]
            public JToken Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CupHistoryRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class CupHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("cupId")]
            public string CupId { get; set; }

            [JsonProperty("finishedAt")]
            public string FinishedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("payouts")]
            public List<PayoutsItem> Payouts { get; set; }

            [JsonProperty("place")]
            public long? Place { get; set; }

            [JsonProperty("playerStatus")]
            public string PlayerStatus { get; set; }

            [JsonProperty("players")]
            public long? Players { get; set; }

            [JsonProperty("reached")]
            public long? Reached { get; set; }

            [JsonProperty("seed")]
            public long? Seed { get; set; }

            [JsonProperty("startsAt")]
            public string StartsAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PayoutsItem
            {
                [JsonProperty("amounts")]
                public JObject Amounts { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("prizeKey")]
                public string PrizeKey { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class CupListRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("offset")]
        public long? Offset { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public sealed class CupListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("more")]
        public bool? More { get; set; }

        [JsonProperty("offset")]
        public long? Offset { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("bestOf")]
            public JToken BestOf { get; set; }

            [JsonProperty("cancelReason")]
            public string CancelReason { get; set; }

            [JsonProperty("capacity")]
            public JToken Capacity { get; set; }

            [JsonProperty("championId")]
            public string ChampionId { get; set; }

            [JsonProperty("currentRound")]
            public long? CurrentRound { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("fee")]
            public FeeData Fee { get; set; }

            [JsonProperty("finishedAt")]
            public string FinishedAt { get; set; }

            [JsonProperty("game")]
            public JToken Game { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("me")]
            public MeData Me { get; set; }

            [JsonProperty("minPlayers")]
            public JToken MinPlayers { get; set; }

            [JsonProperty("mode")]
            public JToken Mode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("players")]
            public long? Players { get; set; }

            [JsonProperty("prizes")]
            public PrizesData Prizes { get; set; }

            [JsonProperty("rated")]
            public JToken Rated { get; set; }

            [JsonProperty("requirements")]
            public RequirementsData Requirements { get; set; }

            [JsonProperty("rounds")]
            public long? Rounds { get; set; }

            [JsonProperty("seeding")]
            public JToken Seeding { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("signupAt")]
            public string SignupAt { get; set; }

            [JsonProperty("size")]
            public long? Size { get; set; }

            [JsonProperty("startedAt")]
            public string StartedAt { get; set; }

            [JsonProperty("startsAt")]
            public string StartsAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("templateKey")]
            public string TemplateKey { get; set; }

            [JsonProperty("thirdPlace")]
            public JToken ThirdPlace { get; set; }

            [JsonProperty("timing")]
            public TimingData Timing { get; set; }

            [JsonProperty("withdrawRefundPercent")]
            public JToken WithdrawRefundPercent { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class FeeData
            {
                [JsonProperty("amount")]
                public JToken Amount { get; set; }

                [JsonProperty("currencyKey")]
                public JToken CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class MeData
            {
                [JsonProperty("canSignUp")]
                public bool? CanSignUp { get; set; }

                [JsonProperty("canWithdraw")]
                public bool? CanWithdraw { get; set; }

                [JsonProperty("place")]
                public long? Place { get; set; }

                [JsonProperty("reached")]
                public long? Reached { get; set; }

                [JsonProperty("registered")]
                public bool? Registered { get; set; }

                [JsonProperty("seed")]
                public long? Seed { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizesData
            {
                [JsonProperty("champion")]
                public JToken Champion { get; set; }

                [JsonProperty("fourth")]
                public JToken Fourth { get; set; }

                [JsonProperty("pool")]
                public PoolData Pool { get; set; }

                [JsonProperty("reached")]
                public List<ReachedItem> Reached { get; set; }

                [JsonProperty("runnerUp")]
                public JToken RunnerUp { get; set; }

                [JsonProperty("semi")]
                public JToken Semi { get; set; }

                [JsonProperty("third")]
                public JToken Third { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class PoolData
                {
                    [JsonProperty("amount")]
                    public JToken Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public JToken CurrencyKey { get; set; }

                    [JsonProperty("percent")]
                    public JToken Percent { get; set; }

                    [JsonProperty("shares")]
                    public SharesData Shares { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class SharesData
                    {
                        [JsonProperty("champion")]
                        public JToken Champion { get; set; }

                        [JsonProperty("fourth")]
                        public JToken Fourth { get; set; }

                        [JsonProperty("runnerUp")]
                        public JToken RunnerUp { get; set; }

                        [JsonProperty("semi")]
                        public JToken Semi { get; set; }

                        [JsonProperty("third")]
                        public JToken Third { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class ReachedItem
                {
                    [JsonProperty("prizeKey")]
                    public JToken PrizeKey { get; set; }

                    [JsonProperty("round")]
                    public JToken Round { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class RequirementsData
            {
                [JsonProperty("excludeTagIds")]
                public JToken ExcludeTagIds { get; set; }

                [JsonProperty("leagues")]
                public JToken Leagues { get; set; }

                [JsonProperty("maxTrophies")]
                public JToken MaxTrophies { get; set; }

                [JsonProperty("minTrophies")]
                public JToken MinTrophies { get; set; }

                [JsonProperty("tagIds")]
                public JToken TagIds { get; set; }

                [JsonProperty("tagsMode")]
                public JToken TagsMode { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class TimingData
            {
                [JsonProperty("checkInMinutes")]
                public JToken CheckInMinutes { get; set; }

                [JsonProperty("mode")]
                public JToken Mode { get; set; }

                [JsonProperty("readySeconds")]
                public JToken ReadySeconds { get; set; }

                [JsonProperty("roundMinutes")]
                public JToken RoundMinutes { get; set; }

                [JsonProperty("windowMinutes")]
                public JToken WindowMinutes { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class CupMyMatchRequest
    {
        [JsonProperty("cupId")]
        public string CupId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class CupMyMatchResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("cupId")]
            public JToken CupId { get; set; }

            [JsonProperty("cupName")]
            public string CupName { get; set; }

            [JsonProperty("cupStatus")]
            public JToken CupStatus { get; set; }

            [JsonProperty("match")]
            public JObject Match { get; set; }

            [JsonProperty("playerStatus")]
            public string PlayerStatus { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class CupReadyRequest
    {
        [JsonProperty("cupId")]
        public string CupId { get; set; }
    }

    public sealed class CupReadyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("gameMatchId")]
        public string GameMatchId { get; set; }

        [JsonProperty("gameNo")]
        public long? GameNo { get; set; }

        [JsonProperty("launched")]
        public bool? Launched { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class CupSignupRequest
    {
        [JsonProperty("cupId")]
        public string CupId { get; set; }
    }

    public sealed class CupSignupResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cup")]
        public CupData Cup { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CupData
        {
            [JsonProperty("bestOf")]
            public JToken BestOf { get; set; }

            [JsonProperty("cancelReason")]
            public string CancelReason { get; set; }

            [JsonProperty("capacity")]
            public JToken Capacity { get; set; }

            [JsonProperty("championId")]
            public string ChampionId { get; set; }

            [JsonProperty("currentRound")]
            public long? CurrentRound { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("fee")]
            public FeeData Fee { get; set; }

            [JsonProperty("finishedAt")]
            public string FinishedAt { get; set; }

            [JsonProperty("game")]
            public JToken Game { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("me")]
            public MeData Me { get; set; }

            [JsonProperty("minPlayers")]
            public JToken MinPlayers { get; set; }

            [JsonProperty("mode")]
            public JToken Mode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("players")]
            public long? Players { get; set; }

            [JsonProperty("prizes")]
            public PrizesData Prizes { get; set; }

            [JsonProperty("rated")]
            public JToken Rated { get; set; }

            [JsonProperty("requirements")]
            public RequirementsData Requirements { get; set; }

            [JsonProperty("rounds")]
            public long? Rounds { get; set; }

            [JsonProperty("seeding")]
            public JToken Seeding { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("signupAt")]
            public string SignupAt { get; set; }

            [JsonProperty("size")]
            public long? Size { get; set; }

            [JsonProperty("startedAt")]
            public string StartedAt { get; set; }

            [JsonProperty("startsAt")]
            public string StartsAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("templateKey")]
            public string TemplateKey { get; set; }

            [JsonProperty("thirdPlace")]
            public JToken ThirdPlace { get; set; }

            [JsonProperty("timing")]
            public TimingData Timing { get; set; }

            [JsonProperty("withdrawRefundPercent")]
            public JToken WithdrawRefundPercent { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class FeeData
            {
                [JsonProperty("amount")]
                public JToken Amount { get; set; }

                [JsonProperty("currencyKey")]
                public JToken CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class MeData
            {
                [JsonProperty("canSignUp")]
                public bool? CanSignUp { get; set; }

                [JsonProperty("canWithdraw")]
                public bool? CanWithdraw { get; set; }

                [JsonProperty("place")]
                public long? Place { get; set; }

                [JsonProperty("reached")]
                public long? Reached { get; set; }

                [JsonProperty("registered")]
                public bool? Registered { get; set; }

                [JsonProperty("seed")]
                public long? Seed { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizesData
            {
                [JsonProperty("champion")]
                public JToken Champion { get; set; }

                [JsonProperty("fourth")]
                public JToken Fourth { get; set; }

                [JsonProperty("pool")]
                public PoolData Pool { get; set; }

                [JsonProperty("reached")]
                public List<ReachedItem> Reached { get; set; }

                [JsonProperty("runnerUp")]
                public JToken RunnerUp { get; set; }

                [JsonProperty("semi")]
                public JToken Semi { get; set; }

                [JsonProperty("third")]
                public JToken Third { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class PoolData
                {
                    [JsonProperty("amount")]
                    public JToken Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public JToken CurrencyKey { get; set; }

                    [JsonProperty("percent")]
                    public JToken Percent { get; set; }

                    [JsonProperty("shares")]
                    public SharesData Shares { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class SharesData
                    {
                        [JsonProperty("champion")]
                        public JToken Champion { get; set; }

                        [JsonProperty("fourth")]
                        public JToken Fourth { get; set; }

                        [JsonProperty("runnerUp")]
                        public JToken RunnerUp { get; set; }

                        [JsonProperty("semi")]
                        public JToken Semi { get; set; }

                        [JsonProperty("third")]
                        public JToken Third { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class ReachedItem
                {
                    [JsonProperty("prizeKey")]
                    public JToken PrizeKey { get; set; }

                    [JsonProperty("round")]
                    public JToken Round { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class RequirementsData
            {
                [JsonProperty("excludeTagIds")]
                public JToken ExcludeTagIds { get; set; }

                [JsonProperty("leagues")]
                public JToken Leagues { get; set; }

                [JsonProperty("maxTrophies")]
                public JToken MaxTrophies { get; set; }

                [JsonProperty("minTrophies")]
                public JToken MinTrophies { get; set; }

                [JsonProperty("tagIds")]
                public JToken TagIds { get; set; }

                [JsonProperty("tagsMode")]
                public JToken TagsMode { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class TimingData
            {
                [JsonProperty("checkInMinutes")]
                public JToken CheckInMinutes { get; set; }

                [JsonProperty("mode")]
                public JToken Mode { get; set; }

                [JsonProperty("readySeconds")]
                public JToken ReadySeconds { get; set; }

                [JsonProperty("roundMinutes")]
                public JToken RoundMinutes { get; set; }

                [JsonProperty("windowMinutes")]
                public JToken WindowMinutes { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class CupStartRequest
    {
        [JsonProperty("cupId")]
        public string CupId { get; set; }
    }

    public sealed class CupStartResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("gameMatchId")]
        public string GameMatchId { get; set; }

        [JsonProperty("gameNo")]
        public long? GameNo { get; set; }

        [JsonProperty("launched")]
        public bool? Launched { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class CupWithdrawRequest
    {
        [JsonProperty("cupId")]
        public string CupId { get; set; }
    }

    public sealed class CupWithdrawResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cup")]
        public CupData Cup { get; set; }

        [JsonProperty("refunded")]
        public RefundedData Refunded { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CupData
        {
            [JsonProperty("bestOf")]
            public JToken BestOf { get; set; }

            [JsonProperty("cancelReason")]
            public string CancelReason { get; set; }

            [JsonProperty("capacity")]
            public JToken Capacity { get; set; }

            [JsonProperty("championId")]
            public string ChampionId { get; set; }

            [JsonProperty("currentRound")]
            public long? CurrentRound { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("fee")]
            public FeeData Fee { get; set; }

            [JsonProperty("finishedAt")]
            public string FinishedAt { get; set; }

            [JsonProperty("game")]
            public JToken Game { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("me")]
            public MeData Me { get; set; }

            [JsonProperty("minPlayers")]
            public JToken MinPlayers { get; set; }

            [JsonProperty("mode")]
            public JToken Mode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("players")]
            public long? Players { get; set; }

            [JsonProperty("prizes")]
            public PrizesData Prizes { get; set; }

            [JsonProperty("rated")]
            public JToken Rated { get; set; }

            [JsonProperty("requirements")]
            public RequirementsData Requirements { get; set; }

            [JsonProperty("rounds")]
            public long? Rounds { get; set; }

            [JsonProperty("seeding")]
            public JToken Seeding { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("signupAt")]
            public string SignupAt { get; set; }

            [JsonProperty("size")]
            public long? Size { get; set; }

            [JsonProperty("startedAt")]
            public string StartedAt { get; set; }

            [JsonProperty("startsAt")]
            public string StartsAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("templateKey")]
            public string TemplateKey { get; set; }

            [JsonProperty("thirdPlace")]
            public JToken ThirdPlace { get; set; }

            [JsonProperty("timing")]
            public TimingData Timing { get; set; }

            [JsonProperty("withdrawRefundPercent")]
            public JToken WithdrawRefundPercent { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class FeeData
            {
                [JsonProperty("amount")]
                public JToken Amount { get; set; }

                [JsonProperty("currencyKey")]
                public JToken CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class MeData
            {
                [JsonProperty("canSignUp")]
                public bool? CanSignUp { get; set; }

                [JsonProperty("canWithdraw")]
                public bool? CanWithdraw { get; set; }

                [JsonProperty("place")]
                public long? Place { get; set; }

                [JsonProperty("reached")]
                public long? Reached { get; set; }

                [JsonProperty("registered")]
                public bool? Registered { get; set; }

                [JsonProperty("seed")]
                public long? Seed { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizesData
            {
                [JsonProperty("champion")]
                public JToken Champion { get; set; }

                [JsonProperty("fourth")]
                public JToken Fourth { get; set; }

                [JsonProperty("pool")]
                public PoolData Pool { get; set; }

                [JsonProperty("reached")]
                public List<ReachedItem> Reached { get; set; }

                [JsonProperty("runnerUp")]
                public JToken RunnerUp { get; set; }

                [JsonProperty("semi")]
                public JToken Semi { get; set; }

                [JsonProperty("third")]
                public JToken Third { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class PoolData
                {
                    [JsonProperty("amount")]
                    public JToken Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public JToken CurrencyKey { get; set; }

                    [JsonProperty("percent")]
                    public JToken Percent { get; set; }

                    [JsonProperty("shares")]
                    public SharesData Shares { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class SharesData
                    {
                        [JsonProperty("champion")]
                        public JToken Champion { get; set; }

                        [JsonProperty("fourth")]
                        public JToken Fourth { get; set; }

                        [JsonProperty("runnerUp")]
                        public JToken RunnerUp { get; set; }

                        [JsonProperty("semi")]
                        public JToken Semi { get; set; }

                        [JsonProperty("third")]
                        public JToken Third { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class ReachedItem
                {
                    [JsonProperty("prizeKey")]
                    public JToken PrizeKey { get; set; }

                    [JsonProperty("round")]
                    public JToken Round { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class RequirementsData
            {
                [JsonProperty("excludeTagIds")]
                public JToken ExcludeTagIds { get; set; }

                [JsonProperty("leagues")]
                public JToken Leagues { get; set; }

                [JsonProperty("maxTrophies")]
                public JToken MaxTrophies { get; set; }

                [JsonProperty("minTrophies")]
                public JToken MinTrophies { get; set; }

                [JsonProperty("tagIds")]
                public JToken TagIds { get; set; }

                [JsonProperty("tagsMode")]
                public JToken TagsMode { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class TimingData
            {
                [JsonProperty("checkInMinutes")]
                public JToken CheckInMinutes { get; set; }

                [JsonProperty("mode")]
                public JToken Mode { get; set; }

                [JsonProperty("readySeconds")]
                public JToken ReadySeconds { get; set; }

                [JsonProperty("roundMinutes")]
                public JToken RoundMinutes { get; set; }

                [JsonProperty("windowMinutes")]
                public JToken WindowMinutes { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class RefundedData
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonProperty("percent")]
            public JToken Percent { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class DevkitErrorCatalogRequest
    {
        [JsonProperty("codes")]
        public List<string> Codes { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class DevkitErrorCatalogResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cacheSeconds")]
        public long? CacheSeconds { get; set; }

        [JsonProperty("errors")]
        public JObject Errors { get; set; }

        [JsonProperty("fallbackLang")]
        public string FallbackLang { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("moduleMode")]
        public string ModuleMode { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class DevkitRpcSchemaRequest
    {
        [JsonProperty("module")]
        public string Module { get; set; }
    }

    public sealed class DevkitRpcSchemaResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("rpcs")]
        public List<JToken> Rpcs { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyAchievementClaimRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("tier")]
        public long? Tier { get; set; }
    }

    public sealed class EconomyAchievementClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("achievement")]
        public AchievementData Achievement { get; set; }

        [JsonProperty("claims")]
        public List<ClaimsItem> Claims { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("levels")]
        public List<LevelsItem> Levels { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AchievementData
        {
            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("claimable")]
            public List<long?> Claimable { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("displayIconUrl")]
            public string DisplayIconUrl { get; set; }

            [JsonProperty("hidden")]
            public bool? Hidden { get; set; }

            [JsonProperty("hint")]
            public JToken Hint { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("lockedIconUrl")]
            public string LockedIconUrl { get; set; }

            [JsonProperty("maxTier")]
            public JToken MaxTier { get; set; }

            [JsonProperty("metric")]
            public string Metric { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("next")]
            public JObject Next { get; set; }

            [JsonProperty("points")]
            public long? Points { get; set; }

            [JsonProperty("progress")]
            public double? Progress { get; set; }

            [JsonProperty("rarity")]
            public string Rarity { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("tier")]
            public long? Tier { get; set; }

            [JsonProperty("tierAt")]
            public string TierAt { get; set; }

            [JsonProperty("tierName")]
            public string TierName { get; set; }

            [JsonProperty("tiered")]
            public bool? Tiered { get; set; }

            [JsonProperty("tiers")]
            public List<TiersItem> Tiers { get; set; }

            [JsonProperty("unlocked")]
            public bool? Unlocked { get; set; }

            [JsonProperty("unlockedAt")]
            public string UnlockedAt { get; set; }

            [JsonProperty("unlockedBy")]
            public string UnlockedBy { get; set; }

            [JsonProperty("unlockedRef")]
            public string UnlockedRef { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonProperty("valueMax")]
            public double? ValueMax { get; set; }

            [JsonProperty("valueMin")]
            public double? ValueMin { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class TiersItem
            {
                [JsonProperty("claimId")]
                public string ClaimId { get; set; }

                [JsonProperty("grantMode")]
                public JToken GrantMode { get; set; }

                [JsonProperty("iconUrl")]
                public JToken IconUrl { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("prize")]
                public PrizeData Prize { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonProperty("threshold")]
                public JToken Threshold { get; set; }

                [JsonProperty("tier")]
                public JToken Tier { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class PrizeData
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("message")]
                    public string Message { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }

        public sealed class ClaimsItem
        {
            [JsonProperty("claimId")]
            public JToken ClaimId { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("rewards")]
            public JToken Rewards { get; set; }

            [JsonProperty("tier")]
            public JToken Tier { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class LevelsItem
        {
            [JsonProperty("from")]
            public long? From { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("tableId")]
            public string TableId { get; set; }

            [JsonProperty("to")]
            public long? To { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAchievementsRequest
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyAchievementsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JToken> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("points")]
        public long? Points { get; set; }

        [JsonProperty("ready")]
        public long? Ready { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("unlocked")]
        public long? Unlocked { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyAchievementsProfileRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class EconomyAchievementsProfileResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("points")]
        public long? Points { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("unlocked")]
        public long? Unlocked { get; set; }

        [JsonProperty("user")]
        public UserData User { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("categoryKey")]
            public JToken CategoryKey { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("hidden")]
            public JToken Hidden { get; set; }

            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("maxTier")]
            public long? MaxTier { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("points")]
            public JToken Points { get; set; }

            [JsonProperty("rarity")]
            public JToken Rarity { get; set; }

            [JsonProperty("tier")]
            public JToken Tier { get; set; }

            [JsonProperty("tierName")]
            public string TierName { get; set; }

            [JsonProperty("unlockedAt")]
            public string UnlockedAt { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class UserData
        {
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("self")]
            public bool? Self { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAvatarBuyRequest
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class EconomyAvatarBuyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("item")]
        public JObject Item { get; set; }

        [JsonProperty("lang")]
        public JToken Lang { get; set; }

        [JsonProperty("paid")]
        public List<PaidItem> Paid { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("wallet")]
        public JObject Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PaidItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAvatarCatalogRequest
    {
        [JsonProperty("avatarId")]
        public string AvatarId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyAvatarCatalogResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("avatarId")]
        public string AvatarId { get; set; }

        [JsonProperty("categories")]
        public List<JToken> Categories { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("lang")]
        public JToken Lang { get; set; }

        [JsonProperty("types")]
        public List<JToken> Types { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyAvatarCreateRequest
    {
        [JsonProperty("activate")]
        public bool? Activate { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public sealed class EconomyAvatarCreateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("activeId")]
        public string ActiveId { get; set; }

        [JsonProperty("avatar")]
        public JToken Avatar { get; set; }

        [JsonProperty("avatars")]
        public List<AvatarsItem> Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public JToken Limit { get; set; }

        [JsonProperty("nameMaxLength")]
        public long? NameMaxLength { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AvatarsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("look")]
            public JToken Look { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public JToken Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAvatarDeleteRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyAvatarDeleteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("activeId")]
        public string ActiveId { get; set; }

        [JsonProperty("avatars")]
        public List<AvatarsItem> Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public LimitData Limit { get; set; }

        [JsonProperty("nameMaxLength")]
        public long? NameMaxLength { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AvatarsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("look")]
            public LookData Look { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public TypeData Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class LookData
            {
                [JsonProperty("items")]
                public JObject Items { get; set; }

                [JsonProperty("layers")]
                public List<LayersItem> Layers { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class LayersItem
                {
                    [JsonProperty("category")]
                    public string Category { get; set; }

                    [JsonProperty("imageUrl")]
                    public string ImageUrl { get; set; }

                    [JsonProperty("item")]
                    public string Item { get; set; }

                    [JsonProperty("layer")]
                    public long? Layer { get; set; }

                    [JsonProperty("value")]
                    public string Value { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class TypeData
            {
                [JsonProperty("iconUrl")]
                public JToken IconUrl { get; set; }

                [JsonProperty("imageUrl")]
                public JToken ImageUrl { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class LimitData
        {
            [JsonProperty("canCreate")]
            public bool? CanCreate { get; set; }

            [JsonProperty("count")]
            public long? Count { get; set; }

            [JsonProperty("max")]
            public JToken Max { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAvatarEquipRequest
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyAvatarEquipResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("activeId")]
        public string ActiveId { get; set; }

        [JsonProperty("avatar")]
        public JToken Avatar { get; set; }

        [JsonProperty("avatars")]
        public List<JToken> Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public JToken Limit { get; set; }

        [JsonProperty("nameMaxLength")]
        public long? NameMaxLength { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyAvatarListRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyAvatarListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("activeId")]
        public string ActiveId { get; set; }

        [JsonProperty("avatars")]
        public List<AvatarsItem> Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public LimitData Limit { get; set; }

        [JsonProperty("nameMaxLength")]
        public long? NameMaxLength { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AvatarsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("look")]
            public LookData Look { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public TypeData Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class LookData
            {
                [JsonProperty("items")]
                public JObject Items { get; set; }

                [JsonProperty("layers")]
                public List<LayersItem> Layers { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class LayersItem
                {
                    [JsonProperty("category")]
                    public string Category { get; set; }

                    [JsonProperty("imageUrl")]
                    public string ImageUrl { get; set; }

                    [JsonProperty("item")]
                    public string Item { get; set; }

                    [JsonProperty("layer")]
                    public long? Layer { get; set; }

                    [JsonProperty("value")]
                    public string Value { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class TypeData
            {
                [JsonProperty("iconUrl")]
                public JToken IconUrl { get; set; }

                [JsonProperty("imageUrl")]
                public JToken ImageUrl { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class LimitData
        {
            [JsonProperty("canCreate")]
            public bool? CanCreate { get; set; }

            [JsonProperty("count")]
            public long? Count { get; set; }

            [JsonProperty("max")]
            public long? Max { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAvatarLooksRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("userIds")]
        public List<string> UserIds { get; set; }
    }

    public sealed class EconomyAvatarLooksResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("avatars")]
        public JObject Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyAvatarRenameRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public sealed class EconomyAvatarRenameResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("activeId")]
        public string ActiveId { get; set; }

        [JsonProperty("avatar")]
        public JToken Avatar { get; set; }

        [JsonProperty("avatars")]
        public List<AvatarsItem> Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public JToken Limit { get; set; }

        [JsonProperty("nameMaxLength")]
        public long? NameMaxLength { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AvatarsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("look")]
            public JToken Look { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public JToken Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAvatarSetActiveRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyAvatarSetActiveResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("activeId")]
        public string ActiveId { get; set; }

        [JsonProperty("avatar")]
        public JToken Avatar { get; set; }

        [JsonProperty("avatars")]
        public List<AvatarsItem> Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public JToken Limit { get; set; }

        [JsonProperty("nameMaxLength")]
        public long? NameMaxLength { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AvatarsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("look")]
            public JToken Look { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public JToken Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyAvatarUnequipRequest
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyAvatarUnequipResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("activeId")]
        public string ActiveId { get; set; }

        [JsonProperty("avatar")]
        public JToken Avatar { get; set; }

        [JsonProperty("avatars")]
        public List<JToken> Avatars { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public JToken Limit { get; set; }

        [JsonProperty("nameMaxLength")]
        public long? NameMaxLength { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyBalancesRequest
    {
    }

    public sealed class EconomyBalancesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("metas")]
        public JObject Metas { get; set; }

        [JsonProperty("regen")]
        public List<JToken> Regen { get; set; }

        [JsonProperty("wallet")]
        public JObject Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("updatedAt")]
            public JToken UpdatedAt { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyBoostersRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyBoostersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("expiresAt")]
            public string ExpiresAt { get; set; }

            [JsonProperty("metaKey")]
            public string MetaKey { get; set; }

            [JsonProperty("metaName")]
            public string MetaName { get; set; }

            [JsonProperty("multiplier")]
            public double? Multiplier { get; set; }

            [JsonProperty("secondsLeft")]
            public long? SecondsLeft { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyCatalogRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyCatalogResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("categories")]
        public List<CategoriesItem> Categories { get; set; }

        [JsonProperty("currencies")]
        public List<CurrenciesItem> Currencies { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("products")]
        public List<ProductsItem> Products { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CategoriesItem
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class CurrenciesItem
        {
            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("regen")]
            public RegenData Regen { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RegenData
            {
                [JsonProperty("intervalSeconds")]
                public long? IntervalSeconds { get; set; }

                [JsonProperty("max")]
                public long? Max { get; set; }

                [JsonProperty("refillPrice")]
                public JToken RefillPrice { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class ProductsItem
        {
            [JsonProperty("bought")]
            public bool? Bought { get; set; }

            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("coinOriginal")]
            public JToken CoinOriginal { get; set; }

            [JsonProperty("coinPrice")]
            public CoinPriceData CoinPrice { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("discountPercent")]
            public long? DiscountPercent { get; set; }

            [JsonProperty("exclusive")]
            public bool? Exclusive { get; set; }

            [JsonProperty("finalMinor")]
            public JToken FinalMinor { get; set; }

            [JsonProperty("finalToman")]
            public JToken FinalToman { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isOneTime")]
            public bool? IsOneTime { get; set; }

            [JsonProperty("isSubscription")]
            public bool? IsSubscription { get; set; }

            [JsonProperty("items")]
            public List<string> Items { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("levelLocked")]
            public JToken LevelLocked { get; set; }

            [JsonProperty("maxLevel")]
            public long? MaxLevel { get; set; }

            [JsonProperty("minLevel")]
            public long? MinLevel { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("owned")]
            public JToken Owned { get; set; }

            [JsonProperty("paymentMethods")]
            public List<string> PaymentMethods { get; set; }

            [JsonProperty("priceCurrency")]
            public string PriceCurrency { get; set; }

            [JsonProperty("priceMinor")]
            public long? PriceMinor { get; set; }

            [JsonProperty("priceToman")]
            public long? PriceToman { get; set; }

            [JsonProperty("purchaseCount")]
            public JToken PurchaseCount { get; set; }

            [JsonProperty("purchaseMessage")]
            public string PurchaseMessage { get; set; }

            [JsonProperty("requiresKey")]
            public JToken RequiresKey { get; set; }

            [JsonProperty("sku")]
            public JObject Sku { get; set; }

            [JsonProperty("storeFinalToman")]
            public JToken StoreFinalToman { get; set; }

            [JsonProperty("tagDiscountPercent")]
            public long? TagDiscountPercent { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CoinPriceData
            {
                [JsonProperty("amount")]
                public long? Amount { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyChanceAckRequest
    {
        [JsonProperty("playId")]
        public string PlayId { get; set; }
    }

    public sealed class EconomyChanceAckResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("ackedAt")]
        public string AckedAt { get; set; }

        [JsonProperty("acknowledged")]
        public bool? Acknowledged { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("playId")]
        public string PlayId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyChanceCanPlayRequest
    {
        [JsonProperty("expectedCost")]
        public long? ExpectedCost { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyChanceCanPlayResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canPlay")]
        public bool? CanPlay { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("nextPlayTime")]
        public long? NextPlayTime { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyChanceGameRequest
    {
        [JsonProperty("expectedCost")]
        public long? ExpectedCost { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyChanceGameResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("game")]
        public GameData Game { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GameData
        {
            [JsonProperty("canPlay")]
            public bool? CanPlay { get; set; }

            [JsonProperty("dailyLimit")]
            public long? DailyLimit { get; set; }

            [JsonProperty("dayEndsAt")]
            public string DayEndsAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("intervalTime")]
            public long? IntervalTime { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("lastPlayAt")]
            public string LastPlayAt { get; set; }

            [JsonProperty("limitReached")]
            public bool? LimitReached { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextPlayAt")]
            public string NextPlayAt { get; set; }

            [JsonProperty("nextPlayTime")]
            public long? NextPlayTime { get; set; }

            [JsonProperty("plays")]
            public long? Plays { get; set; }

            [JsonProperty("playsLeft")]
            public long? PlaysLeft { get; set; }

            [JsonProperty("playsLeftToday")]
            public long? PlaysLeftToday { get; set; }

            [JsonProperty("playsToday")]
            public long? PlaysToday { get; set; }

            [JsonProperty("price")]
            public PriceData Price { get; set; }

            [JsonProperty("priceLadder")]
            public List<long?> PriceLadder { get; set; }

            [JsonProperty("prize")]
            public List<PrizeItem> Prize { get; set; }

            [JsonProperty("prizeType")]
            public string PrizeType { get; set; }

            [JsonProperty("revealAck")]
            public bool? RevealAck { get; set; }

            [JsonProperty("showOdds")]
            public bool? ShowOdds { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("ticketsToday")]
            public long? TicketsToday { get; set; }

            [JsonProperty("totalLimit")]
            public long? TotalLimit { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PriceData
            {
                [JsonProperty("amount")]
                public long? Amount { get; set; }

                [JsonProperty("currencyId")]
                public string CurrencyId { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonProperty("currencyName")]
                public string CurrencyName { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizeItem
            {
                [JsonProperty("chance")]
                public JToken Chance { get; set; }

                [JsonProperty("group")]
                public GroupData Group { get; set; }

                [JsonProperty("prize")]
                public PrizeData Prize { get; set; }

                [JsonProperty("prizeGroupId")]
                public JToken PrizeGroupId { get; set; }

                [JsonProperty("prizeId")]
                public JToken PrizeId { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class GroupData
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonProperty("prizes")]
                    public List<PrizesItem> Prizes { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class PrizesItem
                    {
                        [JsonProperty("id")]
                        public string Id { get; set; }

                        [JsonProperty("key")]
                        public string Key { get; set; }

                        [JsonProperty("name")]
                        public string Name { get; set; }

                        [JsonProperty("share")]
                        public JToken Share { get; set; }

                        [JsonProperty("weight")]
                        public JToken Weight { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class PrizeData
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("message")]
                    public string Message { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }
    }

    public sealed class EconomyChanceGamesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyChanceGamesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("canPlay")]
            public bool? CanPlay { get; set; }

            [JsonProperty("dailyLimit")]
            public long? DailyLimit { get; set; }

            [JsonProperty("dayEndsAt")]
            public string DayEndsAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("intervalTime")]
            public long? IntervalTime { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("lastPlayAt")]
            public string LastPlayAt { get; set; }

            [JsonProperty("limitReached")]
            public bool? LimitReached { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nextPlayAt")]
            public string NextPlayAt { get; set; }

            [JsonProperty("nextPlayTime")]
            public long? NextPlayTime { get; set; }

            [JsonProperty("plays")]
            public long? Plays { get; set; }

            [JsonProperty("playsLeft")]
            public long? PlaysLeft { get; set; }

            [JsonProperty("playsLeftToday")]
            public long? PlaysLeftToday { get; set; }

            [JsonProperty("playsToday")]
            public long? PlaysToday { get; set; }

            [JsonProperty("price")]
            public PriceData Price { get; set; }

            [JsonProperty("priceLadder")]
            public List<long?> PriceLadder { get; set; }

            [JsonProperty("prize")]
            public List<PrizeItem> Prize { get; set; }

            [JsonProperty("prizeType")]
            public string PrizeType { get; set; }

            [JsonProperty("revealAck")]
            public bool? RevealAck { get; set; }

            [JsonProperty("showOdds")]
            public bool? ShowOdds { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("ticketsToday")]
            public long? TicketsToday { get; set; }

            [JsonProperty("totalLimit")]
            public long? TotalLimit { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PriceData
            {
                [JsonProperty("amount")]
                public long? Amount { get; set; }

                [JsonProperty("currencyId")]
                public string CurrencyId { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonProperty("currencyName")]
                public string CurrencyName { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizeItem
            {
                [JsonProperty("chance")]
                public JToken Chance { get; set; }

                [JsonProperty("group")]
                public GroupData Group { get; set; }

                [JsonProperty("prize")]
                public PrizeData Prize { get; set; }

                [JsonProperty("prizeGroupId")]
                public JToken PrizeGroupId { get; set; }

                [JsonProperty("prizeId")]
                public JToken PrizeId { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class GroupData
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonProperty("prizes")]
                    public List<PrizesItem> Prizes { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class PrizesItem
                    {
                        [JsonProperty("id")]
                        public string Id { get; set; }

                        [JsonProperty("key")]
                        public string Key { get; set; }

                        [JsonProperty("name")]
                        public string Name { get; set; }

                        [JsonProperty("share")]
                        public JToken Share { get; set; }

                        [JsonProperty("weight")]
                        public JToken Weight { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class PrizeData
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("message")]
                    public string Message { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }
    }

    public sealed class EconomyChanceHistoryRequest
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class EconomyChanceHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("gameId")]
            public JToken GameId { get; set; }

            [JsonProperty("gameKey")]
            public JToken GameKey { get; set; }

            [JsonProperty("gameName")]
            public string GameName { get; set; }

            [JsonProperty("mode")]
            public JToken Mode { get; set; }

            [JsonProperty("outcome")]
            public List<JObject> Outcome { get; set; }

            [JsonProperty("playId")]
            public JToken PlayId { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("prizeGroupId")]
            public JToken PrizeGroupId { get; set; }

            [JsonProperty("prizeId")]
            public JToken PrizeId { get; set; }

            [JsonProperty("rewards")]
            public List<RewardsItem> Rewards { get; set; }

            [JsonProperty("roll")]
            public double? Roll { get; set; }

            [JsonProperty("slot")]
            public JToken Slot { get; set; }

            [JsonProperty("spent")]
            public SpentData Spent { get; set; }

            [JsonProperty("status")]
            public JToken Status { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class RewardsItem
            {
                [JsonProperty("action")]
                public string Action { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("rewards")]
                public List<RewardsItem_> Rewards { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class RewardsItem_
                {
                    [JsonProperty("action")]
                    public string Action { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("rewards")]
                    public List<JToken> Rewards { get; set; }

                    [JsonProperty("type")]
                    public string Type { get; set; }

                    [JsonProperty("value")]
                    public JToken Value { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class SpentData
            {
                [JsonProperty("amount")]
                public long? Amount { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyChanceNextPlayTimeRequest
    {
        [JsonProperty("expectedCost")]
        public long? ExpectedCost { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyChanceNextPlayTimeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("nextPlayAt")]
        public string NextPlayAt { get; set; }

        [JsonProperty("nextPlayTime")]
        public long? NextPlayTime { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyChancePlayRequest
    {
        [JsonProperty("expectedCost")]
        public long? ExpectedCost { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyChancePlayResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("gameId")]
        public JToken GameId { get; set; }

        [JsonProperty("gameKey")]
        public JToken GameKey { get; set; }

        [JsonProperty("group")]
        public GroupData Group { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("needsAck")]
        public bool? NeedsAck { get; set; }

        [JsonProperty("nextPlayAt")]
        public string NextPlayAt { get; set; }

        [JsonProperty("nextPlayTime")]
        public long? NextPlayTime { get; set; }

        [JsonProperty("nextTicketCost")]
        public long? NextTicketCost { get; set; }

        [JsonProperty("outcome")]
        public List<JObject> Outcome { get; set; }

        [JsonProperty("playId")]
        public JToken PlayId { get; set; }

        [JsonProperty("playsLeft")]
        public JToken PlaysLeft { get; set; }

        [JsonProperty("playsLeftToday")]
        public JToken PlaysLeftToday { get; set; }

        [JsonProperty("prize")]
        public PrizeData Prize { get; set; }

        [JsonProperty("prizeGroupId")]
        public JToken PrizeGroupId { get; set; }

        [JsonProperty("prizeId")]
        public JToken PrizeId { get; set; }

        [JsonProperty("rewards")]
        public JToken Rewards { get; set; }

        [JsonProperty("roll")]
        public double? Roll { get; set; }

        [JsonProperty("slot")]
        public JToken Slot { get; set; }

        [JsonProperty("spent")]
        public SpentData Spent { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("wallet")]
        public JObject Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GroupData
        {
            [JsonProperty("id")]
            public JToken Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PrizeData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SpentData
        {
            [JsonProperty("amount")]
            public JToken Amount { get; set; }

            [JsonProperty("currencyKey")]
            public JToken CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyChancePlayWithTicketRequest
    {
        [JsonProperty("expectedCost")]
        public long? ExpectedCost { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyChancePlayWithTicketResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("gameId")]
        public JToken GameId { get; set; }

        [JsonProperty("gameKey")]
        public JToken GameKey { get; set; }

        [JsonProperty("group")]
        public GroupData Group { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("needsAck")]
        public bool? NeedsAck { get; set; }

        [JsonProperty("nextPlayAt")]
        public string NextPlayAt { get; set; }

        [JsonProperty("nextPlayTime")]
        public long? NextPlayTime { get; set; }

        [JsonProperty("nextTicketCost")]
        public long? NextTicketCost { get; set; }

        [JsonProperty("outcome")]
        public List<JObject> Outcome { get; set; }

        [JsonProperty("playId")]
        public JToken PlayId { get; set; }

        [JsonProperty("playsLeft")]
        public JToken PlaysLeft { get; set; }

        [JsonProperty("playsLeftToday")]
        public JToken PlaysLeftToday { get; set; }

        [JsonProperty("prize")]
        public PrizeData Prize { get; set; }

        [JsonProperty("prizeGroupId")]
        public JToken PrizeGroupId { get; set; }

        [JsonProperty("prizeId")]
        public JToken PrizeId { get; set; }

        [JsonProperty("rewards")]
        public JToken Rewards { get; set; }

        [JsonProperty("roll")]
        public double? Roll { get; set; }

        [JsonProperty("slot")]
        public JToken Slot { get; set; }

        [JsonProperty("spent")]
        public SpentData Spent { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("wallet")]
        public JObject Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GroupData
        {
            [JsonProperty("id")]
            public JToken Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PrizeData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SpentData
        {
            [JsonProperty("amount")]
            public JToken Amount { get; set; }

            [JsonProperty("currencyKey")]
            public JToken CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyEventRecordRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public sealed class EconomyEventRecordResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claims")]
        public List<ClaimsItem> Claims { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("levels")]
        public List<LevelsItem> Levels { get; set; }

        [JsonProperty("metas")]
        public JObject Metas { get; set; }

        [JsonProperty("relations")]
        public List<RelationsItem> Relations { get; set; }

        [JsonProperty("rules")]
        public List<RulesItem> Rules { get; set; }

        [JsonProperty("streaks")]
        public List<StreaksItem> Streaks { get; set; }

        [JsonProperty("value")]
        public double? Value { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClaimsItem
        {
            [JsonProperty("claimId")]
            public JToken ClaimId { get; set; }

            [JsonProperty("grantMode")]
            public JToken GrantMode { get; set; }

            [JsonProperty("kind")]
            public JToken Kind { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("status")]
            public JToken Status { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class LevelsItem
        {
            [JsonProperty("from")]
            public long? From { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("tableId")]
            public string TableId { get; set; }

            [JsonProperty("to")]
            public long? To { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RelationsItem
        {
            [JsonProperty("claimId")]
            public string ClaimId { get; set; }

            [JsonProperty("fires")]
            public long? Fires { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("relationId")]
            public string RelationId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RulesItem
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("measure")]
            public string Measure { get; set; }

            [JsonProperty("newClaims")]
            public long? NewClaims { get; set; }

            [JsonProperty("period")]
            public string Period { get; set; }

            [JsonProperty("periodEndsAt")]
            public JToken PeriodEndsAt { get; set; }

            [JsonProperty("periodStart")]
            public string PeriodStart { get; set; }

            [JsonProperty("reached")]
            public bool? Reached { get; set; }

            [JsonProperty("ruleId")]
            public string RuleId { get; set; }

            [JsonProperty("threshold")]
            public double? Threshold { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class StreaksItem
        {
            [JsonProperty("advanced")]
            public bool? Advanced { get; set; }

            [JsonProperty("best")]
            public long? Best { get; set; }

            [JsonProperty("count")]
            public long? Count { get; set; }

            [JsonProperty("floor")]
            public long? Floor { get; set; }

            [JsonProperty("floored")]
            public bool? Floored { get; set; }

            [JsonProperty("infinityAmount")]
            public long? InfinityAmount { get; set; }

            [JsonProperty("infinityCurrency")]
            public string InfinityCurrency { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("nextMilestone")]
            public long? NextMilestone { get; set; }

            [JsonProperty("phase")]
            public string Phase { get; set; }

            [JsonProperty("reset")]
            public bool? Reset { get; set; }

            [JsonProperty("streakId")]
            public string StreakId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyEventsProgressRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyEventsProgressResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("ready")]
        public List<ReadyItem> Ready { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("claimable")]
            public List<string> Claimable { get; set; }

            [JsonProperty("claims")]
            public long? Claims { get; set; }

            [JsonProperty("current")]
            public JToken Current { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("done")]
            public bool? Done { get; set; }

            [JsonProperty("endsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("eventKey")]
            public JToken EventKey { get; set; }

            [JsonProperty("eventName")]
            public string EventName { get; set; }

            [JsonProperty("grantMode")]
            public JToken GrantMode { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("maxClaims")]
            public JToken MaxClaims { get; set; }

            [JsonProperty("measure")]
            public JToken Measure { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("period")]
            public JToken Period { get; set; }

            [JsonProperty("periodEndsAt")]
            public string PeriodEndsAt { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("repeat")]
            public JToken Repeat { get; set; }

            [JsonProperty("target")]
            public JToken Target { get; set; }

            [JsonProperty("threshold")]
            public JToken Threshold { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class ReadyItem
        {
            [JsonProperty("claimId")]
            public JToken ClaimId { get; set; }

            [JsonProperty("createdAt")]
            public JToken CreatedAt { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("source")]
            public JToken Source { get; set; }

            [JsonProperty("sourceName")]
            public string SourceName { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyFriendGiftAcceptRequest
    {
    }

    public sealed class EconomyFriendGiftAcceptResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyFriendGiftCancelRequest
    {
    }

    public sealed class EconomyFriendGiftCancelResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyFriendGiftDeclineRequest
    {
    }

    public sealed class EconomyFriendGiftDeclineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyFriendGiftOptionsRequest
    {
        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyFriendGiftOptionsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canSend")]
        public bool? CanSend { get; set; }

        [JsonProperty("currencies")]
        public List<CurrenciesItem> Currencies { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("delivery")]
        public string Delivery { get; set; }

        [JsonProperty("discountCodes")]
        public bool? DiscountCodes { get; set; }

        [JsonProperty("expiryHours")]
        public long? ExpiryHours { get; set; }

        [JsonProperty("friend")]
        public FriendData Friend { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limits")]
        public LimitsData Limits { get; set; }

        [JsonProperty("messageEnabled")]
        public bool? MessageEnabled { get; set; }

        [JsonProperty("messageMaxLength")]
        public long? MessageMaxLength { get; set; }

        [JsonProperty("products")]
        public List<ProductsItem> Products { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CurrenciesItem
        {
            [JsonProperty("balance")]
            public JToken Balance { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("max")]
            public JToken Max { get; set; }

            [JsonProperty("min")]
            public JToken Min { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class FriendData
        {
            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isFriend")]
            public bool? IsFriend { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ItemsItem
        {
            [JsonProperty("giftable")]
            public bool? Giftable { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("recipientOwns")]
            public bool? RecipientOwns { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LimitsData
        {
            [JsonProperty("pair")]
            public PairData Pair { get; set; }

            [JsonProperty("recipient")]
            public RecipientData Recipient { get; set; }

            [JsonProperty("sender")]
            public SenderData Sender { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PairData
            {
                [JsonProperty("limit")]
                public JToken Limit { get; set; }

                [JsonProperty("remaining")]
                public JToken Remaining { get; set; }

                [JsonProperty("used")]
                public JToken Used { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class RecipientData
            {
                [JsonProperty("bonus")]
                public JToken Bonus { get; set; }

                [JsonProperty("limit")]
                public JToken Limit { get; set; }

                [JsonProperty("remaining")]
                public JToken Remaining { get; set; }

                [JsonProperty("used")]
                public JToken Used { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class SenderData
            {
                [JsonProperty("bonus")]
                public JToken Bonus { get; set; }

                [JsonProperty("limit")]
                public JToken Limit { get; set; }

                [JsonProperty("remaining")]
                public JToken Remaining { get; set; }

                [JsonProperty("used")]
                public JToken Used { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class ProductsItem
        {
            [JsonProperty("coinPrice")]
            public CoinPriceData CoinPrice { get; set; }

            [JsonProperty("coverUrl")]
            public string CoverUrl { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("discountPercent")]
            public long? DiscountPercent { get; set; }

            [JsonProperty("finalToman")]
            public JToken FinalToman { get; set; }

            [JsonProperty("giftable")]
            public bool? Giftable { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("items")]
            public List<string> Items { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("paymentMethods")]
            public List<string> PaymentMethods { get; set; }

            [JsonProperty("priceToman")]
            public long? PriceToman { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("recipientOwns")]
            public bool? RecipientOwns { get; set; }

            [JsonProperty("sku")]
            public JObject Sku { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CoinPriceData
            {
                [JsonProperty("amount")]
                public long? Amount { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyFriendGiftSendRequest
    {
        [JsonProperty("amount")]
        public long? Amount { get; set; }

        [JsonProperty("currencyKey")]
        public string CurrencyKey { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("giftCode")]
        public string GiftCode { get; set; }

        [JsonProperty("itemKey")]
        public string ItemKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class EconomyFriendGiftSendResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("gift")]
        public JToken Gift { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyFriendGiftsRequest
    {
        [JsonProperty("box")]
        public string Box { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public sealed class EconomyFriendGiftsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("pendingCount")]
        public long? PendingCount { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("amount")]
            public JToken Amount { get; set; }

            [JsonProperty("box")]
            public string Box { get; set; }

            [JsonProperty("createdAt")]
            public JToken CreatedAt { get; set; }

            [JsonProperty("currencyKey")]
            public JToken CurrencyKey { get; set; }

            [JsonProperty("deliveredAt")]
            public JToken DeliveredAt { get; set; }

            [JsonProperty("delivery")]
            public JToken Delivery { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("from")]
            public FromData From { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public JToken Id { get; set; }

            [JsonProperty("itemKey")]
            public JToken ItemKey { get; set; }

            [JsonProperty("items")]
            public JToken Items { get; set; }

            [JsonProperty("kind")]
            public JToken Kind { get; set; }

            [JsonProperty("message")]
            public JToken Message { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("outcome")]
            public JToken Outcome { get; set; }

            [JsonProperty("productKey")]
            public JToken ProductKey { get; set; }

            [JsonProperty("respondedAt")]
            public JToken RespondedAt { get; set; }

            [JsonProperty("secondsLeft")]
            public long? SecondsLeft { get; set; }

            [JsonProperty("source")]
            public JToken Source { get; set; }

            [JsonProperty("status")]
            public JToken Status { get; set; }

            [JsonProperty("to")]
            public ToData To { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class FromData
            {
                [JsonProperty("displayName")]
                public JToken DisplayName { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("username")]
                public JToken Username { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class ToData
            {
                [JsonProperty("displayName")]
                public JToken DisplayName { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("username")]
                public JToken Username { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyGameRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("botsAllowed")]
        public bool? BotsAllowed { get; set; }

        [JsonProperty("category")]
        public CategoryData Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("hidden")]
        public bool? Hidden { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("leaderboardId")]
        public string LeaderboardId { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("maintenance")]
        public string Maintenance { get; set; }

        [JsonProperty("matchSeconds")]
        public long? MatchSeconds { get; set; }

        [JsonProperty("maxPlayers")]
        public long? MaxPlayers { get; set; }

        [JsonProperty("minPlayers")]
        public long? MinPlayers { get; set; }

        [JsonProperty("multiplayer")]
        public bool? Multiplayer { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("newPlayer")]
        public bool? NewPlayer { get; set; }

        [JsonProperty("oneMatchPerPlayer")]
        public bool? OneMatchPerPlayer { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("realtime")]
        public bool? Realtime { get; set; }

        [JsonProperty("requirements")]
        public RequirementsData Requirements { get; set; }

        [JsonProperty("rooms")]
        public List<RoomsItem> Rooms { get; set; }

        [JsonProperty("settings")]
        public JObject Settings { get; set; }

        [JsonProperty("sort")]
        public long? Sort { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("turnSeconds")]
        public long? TurnSeconds { get; set; }

        [JsonProperty("voice")]
        public bool? Voice { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CategoryData
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RequirementsData
        {
            [JsonProperty("consumes")]
            public JToken Consumes { get; set; }

            [JsonProperty("excludesTags")]
            public bool? ExcludesTags { get; set; }

            [JsonProperty("items")]
            public ItemsData Items { get; set; }

            [JsonProperty("metas")]
            public List<MetasItem> Metas { get; set; }

            [JsonProperty("minLevel")]
            public JToken MinLevel { get; set; }

            [JsonProperty("paths")]
            public JToken Paths { get; set; }

            [JsonProperty("refund")]
            public string Refund { get; set; }

            [JsonProperty("tags")]
            public TagsData Tags { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsData
            {
                [JsonProperty("consume")]
                public JToken Consume { get; set; }

                [JsonProperty("list")]
                public List<ListItem> List { get; set; }

                [JsonProperty("mode")]
                public string Mode { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ListItem
                {
                    [JsonProperty("iconUrl")]
                    public JToken IconUrl { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("name")]
                    public JToken Name { get; set; }

                    [JsonProperty("owned")]
                    public bool? Owned { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class MetasItem
            {
                [JsonProperty("consume")]
                public JToken Consume { get; set; }

                [JsonProperty("have")]
                public double? Have { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("operator")]
                public JToken Operator { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class TagsData
            {
                [JsonProperty("list")]
                public List<ListItem> List { get; set; }

                [JsonProperty("mode")]
                public string Mode { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ListItem
                {
                    [JsonProperty("iconUrl")]
                    public JToken IconUrl { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("name")]
                    public JToken Name { get; set; }

                    [JsonProperty("owned")]
                    public bool? Owned { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }

        public sealed class RoomsItem
        {
            [JsonProperty("entryFee")]
            public EntryFeeData EntryFee { get; set; }

            [JsonProperty("inheritsGame")]
            public JToken InheritsGame { get; set; }

            [JsonProperty("joinable")]
            public bool? Joinable { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("levelLocked")]
            public bool? LevelLocked { get; set; }

            [JsonProperty("locked")]
            public bool? Locked { get; set; }

            [JsonProperty("minLevel")]
            public JToken MinLevel { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("prize")]
            public JToken Prize { get; set; }

            [JsonProperty("requirements")]
            public RequirementsData Requirements { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class EntryFeeData
            {
                [JsonProperty("amount")]
                public JToken Amount { get; set; }

                [JsonProperty("currencyKey")]
                public JToken CurrencyKey { get; set; }

                [JsonProperty("currencyName")]
                public string CurrencyName { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class RequirementsData
            {
                [JsonProperty("consumes")]
                public JToken Consumes { get; set; }

                [JsonProperty("excludesTags")]
                public bool? ExcludesTags { get; set; }

                [JsonProperty("items")]
                public ItemsData Items { get; set; }

                [JsonProperty("metas")]
                public List<MetasItem> Metas { get; set; }

                [JsonProperty("minLevel")]
                public JToken MinLevel { get; set; }

                [JsonProperty("paths")]
                public JToken Paths { get; set; }

                [JsonProperty("refund")]
                public string Refund { get; set; }

                [JsonProperty("tags")]
                public TagsData Tags { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ItemsData
                {
                    [JsonProperty("consume")]
                    public JToken Consume { get; set; }

                    [JsonProperty("list")]
                    public List<ListItem> List { get; set; }

                    [JsonProperty("mode")]
                    public string Mode { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class ListItem
                    {
                        [JsonProperty("iconUrl")]
                        public JToken IconUrl { get; set; }

                        [JsonProperty("key")]
                        public JToken Key { get; set; }

                        [JsonProperty("name")]
                        public JToken Name { get; set; }

                        [JsonProperty("owned")]
                        public bool? Owned { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class MetasItem
                {
                    [JsonProperty("consume")]
                    public JToken Consume { get; set; }

                    [JsonProperty("have")]
                    public double? Have { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonProperty("operator")]
                    public JToken Operator { get; set; }

                    [JsonProperty("value")]
                    public JToken Value { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class TagsData
                {
                    [JsonProperty("list")]
                    public List<ListItem> List { get; set; }

                    [JsonProperty("mode")]
                    public string Mode { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class ListItem
                    {
                        [JsonProperty("iconUrl")]
                        public JToken IconUrl { get; set; }

                        [JsonProperty("key")]
                        public JToken Key { get; set; }

                        [JsonProperty("name")]
                        public JToken Name { get; set; }

                        [JsonProperty("owned")]
                        public bool? Owned { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }
            }
        }
    }

    public sealed class EconomyGameActiveRequest
    {
    }

    public sealed class EconomyGameActiveResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("match")]
        public JToken Match { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameBotRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameBotResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("botAfterSeconds")]
        public long? BotAfterSeconds { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("matchId")]
        public JToken MatchId { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameFriendCancelRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameFriendCancelResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("done")]
        public bool? Done { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameFriendCreateRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameFriendCreateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public JToken Code { get; set; }

        [JsonProperty("existing")]
        public bool? Existing { get; set; }

        [JsonProperty("expiresInSeconds")]
        public long? ExpiresInSeconds { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("matchId")]
        public JToken MatchId { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameFriendDeclineRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameFriendDeclineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("done")]
        public bool? Done { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameFriendJoinRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameFriendJoinResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("expiresInSeconds")]
        public JToken ExpiresInSeconds { get; set; }

        [JsonProperty("hostId")]
        public JToken HostId { get; set; }

        [JsonProperty("key")]
        public JToken Key { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("room")]
        public JToken Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameJoinRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameJoinResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("consumes")]
        public bool? Consumes { get; set; }

        [JsonProperty("entryFee")]
        public JToken EntryFee { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("maxCount")]
        public long? MaxCount { get; set; }

        [JsonProperty("minCount")]
        public long? MinCount { get; set; }

        [JsonProperty("numericProperties")]
        public JObject NumericProperties { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("realtime")]
        public bool? Realtime { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("stringProperties")]
        public JObject StringProperties { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameQueueRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("friendId")]
        public string FriendId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGameQueueResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("botFillSeconds")]
        public JToken BotFillSeconds { get; set; }

        [JsonProperty("humanSeats")]
        public JToken HumanSeats { get; set; }

        [JsonProperty("key")]
        public JToken Key { get; set; }

        [JsonProperty("players")]
        public JToken Players { get; set; }

        [JsonProperty("room")]
        public JToken Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyGameStatsRequest
    {
        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class EconomyGameStatsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("forfeits")]
            public long? Forfeits { get; set; }

            [JsonProperty("game")]
            public string Game { get; set; }

            [JsonProperty("lastPlayedAt")]
            public string LastPlayedAt { get; set; }

            [JsonProperty("lossRate")]
            public double? LossRate { get; set; }

            [JsonProperty("losses")]
            public long? Losses { get; set; }

            [JsonProperty("playtimeSeconds")]
            public long? PlaytimeSeconds { get; set; }

            [JsonProperty("timeouts")]
            public long? Timeouts { get; set; }

            [JsonProperty("totalGames")]
            public long? TotalGames { get; set; }

            [JsonProperty("winRate")]
            public double? WinRate { get; set; }

            [JsonProperty("winnings")]
            public JObject Winnings { get; set; }

            [JsonProperty("wins")]
            public long? Wins { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyGamesRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class EconomyGamesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public JToken Lang { get; set; }

        [JsonProperty("level")]
        public JToken Level { get; set; }

        [JsonProperty("path")]
        public JToken Path { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("botsAllowed")]
            public bool? BotsAllowed { get; set; }

            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("hidden")]
            public bool? Hidden { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("leaderboardId")]
            public string LeaderboardId { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("maintenance")]
            public string Maintenance { get; set; }

            [JsonProperty("matchSeconds")]
            public long? MatchSeconds { get; set; }

            [JsonProperty("maxPlayers")]
            public long? MaxPlayers { get; set; }

            [JsonProperty("minPlayers")]
            public long? MinPlayers { get; set; }

            [JsonProperty("multiplayer")]
            public bool? Multiplayer { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("newPlayer")]
            public bool? NewPlayer { get; set; }

            [JsonProperty("oneMatchPerPlayer")]
            public bool? OneMatchPerPlayer { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("realtime")]
            public bool? Realtime { get; set; }

            [JsonProperty("requirements")]
            public RequirementsData Requirements { get; set; }

            [JsonProperty("rooms")]
            public List<RoomsItem> Rooms { get; set; }

            [JsonProperty("settings")]
            public JObject Settings { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("turnSeconds")]
            public long? TurnSeconds { get; set; }

            [JsonProperty("voice")]
            public bool? Voice { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class RequirementsData
            {
                [JsonProperty("consumes")]
                public JToken Consumes { get; set; }

                [JsonProperty("excludesTags")]
                public bool? ExcludesTags { get; set; }

                [JsonProperty("items")]
                public ItemsData Items { get; set; }

                [JsonProperty("metas")]
                public List<MetasItem> Metas { get; set; }

                [JsonProperty("minLevel")]
                public JToken MinLevel { get; set; }

                [JsonProperty("paths")]
                public JToken Paths { get; set; }

                [JsonProperty("refund")]
                public string Refund { get; set; }

                [JsonProperty("tags")]
                public TagsData Tags { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ItemsData
                {
                    [JsonProperty("consume")]
                    public JToken Consume { get; set; }

                    [JsonProperty("list")]
                    public List<ListItem> List { get; set; }

                    [JsonProperty("mode")]
                    public string Mode { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class ListItem
                    {
                        [JsonProperty("iconUrl")]
                        public JToken IconUrl { get; set; }

                        [JsonProperty("key")]
                        public JToken Key { get; set; }

                        [JsonProperty("name")]
                        public JToken Name { get; set; }

                        [JsonProperty("owned")]
                        public bool? Owned { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }

                public sealed class MetasItem
                {
                    [JsonProperty("consume")]
                    public JToken Consume { get; set; }

                    [JsonProperty("have")]
                    public double? Have { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonProperty("operator")]
                    public JToken Operator { get; set; }

                    [JsonProperty("value")]
                    public JToken Value { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class TagsData
                {
                    [JsonProperty("list")]
                    public List<ListItem> List { get; set; }

                    [JsonProperty("mode")]
                    public string Mode { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class ListItem
                    {
                        [JsonProperty("iconUrl")]
                        public JToken IconUrl { get; set; }

                        [JsonProperty("key")]
                        public JToken Key { get; set; }

                        [JsonProperty("name")]
                        public JToken Name { get; set; }

                        [JsonProperty("owned")]
                        public bool? Owned { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }
                }
            }

            public sealed class RoomsItem
            {
                [JsonProperty("entryFee")]
                public EntryFeeData EntryFee { get; set; }

                [JsonProperty("inheritsGame")]
                public JToken InheritsGame { get; set; }

                [JsonProperty("joinable")]
                public bool? Joinable { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("levelLocked")]
                public bool? LevelLocked { get; set; }

                [JsonProperty("locked")]
                public bool? Locked { get; set; }

                [JsonProperty("minLevel")]
                public JToken MinLevel { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("prize")]
                public JToken Prize { get; set; }

                [JsonProperty("requirements")]
                public RequirementsData Requirements { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class EntryFeeData
                {
                    [JsonProperty("amount")]
                    public JToken Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public JToken CurrencyKey { get; set; }

                    [JsonProperty("currencyName")]
                    public string CurrencyName { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class RequirementsData
                {
                    [JsonProperty("consumes")]
                    public JToken Consumes { get; set; }

                    [JsonProperty("excludesTags")]
                    public bool? ExcludesTags { get; set; }

                    [JsonProperty("items")]
                    public ItemsData Items { get; set; }

                    [JsonProperty("metas")]
                    public List<MetasItem> Metas { get; set; }

                    [JsonProperty("minLevel")]
                    public JToken MinLevel { get; set; }

                    [JsonProperty("paths")]
                    public JToken Paths { get; set; }

                    [JsonProperty("refund")]
                    public string Refund { get; set; }

                    [JsonProperty("tags")]
                    public TagsData Tags { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }

                    public sealed class ItemsData
                    {
                        [JsonProperty("consume")]
                        public JToken Consume { get; set; }

                        [JsonProperty("list")]
                        public List<ListItem> List { get; set; }

                        [JsonProperty("mode")]
                        public string Mode { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }

                        public sealed class ListItem
                        {
                            [JsonProperty("iconUrl")]
                            public JToken IconUrl { get; set; }

                            [JsonProperty("key")]
                            public JToken Key { get; set; }

                            [JsonProperty("name")]
                            public JToken Name { get; set; }

                            [JsonProperty("owned")]
                            public bool? Owned { get; set; }

                            [JsonExtensionData]
                            public IDictionary<string, JToken> Extra { get; set; }
                        }
                    }

                    public sealed class MetasItem
                    {
                        [JsonProperty("consume")]
                        public JToken Consume { get; set; }

                        [JsonProperty("have")]
                        public double? Have { get; set; }

                        [JsonProperty("key")]
                        public string Key { get; set; }

                        [JsonProperty("name")]
                        public string Name { get; set; }

                        [JsonProperty("operator")]
                        public JToken Operator { get; set; }

                        [JsonProperty("value")]
                        public JToken Value { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }
                    }

                    public sealed class TagsData
                    {
                        [JsonProperty("list")]
                        public List<ListItem> List { get; set; }

                        [JsonProperty("mode")]
                        public string Mode { get; set; }

                        [JsonExtensionData]
                        public IDictionary<string, JToken> Extra { get; set; }

                        public sealed class ListItem
                        {
                            [JsonProperty("iconUrl")]
                            public JToken IconUrl { get; set; }

                            [JsonProperty("key")]
                            public JToken Key { get; set; }

                            [JsonProperty("name")]
                            public JToken Name { get; set; }

                            [JsonProperty("owned")]
                            public bool? Owned { get; set; }

                            [JsonExtensionData]
                            public IDictionary<string, JToken> Extra { get; set; }
                        }
                    }
                }
            }
        }
    }

    public sealed class EconomyGiftRedeemRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public sealed class EconomyGiftRedeemResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("gift")]
        public GiftData Gift { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GiftData
        {
            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RewardsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<RewardsItem_> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardsItem_
            {
                [JsonProperty("action")]
                public string Action { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("rewards")]
                public List<JToken> Rewards { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyInventoryRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("withProfile")]
        public bool? WithProfile { get; set; }
    }

    public sealed class EconomyInventoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("counts")]
        public CountsData Counts { get; set; }

        [JsonProperty("equipped")]
        public JObject Equipped { get; set; }

        [JsonProperty("items")]
        public List<JObject> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CountsData
        {
            [JsonProperty("owned")]
            public long? Owned { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyItemBuyRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class EconomyItemBuyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("item")]
        public JToken Item { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("paid")]
        public List<PaidItem> Paid { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("units")]
        public long? Units { get; set; }

        [JsonProperty("wallet")]
        public JToken Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PaidItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyItemEquipRequest
    {
    }

    public sealed class EconomyItemEquipResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyItemUnequipRequest
    {
    }

    public sealed class EconomyItemUnequipResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyItemUnlockRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyItemUnlockResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("item")]
        public JToken Item { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("paid")]
        public List<PaidItem> Paid { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("units")]
        public long? Units { get; set; }

        [JsonProperty("wallet")]
        public JToken Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PaidItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyItemUpgradeRequest
    {
        [JsonProperty("fromLevel")]
        public long? FromLevel { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class EconomyItemUpgradeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("item")]
        public JToken Item { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("paid")]
        public List<PaidItem> Paid { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("units")]
        public long? Units { get; set; }

        [JsonProperty("wallet")]
        public JToken Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PaidItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyItemUseRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("units")]
        public long? Units { get; set; }
    }

    public sealed class EconomyItemUseResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("item")]
        public JToken Item { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("paid")]
        public List<PaidItem> Paid { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("units")]
        public long? Units { get; set; }

        [JsonProperty("wallet")]
        public JToken Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PaidItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyLevelsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyLevelsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JObject> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyMetaRelationsRequest
    {
        [JsonProperty("completedOnly")]
        public bool? CompletedOnly { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyMetaRelationsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("ready")]
        public List<ReadyItem> Ready { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("active")]
            public JToken Active { get; set; }

            [JsonProperty("claims")]
            public List<ClaimsItem> Claims { get; set; }

            [JsonProperty("completed")]
            public bool? Completed { get; set; }

            [JsonProperty("condition")]
            public ConditionData Condition { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("done")]
            public bool? Done { get; set; }

            [JsonProperty("endsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("fires")]
            public JToken Fires { get; set; }

            [JsonProperty("grantMode")]
            public JToken GrantMode { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("lastDoneAt")]
            public string LastDoneAt { get; set; }

            [JsonProperty("maxFires")]
            public JToken MaxFires { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("prizeGroup")]
            public bool? PrizeGroup { get; set; }

            [JsonProperty("repeat")]
            public JToken Repeat { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ClaimsItem
            {
                [JsonProperty("claimId")]
                public JToken ClaimId { get; set; }

                [JsonProperty("createdAt")]
                public JToken CreatedAt { get; set; }

                [JsonProperty("grantMode")]
                public JToken GrantMode { get; set; }

                [JsonProperty("prize")]
                public PrizeData Prize { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class PrizeData
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("message")]
                    public string Message { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class ConditionData
            {
                [JsonProperty("current")]
                public JToken Current { get; set; }

                [JsonProperty("holds")]
                public bool? Holds { get; set; }

                [JsonProperty("meta")]
                public JToken Meta { get; set; }

                [JsonProperty("metaName")]
                public string MetaName { get; set; }

                [JsonProperty("operator")]
                public JToken Operator { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class ReadyItem
        {
            [JsonProperty("claimId")]
            public JToken ClaimId { get; set; }

            [JsonProperty("createdAt")]
            public JToken CreatedAt { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("source")]
            public JToken Source { get; set; }

            [JsonProperty("sourceName")]
            public string SourceName { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyOfferBuyRequest
    {
        [JsonProperty("giftCode")]
        public string GiftCode { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }
    }

    public sealed class EconomyOfferBuyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("amountMinor")]
        public JToken AmountMinor { get; set; }

        [JsonProperty("currency")]
        public JToken Currency { get; set; }

        [JsonProperty("developerPayload")]
        public string DeveloperPayload { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("publishableKey")]
        public string PublishableKey { get; set; }

        [JsonProperty("purchaseMessage")]
        public string PurchaseMessage { get; set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("rewardGranted")]
        public bool? RewardGranted { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

        [JsonProperty("sessionId")]
        public JToken SessionId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<RewardsItem_> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardsItem_
            {
                [JsonProperty("action")]
                public string Action { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("rewards")]
                public List<JToken> Rewards { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyOfferSeenRequest
    {
        [JsonProperty("offerId")]
        public string OfferId { get; set; }
    }

    public sealed class EconomyOfferSeenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("offerId")]
        public JToken OfferId { get; set; }

        [JsonProperty("secondsLeft")]
        public long? SecondsLeft { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyOffersRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyOffersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("daily")]
        public DailyData Daily { get; set; }

        [JsonProperty("entry")]
        public EntryData Entry { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("now")]
        public JToken Now { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DailyData
        {
            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("items")]
            public List<ItemsItem> Items { get; set; }

            [JsonProperty("periodEnd")]
            public JToken PeriodEnd { get; set; }

            [JsonProperty("periodStart")]
            public JToken PeriodStart { get; set; }

            [JsonProperty("reroll")]
            public RerollData Reroll { get; set; }

            [JsonProperty("secondsLeft")]
            public long? SecondsLeft { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsItem
            {
                [JsonProperty("badge")]
                public string Badge { get; set; }

                [JsonProperty("bought")]
                public long? Bought { get; set; }

                [JsonProperty("coinOriginal")]
                public JToken CoinOriginal { get; set; }

                [JsonProperty("coinPrice")]
                public JToken CoinPrice { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("discountPercent")]
                public JToken DiscountPercent { get; set; }

                [JsonProperty("durationMinutes")]
                public long? DurationMinutes { get; set; }

                [JsonProperty("expiresAt")]
                public string ExpiresAt { get; set; }

                [JsonProperty("finalToman")]
                public JToken FinalToman { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("offerId")]
                public string OfferId { get; set; }

                [JsonProperty("originalToman")]
                public JToken OriginalToman { get; set; }

                [JsonProperty("paymentMethods")]
                public JToken PaymentMethods { get; set; }

                [JsonProperty("product")]
                public ProductData Product { get; set; }

                [JsonProperty("purchaseLimit")]
                public long? PurchaseLimit { get; set; }

                [JsonProperty("remaining")]
                public JToken Remaining { get; set; }

                [JsonProperty("secondsLeft")]
                public JToken SecondsLeft { get; set; }

                [JsonProperty("shownAt")]
                public string ShownAt { get; set; }

                [JsonProperty("sku")]
                public JObject Sku { get; set; }

                [JsonProperty("slot")]
                public long? Slot { get; set; }

                [JsonProperty("soldOut")]
                public JToken SoldOut { get; set; }

                [JsonProperty("started")]
                public bool? Started { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ProductData
                {
                    [JsonProperty("coverUrl")]
                    public JToken CoverUrl { get; set; }

                    [JsonProperty("iconUrl")]
                    public JToken IconUrl { get; set; }

                    [JsonProperty("id")]
                    public JToken Id { get; set; }

                    [JsonProperty("items")]
                    public JToken Items { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class RerollData
            {
                [JsonProperty("cost")]
                public JToken Cost { get; set; }

                [JsonProperty("enabled")]
                public bool? Enabled { get; set; }

                [JsonProperty("left")]
                public JToken Left { get; set; }

                [JsonProperty("limit")]
                public JToken Limit { get; set; }

                [JsonProperty("used")]
                public long? Used { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class EntryData
        {
            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("items")]
            public List<ItemsItem> Items { get; set; }

            [JsonProperty("timerStart")]
            public string TimerStart { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsItem
            {
                [JsonProperty("badge")]
                public string Badge { get; set; }

                [JsonProperty("bought")]
                public long? Bought { get; set; }

                [JsonProperty("coinOriginal")]
                public JToken CoinOriginal { get; set; }

                [JsonProperty("coinPrice")]
                public JToken CoinPrice { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("discountPercent")]
                public JToken DiscountPercent { get; set; }

                [JsonProperty("durationMinutes")]
                public long? DurationMinutes { get; set; }

                [JsonProperty("expiresAt")]
                public string ExpiresAt { get; set; }

                [JsonProperty("finalToman")]
                public JToken FinalToman { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("offerId")]
                public string OfferId { get; set; }

                [JsonProperty("originalToman")]
                public JToken OriginalToman { get; set; }

                [JsonProperty("paymentMethods")]
                public JToken PaymentMethods { get; set; }

                [JsonProperty("product")]
                public ProductData Product { get; set; }

                [JsonProperty("purchaseLimit")]
                public long? PurchaseLimit { get; set; }

                [JsonProperty("remaining")]
                public JToken Remaining { get; set; }

                [JsonProperty("secondsLeft")]
                public JToken SecondsLeft { get; set; }

                [JsonProperty("shownAt")]
                public string ShownAt { get; set; }

                [JsonProperty("sku")]
                public JObject Sku { get; set; }

                [JsonProperty("slot")]
                public long? Slot { get; set; }

                [JsonProperty("soldOut")]
                public JToken SoldOut { get; set; }

                [JsonProperty("started")]
                public bool? Started { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ProductData
                {
                    [JsonProperty("coverUrl")]
                    public JToken CoverUrl { get; set; }

                    [JsonProperty("iconUrl")]
                    public JToken IconUrl { get; set; }

                    [JsonProperty("id")]
                    public JToken Id { get; set; }

                    [JsonProperty("items")]
                    public JToken Items { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }
    }

    public sealed class EconomyOffersRerollRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyOffersRerollResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("daily")]
        public DailyData Daily { get; set; }

        [JsonProperty("entry")]
        public EntryData Entry { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("now")]
        public JToken Now { get; set; }

        [JsonProperty("paid")]
        public PaidData Paid { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DailyData
        {
            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("items")]
            public List<ItemsItem> Items { get; set; }

            [JsonProperty("periodEnd")]
            public JToken PeriodEnd { get; set; }

            [JsonProperty("periodStart")]
            public JToken PeriodStart { get; set; }

            [JsonProperty("reroll")]
            public RerollData Reroll { get; set; }

            [JsonProperty("secondsLeft")]
            public JToken SecondsLeft { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsItem
            {
                [JsonProperty("badge")]
                public string Badge { get; set; }

                [JsonProperty("bought")]
                public long? Bought { get; set; }

                [JsonProperty("coinOriginal")]
                public JToken CoinOriginal { get; set; }

                [JsonProperty("coinPrice")]
                public JToken CoinPrice { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("discountPercent")]
                public JToken DiscountPercent { get; set; }

                [JsonProperty("durationMinutes")]
                public long? DurationMinutes { get; set; }

                [JsonProperty("expiresAt")]
                public string ExpiresAt { get; set; }

                [JsonProperty("finalToman")]
                public JToken FinalToman { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("offerId")]
                public string OfferId { get; set; }

                [JsonProperty("originalToman")]
                public JToken OriginalToman { get; set; }

                [JsonProperty("paymentMethods")]
                public JToken PaymentMethods { get; set; }

                [JsonProperty("product")]
                public ProductData Product { get; set; }

                [JsonProperty("purchaseLimit")]
                public long? PurchaseLimit { get; set; }

                [JsonProperty("remaining")]
                public JToken Remaining { get; set; }

                [JsonProperty("secondsLeft")]
                public JToken SecondsLeft { get; set; }

                [JsonProperty("shownAt")]
                public string ShownAt { get; set; }

                [JsonProperty("sku")]
                public JObject Sku { get; set; }

                [JsonProperty("slot")]
                public long? Slot { get; set; }

                [JsonProperty("soldOut")]
                public JToken SoldOut { get; set; }

                [JsonProperty("started")]
                public bool? Started { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ProductData
                {
                    [JsonProperty("coverUrl")]
                    public JToken CoverUrl { get; set; }

                    [JsonProperty("iconUrl")]
                    public JToken IconUrl { get; set; }

                    [JsonProperty("id")]
                    public JToken Id { get; set; }

                    [JsonProperty("items")]
                    public JToken Items { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class RerollData
            {
                [JsonProperty("cost")]
                public JToken Cost { get; set; }

                [JsonProperty("enabled")]
                public bool? Enabled { get; set; }

                [JsonProperty("left")]
                public JToken Left { get; set; }

                [JsonProperty("limit")]
                public JToken Limit { get; set; }

                [JsonProperty("used")]
                public JToken Used { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class EntryData
        {
            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("items")]
            public List<ItemsItem> Items { get; set; }

            [JsonProperty("timerStart")]
            public string TimerStart { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsItem
            {
                [JsonProperty("badge")]
                public string Badge { get; set; }

                [JsonProperty("bought")]
                public long? Bought { get; set; }

                [JsonProperty("coinOriginal")]
                public JToken CoinOriginal { get; set; }

                [JsonProperty("coinPrice")]
                public JToken CoinPrice { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("discountPercent")]
                public JToken DiscountPercent { get; set; }

                [JsonProperty("durationMinutes")]
                public long? DurationMinutes { get; set; }

                [JsonProperty("expiresAt")]
                public string ExpiresAt { get; set; }

                [JsonProperty("finalToman")]
                public JToken FinalToman { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("offerId")]
                public string OfferId { get; set; }

                [JsonProperty("originalToman")]
                public JToken OriginalToman { get; set; }

                [JsonProperty("paymentMethods")]
                public JToken PaymentMethods { get; set; }

                [JsonProperty("product")]
                public ProductData Product { get; set; }

                [JsonProperty("purchaseLimit")]
                public long? PurchaseLimit { get; set; }

                [JsonProperty("remaining")]
                public JToken Remaining { get; set; }

                [JsonProperty("secondsLeft")]
                public JToken SecondsLeft { get; set; }

                [JsonProperty("shownAt")]
                public string ShownAt { get; set; }

                [JsonProperty("sku")]
                public JObject Sku { get; set; }

                [JsonProperty("slot")]
                public long? Slot { get; set; }

                [JsonProperty("soldOut")]
                public JToken SoldOut { get; set; }

                [JsonProperty("started")]
                public bool? Started { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class ProductData
                {
                    [JsonProperty("coverUrl")]
                    public JToken CoverUrl { get; set; }

                    [JsonProperty("iconUrl")]
                    public JToken IconUrl { get; set; }

                    [JsonProperty("id")]
                    public JToken Id { get; set; }

                    [JsonProperty("items")]
                    public JToken Items { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }

        public sealed class PaidData
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyPaymentsMineRequest
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class EconomyPaymentsMineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("productName")]
            public string ProductName { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyPlayerCardRequest
    {
        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("levelTable")]
        public string LevelTable { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class EconomyPlayerCardResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("avatar")]
        public AvatarData Avatar { get; set; }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("equipped")]
        public JObject Equipped { get; set; }

        [JsonProperty("gameStats")]
        public GameStatsData GameStats { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public LevelData Level { get; set; }

        [JsonProperty("stats")]
        public JToken Stats { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AvatarData
        {
            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class GameStatsData
        {
            [JsonProperty("forfeits")]
            public long? Forfeits { get; set; }

            [JsonProperty("game")]
            public string Game { get; set; }

            [JsonProperty("lastPlayedAt")]
            public string LastPlayedAt { get; set; }

            [JsonProperty("lossRate")]
            public double? LossRate { get; set; }

            [JsonProperty("losses")]
            public long? Losses { get; set; }

            [JsonProperty("playtimeSeconds")]
            public long? PlaytimeSeconds { get; set; }

            [JsonProperty("timeouts")]
            public long? Timeouts { get; set; }

            [JsonProperty("totalGames")]
            public long? TotalGames { get; set; }

            [JsonProperty("winRate")]
            public double? WinRate { get; set; }

            [JsonProperty("winnings")]
            public JObject Winnings { get; set; }

            [JsonProperty("wins")]
            public long? Wins { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LevelData
        {
            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelStart")]
            public long? LevelStart { get; set; }

            [JsonProperty("maxLevel")]
            public long? MaxLevel { get; set; }

            [JsonProperty("next")]
            public JToken Next { get; set; }

            [JsonProperty("table")]
            public string Table { get; set; }

            [JsonProperty("xp")]
            public long? Xp { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyPurchaseReviewRequest
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public sealed class EconomyPurchaseReviewResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("rewardGranted")]
        public bool? RewardGranted { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<RewardsItem_> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardsItem_
            {
                [JsonProperty("action")]
                public string Action { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("rewards")]
                public List<JToken> Rewards { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyPurchaseStartRequest
    {
        [JsonProperty("giftCode")]
        public string GiftCode { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }
    }

    public sealed class EconomyPurchaseStartResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("amountMinor")]
        public JToken AmountMinor { get; set; }

        [JsonProperty("currency")]
        public JToken Currency { get; set; }

        [JsonProperty("developerPayload")]
        public string DeveloperPayload { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("publishableKey")]
        public string PublishableKey { get; set; }

        [JsonProperty("purchaseMessage")]
        public string PurchaseMessage { get; set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("rewardGranted")]
        public bool? RewardGranted { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

        [JsonProperty("sessionId")]
        public JToken SessionId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<RewardsItem_> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardsItem_
            {
                [JsonProperty("action")]
                public string Action { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("rewards")]
                public List<JToken> Rewards { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyPurchaseStatusRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }
    }

    public sealed class EconomyPurchaseStatusResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("error")]
        public JToken Error { get; set; }

        [JsonProperty("paymentId")]
        public JToken PaymentId { get; set; }

        [JsonProperty("purchaseMessage")]
        public string PurchaseMessage { get; set; }

        [JsonProperty("rewardGranted")]
        public JToken RewardGranted { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyPurchaseSubmitRequest
    {
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public sealed class EconomyPurchaseSubmitResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("rewardGranted")]
        public bool? RewardGranted { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<RewardsItem_> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardsItem_
            {
                [JsonProperty("action")]
                public string Action { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("rewards")]
                public List<JToken> Rewards { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyPurchasesMineRequest
    {
    }

    public sealed class EconomyPurchasesMineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("count")]
            public long? Count { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("lastPurchasedAt")]
            public string LastPurchasedAt { get; set; }

            [JsonProperty("productId")]
            public string ProductId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyReferralEnterRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyReferralEnterResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canEnter")]
        public bool? CanEnter { get; set; }

        [JsonProperty("code")]
        public JToken Code { get; set; }

        [JsonProperty("counts")]
        public CountsData Counts { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("enterUntil")]
        public string EnterUntil { get; set; }

        [JsonProperty("entered")]
        public EnteredData Entered { get; set; }

        [JsonProperty("goal")]
        public GoalData Goal { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("newAccountDays")]
        public JToken NewAccountDays { get; set; }

        [JsonProperty("recent")]
        public List<RecentItem> Recent { get; set; }

        [JsonProperty("referredBy")]
        public ReferredByData ReferredBy { get; set; }

        [JsonProperty("rewards")]
        public RewardsData Rewards { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CountsData
        {
            [JsonProperty("completed")]
            public long? Completed { get; set; }

            [JsonProperty("pending")]
            public long? Pending { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class EnteredData
        {
            [JsonProperty("claims")]
            public List<ClaimsItem> Claims { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ClaimsItem
            {
                [JsonProperty("claimId")]
                public string ClaimId { get; set; }

                [JsonProperty("expiresAt")]
                public JToken ExpiresAt { get; set; }

                [JsonProperty("grantMode")]
                public string GrantMode { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("prizeId")]
                public string PrizeId { get; set; }

                [JsonProperty("prizeKey")]
                public string PrizeKey { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class GoalData
        {
            [JsonProperty("eventKey")]
            public string EventKey { get; set; }

            [JsonProperty("eventName")]
            public string EventName { get; set; }

            [JsonProperty("measure")]
            public string Measure { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RecentItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ReferredByData
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RewardsData
        {
            [JsonProperty("referee")]
            public RefereeData Referee { get; set; }

            [JsonProperty("referrer")]
            public ReferrerData Referrer { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RefereeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class ReferrerData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyReferralMeRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyReferralMeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canEnter")]
        public bool? CanEnter { get; set; }

        [JsonProperty("code")]
        public JToken Code { get; set; }

        [JsonProperty("counts")]
        public CountsData Counts { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("enterUntil")]
        public string EnterUntil { get; set; }

        [JsonProperty("goal")]
        public GoalData Goal { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("newAccountDays")]
        public JToken NewAccountDays { get; set; }

        [JsonProperty("recent")]
        public List<RecentItem> Recent { get; set; }

        [JsonProperty("referredBy")]
        public ReferredByData ReferredBy { get; set; }

        [JsonProperty("rewards")]
        public RewardsData Rewards { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CountsData
        {
            [JsonProperty("completed")]
            public long? Completed { get; set; }

            [JsonProperty("pending")]
            public long? Pending { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class GoalData
        {
            [JsonProperty("eventKey")]
            public string EventKey { get; set; }

            [JsonProperty("eventName")]
            public string EventName { get; set; }

            [JsonProperty("measure")]
            public string Measure { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RecentItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ReferredByData
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RewardsData
        {
            [JsonProperty("referee")]
            public RefereeData Referee { get; set; }

            [JsonProperty("referrer")]
            public ReferrerData Referrer { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RefereeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class ReferrerData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyRegenRefillRequest
    {
        [JsonProperty("currencyKey")]
        public string CurrencyKey { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class EconomyRegenRefillResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyRegenStateRequest
    {
        [JsonProperty("currencies")]
        public List<string> Currencies { get; set; }
    }

    public sealed class EconomyRegenStateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("currencies")]
        public List<JToken> Currencies { get; set; }

        [JsonProperty("serverTime")]
        public JToken ServerTime { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyRewardClaimRequest
    {
        [JsonProperty("claimId")]
        public string ClaimId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyRewardClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("ClaimID")]
        public string ClaimID { get; set; }

        [JsonProperty("Extra")]
        public ExtraData Extra { get; set; }

        [JsonProperty("PrizeID")]
        public string PrizeID { get; set; }

        [JsonProperty("Rewards")]
        public List<RewardsItem> Rewards { get; set; }

        [JsonProperty("Task")]
        public TaskData Task { get; set; }

        [JsonProperty("claimId")]
        public string ClaimId { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("levels")]
        public List<LevelsItem> Levels { get; set; }

        [JsonProperty("prize")]
        public PrizeData Prize { get; set; }

        [JsonProperty("rewards")]
        public List<Rewards_Item> Rewards_ { get; set; }

        [JsonProperty("task")]
        public Task_Data Task_ { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra_ { get; set; }

        public sealed class ExtraData
        {
            [JsonProperty("achievements")]
            public List<JToken> Achievements { get; set; }

            [JsonProperty("claims")]
            public List<JToken> Claims { get; set; }

            [JsonProperty("eventId")]
            public string EventId { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("levels")]
            public List<JToken> Levels { get; set; }

            [JsonProperty("metas")]
            public JObject Metas { get; set; }

            [JsonProperty("relations")]
            public List<JToken> Relations { get; set; }

            [JsonProperty("rules")]
            public List<JToken> Rules { get; set; }

            [JsonProperty("streaks")]
            public List<JToken> Streaks { get; set; }

            [JsonProperty("tasks")]
            public List<JToken> Tasks { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RewardsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<JToken> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class TaskData
        {
            [JsonProperty("Active")]
            public bool? Active { get; set; }

            [JsonProperty("Audience")]
            public List<JToken> Audience { get; set; }

            [JsonProperty("CategoryID")]
            public string CategoryID { get; set; }

            [JsonProperty("Condition")]
            public string Condition { get; set; }

            [JsonProperty("CreatedAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("DependsOn")]
            public List<JToken> DependsOn { get; set; }

            [JsonProperty("Description")]
            public string Description { get; set; }

            [JsonProperty("EndsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("EventTypeID")]
            public string EventTypeID { get; set; }

            [JsonProperty("GrantMode")]
            public string GrantMode { get; set; }

            [JsonProperty("GroupID")]
            public string GroupID { get; set; }

            [JsonProperty("ID")]
            public string ID { get; set; }

            [JsonProperty("IconURL")]
            public string IconURL { get; set; }

            [JsonProperty("Key")]
            public string Key { get; set; }

            [JsonProperty("LevelTableID")]
            public string LevelTableID { get; set; }

            [JsonProperty("MaxCompletions")]
            public long? MaxCompletions { get; set; }

            [JsonProperty("MaxLevel")]
            public JToken MaxLevel { get; set; }

            [JsonProperty("Metric")]
            public string Metric { get; set; }

            [JsonProperty("MinLevel")]
            public JToken MinLevel { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Notify")]
            public bool? Notify { get; set; }

            [JsonProperty("ParentID")]
            public string ParentID { get; set; }

            [JsonProperty("PrizeID")]
            public string PrizeID { get; set; }

            [JsonProperty("Repeat")]
            public string Repeat { get; set; }

            [JsonProperty("RepeatMinutes")]
            public long? RepeatMinutes { get; set; }

            [JsonProperty("Sort")]
            public long? Sort { get; set; }

            [JsonProperty("StartsAt")]
            public JToken StartsAt { get; set; }

            [JsonProperty("TagIDs")]
            public List<JToken> TagIDs { get; set; }

            [JsonProperty("Target")]
            public double? Target { get; set; }

            [JsonProperty("ValueMax")]
            public JToken ValueMax { get; set; }

            [JsonProperty("ValueMin")]
            public JToken ValueMin { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LevelsItem
        {
            [JsonProperty("from")]
            public long? From { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("tableId")]
            public string TableId { get; set; }

            [JsonProperty("to")]
            public long? To { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PrizeData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class Rewards_Item
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<JToken> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class Task_Data
        {
            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("children")]
            public List<JToken> Children { get; set; }

            [JsonProperty("claimId")]
            public string ClaimId { get; set; }

            [JsonProperty("claimable")]
            public bool? Claimable { get; set; }

            [JsonProperty("claimedAt")]
            public JToken ClaimedAt { get; set; }

            [JsonProperty("completedAt")]
            public JToken CompletedAt { get; set; }

            [JsonProperty("completions")]
            public JToken Completions { get; set; }

            [JsonProperty("condition")]
            public string Condition { get; set; }

            [JsonProperty("dependsOn")]
            public List<DependsOnItem> DependsOn { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("grantMode")]
            public string GrantMode { get; set; }

            [JsonProperty("groupId")]
            public string GroupId { get; set; }

            [JsonProperty("groupKey")]
            public string GroupKey { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("maxCompletions")]
            public long? MaxCompletions { get; set; }

            [JsonProperty("metric")]
            public string Metric { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("nextAt")]
            public JToken NextAt { get; set; }

            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            [JsonProperty("parentKey")]
            public JToken ParentKey { get; set; }

            [JsonProperty("pending")]
            public long? Pending { get; set; }

            [JsonProperty("periodEndsAt")]
            public JToken PeriodEndsAt { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("progress")]
            public double? Progress { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("repeat")]
            public string Repeat { get; set; }

            [JsonProperty("repeatMinutes")]
            public long? RepeatMinutes { get; set; }

            [JsonProperty("scope")]
            public JToken Scope { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("tags")]
            public JToken Tags { get; set; }

            [JsonProperty("target")]
            public double? Target { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonProperty("valueMax")]
            public double? ValueMax { get; set; }

            [JsonProperty("valueMin")]
            public double? ValueMin { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class DependsOnItem
            {
                [JsonProperty("done")]
                public long? Done { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyRewardsMineRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public sealed class EconomyRewardsMineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JObject> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyStoreConfigRequest
    {
        [JsonProperty("method")]
        public string Method { get; set; }
    }

    public sealed class EconomyStoreConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("bundleId")]
        public string BundleId { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        [JsonProperty("rsaPublicKey")]
        public string RsaPublicKey { get; set; }

        [JsonProperty("sandbox")]
        public bool? Sandbox { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyStreaksRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyStreaksResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JObject> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class EconomyTaskClaimRequest
    {
        [JsonProperty("claimId")]
        public string ClaimId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("taskId")]
        public string TaskId { get; set; }
    }

    public sealed class EconomyTaskClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimId")]
        public string ClaimId { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("levels")]
        public List<JToken> Levels { get; set; }

        [JsonProperty("prize")]
        public PrizeData Prize { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

        [JsonProperty("task")]
        public TaskData Task { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PrizeData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RewardsItem
        {
            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("rewards")]
            public List<JToken> Rewards { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class TaskData
        {
            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("children")]
            public List<JToken> Children { get; set; }

            [JsonProperty("claimId")]
            public string ClaimId { get; set; }

            [JsonProperty("claimable")]
            public bool? Claimable { get; set; }

            [JsonProperty("claimedAt")]
            public JToken ClaimedAt { get; set; }

            [JsonProperty("completedAt")]
            public JToken CompletedAt { get; set; }

            [JsonProperty("completions")]
            public JToken Completions { get; set; }

            [JsonProperty("condition")]
            public string Condition { get; set; }

            [JsonProperty("dependsOn")]
            public List<DependsOnItem> DependsOn { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("grantMode")]
            public string GrantMode { get; set; }

            [JsonProperty("groupId")]
            public string GroupId { get; set; }

            [JsonProperty("groupKey")]
            public string GroupKey { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("maxCompletions")]
            public long? MaxCompletions { get; set; }

            [JsonProperty("metric")]
            public string Metric { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("nextAt")]
            public JToken NextAt { get; set; }

            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            [JsonProperty("parentKey")]
            public JToken ParentKey { get; set; }

            [JsonProperty("pending")]
            public long? Pending { get; set; }

            [JsonProperty("periodEndsAt")]
            public JToken PeriodEndsAt { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("progress")]
            public double? Progress { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("repeat")]
            public string Repeat { get; set; }

            [JsonProperty("repeatMinutes")]
            public long? RepeatMinutes { get; set; }

            [JsonProperty("scope")]
            public JToken Scope { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("tags")]
            public JToken Tags { get; set; }

            [JsonProperty("target")]
            public double? Target { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonProperty("valueMax")]
            public double? ValueMax { get; set; }

            [JsonProperty("valueMin")]
            public double? ValueMin { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class DependsOnItem
            {
                [JsonProperty("done")]
                public long? Done { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class EconomyTaskGroupCurrentRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyTaskGroupCurrentResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("group")]
        public GroupData Group { get; set; }

        [JsonProperty("handed")]
        public List<string> Handed { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GroupData
        {
            [JsonProperty("activeCount")]
            public long? ActiveCount { get; set; }

            [JsonProperty("canRequest")]
            public JToken CanRequest { get; set; }

            [JsonProperty("categoryKey")]
            public JToken CategoryKey { get; set; }

            [JsonProperty("cycle")]
            public JToken Cycle { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("done")]
            public JToken Done { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("finished")]
            public JToken Finished { get; set; }

            [JsonProperty("handout")]
            public string Handout { get; set; }

            [JsonProperty("handoutMinutes")]
            public long? HandoutMinutes { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("nextAt")]
            public JToken NextAt { get; set; }

            [JsonProperty("open")]
            public bool? Open { get; set; }

            [JsonProperty("orderMode")]
            public string OrderMode { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("remaining")]
            public JToken Remaining { get; set; }

            [JsonProperty("repeatable")]
            public bool? Repeatable { get; set; }

            [JsonProperty("tasks")]
            public JToken Tasks { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyTaskGroupNextRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyTaskGroupNextResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("group")]
        public GroupData Group { get; set; }

        [JsonProperty("handed")]
        public List<string> Handed { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GroupData
        {
            [JsonProperty("activeCount")]
            public long? ActiveCount { get; set; }

            [JsonProperty("canRequest")]
            public JToken CanRequest { get; set; }

            [JsonProperty("categoryKey")]
            public JToken CategoryKey { get; set; }

            [JsonProperty("cycle")]
            public JToken Cycle { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("done")]
            public JToken Done { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("finished")]
            public JToken Finished { get; set; }

            [JsonProperty("handout")]
            public string Handout { get; set; }

            [JsonProperty("handoutMinutes")]
            public long? HandoutMinutes { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("nextAt")]
            public JToken NextAt { get; set; }

            [JsonProperty("open")]
            public bool? Open { get; set; }

            [JsonProperty("orderMode")]
            public string OrderMode { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("remaining")]
            public JToken Remaining { get; set; }

            [JsonProperty("repeatable")]
            public bool? Repeatable { get; set; }

            [JsonProperty("tasks")]
            public JToken Tasks { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyTasksListRequest
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class EconomyTasksListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("groups")]
        public List<GroupsItem> Groups { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("ready")]
        public long? Ready { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class GroupsItem
        {
            [JsonProperty("activeCount")]
            public long? ActiveCount { get; set; }

            [JsonProperty("canRequest")]
            public bool? CanRequest { get; set; }

            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("cycle")]
            public JToken Cycle { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("done")]
            public long? Done { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("finished")]
            public bool? Finished { get; set; }

            [JsonProperty("handout")]
            public string Handout { get; set; }

            [JsonProperty("handoutMinutes")]
            public long? HandoutMinutes { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("nextAt")]
            public JToken NextAt { get; set; }

            [JsonProperty("open")]
            public bool? Open { get; set; }

            [JsonProperty("orderMode")]
            public string OrderMode { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("remaining")]
            public long? Remaining { get; set; }

            [JsonProperty("repeatable")]
            public bool? Repeatable { get; set; }

            [JsonProperty("tasks")]
            public List<TasksItem> Tasks { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class TasksItem
            {
                [JsonProperty("categoryKey")]
                public string CategoryKey { get; set; }

                [JsonProperty("children")]
                public List<JToken> Children { get; set; }

                [JsonProperty("claimId")]
                public string ClaimId { get; set; }

                [JsonProperty("claimable")]
                public bool? Claimable { get; set; }

                [JsonProperty("claimedAt")]
                public JToken ClaimedAt { get; set; }

                [JsonProperty("completedAt")]
                public JToken CompletedAt { get; set; }

                [JsonProperty("completions")]
                public JToken Completions { get; set; }

                [JsonProperty("condition")]
                public string Condition { get; set; }

                [JsonProperty("dependsOn")]
                public List<DependsOnItem> DependsOn { get; set; }

                [JsonProperty("description")]
                public JToken Description { get; set; }

                [JsonProperty("error")]
                public string Error { get; set; }

                [JsonProperty("expiresAt")]
                public JToken ExpiresAt { get; set; }

                [JsonProperty("grantMode")]
                public string GrantMode { get; set; }

                [JsonProperty("groupId")]
                public string GroupId { get; set; }

                [JsonProperty("groupKey")]
                public string GroupKey { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("isActive")]
                public bool? IsActive { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("maxCompletions")]
                public long? MaxCompletions { get; set; }

                [JsonProperty("metric")]
                public string Metric { get; set; }

                [JsonProperty("name")]
                public JToken Name { get; set; }

                [JsonProperty("nextAt")]
                public JToken NextAt { get; set; }

                [JsonProperty("parentId")]
                public string ParentId { get; set; }

                [JsonProperty("parentKey")]
                public JToken ParentKey { get; set; }

                [JsonProperty("pending")]
                public long? Pending { get; set; }

                [JsonProperty("periodEndsAt")]
                public JToken PeriodEndsAt { get; set; }

                [JsonProperty("prize")]
                public PrizeData Prize { get; set; }

                [JsonProperty("progress")]
                public double? Progress { get; set; }

                [JsonProperty("reason")]
                public string Reason { get; set; }

                [JsonProperty("repeat")]
                public string Repeat { get; set; }

                [JsonProperty("repeatMinutes")]
                public long? RepeatMinutes { get; set; }

                [JsonProperty("scope")]
                public JToken Scope { get; set; }

                [JsonProperty("state")]
                public string State { get; set; }

                [JsonProperty("status")]
                public string Status { get; set; }

                [JsonProperty("tags")]
                public JToken Tags { get; set; }

                [JsonProperty("target")]
                public double? Target { get; set; }

                [JsonProperty("value")]
                public double? Value { get; set; }

                [JsonProperty("valueMax")]
                public double? ValueMax { get; set; }

                [JsonProperty("valueMin")]
                public double? ValueMin { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class DependsOnItem
                {
                    [JsonProperty("done")]
                    public long? Done { get; set; }

                    [JsonProperty("id")]
                    public JToken Id { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class PrizeData
                {
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("message")]
                    public string Message { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }

        public sealed class ItemsItem
        {
            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("children")]
            public List<JToken> Children { get; set; }

            [JsonProperty("claimId")]
            public string ClaimId { get; set; }

            [JsonProperty("claimable")]
            public bool? Claimable { get; set; }

            [JsonProperty("claimedAt")]
            public JToken ClaimedAt { get; set; }

            [JsonProperty("completedAt")]
            public JToken CompletedAt { get; set; }

            [JsonProperty("completions")]
            public JToken Completions { get; set; }

            [JsonProperty("condition")]
            public string Condition { get; set; }

            [JsonProperty("dependsOn")]
            public List<DependsOnItem> DependsOn { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("grantMode")]
            public string GrantMode { get; set; }

            [JsonProperty("groupId")]
            public string GroupId { get; set; }

            [JsonProperty("groupKey")]
            public string GroupKey { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("maxCompletions")]
            public long? MaxCompletions { get; set; }

            [JsonProperty("metric")]
            public string Metric { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("nextAt")]
            public JToken NextAt { get; set; }

            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            [JsonProperty("parentKey")]
            public JToken ParentKey { get; set; }

            [JsonProperty("pending")]
            public long? Pending { get; set; }

            [JsonProperty("periodEndsAt")]
            public JToken PeriodEndsAt { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("progress")]
            public double? Progress { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("repeat")]
            public string Repeat { get; set; }

            [JsonProperty("repeatMinutes")]
            public long? RepeatMinutes { get; set; }

            [JsonProperty("scope")]
            public JToken Scope { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("tags")]
            public JToken Tags { get; set; }

            [JsonProperty("target")]
            public double? Target { get; set; }

            [JsonProperty("value")]
            public double? Value { get; set; }

            [JsonProperty("valueMax")]
            public double? ValueMax { get; set; }

            [JsonProperty("valueMin")]
            public double? ValueMin { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class DependsOnItem
            {
                [JsonProperty("done")]
                public long? Done { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class FlickkickBotMatchRequest
    {
    }

    public sealed class FlickkickBotMatchResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("matchId")]
        public JToken MatchId { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class FlickkickConfigRequest
    {
    }

    public sealed class FlickkickConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("arena")]
        public JToken Arena { get; set; }

        [JsonProperty("ball")]
        public BallData Ball { get; set; }

        [JsonProperty("botPrize")]
        public BotPrizeData BotPrize { get; set; }

        [JsonProperty("botTimeoutSeconds")]
        public long? BotTimeoutSeconds { get; set; }

        [JsonProperty("botsAllowed")]
        public bool? BotsAllowed { get; set; }

        [JsonProperty("cosmeticSlots")]
        public List<string> CosmeticSlots { get; set; }

        [JsonProperty("defaultFormation")]
        public JToken DefaultFormation { get; set; }

        [JsonProperty("disc")]
        public DiscData Disc { get; set; }

        [JsonProperty("discsPerTeam")]
        public JToken DiscsPerTeam { get; set; }

        [JsonProperty("formation")]
        public JToken Formation { get; set; }

        [JsonProperty("formationItemType")]
        public string FormationItemType { get; set; }

        [JsonProperty("formationMode")]
        public string FormationMode { get; set; }

        [JsonProperty("formationModes")]
        public JObject FormationModes { get; set; }

        [JsonProperty("formationRooms")]
        public List<string> FormationRooms { get; set; }

        [JsonProperty("formations")]
        public List<FormationsItem> Formations { get; set; }

        [JsonProperty("friendRooms")]
        public bool? FriendRooms { get; set; }

        [JsonProperty("goalsToWin")]
        public JToken GoalsToWin { get; set; }

        [JsonProperty("graceSeconds")]
        public long? GraceSeconds { get; set; }

        [JsonProperty("keyframeSteps")]
        public long? KeyframeSteps { get; set; }

        [JsonProperty("matchSeconds")]
        public long? MatchSeconds { get; set; }

        [JsonProperty("maxImpulse")]
        public JToken MaxImpulse { get; set; }

        [JsonProperty("maxShots")]
        public JToken MaxShots { get; set; }

        [JsonProperty("minImpulse")]
        public JToken MinImpulse { get; set; }

        [JsonProperty("protocolVersion")]
        public JToken ProtocolVersion { get; set; }

        [JsonProperty("rooms")]
        public long? Rooms { get; set; }

        [JsonProperty("simVersion")]
        public JToken SimVersion { get; set; }

        [JsonProperty("stepHz")]
        public JToken StepHz { get; set; }

        [JsonProperty("turnSeconds")]
        public long? TurnSeconds { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class BallData
        {
            [JsonProperty("radius")]
            public JToken Radius { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class BotPrizeData
        {
            [JsonProperty("afterCap")]
            public string AfterCap { get; set; }

            [JsonProperty("dailyCap")]
            public long? DailyCap { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("roomModes")]
            public JObject RoomModes { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class DiscData
        {
            [JsonProperty("radius")]
            public JToken Radius { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class FormationsItem
        {
            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("points")]
            public JToken Points { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class FlickkickFormationsRequest
    {
    }

    public sealed class FlickkickFormationsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("defaultFormation")]
        public JToken DefaultFormation { get; set; }

        [JsonProperty("formations")]
        public List<FormationsItem> Formations { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class FormationsItem
        {
            [JsonProperty("item")]
            public Item_ Item { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("points")]
            public List<List<double?>> Points { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("usable")]
            public bool? Usable { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class Item_
            {
                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("imageUrl")]
                public string ImageUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("metadata")]
                public JToken Metadata { get; set; }

                [JsonProperty("name")]
                public JToken Name { get; set; }

                [JsonProperty("owned")]
                public bool? Owned { get; set; }

                [JsonProperty("price")]
                public JToken Price { get; set; }

                [JsonProperty("rarity")]
                public string Rarity { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class FlickkickFriendCancelRequest
    {
    }

    public sealed class FlickkickFriendCancelResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class FlickkickFriendCreateRequest
    {
    }

    public sealed class FlickkickFriendCreateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("existing")]
        public bool? Existing { get; set; }

        [JsonProperty("expiresInSeconds")]
        public long? ExpiresInSeconds { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class FlickkickFriendJoinRequest
    {
    }

    public sealed class FlickkickFriendJoinResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("room")]
        public JToken Room { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class InsightsConfigRequest
    {
        [JsonProperty("game")]
        public string Game { get; set; }
    }

    public sealed class InsightsConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("events")]
        public EventsData Events { get; set; }

        [JsonProperty("heatmap")]
        public HeatmapData Heatmap { get; set; }

        [JsonProperty("sessions")]
        public SessionsData Sessions { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class EventsData
        {
            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("flushSeconds")]
            public JToken FlushSeconds { get; set; }

            [JsonProperty("game")]
            public string Game { get; set; }

            [JsonProperty("maxBatch")]
            public JToken MaxBatch { get; set; }

            [JsonProperty("maxNameLength")]
            public JToken MaxNameLength { get; set; }

            [JsonProperty("maxQueue")]
            public JToken MaxQueue { get; set; }

            [JsonProperty("maxTags")]
            public JToken MaxTags { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class HeatmapData
        {
            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("format")]
            public string Format { get; set; }

            [JsonProperty("maps")]
            public List<string> Maps { get; set; }

            [JsonProperty("maxBytes")]
            public JToken MaxBytes { get; set; }

            [JsonProperty("maxPoints")]
            public JToken MaxPoints { get; set; }

            [JsonProperty("unknownMaps")]
            public JToken UnknownMaps { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SessionsData
        {
            [JsonProperty("pingSeconds")]
            public JToken PingSeconds { get; set; }

            [JsonProperty("source")]
            public JToken Source { get; set; }

            [JsonProperty("timeoutSeconds")]
            public JToken TimeoutSeconds { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class InsightsHeatmapRequest
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("part")]
        public long? Part { get; set; }

        [JsonProperty("points")]
        public List<List<JToken>> Points { get; set; }

        [JsonProperty("uploadId")]
        public string UploadId { get; set; }
    }

    public sealed class InsightsHeatmapResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accepted")]
        public long? Accepted { get; set; }

        [JsonProperty("cells")]
        public long? Cells { get; set; }

        [JsonProperty("dropped")]
        public long? Dropped { get; set; }

        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }

        [JsonProperty("part")]
        public long? Part { get; set; }

        [JsonProperty("players")]
        public long? Players { get; set; }

        [JsonProperty("uploadId")]
        public string UploadId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class InsightsSendRequest
    {
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("batchId")]
        public string BatchId { get; set; }

        [JsonProperty("events")]
        public List<JToken> Events { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class InsightsSendResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accepted")]
        public long? Accepted { get; set; }

        [JsonProperty("batchId")]
        public string BatchId { get; set; }

        [JsonProperty("dropped")]
        public long? Dropped { get; set; }

        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }

        [JsonProperty("flagged")]
        public long? Flagged { get; set; }

        [JsonProperty("received")]
        public long? Received { get; set; }

        [JsonProperty("rejected")]
        public long? Rejected { get; set; }

        [JsonProperty("results")]
        public List<JToken> Results { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class InsightsSessionRequest
    {
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("seconds")]
        public double? Seconds { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class InsightsSessionResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("created")]
        public bool? Created { get; set; }

        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }

        [JsonProperty("ignored")]
        public bool? Ignored { get; set; }

        [JsonProperty("pingSeconds")]
        public JToken PingSeconds { get; set; }

        [JsonProperty("seconds")]
        public JToken Seconds { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("source")]
        public JToken Source { get; set; }

        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timeoutSeconds")]
        public JToken TimeoutSeconds { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class InventoryxItemsRequest
    {
        [JsonProperty("keys")]
        public List<string> Keys { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class InventoryxItemsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("level")]
        public JToken Level { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("attributes")]
            public JObject Attributes { get; set; }

            [JsonProperty("canUnlockEarly")]
            public bool? CanUnlockEarly { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("tracks")]
            public List<TracksItem> Tracks { get; set; }

            [JsonProperty("unlockLevel")]
            public JToken UnlockLevel { get; set; }

            [JsonProperty("unlockPrices")]
            public JToken UnlockPrices { get; set; }

            [JsonProperty("unlocked")]
            public bool? Unlocked { get; set; }

            [JsonProperty("unlockedEarly")]
            public bool? UnlockedEarly { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class TracksItem
            {
                [JsonProperty("base")]
                public double? Base { get; set; }

                [JsonProperty("canUpgrade")]
                public bool? CanUpgrade { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("level")]
                public JToken Level { get; set; }

                [JsonProperty("maxLevel")]
                public long? MaxLevel { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("nextMinPlayerLevel")]
                public long? NextMinPlayerLevel { get; set; }

                [JsonProperty("nextPrice")]
                public NextPriceData NextPrice { get; set; }

                [JsonProperty("nextRequires")]
                public List<NextRequiresItem> NextRequires { get; set; }

                [JsonProperty("nextValue")]
                public double? NextValue { get; set; }

                [JsonProperty("unit")]
                public string Unit { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class NextPriceData
                {
                    [JsonProperty("amount")]
                    public long? Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public string CurrencyKey { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class NextRequiresItem
                {
                    [JsonProperty("level")]
                    public JToken Level { get; set; }

                    [JsonProperty("met")]
                    public bool? Met { get; set; }

                    [JsonProperty("track")]
                    public JToken Track { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }
    }

    public sealed class InventoryxUnlockRequest
    {
        [JsonProperty("currencyKey")]
        public string CurrencyKey { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class InventoryxUnlockResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("item")]
        public Item_ Item { get; set; }

        [JsonProperty("itemKey")]
        public string ItemKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("owned")]
        public bool? Owned { get; set; }

        [JsonProperty("paid")]
        public List<PaidItem> Paid { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("unlocked")]
        public bool? Unlocked { get; set; }

        [JsonProperty("wallet")]
        public JObject Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class Item_
        {
            [JsonProperty("attributes")]
            public JObject Attributes { get; set; }

            [JsonProperty("canUnlockEarly")]
            public bool? CanUnlockEarly { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("tracks")]
            public List<TracksItem> Tracks { get; set; }

            [JsonProperty("unlockPrices")]
            public List<UnlockPricesItem> UnlockPrices { get; set; }

            [JsonProperty("unlocked")]
            public bool? Unlocked { get; set; }

            [JsonProperty("unlockedEarly")]
            public bool? UnlockedEarly { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class TracksItem
            {
                [JsonProperty("base")]
                public double? Base { get; set; }

                [JsonProperty("canUpgrade")]
                public bool? CanUpgrade { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("level")]
                public JToken Level { get; set; }

                [JsonProperty("maxLevel")]
                public long? MaxLevel { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("nextMinPlayerLevel")]
                public long? NextMinPlayerLevel { get; set; }

                [JsonProperty("nextPrice")]
                public NextPriceData NextPrice { get; set; }

                [JsonProperty("nextRequires")]
                public List<NextRequiresItem> NextRequires { get; set; }

                [JsonProperty("nextValue")]
                public JToken NextValue { get; set; }

                [JsonProperty("unit")]
                public string Unit { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class NextPriceData
                {
                    [JsonProperty("amount")]
                    public long? Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public string CurrencyKey { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class NextRequiresItem
                {
                    [JsonProperty("level")]
                    public JToken Level { get; set; }

                    [JsonProperty("met")]
                    public bool? Met { get; set; }

                    [JsonProperty("track")]
                    public JToken Track { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class UnlockPricesItem
            {
                [JsonProperty("amount")]
                public long? Amount { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class PaidItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class InventoryxUpgradeRequest
    {
        [JsonProperty("fromLevel")]
        public long? FromLevel { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("track")]
        public string Track { get; set; }
    }

    public sealed class InventoryxUpgradeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("item")]
        public Item_ Item { get; set; }

        [JsonProperty("itemKey")]
        public string ItemKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("owned")]
        public bool? Owned { get; set; }

        [JsonProperty("paid")]
        public List<PaidItem> Paid { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("unlocked")]
        public bool? Unlocked { get; set; }

        [JsonProperty("wallet")]
        public JObject Wallet { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class Item_
        {
            [JsonProperty("attributes")]
            public JObject Attributes { get; set; }

            [JsonProperty("canUnlockEarly")]
            public bool? CanUnlockEarly { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("tracks")]
            public List<TracksItem> Tracks { get; set; }

            [JsonProperty("unlockPrices")]
            public List<UnlockPricesItem> UnlockPrices { get; set; }

            [JsonProperty("unlocked")]
            public bool? Unlocked { get; set; }

            [JsonProperty("unlockedEarly")]
            public bool? UnlockedEarly { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class TracksItem
            {
                [JsonProperty("base")]
                public double? Base { get; set; }

                [JsonProperty("canUpgrade")]
                public bool? CanUpgrade { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("level")]
                public JToken Level { get; set; }

                [JsonProperty("maxLevel")]
                public long? MaxLevel { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("nextMinPlayerLevel")]
                public long? NextMinPlayerLevel { get; set; }

                [JsonProperty("nextPrice")]
                public NextPriceData NextPrice { get; set; }

                [JsonProperty("nextRequires")]
                public List<NextRequiresItem> NextRequires { get; set; }

                [JsonProperty("nextValue")]
                public JToken NextValue { get; set; }

                [JsonProperty("unit")]
                public string Unit { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class NextPriceData
                {
                    [JsonProperty("amount")]
                    public long? Amount { get; set; }

                    [JsonProperty("currencyKey")]
                    public string CurrencyKey { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class NextRequiresItem
                {
                    [JsonProperty("level")]
                    public JToken Level { get; set; }

                    [JsonProperty("met")]
                    public bool? Met { get; set; }

                    [JsonProperty("track")]
                    public JToken Track { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class UnlockPricesItem
            {
                [JsonProperty("amount")]
                public long? Amount { get; set; }

                [JsonProperty("currencyKey")]
                public string CurrencyKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class PaidItem
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class LeaderboardxBoardRequest
    {
        [JsonProperty("around")]
        public long? Around { get; set; }

        [JsonProperty("clan")]
        public bool? Clan { get; set; }

        [JsonProperty("clanId")]
        public string ClanId { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class LeaderboardxBoardResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("around")]
        public List<JObject> Around { get; set; }

        [JsonProperty("clan")]
        public ClanData Clan { get; set; }

        [JsonProperty("clientSubmit")]
        public bool? ClientSubmit { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("endsAt")]
        public string EndsAt { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("me")]
        public MeData Me { get; set; }

        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("payMode")]
        public string PayMode { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("periodEnd")]
        public string PeriodEnd { get; set; }

        [JsonProperty("periodStart")]
        public string PeriodStart { get; set; }

        [JsonProperty("players")]
        public long? Players { get; set; }

        [JsonProperty("resetSchedule")]
        public string ResetSchedule { get; set; }

        [JsonProperty("rewardMinScore")]
        public long? RewardMinScore { get; set; }

        [JsonProperty("rewards")]
        public List<JObject> Rewards { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("sort")]
        public long? Sort { get; set; }

        [JsonProperty("sortOrder")]
        public string SortOrder { get; set; }

        [JsonProperty("startsAt")]
        public string StartsAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tierBasis")]
        public string TierBasis { get; set; }

        [JsonProperty("tiers")]
        public List<TiersItem> Tiers { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClanData
        {
            [JsonProperty("clanId")]
            public string ClanId { get; set; }

            [JsonProperty("me")]
            public JObject Me { get; set; }

            [JsonProperty("members")]
            public long? Members { get; set; }

            [JsonProperty("top")]
            public List<JObject> Top { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class MeData
        {
            [JsonProperty("nextTier")]
            public NextTierData NextTier { get; set; }

            [JsonProperty("rank")]
            public JToken Rank { get; set; }

            [JsonProperty("score")]
            public JToken Score { get; set; }

            [JsonProperty("subscore")]
            public JToken Subscore { get; set; }

            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class NextTierData
            {
                [JsonProperty("index")]
                public JToken Index { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("need")]
                public JToken Need { get; set; }

                [JsonProperty("rank")]
                public long? Rank { get; set; }

                [JsonProperty("score")]
                public double? Score { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class TiersItem
        {
            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("threshold")]
            public JToken Threshold { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class LeaderboardxClaimRequest
    {
        [JsonProperty("all")]
        public bool? All { get; set; }

        [JsonProperty("periodId")]
        public string PeriodId { get; set; }
    }

    public sealed class LeaderboardxClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimed")]
        public List<ClaimedItem> Claimed { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ClaimedItem
        {
            [JsonProperty("boardKey")]
            public string BoardKey { get; set; }

            [JsonProperty("periodId")]
            public string PeriodId { get; set; }

            [JsonProperty("rank")]
            public long? Rank { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class LeaderboardxHistoryRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("offset")]
        public long? Offset { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public sealed class LeaderboardxHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimable")]
        public long? Claimable { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("more")]
        public bool? More { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("claimExpiresAt")]
            public JToken ClaimExpiresAt { get; set; }

            [JsonProperty("lastError")]
            public string LastError { get; set; }

            [JsonProperty("paid")]
            public JObject Paid { get; set; }

            [JsonProperty("paidAt")]
            public JToken PaidAt { get; set; }

            [JsonProperty("payTries")]
            public long? PayTries { get; set; }

            [JsonProperty("periodId")]
            public string PeriodId { get; set; }

            [JsonProperty("rank")]
            public long? Rank { get; set; }

            [JsonProperty("rewards")]
            public RewardsData Rewards { get; set; }

            [JsonProperty("score")]
            public long? Score { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("subscore")]
            public long? Subscore { get; set; }

            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonProperty("tierRank")]
            public long? TierRank { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardsData
            {
                [JsonProperty("currencies")]
                public JToken Currencies { get; set; }

                [JsonProperty("prizes")]
                public JToken Prizes { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class LeaderboardxListRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class LeaderboardxListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("boards")]
        public List<BoardsItem> Boards { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class BoardsItem
        {
            [JsonProperty("claimable")]
            public long? Claimable { get; set; }

            [JsonProperty("clientSubmit")]
            public bool? ClientSubmit { get; set; }

            [JsonProperty("description")]
            public JToken Description { get; set; }

            [JsonProperty("endsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("me")]
            public MeData Me { get; set; }

            [JsonProperty("metadata")]
            public JObject Metadata { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("operator")]
            public string Operator { get; set; }

            [JsonProperty("payMode")]
            public JToken PayMode { get; set; }

            [JsonProperty("period")]
            public string Period { get; set; }

            [JsonProperty("periodEnd")]
            public JToken PeriodEnd { get; set; }

            [JsonProperty("periodStart")]
            public JToken PeriodStart { get; set; }

            [JsonProperty("resetSchedule")]
            public string ResetSchedule { get; set; }

            [JsonProperty("rewardMinScore")]
            public long? RewardMinScore { get; set; }

            [JsonProperty("rewards")]
            public JToken Rewards { get; set; }

            [JsonProperty("scope")]
            public string Scope { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("sortOrder")]
            public string SortOrder { get; set; }

            [JsonProperty("startsAt")]
            public JToken StartsAt { get; set; }

            [JsonProperty("status")]
            public JToken Status { get; set; }

            [JsonProperty("tierBasis")]
            public string TierBasis { get; set; }

            [JsonProperty("tiers")]
            public List<TiersItem> Tiers { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class MeData
            {
                [JsonProperty("nextTier")]
                public NextTierData NextTier { get; set; }

                [JsonProperty("rank")]
                public JToken Rank { get; set; }

                [JsonProperty("score")]
                public JToken Score { get; set; }

                [JsonProperty("subscore")]
                public JToken Subscore { get; set; }

                [JsonProperty("tier")]
                public string Tier { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class NextTierData
                {
                    [JsonProperty("index")]
                    public JToken Index { get; set; }

                    [JsonProperty("key")]
                    public JToken Key { get; set; }

                    [JsonProperty("need")]
                    public JToken Need { get; set; }

                    [JsonProperty("rank")]
                    public long? Rank { get; set; }

                    [JsonProperty("score")]
                    public double? Score { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class TiersItem
            {
                [JsonProperty("iconUrl")]
                public JToken IconUrl { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("threshold")]
                public JToken Threshold { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class LeaderboardxSubmitRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("score")]
        public double? Score { get; set; }

        [JsonProperty("subscore")]
        public double? Subscore { get; set; }
    }

    public sealed class LeaderboardxSubmitResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accepted")]
        public bool? Accepted { get; set; }

        [JsonProperty("clamped")]
        public bool? Clamped { get; set; }

        [JsonProperty("key")]
        public JToken Key { get; set; }

        [JsonProperty("rank")]
        public JToken Rank { get; set; }

        [JsonProperty("replayed")]
        public JToken Replayed { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("score")]
        public JToken Score { get; set; }

        [JsonProperty("subscore")]
        public JToken Subscore { get; set; }

        [JsonProperty("tier")]
        public JToken Tier { get; set; }

        [JsonProperty("written")]
        public JToken Written { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class LeaderboardxWinnersRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("periodId")]
        public string PeriodId { get; set; }
    }

    public sealed class LeaderboardxWinnersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("period")]
        public JToken Period { get; set; }

        [JsonProperty("periods")]
        public List<PeriodsItem> Periods { get; set; }

        [JsonProperty("winners")]
        public List<JObject> Winners { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PeriodsItem
        {
            [JsonProperty("periodEnd")]
            public string PeriodEnd { get; set; }

            [JsonProperty("periodId")]
            public string PeriodId { get; set; }

            [JsonProperty("periodStart")]
            public string PeriodStart { get; set; }

            [JsonProperty("players")]
            public long? Players { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class LedgerKindsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class LedgerKindsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("historyDays")]
        public JToken HistoryDays { get; set; }

        [JsonProperty("kinds")]
        public List<KindsItem> Kinds { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("maxLimit")]
        public JToken MaxLimit { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class KindsItem
        {
            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class LedgerListRequest
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("itemKey")]
        public string ItemKey { get; set; }

        [JsonProperty("kinds")]
        public List<string> Kinds { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("refId")]
        public string RefId { get; set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

    public sealed class LedgerListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("amount")]
            public JToken Amount { get; set; }

            [JsonProperty("at")]
            public string At { get; set; }

            [JsonProperty("change")]
            public JToken Change { get; set; }

            [JsonProperty("currency")]
            public JToken Currency { get; set; }

            [JsonProperty("currencyName")]
            public string CurrencyName { get; set; }

            [JsonProperty("id")]
            public JToken Id { get; set; }

            [JsonProperty("itemKey")]
            public JToken ItemKey { get; set; }

            [JsonProperty("itemName")]
            public string ItemName { get; set; }

            [JsonProperty("kind")]
            public JToken Kind { get; set; }

            [JsonProperty("kindName")]
            public JToken KindName { get; set; }

            [JsonProperty("level")]
            public JToken Level { get; set; }

            [JsonProperty("reason")]
            public JToken Reason { get; set; }

            [JsonProperty("refId")]
            public JToken RefId { get; set; }

            [JsonProperty("source")]
            public JToken Source { get; set; }

            [JsonProperty("sourceId")]
            public JToken SourceId { get; set; }

            [JsonProperty("sourceType")]
            public JToken SourceType { get; set; }

            [JsonProperty("title")]
            public JToken Title { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PpLocalStateRequest
    {
        [JsonProperty("balances")]
        public List<BalancesItem> Balances { get; set; }

        [JsonProperty("ownedKeys")]
        public List<string> OwnedKeys { get; set; }

        public sealed class BalancesItem
        {
            [JsonProperty("amount")]
            public double? Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("currencyId")]
            public string CurrencyId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PpLocalStateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("_mismatch")]
        public MismatchData Mismatch { get; set; }

        [JsonProperty("adopted")]
        public JObject Adopted { get; set; }

        [JsonProperty("received")]
        public bool? Received { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class MismatchData
        {
            [JsonProperty("balances")]
            public List<BalancesItem> Balances { get; set; }

            [JsonProperty("items")]
            public List<string> Items { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class BalancesItem
            {
                [JsonProperty("currency")]
                public string Currency { get; set; }

                [JsonProperty("local")]
                public double? Local { get; set; }

                [JsonProperty("server")]
                public double? Server { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class PredictionAnswerUpdateRequest
    {
    }

    public sealed class PredictionAnswerUpdateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionConfigRequest
    {
    }

    public sealed class PredictionConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answerEdit")]
        public JToken AnswerEdit { get; set; }

        [JsonProperty("kickoffLockOffsetSeconds")]
        public JToken KickoffLockOffsetSeconds { get; set; }

        [JsonProperty("leaderboard")]
        public LeaderboardData Leaderboard { get; set; }

        [JsonProperty("lockPolicy")]
        public JToken LockPolicy { get; set; }

        [JsonProperty("scoreline")]
        public ScorelineData Scoreline { get; set; }

        [JsonProperty("winThreshold")]
        public JToken WinThreshold { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class LeaderboardData
        {
            [JsonProperty("basis")]
            public JToken Basis { get; set; }

            [JsonProperty("currency")]
            public JToken Currency { get; set; }

            [JsonProperty("pointsPerFullAnswer")]
            public JToken PointsPerFullAnswer { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ScorelineData
        {
            [JsonProperty("maxGoals")]
            public JToken MaxGoals { get; set; }

            [JsonProperty("scoringMode")]
            public JToken ScoringMode { get; set; }

            [JsonProperty("tiers")]
            public JToken Tiers { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PredictionEventRequest
    {
    }

    public sealed class PredictionEventResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionEventsRequest
    {
    }

    public sealed class PredictionEventsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionHistoryRequest
    {
    }

    public sealed class PredictionHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionLeaderboardRequest
    {
    }

    public sealed class PredictionLeaderboardResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionLeagueRequest
    {
    }

    public sealed class PredictionLeagueResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionLeaguesRequest
    {
    }

    public sealed class PredictionLeaguesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionMyAnswersRequest
    {
    }

    public sealed class PredictionMyAnswersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionMyStatsRequest
    {
    }

    public sealed class PredictionMyStatsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionQuestionEventsRequest
    {
    }

    public sealed class PredictionQuestionEventsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionResultsRequest
    {
    }

    public sealed class PredictionResultsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PredictionSubmitRequest
    {
    }

    public sealed class PredictionSubmitResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationBannerClickRequest
    {
        [JsonProperty("bannerId")]
        public string BannerId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class PublicationBannerClickResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("action")]
        public JToken Action { get; set; }

        [JsonProperty("bannerId")]
        public JToken BannerId { get; set; }

        [JsonProperty("counted")]
        public bool? Counted { get; set; }

        [JsonProperty("sponsorCounted")]
        public bool? SponsorCounted { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationBannerViewRequest
    {
        [JsonProperty("bannerIds")]
        public List<string> BannerIds { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class PublicationBannerViewResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("counted")]
        public List<string> Counted { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("skipped")]
        public List<string> Skipped { get; set; }

        [JsonProperty("sponsorsCounted")]
        public List<string> SponsorsCounted { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationBannersRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("placement")]
        public string Placement { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public sealed class PublicationBannersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("placement")]
        public PlacementData Placement { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("action")]
            public ActionData Action { get; set; }

            [JsonProperty("bgColor")]
            public string BgColor { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("endsAt")]
            public string EndsAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("imageUrl")]
            public string ImageUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("priority")]
            public long? Priority { get; set; }

            [JsonProperty("sponsor")]
            public JToken Sponsor { get; set; }

            [JsonProperty("subtitle")]
            public string Subtitle { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ActionData
            {
                [JsonProperty("label")]
                public string Label { get; set; }

                [JsonProperty("sponsorId")]
                public string SponsorId { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("url")]
                public JToken Url { get; set; }

                [JsonProperty("value")]
                public string Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class PlacementData
        {
            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("layout")]
            public JToken Layout { get; set; }

            [JsonProperty("maxItems")]
            public JToken MaxItems { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("rotateSeconds")]
            public JToken RotateSeconds { get; set; }

            [JsonProperty("sponsor")]
            public JToken Sponsor { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationFaqListRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("q")]
        public string Q { get; set; }
    }

    public sealed class PublicationFaqListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("categories")]
        public List<CategoriesItem> Categories { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CategoriesItem
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ItemsItem
        {
            [JsonProperty("answer")]
            public string Answer { get; set; }

            [JsonProperty("answerHtml")]
            public string AnswerHtml { get; set; }

            [JsonProperty("categoryKey")]
            public JToken CategoryKey { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("question")]
            public string Question { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationInboxRequest
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class PublicationInboxResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("unread")]
        public long? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("action")]
            public ActionData Action { get; set; }

            [JsonProperty("body")]
            public JToken Body { get; set; }

            [JsonProperty("bodyHtml")]
            public string BodyHtml { get; set; }

            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("claimed")]
            public JToken Claimed { get; set; }

            [JsonProperty("claimedAt")]
            public JToken ClaimedAt { get; set; }

            [JsonProperty("createdAt")]
            public JToken CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("imageUrl")]
            public string ImageUrl { get; set; }

            [JsonProperty("opened")]
            public bool? Opened { get; set; }

            [JsonProperty("prize")]
            public PrizeData Prize { get; set; }

            [JsonProperty("seen")]
            public bool? Seen { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ActionData
            {
                [JsonProperty("label")]
                public string Label { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public string Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class CategoryData
            {
                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class PrizeData
            {
                [JsonProperty("id")]
                public string Id { get; set; }

                [JsonProperty("items")]
                public JToken Items { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class PublicationInboxClaimRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("notificationId")]
        public string NotificationId { get; set; }
    }

    public sealed class PublicationInboxClaimResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("claimed")]
        public bool? Claimed { get; set; }

        [JsonProperty("notificationId")]
        public string NotificationId { get; set; }

        [JsonProperty("prizes")]
        public JToken Prizes { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationInboxSeenRequest
    {
        [JsonProperty("all")]
        public bool? All { get; set; }

        [JsonProperty("ids")]
        public List<string> Ids { get; set; }
    }

    public sealed class PublicationInboxSeenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("unread")]
        public long? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNewsBySlugRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public sealed class PublicationNewsBySlugResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("actions")]
        public List<ActionsItem> Actions { get; set; }

        [JsonProperty("allowComment")]
        public bool? AllowComment { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("bodyFormat")]
        public string BodyFormat { get; set; }

        [JsonProperty("bodyHtml")]
        public string BodyHtml { get; set; }

        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("commentCount")]
        public long? CommentCount { get; set; }

        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }

        [JsonProperty("expired")]
        public bool? Expired { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isPinned")]
        public bool? IsPinned { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("publishedAt")]
        public JToken PublishedAt { get; set; }

        [JsonProperty("reactionTypes")]
        public JToken ReactionTypes { get; set; }

        [JsonProperty("seen")]
        public bool? Seen { get; set; }

        [JsonProperty("seo")]
        public SeoData Seo { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ActionsItem
        {
            [JsonProperty("label")]
            public string Label { get; set; }

            [JsonProperty("type")]
            public JToken Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SeoData
        {
            [JsonProperty("canonicalUrl")]
            public string CanonicalUrl { get; set; }

            [JsonProperty("keywords")]
            public List<string> Keywords { get; set; }

            [JsonProperty("metaDescription")]
            public string MetaDescription { get; set; }

            [JsonProperty("metaTitle")]
            public string MetaTitle { get; set; }

            [JsonProperty("noindex")]
            public bool? Noindex { get; set; }

            [JsonProperty("ogImage")]
            public string OgImage { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationNewsCommentRequest
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("newsId")]
        public string NewsId { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }
    }

    public sealed class PublicationNewsCommentResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("replies")]
        public List<JObject> Replies { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNewsCommentDeleteRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public sealed class PublicationNewsCommentDeleteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNewsCommentsRequest
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("newsId")]
        public string NewsId { get; set; }
    }

    public sealed class PublicationNewsCommentsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("replies")]
            public List<JObject> Replies { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationNewsGetRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public sealed class PublicationNewsGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("actions")]
        public List<ActionsItem> Actions { get; set; }

        [JsonProperty("allowComment")]
        public bool? AllowComment { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("bodyFormat")]
        public string BodyFormat { get; set; }

        [JsonProperty("bodyHtml")]
        public string BodyHtml { get; set; }

        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("commentCount")]
        public long? CommentCount { get; set; }

        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }

        [JsonProperty("expired")]
        public bool? Expired { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isPinned")]
        public bool? IsPinned { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("publishedAt")]
        public JToken PublishedAt { get; set; }

        [JsonProperty("reactionTypes")]
        public JToken ReactionTypes { get; set; }

        [JsonProperty("seen")]
        public bool? Seen { get; set; }

        [JsonProperty("seo")]
        public SeoData Seo { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ActionsItem
        {
            [JsonProperty("label")]
            public string Label { get; set; }

            [JsonProperty("type")]
            public JToken Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SeoData
        {
            [JsonProperty("canonicalUrl")]
            public string CanonicalUrl { get; set; }

            [JsonProperty("keywords")]
            public List<string> Keywords { get; set; }

            [JsonProperty("metaDescription")]
            public string MetaDescription { get; set; }

            [JsonProperty("metaTitle")]
            public string MetaTitle { get; set; }

            [JsonProperty("noindex")]
            public bool? Noindex { get; set; }

            [JsonProperty("ogImage")]
            public string OgImage { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationNewsListRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("expired")]
        public string Expired { get; set; }

        [JsonProperty("includeReactions")]
        public bool? IncludeReactions { get; set; }

        [JsonProperty("includeSeo")]
        public bool? IncludeSeo { get; set; }

        [JsonProperty("includeTags")]
        public bool? IncludeTags { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("tagKey")]
        public string TagKey { get; set; }

        [JsonProperty("tagKeys")]
        public List<string> TagKeys { get; set; }

        [JsonProperty("tagMode")]
        public string TagMode { get; set; }

        [JsonProperty("unreadOnly")]
        public bool? UnreadOnly { get; set; }
    }

    public sealed class PublicationNewsListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("reactionTypes")]
        public JToken ReactionTypes { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("allowComment")]
            public JToken AllowComment { get; set; }

            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

            [JsonProperty("commentCount")]
            public JToken CommentCount { get; set; }

            [JsonProperty("coverUrl")]
            public JToken CoverUrl { get; set; }

            [JsonProperty("expired")]
            public bool? Expired { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("id")]
            public JToken Id { get; set; }

            [JsonProperty("isPinned")]
            public JToken IsPinned { get; set; }

            [JsonProperty("publishedAt")]
            public JToken PublishedAt { get; set; }

            [JsonProperty("seen")]
            public JToken Seen { get; set; }

            [JsonProperty("seo")]
            public SeoData Seo { get; set; }

            [JsonProperty("slug")]
            public JToken Slug { get; set; }

            [JsonProperty("sourceUrl")]
            public string SourceUrl { get; set; }

            [JsonProperty("summary")]
            public string Summary { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class SeoData
            {
                [JsonProperty("canonicalUrl")]
                public string CanonicalUrl { get; set; }

                [JsonProperty("keywords")]
                public List<string> Keywords { get; set; }

                [JsonProperty("metaDescription")]
                public string MetaDescription { get; set; }

                [JsonProperty("metaTitle")]
                public string MetaTitle { get; set; }

                [JsonProperty("noindex")]
                public bool? Noindex { get; set; }

                [JsonProperty("ogImage")]
                public string OgImage { get; set; }

                [JsonProperty("slug")]
                public string Slug { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class PublicationNewsReactRequest
    {
        [JsonProperty("newsId")]
        public string NewsId { get; set; }

        [JsonProperty("reaction")]
        public string Reaction { get; set; }
    }

    public sealed class PublicationNewsReactResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("newsId")]
        public string NewsId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNewsReactionTypesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class PublicationNewsReactionTypesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JObject> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNewsSeenRequest
    {
        [JsonProperty("all")]
        public bool? All { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ids")]
        public List<string> Ids { get; set; }
    }

    public sealed class PublicationNewsSeenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("unread")]
        public JToken Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNewsUnreadRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("tagKey")]
        public string TagKey { get; set; }

        [JsonProperty("tagKeys")]
        public List<string> TagKeys { get; set; }

        [JsonProperty("tagMode")]
        public string TagMode { get; set; }
    }

    public sealed class PublicationNewsUnreadResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("unread")]
        public long? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNotificationOpenedRequest
    {
        [JsonProperty("notificationId")]
        public string NotificationId { get; set; }
    }

    public sealed class PublicationNotificationOpenedResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("counted")]
        public bool? Counted { get; set; }

        [JsonProperty("unread")]
        public long? Unread { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationNotifyPrefsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class PublicationNotifyPrefsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("pushDevices")]
        public long? PushDevices { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("canOptOut")]
            public bool? CanOptOut { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationNotifyPrefsSetRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("prefs")]
        public JObject Prefs { get; set; }
    }

    public sealed class PublicationNotifyPrefsSetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("pushDevices")]
        public long? PushDevices { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("canOptOut")]
            public bool? CanOptOut { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationOtpRequestRequest
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public sealed class PublicationOtpRequestResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("codeLength")]
        public long? CodeLength { get; set; }

        [JsonProperty("expiresIn")]
        public long? ExpiresIn { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("resendAfter")]
        public long? ResendAfter { get; set; }

        [JsonProperty("sandbox")]
        public bool? Sandbox { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationOtpVerifyRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("link")]
        public bool? Link { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public sealed class PublicationOtpVerifyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("created")]
        public bool? Created { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("linked")]
        public bool? Linked { get; set; }

        [JsonProperty("loginKey")]
        public string LoginKey { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("token")]
        public JToken Token { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationPhoneRequest
    {
    }

    public sealed class PublicationPhoneResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("codeLength")]
        public long? CodeLength { get; set; }

        [JsonProperty("otpEnabled")]
        public bool? OtpEnabled { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationPushDevicesRequest
    {
    }

    public sealed class PublicationPushDevicesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("active")]
            public bool? Active { get; set; }

            [JsonProperty("appVersion")]
            public string AppVersion { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("lastSeenAt")]
            public JToken LastSeenAt { get; set; }

            [JsonProperty("platform")]
            public string Platform { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class PublicationPushRegisterRequest
    {
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public sealed class PublicationPushRegisterResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationPushUnregisterRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public sealed class PublicationPushUnregisterResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("removed")]
        public bool? Removed { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationSponsorClickRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("sponsorId")]
        public string SponsorId { get; set; }
    }

    public sealed class PublicationSponsorClickResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("counted")]
        public bool? Counted { get; set; }

        [JsonProperty("sponsor")]
        public SponsorData Sponsor { get; set; }

        [JsonProperty("sponsorId")]
        public JToken SponsorId { get; set; }

        [JsonProperty("url")]
        public JToken Url { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class SponsorData
        {
            [JsonProperty("action")]
            public ActionData Action { get; set; }

            [JsonProperty("bgColor")]
            public string BgColor { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("endsAt")]
            public string EndsAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("imageUrl")]
            public string ImageUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("links")]
            public List<LinksItem> Links { get; set; }

            [JsonProperty("priority")]
            public long? Priority { get; set; }

            [JsonProperty("sponsor")]
            public JToken Sponsor { get; set; }

            [JsonProperty("subtitle")]
            public string Subtitle { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ActionData
            {
                [JsonProperty("label")]
                public string Label { get; set; }

                [JsonProperty("sponsorId")]
                public string SponsorId { get; set; }

                [JsonProperty("type")]
                public JToken Type { get; set; }

                [JsonProperty("url")]
                public JToken Url { get; set; }

                [JsonProperty("value")]
                public string Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class LinksItem
            {
                [JsonProperty("label")]
                public string Label { get; set; }

                [JsonProperty("type")]
                public JToken Type { get; set; }

                [JsonProperty("url")]
                public JToken Url { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class PublicationSponsorViewRequest
    {
        [JsonProperty("sponsorIds")]
        public List<string> SponsorIds { get; set; }
    }

    public sealed class PublicationSponsorViewResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("counted")]
        public List<string> Counted { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("skipped")]
        public List<string> Skipped { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class PublicationSponsorsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("tagKey")]
        public string TagKey { get; set; }
    }

    public sealed class PublicationSponsorsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("action")]
            public ActionData Action { get; set; }

            [JsonProperty("bgColor")]
            public string BgColor { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("endsAt")]
            public string EndsAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("imageUrl")]
            public string ImageUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("links")]
            public List<LinksItem> Links { get; set; }

            [JsonProperty("priority")]
            public long? Priority { get; set; }

            [JsonProperty("sponsor")]
            public JToken Sponsor { get; set; }

            [JsonProperty("subtitle")]
            public string Subtitle { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ActionData
            {
                [JsonProperty("label")]
                public string Label { get; set; }

                [JsonProperty("sponsorId")]
                public string SponsorId { get; set; }

                [JsonProperty("type")]
                public JToken Type { get; set; }

                [JsonProperty("url")]
                public JToken Url { get; set; }

                [JsonProperty("value")]
                public string Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class LinksItem
            {
                [JsonProperty("label")]
                public string Label { get; set; }

                [JsonProperty("type")]
                public JToken Type { get; set; }

                [JsonProperty("url")]
                public JToken Url { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizAnswerRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("optionIds")]
        public List<long?> OptionIds { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public sealed class QuizAnswerResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answered")]
        public JToken Answered { get; set; }

        [JsonProperty("correct")]
        public bool? Correct { get; set; }

        [JsonProperty("correctCount")]
        public JToken CorrectCount { get; set; }

        [JsonProperty("next")]
        public NextData Next { get; set; }

        [JsonProperty("outcome")]
        public string Outcome { get; set; }

        [JsonProperty("questionId")]
        public JToken QuestionId { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("sessionId")]
        public JToken SessionId { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class NextData
        {
            [JsonProperty("acceptedAnswers")]
            public JObject AcceptedAnswers { get; set; }

            [JsonProperty("answered")]
            public AnsweredData Answered { get; set; }

            [JsonProperty("deadlineAt")]
            public string DeadlineAt { get; set; }

            [JsonProperty("difficulty")]
            public long? Difficulty { get; set; }

            [JsonProperty("hints")]
            public List<HintsItem> Hints { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("mediaUrl")]
            public string MediaUrl { get; set; }

            [JsonProperty("options")]
            public List<OptionsItem> Options { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("timeSeconds")]
            public JToken TimeSeconds { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class AnsweredData
            {
                [JsonProperty("optionIds")]
                public List<long?> OptionIds { get; set; }

                [JsonProperty("outcome")]
                public string Outcome { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class HintsItem
            {
                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("owned")]
                public bool? Owned { get; set; }

                [JsonProperty("price")]
                public JToken Price { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OptionsItem
            {
                [JsonProperty("correct")]
                public bool? Correct { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("mediaUrl")]
                public JToken MediaUrl { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizAnswerAllRequest
    {
        [JsonProperty("answers")]
        public List<AnswersItem> Answers { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        public sealed class AnswersItem
        {
            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("optionId")]
            public long? OptionId { get; set; }

            [JsonProperty("optionIds")]
            public List<long?> OptionIds { get; set; }

            [JsonProperty("questionId")]
            public string QuestionId { get; set; }

            [JsonProperty("sessionId")]
            public string SessionId { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizAnswerAllResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answers")]
        public List<AnswersItem> Answers { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AnswersItem
        {
            [JsonProperty("error")]
            public JToken Error { get; set; }

            [JsonProperty("questionId")]
            public JToken QuestionId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizDuelAcceptRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("duelId")]
        public string DuelId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
    }

    public sealed class QuizDuelAcceptResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("duelId")]
        public JToken DuelId { get; set; }

        [JsonProperty("entryFee")]
        public JToken EntryFee { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("finishedAt")]
        public JToken FinishedAt { get; set; }

        [JsonProperty("invitedByYou")]
        public bool? InvitedByYou { get; set; }

        [JsonProperty("mode")]
        public JToken Mode { get; set; }

        [JsonProperty("opponent")]
        public JToken Opponent { get; set; }

        [JsonProperty("questionSeconds")]
        public JToken QuestionSeconds { get; set; }

        [JsonProperty("questionsPerRound")]
        public JToken QuestionsPerRound { get; set; }

        [JsonProperty("reason")]
        public JToken Reason { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("roundList")]
        public List<RoundListItem> RoundList { get; set; }

        [JsonProperty("rounds")]
        public JToken Rounds { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("step")]
        public StepData Step { get; set; }

        [JsonProperty("turn")]
        public JToken Turn { get; set; }

        [JsonProperty("turnDeadline")]
        public JToken TurnDeadline { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("winner")]
        public JToken Winner { get; set; }

        [JsonProperty("you")]
        public JToken You { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RoundListItem
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("opponentCorrect")]
            public JToken OpponentCorrect { get; set; }

            [JsonProperty("picker")]
            public string Picker { get; set; }

            [JsonProperty("round")]
            public string Round { get; set; }

            [JsonProperty("you")]
            public List<string> You { get; set; }

            [JsonProperty("youCorrect")]
            public long? YouCorrect { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StepData
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("offers")]
            public List<OffersItem> Offers { get; set; }

            [JsonProperty("round")]
            public JToken Round { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OffersItem
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelAnswerRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("duelId")]
        public string DuelId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
    }

    public sealed class QuizDuelAnswerResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("duel")]
        public DuelData Duel { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        [JsonProperty("next")]
        public NextData Next { get; set; }

        [JsonProperty("roundDone")]
        public bool? RoundDone { get; set; }

        [JsonProperty("roundTotal")]
        public long? RoundTotal { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DuelData
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("duelId")]
            public string DuelId { get; set; }

            [JsonProperty("entryFee")]
            public JToken EntryFee { get; set; }

            [JsonProperty("expiresAt")]
            public string ExpiresAt { get; set; }

            [JsonProperty("finishedAt")]
            public string FinishedAt { get; set; }

            [JsonProperty("invitedByYou")]
            public bool? InvitedByYou { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("opponent")]
            public OpponentData Opponent { get; set; }

            [JsonProperty("questionSeconds")]
            public long? QuestionSeconds { get; set; }

            [JsonProperty("questionsPerRound")]
            public JToken QuestionsPerRound { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("result")]
            public JToken Result { get; set; }

            [JsonProperty("roundList")]
            public List<RoundListItem> RoundList { get; set; }

            [JsonProperty("rounds")]
            public long? Rounds { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("step")]
            public StepData Step { get; set; }

            [JsonProperty("turn")]
            public JToken Turn { get; set; }

            [JsonProperty("turnDeadline")]
            public string TurnDeadline { get; set; }

            [JsonProperty("updatedAt")]
            public string UpdatedAt { get; set; }

            [JsonProperty("winner")]
            public string Winner { get; set; }

            [JsonProperty("you")]
            public YouData You { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class OpponentData
            {
                [JsonProperty("avatarUrl")]
                public JToken AvatarUrl { get; set; }

                [JsonProperty("displayName")]
                public JToken DisplayName { get; set; }

                [JsonProperty("score")]
                public JToken Score { get; set; }

                [JsonProperty("userId")]
                public string UserId { get; set; }

                [JsonProperty("username")]
                public JToken Username { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class RoundListItem
            {
                [JsonProperty("category")]
                public CategoryData Category { get; set; }

                [JsonProperty("opponent")]
                public JToken Opponent { get; set; }

                [JsonProperty("opponentCorrect")]
                public JToken OpponentCorrect { get; set; }

                [JsonProperty("picker")]
                public string Picker { get; set; }

                [JsonProperty("round")]
                public string Round { get; set; }

                [JsonProperty("you")]
                public List<string> You { get; set; }

                [JsonProperty("youCorrect")]
                public long? YouCorrect { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class CategoryData
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class StepData
            {
                [JsonProperty("category")]
                public CategoryData Category { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("offers")]
                public List<OffersItem> Offers { get; set; }

                [JsonProperty("round")]
                public JToken Round { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class CategoryData
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class OffersItem
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class YouData
            {
                [JsonProperty("avatarUrl")]
                public JToken AvatarUrl { get; set; }

                [JsonProperty("displayName")]
                public JToken DisplayName { get; set; }

                [JsonProperty("score")]
                public JToken Score { get; set; }

                [JsonProperty("userId")]
                public string UserId { get; set; }

                [JsonProperty("username")]
                public JToken Username { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class NextData
        {
            [JsonProperty("deadlineAt")]
            public string DeadlineAt { get; set; }

            [JsonProperty("duelId")]
            public string DuelId { get; set; }

            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("mediaUrl")]
            public JToken MediaUrl { get; set; }

            [JsonProperty("options")]
            public List<OptionsItem> Options { get; set; }

            [JsonProperty("questionId")]
            public JToken QuestionId { get; set; }

            [JsonProperty("round")]
            public long? Round { get; set; }

            [JsonProperty("seconds")]
            public long? Seconds { get; set; }

            [JsonProperty("servedAt")]
            public string ServedAt { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class OptionsItem
            {
                [JsonProperty("id")]
                public long? Id { get; set; }

                [JsonProperty("mediaUrl")]
                public string MediaUrl { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelCategoriesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class QuizDuelCategoriesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("categories")]
        public List<CategoriesItem> Categories { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("rules")]
        public RulesData Rules { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CategoriesItem
        {
            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("playable")]
            public bool? Playable { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RulesData
        {
            [JsonProperty("categoryChoices")]
            public JToken CategoryChoices { get; set; }

            [JsonProperty("dailyStarts")]
            public JToken DailyStarts { get; set; }

            [JsonProperty("drawPrize")]
            public JToken DrawPrize { get; set; }

            [JsonProperty("entryFee")]
            public JToken EntryFee { get; set; }

            [JsonProperty("friendsOnly")]
            public JToken FriendsOnly { get; set; }

            [JsonProperty("inviteHours")]
            public JToken InviteHours { get; set; }

            [JsonProperty("losePrize")]
            public JToken LosePrize { get; set; }

            [JsonProperty("maxActive")]
            public JToken MaxActive { get; set; }

            [JsonProperty("perCorrect")]
            public JToken PerCorrect { get; set; }

            [JsonProperty("questionSeconds")]
            public JToken QuestionSeconds { get; set; }

            [JsonProperty("questionsPerRound")]
            public JToken QuestionsPerRound { get; set; }

            [JsonProperty("rounds")]
            public JToken Rounds { get; set; }

            [JsonProperty("turnHours")]
            public JToken TurnHours { get; set; }

            [JsonProperty("waitingHours")]
            public JToken WaitingHours { get; set; }

            [JsonProperty("winPrize")]
            public JToken WinPrize { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizDuelDeclineRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("duelId")]
        public string DuelId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
    }

    public sealed class QuizDuelDeclineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("duelId")]
        public JToken DuelId { get; set; }

        [JsonProperty("entryFee")]
        public JToken EntryFee { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("finishedAt")]
        public JToken FinishedAt { get; set; }

        [JsonProperty("invitedByYou")]
        public bool? InvitedByYou { get; set; }

        [JsonProperty("mode")]
        public JToken Mode { get; set; }

        [JsonProperty("opponent")]
        public JToken Opponent { get; set; }

        [JsonProperty("questionSeconds")]
        public JToken QuestionSeconds { get; set; }

        [JsonProperty("questionsPerRound")]
        public JToken QuestionsPerRound { get; set; }

        [JsonProperty("reason")]
        public JToken Reason { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("roundList")]
        public List<RoundListItem> RoundList { get; set; }

        [JsonProperty("rounds")]
        public JToken Rounds { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("step")]
        public StepData Step { get; set; }

        [JsonProperty("turn")]
        public JToken Turn { get; set; }

        [JsonProperty("turnDeadline")]
        public JToken TurnDeadline { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("winner")]
        public JToken Winner { get; set; }

        [JsonProperty("you")]
        public JToken You { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RoundListItem
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("opponentCorrect")]
            public JToken OpponentCorrect { get; set; }

            [JsonProperty("picker")]
            public string Picker { get; set; }

            [JsonProperty("round")]
            public string Round { get; set; }

            [JsonProperty("you")]
            public List<string> You { get; set; }

            [JsonProperty("youCorrect")]
            public long? YouCorrect { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StepData
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("offers")]
            public List<OffersItem> Offers { get; set; }

            [JsonProperty("round")]
            public JToken Round { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OffersItem
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelForfeitRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("duelId")]
        public string DuelId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
    }

    public sealed class QuizDuelForfeitResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("duelId")]
        public JToken DuelId { get; set; }

        [JsonProperty("entryFee")]
        public JToken EntryFee { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("finishedAt")]
        public JToken FinishedAt { get; set; }

        [JsonProperty("invitedByYou")]
        public bool? InvitedByYou { get; set; }

        [JsonProperty("mode")]
        public JToken Mode { get; set; }

        [JsonProperty("opponent")]
        public JToken Opponent { get; set; }

        [JsonProperty("questionSeconds")]
        public JToken QuestionSeconds { get; set; }

        [JsonProperty("questionsPerRound")]
        public JToken QuestionsPerRound { get; set; }

        [JsonProperty("reason")]
        public JToken Reason { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("roundList")]
        public List<RoundListItem> RoundList { get; set; }

        [JsonProperty("rounds")]
        public JToken Rounds { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("step")]
        public StepData Step { get; set; }

        [JsonProperty("turn")]
        public JToken Turn { get; set; }

        [JsonProperty("turnDeadline")]
        public JToken TurnDeadline { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("winner")]
        public JToken Winner { get; set; }

        [JsonProperty("you")]
        public JToken You { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RoundListItem
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("opponentCorrect")]
            public JToken OpponentCorrect { get; set; }

            [JsonProperty("picker")]
            public string Picker { get; set; }

            [JsonProperty("round")]
            public string Round { get; set; }

            [JsonProperty("you")]
            public List<string> You { get; set; }

            [JsonProperty("youCorrect")]
            public long? YouCorrect { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StepData
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("offers")]
            public List<OffersItem> Offers { get; set; }

            [JsonProperty("round")]
            public JToken Round { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OffersItem
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelGetRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("duelId")]
        public string DuelId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
    }

    public sealed class QuizDuelGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("duelId")]
        public JToken DuelId { get; set; }

        [JsonProperty("entryFee")]
        public JToken EntryFee { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("finishedAt")]
        public JToken FinishedAt { get; set; }

        [JsonProperty("invitedByYou")]
        public bool? InvitedByYou { get; set; }

        [JsonProperty("mode")]
        public JToken Mode { get; set; }

        [JsonProperty("opponent")]
        public JToken Opponent { get; set; }

        [JsonProperty("questionSeconds")]
        public JToken QuestionSeconds { get; set; }

        [JsonProperty("questionsPerRound")]
        public JToken QuestionsPerRound { get; set; }

        [JsonProperty("reason")]
        public JToken Reason { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("roundList")]
        public List<RoundListItem> RoundList { get; set; }

        [JsonProperty("rounds")]
        public JToken Rounds { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("step")]
        public StepData Step { get; set; }

        [JsonProperty("turn")]
        public JToken Turn { get; set; }

        [JsonProperty("turnDeadline")]
        public JToken TurnDeadline { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("winner")]
        public JToken Winner { get; set; }

        [JsonProperty("you")]
        public JToken You { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RoundListItem
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("opponentCorrect")]
            public JToken OpponentCorrect { get; set; }

            [JsonProperty("picker")]
            public string Picker { get; set; }

            [JsonProperty("round")]
            public string Round { get; set; }

            [JsonProperty("you")]
            public List<string> You { get; set; }

            [JsonProperty("youCorrect")]
            public long? YouCorrect { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StepData
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("offers")]
            public List<OffersItem> Offers { get; set; }

            [JsonProperty("round")]
            public JToken Round { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OffersItem
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelListRequest
    {
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public sealed class QuizDuelListResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("duels")]
        public List<DuelsItem> Duels { get; set; }

        [JsonProperty("nextCursor")]
        public string NextCursor { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DuelsItem
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("duelId")]
            public string DuelId { get; set; }

            [JsonProperty("entryFee")]
            public JToken EntryFee { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("finishedAt")]
            public JToken FinishedAt { get; set; }

            [JsonProperty("invitedByYou")]
            public bool? InvitedByYou { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("questionSeconds")]
            public JToken QuestionSeconds { get; set; }

            [JsonProperty("questionsPerRound")]
            public JToken QuestionsPerRound { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("result")]
            public JToken Result { get; set; }

            [JsonProperty("roundList")]
            public List<RoundListItem> RoundList { get; set; }

            [JsonProperty("rounds")]
            public JToken Rounds { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("step")]
            public StepData Step { get; set; }

            [JsonProperty("turn")]
            public JToken Turn { get; set; }

            [JsonProperty("turnDeadline")]
            public JToken TurnDeadline { get; set; }

            [JsonProperty("updatedAt")]
            public string UpdatedAt { get; set; }

            [JsonProperty("winner")]
            public JToken Winner { get; set; }

            [JsonProperty("you")]
            public JToken You { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RoundListItem
            {
                [JsonProperty("category")]
                public CategoryData Category { get; set; }

                [JsonProperty("opponent")]
                public JToken Opponent { get; set; }

                [JsonProperty("opponentCorrect")]
                public JToken OpponentCorrect { get; set; }

                [JsonProperty("picker")]
                public string Picker { get; set; }

                [JsonProperty("round")]
                public string Round { get; set; }

                [JsonProperty("you")]
                public List<string> You { get; set; }

                [JsonProperty("youCorrect")]
                public long? YouCorrect { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class CategoryData
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class StepData
            {
                [JsonProperty("category")]
                public CategoryData Category { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("offers")]
                public List<OffersItem> Offers { get; set; }

                [JsonProperty("round")]
                public JToken Round { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class CategoryData
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class OffersItem
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }
    }

    public sealed class QuizDuelPickCategoryRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("duelId")]
        public string DuelId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
    }

    public sealed class QuizDuelPickCategoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("duelId")]
        public JToken DuelId { get; set; }

        [JsonProperty("entryFee")]
        public JToken EntryFee { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("finishedAt")]
        public JToken FinishedAt { get; set; }

        [JsonProperty("invitedByYou")]
        public bool? InvitedByYou { get; set; }

        [JsonProperty("mode")]
        public JToken Mode { get; set; }

        [JsonProperty("opponent")]
        public JToken Opponent { get; set; }

        [JsonProperty("questionSeconds")]
        public JToken QuestionSeconds { get; set; }

        [JsonProperty("questionsPerRound")]
        public JToken QuestionsPerRound { get; set; }

        [JsonProperty("reason")]
        public JToken Reason { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("roundList")]
        public List<RoundListItem> RoundList { get; set; }

        [JsonProperty("rounds")]
        public JToken Rounds { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("step")]
        public StepData Step { get; set; }

        [JsonProperty("turn")]
        public JToken Turn { get; set; }

        [JsonProperty("turnDeadline")]
        public JToken TurnDeadline { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("winner")]
        public JToken Winner { get; set; }

        [JsonProperty("you")]
        public JToken You { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RoundListItem
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("opponentCorrect")]
            public JToken OpponentCorrect { get; set; }

            [JsonProperty("picker")]
            public string Picker { get; set; }

            [JsonProperty("round")]
            public string Round { get; set; }

            [JsonProperty("you")]
            public List<string> You { get; set; }

            [JsonProperty("youCorrect")]
            public long? YouCorrect { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StepData
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("offers")]
            public List<OffersItem> Offers { get; set; }

            [JsonProperty("round")]
            public JToken Round { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OffersItem
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelQuestionRequest
    {
        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("duelId")]
        public string DuelId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("optionId")]
        public long? OptionId { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
    }

    public sealed class QuizDuelQuestionResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("duel")]
        public DuelData Duel { get; set; }

        [JsonProperty("question")]
        public QuestionData Question { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DuelData
        {
            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("duelId")]
            public string DuelId { get; set; }

            [JsonProperty("entryFee")]
            public JToken EntryFee { get; set; }

            [JsonProperty("expiresAt")]
            public JToken ExpiresAt { get; set; }

            [JsonProperty("finishedAt")]
            public JToken FinishedAt { get; set; }

            [JsonProperty("invitedByYou")]
            public bool? InvitedByYou { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("questionSeconds")]
            public JToken QuestionSeconds { get; set; }

            [JsonProperty("questionsPerRound")]
            public JToken QuestionsPerRound { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("result")]
            public JToken Result { get; set; }

            [JsonProperty("roundList")]
            public List<RoundListItem> RoundList { get; set; }

            [JsonProperty("rounds")]
            public JToken Rounds { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("step")]
            public StepData Step { get; set; }

            [JsonProperty("turn")]
            public JToken Turn { get; set; }

            [JsonProperty("turnDeadline")]
            public JToken TurnDeadline { get; set; }

            [JsonProperty("updatedAt")]
            public string UpdatedAt { get; set; }

            [JsonProperty("winner")]
            public JToken Winner { get; set; }

            [JsonProperty("you")]
            public JToken You { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RoundListItem
            {
                [JsonProperty("category")]
                public CategoryData Category { get; set; }

                [JsonProperty("opponent")]
                public JToken Opponent { get; set; }

                [JsonProperty("opponentCorrect")]
                public JToken OpponentCorrect { get; set; }

                [JsonProperty("picker")]
                public string Picker { get; set; }

                [JsonProperty("round")]
                public string Round { get; set; }

                [JsonProperty("you")]
                public List<string> You { get; set; }

                [JsonProperty("youCorrect")]
                public long? YouCorrect { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class CategoryData
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }

            public sealed class StepData
            {
                [JsonProperty("category")]
                public CategoryData Category { get; set; }

                [JsonProperty("kind")]
                public string Kind { get; set; }

                [JsonProperty("offers")]
                public List<OffersItem> Offers { get; set; }

                [JsonProperty("round")]
                public JToken Round { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }

                public sealed class CategoryData
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }

                public sealed class OffersItem
                {
                    [JsonProperty("color")]
                    public string Color { get; set; }

                    [JsonProperty("description")]
                    public string Description { get; set; }

                    [JsonProperty("iconUrl")]
                    public string IconUrl { get; set; }

                    [JsonProperty("key")]
                    public string Key { get; set; }

                    [JsonProperty("name")]
                    public string Name { get; set; }

                    [JsonExtensionData]
                    public IDictionary<string, JToken> Extra { get; set; }
                }
            }
        }

        public sealed class QuestionData
        {
            [JsonProperty("deadlineAt")]
            public string DeadlineAt { get; set; }

            [JsonProperty("duelId")]
            public string DuelId { get; set; }

            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("mediaUrl")]
            public JToken MediaUrl { get; set; }

            [JsonProperty("options")]
            public List<OptionsItem> Options { get; set; }

            [JsonProperty("questionId")]
            public JToken QuestionId { get; set; }

            [JsonProperty("round")]
            public long? Round { get; set; }

            [JsonProperty("seconds")]
            public long? Seconds { get; set; }

            [JsonProperty("servedAt")]
            public string ServedAt { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("text")]
            public JToken Text { get; set; }

            [JsonProperty("total")]
            public long? Total { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class OptionsItem
            {
                [JsonProperty("id")]
                public long? Id { get; set; }

                [JsonProperty("mediaUrl")]
                public string MediaUrl { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelStartRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class QuizDuelStartResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("duelId")]
        public JToken DuelId { get; set; }

        [JsonProperty("entryFee")]
        public JToken EntryFee { get; set; }

        [JsonProperty("expiresAt")]
        public JToken ExpiresAt { get; set; }

        [JsonProperty("finishedAt")]
        public JToken FinishedAt { get; set; }

        [JsonProperty("invitedByYou")]
        public bool? InvitedByYou { get; set; }

        [JsonProperty("mode")]
        public JToken Mode { get; set; }

        [JsonProperty("opponent")]
        public JToken Opponent { get; set; }

        [JsonProperty("questionSeconds")]
        public JToken QuestionSeconds { get; set; }

        [JsonProperty("questionsPerRound")]
        public JToken QuestionsPerRound { get; set; }

        [JsonProperty("reason")]
        public JToken Reason { get; set; }

        [JsonProperty("result")]
        public JToken Result { get; set; }

        [JsonProperty("roundList")]
        public List<RoundListItem> RoundList { get; set; }

        [JsonProperty("rounds")]
        public JToken Rounds { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("status")]
        public JToken Status { get; set; }

        [JsonProperty("step")]
        public StepData Step { get; set; }

        [JsonProperty("turn")]
        public JToken Turn { get; set; }

        [JsonProperty("turnDeadline")]
        public JToken TurnDeadline { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("winner")]
        public JToken Winner { get; set; }

        [JsonProperty("you")]
        public JToken You { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RoundListItem
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("opponent")]
            public JToken Opponent { get; set; }

            [JsonProperty("opponentCorrect")]
            public JToken OpponentCorrect { get; set; }

            [JsonProperty("picker")]
            public string Picker { get; set; }

            [JsonProperty("round")]
            public string Round { get; set; }

            [JsonProperty("you")]
            public List<string> You { get; set; }

            [JsonProperty("youCorrect")]
            public long? YouCorrect { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StepData
        {
            [JsonProperty("category")]
            public CategoryData Category { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("offers")]
            public List<OffersItem> Offers { get; set; }

            [JsonProperty("round")]
            public JToken Round { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class CategoryData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OffersItem
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizDuelStatsRequest
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public sealed class QuizDuelStatsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answered")]
        public long? Answered { get; set; }

        [JsonProperty("correct")]
        public long? Correct { get; set; }

        [JsonProperty("correctRate")]
        public double? CorrectRate { get; set; }

        [JsonProperty("draws")]
        public long? Draws { get; set; }

        [JsonProperty("losses")]
        public long? Losses { get; set; }

        [JsonProperty("open")]
        public long? Open { get; set; }

        [JsonProperty("played")]
        public long? Played { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("wins")]
        public long? Wins { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class QuizFinishRequest
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class QuizFinishResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answered")]
        public long? Answered { get; set; }

        [JsonProperty("correct")]
        public long? Correct { get; set; }

        [JsonProperty("expired")]
        public bool? Expired { get; set; }

        [JsonProperty("missionRewards")]
        public List<JObject> MissionRewards { get; set; }

        [JsonProperty("missionsCompleted")]
        public List<string> MissionsCompleted { get; set; }

        [JsonProperty("packKey")]
        public string PackKey { get; set; }

        [JsonProperty("passCorrect")]
        public JToken PassCorrect { get; set; }

        [JsonProperty("passed")]
        public bool? Passed { get; set; }

        [JsonProperty("questionRewards")]
        public List<JObject> QuestionRewards { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("review")]
        public List<ReviewItem> Review { get; set; }

        [JsonProperty("rewardLimited")]
        public string RewardLimited { get; set; }

        [JsonProperty("rewards")]
        public List<JObject> Rewards { get; set; }

        [JsonProperty("score")]
        public JToken Score { get; set; }

        [JsonProperty("serverSeconds")]
        public double? ServerSeconds { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ReviewItem
        {
            [JsonProperty("outcome")]
            public string Outcome { get; set; }

            [JsonProperty("questionId")]
            public JToken QuestionId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizHintBuyRequest
    {
        [JsonProperty("hintId")]
        public string HintId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class QuizHintBuyResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("hintId")]
        public JToken HintId { get; set; }

        [JsonProperty("mediaUrl")]
        public JToken MediaUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owned")]
        public bool? Owned { get; set; }

        [JsonProperty("price")]
        public JToken Price { get; set; }

        [JsonProperty("questionId")]
        public JToken QuestionId { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class QuizMissionStartRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class QuizMissionStartResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("completedAt")]
        public string CompletedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("missions")]
        public List<MissionsItem> Missions { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("orderMode")]
        public string OrderMode { get; set; }

        [JsonProperty("parentKey")]
        public string ParentKey { get; set; }

        [JsonProperty("reward")]
        public RewardData Reward { get; set; }

        [JsonProperty("rewarded")]
        public bool? Rewarded { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("sort")]
        public long? Sort { get; set; }

        [JsonProperty("startedAt")]
        public JToken StartedAt { get; set; }

        [JsonProperty("timeOver")]
        public bool? TimeOver { get; set; }

        [JsonProperty("timeSeconds")]
        public long? TimeSeconds { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("completed")]
            public bool? Completed { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("playable")]
            public bool? Playable { get; set; }

            [JsonProperty("sort")]
            public JToken Sort { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class MissionsItem
        {
            [JsonProperty("completedAt")]
            public string CompletedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("expiresAt")]
            public string ExpiresAt { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("items")]
            public List<ItemsItem> Items { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("metadata")]
            public JObject Metadata { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("orderMode")]
            public string OrderMode { get; set; }

            [JsonProperty("parentKey")]
            public string ParentKey { get; set; }

            [JsonProperty("reward")]
            public RewardData Reward { get; set; }

            [JsonProperty("rewarded")]
            public bool? Rewarded { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("startedAt")]
            public JToken StartedAt { get; set; }

            [JsonProperty("timeOver")]
            public bool? TimeOver { get; set; }

            [JsonProperty("timeSeconds")]
            public long? TimeSeconds { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsItem
            {
                [JsonProperty("completed")]
                public bool? Completed { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("playable")]
                public bool? Playable { get; set; }

                [JsonProperty("sort")]
                public JToken Sort { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class RewardData
            {
                [JsonProperty("currencies")]
                public JToken Currencies { get; set; }

                [JsonProperty("prizeGroupKey")]
                public string PrizeGroupKey { get; set; }

                [JsonProperty("prizeKey")]
                public string PrizeKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class RewardData
        {
            [JsonProperty("currencies")]
            public JToken Currencies { get; set; }

            [JsonProperty("prizeGroupKey")]
            public string PrizeGroupKey { get; set; }

            [JsonProperty("prizeKey")]
            public string PrizeKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizMissionsRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class QuizMissionsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("completedAt")]
        public string CompletedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("missions")]
        public List<MissionsItem> Missions { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("orderMode")]
        public string OrderMode { get; set; }

        [JsonProperty("parentKey")]
        public string ParentKey { get; set; }

        [JsonProperty("reward")]
        public RewardData Reward { get; set; }

        [JsonProperty("rewarded")]
        public bool? Rewarded { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("sort")]
        public long? Sort { get; set; }

        [JsonProperty("startedAt")]
        public JToken StartedAt { get; set; }

        [JsonProperty("timeOver")]
        public bool? TimeOver { get; set; }

        [JsonProperty("timeSeconds")]
        public long? TimeSeconds { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("completed")]
            public bool? Completed { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("playable")]
            public bool? Playable { get; set; }

            [JsonProperty("sort")]
            public JToken Sort { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class MissionsItem
        {
            [JsonProperty("completedAt")]
            public string CompletedAt { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("expiresAt")]
            public string ExpiresAt { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("items")]
            public List<ItemsItem> Items { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("metadata")]
            public JObject Metadata { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("orderMode")]
            public string OrderMode { get; set; }

            [JsonProperty("parentKey")]
            public string ParentKey { get; set; }

            [JsonProperty("reward")]
            public RewardData Reward { get; set; }

            [JsonProperty("rewarded")]
            public bool? Rewarded { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("startedAt")]
            public JToken StartedAt { get; set; }

            [JsonProperty("timeOver")]
            public bool? TimeOver { get; set; }

            [JsonProperty("timeSeconds")]
            public long? TimeSeconds { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ItemsItem
            {
                [JsonProperty("completed")]
                public bool? Completed { get; set; }

                [JsonProperty("key")]
                public JToken Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("playable")]
                public bool? Playable { get; set; }

                [JsonProperty("sort")]
                public JToken Sort { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class RewardData
            {
                [JsonProperty("currencies")]
                public JToken Currencies { get; set; }

                [JsonProperty("prizeGroupKey")]
                public string PrizeGroupKey { get; set; }

                [JsonProperty("prizeKey")]
                public string PrizeKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class RewardData
        {
            [JsonProperty("currencies")]
            public JToken Currencies { get; set; }

            [JsonProperty("prizeGroupKey")]
            public string PrizeGroupKey { get; set; }

            [JsonProperty("prizeKey")]
            public string PrizeKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizPackRandomRequest
    {
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("forceNew")]
        public bool? ForceNew { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("preferNew")]
        public bool? PreferNew { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }

    public sealed class QuizPackRandomResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("bestScore")]
        public double? BestScore { get; set; }

        [JsonProperty("campaignStageKey")]
        public string CampaignStageKey { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("difficulty")]
        public long? Difficulty { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lastScore")]
        public double? LastScore { get; set; }

        [JsonProperty("locked")]
        public JToken Locked { get; set; }

        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("missionKey")]
        public string MissionKey { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("openSessionId")]
        public string OpenSessionId { get; set; }

        [JsonProperty("passCorrect")]
        public long? PassCorrect { get; set; }

        [JsonProperty("passed")]
        public bool? Passed { get; set; }

        [JsonProperty("plays")]
        public long? Plays { get; set; }

        [JsonProperty("questionCount")]
        public long? QuestionCount { get; set; }

        [JsonProperty("questionSeconds")]
        public long? QuestionSeconds { get; set; }

        [JsonProperty("reward")]
        public RewardData Reward { get; set; }

        [JsonProperty("rewarded")]
        public bool? Rewarded { get; set; }

        [JsonProperty("sort")]
        public long? Sort { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("timeSeconds")]
        public long? TimeSeconds { get; set; }

        [JsonProperty("wins")]
        public long? Wins { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RewardData
        {
            [JsonProperty("currencies")]
            public JToken Currencies { get; set; }

            [JsonProperty("prizeGroupKey")]
            public string PrizeGroupKey { get; set; }

            [JsonProperty("prizeKey")]
            public string PrizeKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizPacksRequest
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("missionKey")]
        public string MissionKey { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }

    public sealed class QuizPacksResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("packs")]
        public List<PacksItem> Packs { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PacksItem
        {
            [JsonProperty("bestScore")]
            public double? BestScore { get; set; }

            [JsonProperty("campaignStageKey")]
            public string CampaignStageKey { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("difficulty")]
            public long? Difficulty { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }

            [JsonProperty("lastScore")]
            public double? LastScore { get; set; }

            [JsonProperty("locked")]
            public JToken Locked { get; set; }

            [JsonProperty("metadata")]
            public JObject Metadata { get; set; }

            [JsonProperty("missionKey")]
            public string MissionKey { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("openSessionId")]
            public string OpenSessionId { get; set; }

            [JsonProperty("passCorrect")]
            public long? PassCorrect { get; set; }

            [JsonProperty("passed")]
            public bool? Passed { get; set; }

            [JsonProperty("plays")]
            public long? Plays { get; set; }

            [JsonProperty("questionCount")]
            public JToken QuestionCount { get; set; }

            [JsonProperty("questionSeconds")]
            public long? QuestionSeconds { get; set; }

            [JsonProperty("reward")]
            public RewardData Reward { get; set; }

            [JsonProperty("rewarded")]
            public bool? Rewarded { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("timeSeconds")]
            public long? TimeSeconds { get; set; }

            [JsonProperty("wins")]
            public long? Wins { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardData
            {
                [JsonProperty("currencies")]
                public JToken Currencies { get; set; }

                [JsonProperty("prizeGroupKey")]
                public string PrizeGroupKey { get; set; }

                [JsonProperty("prizeKey")]
                public string PrizeKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizPlayRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("packKey")]
        public string PackKey { get; set; }
    }

    public sealed class QuizPlayResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answered")]
        public long? Answered { get; set; }

        [JsonProperty("campaignAttemptId")]
        public JToken CampaignAttemptId { get; set; }

        [JsonProperty("correct")]
        public long? Correct { get; set; }

        [JsonProperty("current")]
        public long? Current { get; set; }

        [JsonProperty("deadlineAt")]
        public JToken DeadlineAt { get; set; }

        [JsonProperty("delivery")]
        public JToken Delivery { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("packKey")]
        public string PackKey { get; set; }

        [JsonProperty("passCorrect")]
        public JToken PassCorrect { get; set; }

        [JsonProperty("questions")]
        public List<QuestionsItem> Questions { get; set; }

        [JsonProperty("resumed")]
        public bool? Resumed { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class QuestionsItem
        {
            [JsonProperty("acceptedAnswers")]
            public JObject AcceptedAnswers { get; set; }

            [JsonProperty("answered")]
            public AnsweredData Answered { get; set; }

            [JsonProperty("deadlineAt")]
            public JToken DeadlineAt { get; set; }

            [JsonProperty("difficulty")]
            public long? Difficulty { get; set; }

            [JsonProperty("hints")]
            public List<HintsItem> Hints { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("mediaUrl")]
            public string MediaUrl { get; set; }

            [JsonProperty("options")]
            public List<OptionsItem> Options { get; set; }

            [JsonProperty("text")]
            public JToken Text { get; set; }

            [JsonProperty("timeSeconds")]
            public JToken TimeSeconds { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class AnsweredData
            {
                [JsonProperty("optionIds")]
                public List<long?> OptionIds { get; set; }

                [JsonProperty("outcome")]
                public string Outcome { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class HintsItem
            {
                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("name")]
                public JToken Name { get; set; }

                [JsonProperty("owned")]
                public bool? Owned { get; set; }

                [JsonProperty("price")]
                public JToken Price { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OptionsItem
            {
                [JsonProperty("correct")]
                public bool? Correct { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("mediaUrl")]
                public JToken MediaUrl { get; set; }

                [JsonProperty("text")]
                public JToken Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizReportQuestionRequest
    {
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }

        [JsonProperty("reasonKey")]
        public string ReasonKey { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class QuizReportQuestionResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }

        [JsonProperty("reportId")]
        public string ReportId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class QuizReportReasonsRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class QuizReportReasonsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("reasons")]
        public List<ReasonsItem> Reasons { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ReasonsItem
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class QuizResultReportRequest
    {
        [JsonProperty("templateKey")]
        public string TemplateKey { get; set; }
    }

    public sealed class QuizResultReportResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("missionKey")]
        public JToken MissionKey { get; set; }

        [JsonProperty("name")]
        public JToken Name { get; set; }

        [JsonProperty("templateKey")]
        public JToken TemplateKey { get; set; }

        [JsonProperty("values")]
        public JObject Values { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class QuizSessionRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("packKey")]
        public string PackKey { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class QuizSessionResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answered")]
        public long? Answered { get; set; }

        [JsonProperty("campaignAttemptId")]
        public string CampaignAttemptId { get; set; }

        [JsonProperty("correct")]
        public long? Correct { get; set; }

        [JsonProperty("current")]
        public long? Current { get; set; }

        [JsonProperty("deadlineAt")]
        public string DeadlineAt { get; set; }

        [JsonProperty("delivery")]
        public JToken Delivery { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("packKey")]
        public string PackKey { get; set; }

        [JsonProperty("passCorrect")]
        public long? PassCorrect { get; set; }

        [JsonProperty("questions")]
        public List<QuestionsItem> Questions { get; set; }

        [JsonProperty("result")]
        public JObject Result { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class QuestionsItem
        {
            [JsonProperty("acceptedAnswers")]
            public JObject AcceptedAnswers { get; set; }

            [JsonProperty("answered")]
            public AnsweredData Answered { get; set; }

            [JsonProperty("deadlineAt")]
            public string DeadlineAt { get; set; }

            [JsonProperty("difficulty")]
            public long? Difficulty { get; set; }

            [JsonProperty("hints")]
            public List<HintsItem> Hints { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("mediaUrl")]
            public string MediaUrl { get; set; }

            [JsonProperty("options")]
            public List<OptionsItem> Options { get; set; }

            [JsonProperty("text")]
            public JToken Text { get; set; }

            [JsonProperty("timeSeconds")]
            public JToken TimeSeconds { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class AnsweredData
            {
                [JsonProperty("optionIds")]
                public List<long?> OptionIds { get; set; }

                [JsonProperty("outcome")]
                public string Outcome { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class HintsItem
            {
                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("owned")]
                public bool? Owned { get; set; }

                [JsonProperty("price")]
                public JToken Price { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class OptionsItem
            {
                [JsonProperty("correct")]
                public bool? Correct { get; set; }

                [JsonProperty("id")]
                public JToken Id { get; set; }

                [JsonProperty("mediaUrl")]
                public JToken MediaUrl { get; set; }

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class QuizStatsRequest
    {
        [JsonProperty("packKey")]
        public string PackKey { get; set; }
    }

    public sealed class QuizStatsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("answers")]
        public long? Answers { get; set; }

        [JsonProperty("bestScore")]
        public double? BestScore { get; set; }

        [JsonProperty("correctAnswers")]
        public long? CorrectAnswers { get; set; }

        [JsonProperty("lastScore")]
        public double? LastScore { get; set; }

        [JsonProperty("packKey")]
        public string PackKey { get; set; }

        [JsonProperty("packsPassed")]
        public long? PacksPassed { get; set; }

        [JsonProperty("plays")]
        public long? Plays { get; set; }

        [JsonProperty("wins")]
        public long? Wins { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ShopxPurchaseCheckRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }
    }

    public sealed class ShopxPurchaseCheckResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("allowed")]
        public bool? Allowed { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("phoneRequired")]
        public bool? PhoneRequired { get; set; }

        [JsonProperty("phoneVerified")]
        public bool? PhoneVerified { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("productKey")]
        public string ProductKey { get; set; }

        [JsonProperty("sandbox")]
        public JToken Sandbox { get; set; }

        [JsonProperty("verifyRpc")]
        public JToken VerifyRpc { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class ShopxPurchaseRulesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class ShopxPurchaseRulesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("methods")]
        public List<MethodsItem> Methods { get; set; }

        [JsonProperty("phoneVerified")]
        public bool? PhoneVerified { get; set; }

        [JsonProperty("verifyRpc")]
        public JToken VerifyRpc { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class MethodsItem
        {
            [JsonProperty("blocked")]
            public bool? Blocked { get; set; }

            [JsonProperty("method")]
            public JToken Method { get; set; }

            [JsonProperty("phoneRequired")]
            public bool? PhoneRequired { get; set; }

            [JsonProperty("sandbox")]
            public JToken Sandbox { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialAvatarRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class SocialAvatarResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("avatar")]
        public JToken Avatar { get; set; }

        [JsonProperty("avatarSlot")]
        public JToken AvatarSlot { get; set; }

        [JsonProperty("avatarUrl")]
        public JToken AvatarUrl { get; set; }

        [JsonProperty("avatars")]
        public List<AvatarsItem> Avatars { get; set; }

        [JsonProperty("equipRpc")]
        public string EquipRpc { get; set; }

        [JsonProperty("frame")]
        public JToken Frame { get; set; }

        [JsonProperty("frameSlot")]
        public JToken FrameSlot { get; set; }

        [JsonProperty("frames")]
        public List<FramesItem> Frames { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AvatarsItem
        {
            [JsonProperty("equipped")]
            public bool? Equipped { get; set; }

            [JsonProperty("forSale")]
            public bool? ForSale { get; set; }

            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("imageUrl")]
            public JToken ImageUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("rarity")]
            public JToken Rarity { get; set; }

            [JsonProperty("unlockLevel")]
            public JToken UnlockLevel { get; set; }

            [JsonProperty("url")]
            public JToken Url { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class FramesItem
        {
            [JsonProperty("equipped")]
            public bool? Equipped { get; set; }

            [JsonProperty("forSale")]
            public bool? ForSale { get; set; }

            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("imageUrl")]
            public JToken ImageUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public JToken Name { get; set; }

            [JsonProperty("owned")]
            public bool? Owned { get; set; }

            [JsonProperty("rarity")]
            public JToken Rarity { get; set; }

            [JsonProperty("unlockLevel")]
            public JToken UnlockLevel { get; set; }

            [JsonProperty("url")]
            public JToken Url { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialCommentDeleteRequest
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }
    }

    public sealed class SocialCommentDeleteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialCommentEditRequest
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }
    }

    public sealed class SocialCommentEditResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("comment")]
        public JObject Comment { get; set; }

        [JsonProperty("masked")]
        public bool? Masked { get; set; }

        [JsonProperty("pending")]
        public bool? Pending { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialCommentPostRequest
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }
    }

    public sealed class SocialCommentPostResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("comment")]
        public JObject Comment { get; set; }

        [JsonProperty("masked")]
        public bool? Masked { get; set; }

        [JsonProperty("pending")]
        public bool? Pending { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialCommentReportRequest
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }
    }

    public sealed class SocialCommentReportResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("hidden")]
        public bool? Hidden { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("reported")]
        public bool? Reported { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialCommentsRequest
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("titleKey")]
        public string TitleKey { get; set; }
    }

    public sealed class SocialCommentsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JObject> Items { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public JToken TargetType { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialConfigRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class SocialConfigResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("comment")]
        public CommentData Comment { get; set; }

        [JsonProperty("follow")]
        public FollowData Follow { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limits")]
        public JObject Limits { get; set; }

        [JsonProperty("notificationCode")]
        public JToken NotificationCode { get; set; }

        [JsonProperty("reactions")]
        public List<ReactionsItem> Reactions { get; set; }

        [JsonProperty("targetTypes")]
        public List<TargetTypesItem> TargetTypes { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CommentData
        {
            [JsonProperty("deleteMinutes")]
            public JToken DeleteMinutes { get; set; }

            [JsonProperty("editMinutes")]
            public JToken EditMinutes { get; set; }

            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("maxDepth")]
            public JToken MaxDepth { get; set; }

            [JsonProperty("maxLength")]
            public JToken MaxLength { get; set; }

            [JsonProperty("minLength")]
            public JToken MinLength { get; set; }

            [JsonProperty("pageSize")]
            public JToken PageSize { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class FollowData
        {
            [JsonProperty("canChangePrivacy")]
            public JToken CanChangePrivacy { get; set; }

            [JsonProperty("enabled")]
            public JToken Enabled { get; set; }

            [JsonProperty("maxFollowing")]
            public JToken MaxFollowing { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ReactionsItem
        {
            [JsonProperty("emoji")]
            public JToken Emoji { get; set; }

            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("targetTypes")]
            public JToken TargetTypes { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class TargetTypesItem
        {
            [JsonProperty("comment")]
            public bool? Comment { get; set; }

            [JsonProperty("favorite")]
            public bool? Favorite { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("moderation")]
            public string Moderation { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("ownerKind")]
            public JToken OwnerKind { get; set; }

            [JsonProperty("rating")]
            public bool? Rating { get; set; }

            [JsonProperty("ratingMax")]
            public long? RatingMax { get; set; }

            [JsonProperty("reaction")]
            public bool? Reaction { get; set; }

            [JsonProperty("reactionMode")]
            public string ReactionMode { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialFavoriteRequest
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetIds")]
        public List<string> TargetIds { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("value")]
        public long? Value { get; set; }
    }

    public sealed class SocialFavoriteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("favorites")]
        public long? Favorites { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialFollowRequest
    {
        [JsonProperty("accept")]
        public bool? Accept { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialFollowResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("followers")]
        public JToken Followers { get; set; }

        [JsonProperty("following")]
        public JToken Following { get; set; }

        [JsonProperty("relation")]
        public RelationData Relation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RelationData
        {
            [JsonProperty("blocked")]
            public bool? Blocked { get; set; }

            [JsonProperty("followedBy")]
            public bool? FollowedBy { get; set; }

            [JsonProperty("following")]
            public bool? Following { get; set; }

            [JsonProperty("requested")]
            public bool? Requested { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialFollowRequestsRequest
    {
        [JsonProperty("accept")]
        public bool? Accept { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialFollowRequestsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("followPolicy")]
            public string FollowPolicy { get; set; }

            [JsonProperty("hideFollowers")]
            public bool? HideFollowers { get; set; }

            [JsonProperty("hideFollowing")]
            public bool? HideFollowing { get; set; }

            [JsonProperty("ownHideFollowers")]
            public bool? OwnHideFollowers { get; set; }

            [JsonProperty("ownHideFollowing")]
            public bool? OwnHideFollowing { get; set; }

            [JsonProperty("ownPolicy")]
            public string OwnPolicy { get; set; }

            [JsonProperty("since")]
            public string Since { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialFollowRespondRequest
    {
        [JsonProperty("accept")]
        public bool? Accept { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialFollowRespondResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("accepted")]
        public bool? Accepted { get; set; }

        [JsonProperty("counts")]
        public CountsData Counts { get; set; }

        [JsonProperty("userId")]
        public JToken UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CountsData
        {
            [JsonProperty("followers")]
            public long? Followers { get; set; }

            [JsonProperty("following")]
            public long? Following { get; set; }

            [JsonProperty("requests")]
            public long? Requests { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialFollowerRemoveRequest
    {
        [JsonProperty("accept")]
        public bool? Accept { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialFollowerRemoveResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("counts")]
        public CountsData Counts { get; set; }

        [JsonProperty("removed")]
        public bool? Removed { get; set; }

        [JsonProperty("userId")]
        public JToken UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class CountsData
        {
            [JsonProperty("followers")]
            public long? Followers { get; set; }

            [JsonProperty("following")]
            public long? Following { get; set; }

            [JsonProperty("requests")]
            public long? Requests { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialFollowersRequest
    {
        [JsonProperty("accept")]
        public bool? Accept { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialFollowersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("followPolicy")]
            public string FollowPolicy { get; set; }

            [JsonProperty("hideFollowers")]
            public bool? HideFollowers { get; set; }

            [JsonProperty("hideFollowing")]
            public bool? HideFollowing { get; set; }

            [JsonProperty("ownHideFollowers")]
            public bool? OwnHideFollowers { get; set; }

            [JsonProperty("ownHideFollowing")]
            public bool? OwnHideFollowing { get; set; }

            [JsonProperty("ownPolicy")]
            public string OwnPolicy { get; set; }

            [JsonProperty("since")]
            public string Since { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialFollowingRequest
    {
        [JsonProperty("accept")]
        public bool? Accept { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialFollowingResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("followPolicy")]
            public string FollowPolicy { get; set; }

            [JsonProperty("hideFollowers")]
            public bool? HideFollowers { get; set; }

            [JsonProperty("hideFollowing")]
            public bool? HideFollowing { get; set; }

            [JsonProperty("ownHideFollowers")]
            public bool? OwnHideFollowers { get; set; }

            [JsonProperty("ownHideFollowing")]
            public bool? OwnHideFollowing { get; set; }

            [JsonProperty("ownPolicy")]
            public string OwnPolicy { get; set; }

            [JsonProperty("since")]
            public string Since { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialMineRequest
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetIds")]
        public List<string> TargetIds { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("value")]
        public long? Value { get; set; }
    }

    public sealed class SocialMineResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("at")]
            public JToken At { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("reaction")]
            public string Reaction { get; set; }

            [JsonProperty("targetId")]
            public string TargetId { get; set; }

            [JsonProperty("targetType")]
            public string TargetType { get; set; }

            [JsonProperty("value")]
            public long? Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialPrivacyGetRequest
    {
    }

    public sealed class SocialPrivacyGetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canChange")]
        public JToken CanChange { get; set; }

        [JsonProperty("defaults")]
        public DefaultsData Defaults { get; set; }

        [JsonProperty("privacy")]
        public PrivacyData Privacy { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DefaultsData
        {
            [JsonProperty("followPolicy")]
            public JToken FollowPolicy { get; set; }

            [JsonProperty("hideFollowers")]
            public JToken HideFollowers { get; set; }

            [JsonProperty("hideFollowing")]
            public JToken HideFollowing { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PrivacyData
        {
            [JsonProperty("followPolicy")]
            public string FollowPolicy { get; set; }

            [JsonProperty("hideFollowers")]
            public bool? HideFollowers { get; set; }

            [JsonProperty("hideFollowing")]
            public bool? HideFollowing { get; set; }

            [JsonProperty("ownHideFollowers")]
            public bool? OwnHideFollowers { get; set; }

            [JsonProperty("ownHideFollowing")]
            public bool? OwnHideFollowing { get; set; }

            [JsonProperty("ownPolicy")]
            public string OwnPolicy { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialPrivacySetRequest
    {
        [JsonProperty("followPolicy")]
        public string FollowPolicy { get; set; }

        [JsonProperty("hideFollowers")]
        public bool? HideFollowers { get; set; }

        [JsonProperty("hideFollowing")]
        public bool? HideFollowing { get; set; }

        [JsonProperty("reset")]
        public bool? Reset { get; set; }
    }

    public sealed class SocialPrivacySetResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canChange")]
        public JToken CanChange { get; set; }

        [JsonProperty("defaults")]
        public DefaultsData Defaults { get; set; }

        [JsonProperty("privacy")]
        public PrivacyData Privacy { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class DefaultsData
        {
            [JsonProperty("followPolicy")]
            public JToken FollowPolicy { get; set; }

            [JsonProperty("hideFollowers")]
            public JToken HideFollowers { get; set; }

            [JsonProperty("hideFollowing")]
            public JToken HideFollowing { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PrivacyData
        {
            [JsonProperty("followPolicy")]
            public string FollowPolicy { get; set; }

            [JsonProperty("hideFollowers")]
            public bool? HideFollowers { get; set; }

            [JsonProperty("hideFollowing")]
            public bool? HideFollowing { get; set; }

            [JsonProperty("ownHideFollowers")]
            public bool? OwnHideFollowers { get; set; }

            [JsonProperty("ownHideFollowing")]
            public bool? OwnHideFollowing { get; set; }

            [JsonProperty("ownPolicy")]
            public string OwnPolicy { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SocialProfileRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("userIds")]
        public List<string> UserIds { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialProfileResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JToken> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialRateRequest
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetIds")]
        public List<string> TargetIds { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("value")]
        public long? Value { get; set; }
    }

    public sealed class SocialRateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("mine")]
        public JToken Mine { get; set; }

        [JsonProperty("rating")]
        public JToken Rating { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialReactRequest
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetIds")]
        public List<string> TargetIds { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("value")]
        public long? Value { get; set; }
    }

    public sealed class SocialReactResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("mine")]
        public JToken Mine { get; set; }

        [JsonProperty("reactions")]
        public JToken Reactions { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SocialSummaryRequest
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("metadata")]
        public JToken Metadata { get; set; }

        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        [JsonProperty("targetIds")]
        public List<string> TargetIds { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("value")]
        public long? Value { get; set; }
    }

    public sealed class SocialSummaryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("comments")]
            public long? Comments { get; set; }

            [JsonProperty("favorited")]
            public bool? Favorited { get; set; }

            [JsonProperty("favorites")]
            public long? Favorites { get; set; }

            [JsonProperty("myRating")]
            public long? MyRating { get; set; }

            [JsonProperty("myReactions")]
            public List<string> MyReactions { get; set; }

            [JsonProperty("rating")]
            public RatingData Rating { get; set; }

            [JsonProperty("reactions")]
            public JObject Reactions { get; set; }

            [JsonProperty("targetId")]
            public string TargetId { get; set; }

            [JsonProperty("targetType")]
            public string TargetType { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RatingData
            {
                [JsonProperty("average")]
                public JToken Average { get; set; }

                [JsonProperty("count")]
                public JToken Count { get; set; }

                [JsonProperty("histogram")]
                public JToken Histogram { get; set; }

                [JsonProperty("max")]
                public JToken Max { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class SocialUnfollowRequest
    {
        [JsonProperty("accept")]
        public bool? Accept { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public sealed class SocialUnfollowResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("followers")]
        public JToken Followers { get; set; }

        [JsonProperty("following")]
        public JToken Following { get; set; }

        [JsonProperty("relation")]
        public RelationData Relation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class RelationData
        {
            [JsonProperty("blocked")]
            public bool? Blocked { get; set; }

            [JsonProperty("followedBy")]
            public bool? FollowedBy { get; set; }

            [JsonProperty("following")]
            public bool? Following { get; set; }

            [JsonProperty("requested")]
            public bool? Requested { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SoltanBootstrapRequest
    {
        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }
    }

    public sealed class SoltanBootstrapResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("chapters")]
        public List<ChaptersItem> Chapters { get; set; }

        [JsonProperty("content")]
        public JObject Content { get; set; }

        [JsonProperty("daily")]
        public DailyData Daily { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prefs")]
        public PrefsData Prefs { get; set; }

        [JsonProperty("prices")]
        public PricesData Prices { get; set; }

        [JsonProperty("progress")]
        public ProgressData Progress { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("settings")]
        public SettingsData Settings { get; set; }

        [JsonProperty("stats")]
        public StatsData Stats { get; set; }

        [JsonProperty("store")]
        public StoreData Store { get; set; }

        [JsonProperty("wallet")]
        public WalletData Wallet { get; set; }

        [JsonProperty("warnings")]
        public List<string> Warnings { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ChaptersItem
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("levels")]
            public List<JToken> Levels { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class DailyData
        {
            [JsonProperty("bestStreak")]
            public long? BestStreak { get; set; }

            [JsonProperty("date")]
            public string Date { get; set; }

            [JsonProperty("dayZone")]
            public string DayZone { get; set; }

            [JsonProperty("enabled")]
            public bool? Enabled { get; set; }

            [JsonProperty("level")]
            public JToken Level { get; set; }

            [JsonProperty("nextAt")]
            public string NextAt { get; set; }

            [JsonProperty("playCost")]
            public JToken PlayCost { get; set; }

            [JsonProperty("played")]
            public bool? Played { get; set; }

            [JsonProperty("plays")]
            public long? Plays { get; set; }

            [JsonProperty("reward")]
            public JToken Reward { get; set; }

            [JsonProperty("rewarded")]
            public bool? Rewarded { get; set; }

            [JsonProperty("serverTime")]
            public string ServerTime { get; set; }

            [JsonProperty("streak")]
            public long? Streak { get; set; }

            [JsonProperty("streakBonus")]
            public JToken StreakBonus { get; set; }

            [JsonProperty("won")]
            public bool? Won { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PrefsData
        {
            [JsonProperty("quickChat")]
            public bool? QuickChat { get; set; }

            [JsonProperty("voice")]
            public bool? Voice { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PricesData
        {
            [JsonProperty("heartRefill")]
            public JToken HeartRefill { get; set; }

            [JsonProperty("hintCoins")]
            public long? HintCoins { get; set; }

            [JsonProperty("rocketCoins")]
            public long? RocketCoins { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ProgressData
        {
            [JsonProperty("chest")]
            public ChestData Chest { get; set; }

            [JsonProperty("currentLevel")]
            public long? CurrentLevel { get; set; }

            [JsonProperty("mapSeen")]
            public long? MapSeen { get; set; }

            [JsonProperty("stars")]
            public JObject Stars { get; set; }

            [JsonProperty("totalStars")]
            public long? TotalStars { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ChestData
            {
                [JsonProperty("every")]
                public JToken Every { get; set; }

                [JsonProperty("opened")]
                public JToken Opened { get; set; }

                [JsonProperty("progress")]
                public JToken Progress { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class SettingsData
        {
            [JsonProperty("bonusCoins")]
            public long? BonusCoins { get; set; }

            [JsonProperty("chestEvery")]
            public long? ChestEvery { get; set; }

            [JsonProperty("chestReward")]
            public ChestRewardData ChestReward { get; set; }

            [JsonProperty("comboSteps")]
            public List<JToken> ComboSteps { get; set; }

            [JsonProperty("comboWindowMs")]
            public long? ComboWindowMs { get; set; }

            [JsonProperty("minWordLength")]
            public long? MinWordLength { get; set; }

            [JsonProperty("replayExtras")]
            public string ReplayExtras { get; set; }

            [JsonProperty("rocketWords")]
            public long? RocketWords { get; set; }

            [JsonProperty("stageReward")]
            public StageRewardData StageReward { get; set; }

            [JsonProperty("stars")]
            public JToken Stars { get; set; }

            [JsonProperty("wordCoins")]
            public long? WordCoins { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class ChestRewardData
            {
                [JsonProperty("currencies")]
                public JToken Currencies { get; set; }

                [JsonProperty("prizeKey")]
                public JToken PrizeKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }

            public sealed class StageRewardData
            {
                [JsonProperty("currencies")]
                public JToken Currencies { get; set; }

                [JsonProperty("prizeKey")]
                public JToken PrizeKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }

        public sealed class StatsData
        {
            [JsonProperty("bestDuelPoints")]
            public long? BestDuelPoints { get; set; }

            [JsonProperty("bestStreak")]
            public long? BestStreak { get; set; }

            [JsonProperty("dailyStreak")]
            public long? DailyStreak { get; set; }

            [JsonProperty("duelsDrawn")]
            public long? DuelsDrawn { get; set; }

            [JsonProperty("duelsLost")]
            public long? DuelsLost { get; set; }

            [JsonProperty("duelsPlayed")]
            public long? DuelsPlayed { get; set; }

            [JsonProperty("duelsWon")]
            public long? DuelsWon { get; set; }

            [JsonProperty("level")]
            public JToken Level { get; set; }

            [JsonProperty("levelsWon")]
            public long? LevelsWon { get; set; }

            [JsonProperty("maxLevel")]
            public JToken MaxLevel { get; set; }

            [JsonProperty("riddlesSolved")]
            public long? RiddlesSolved { get; set; }

            [JsonProperty("totalPoints")]
            public long? TotalPoints { get; set; }

            [JsonProperty("totalStars")]
            public long? TotalStars { get; set; }

            [JsonProperty("xp")]
            public JToken Xp { get; set; }

            [JsonProperty("xpForNext")]
            public JToken XpForNext { get; set; }

            [JsonProperty("xpLevelStart")]
            public JToken XpLevelStart { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class StoreData
        {
            [JsonProperty("currencies")]
            public List<JObject> Currencies { get; set; }

            [JsonProperty("methods")]
            public List<string> Methods { get; set; }

            [JsonProperty("platform")]
            public string Platform { get; set; }

            [JsonProperty("products")]
            public List<JObject> Products { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class WalletData
        {
            [JsonProperty("all")]
            public JObject All { get; set; }

            [JsonProperty("coins")]
            public long? Coins { get; set; }

            [JsonProperty("gems")]
            public long? Gems { get; set; }

            [JsonProperty("hearts")]
            public long? Hearts { get; set; }

            [JsonProperty("heartsRegen")]
            public JToken HeartsRegen { get; set; }

            [JsonProperty("hint")]
            public long? Hint { get; set; }

            [JsonProperty("regen")]
            public List<JToken> Regen { get; set; }

            [JsonProperty("rocket")]
            public long? Rocket { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SoltanDailyStateRequest
    {
    }

    public sealed class SoltanDailyStateResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("bestStreak")]
        public long? BestStreak { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("dayZone")]
        public string DayZone { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("level")]
        public LevelData Level { get; set; }

        [JsonProperty("nextAt")]
        public string NextAt { get; set; }

        [JsonProperty("playCost")]
        public PlayCostData PlayCost { get; set; }

        [JsonProperty("played")]
        public bool? Played { get; set; }

        [JsonProperty("plays")]
        public long? Plays { get; set; }

        [JsonProperty("reward")]
        public RewardData Reward { get; set; }

        [JsonProperty("rewarded")]
        public bool? Rewarded { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("streak")]
        public long? Streak { get; set; }

        [JsonProperty("streakBonus")]
        public StreakBonusData StreakBonus { get; set; }

        [JsonProperty("won")]
        public bool? Won { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class LevelData
        {
            [JsonProperty("clue")]
            public string Clue { get; set; }

            [JsonProperty("difficulty")]
            public string Difficulty { get; set; }

            [JsonProperty("lettersCount")]
            public long? LettersCount { get; set; }

            [JsonProperty("rows")]
            public List<JToken> Rows { get; set; }

            [JsonProperty("theme")]
            public string Theme { get; set; }

            [JsonProperty("wordCount")]
            public long? WordCount { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PlayCostData
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RewardData
        {
            [JsonProperty("currencies")]
            public List<JToken> Currencies { get; set; }

            [JsonProperty("prizeKey")]
            public string PrizeKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class StreakBonusData
        {
            [JsonProperty("daysToNext")]
            public long? DaysToNext { get; set; }

            [JsonProperty("every")]
            public long? Every { get; set; }

            [JsonProperty("reward")]
            public RewardData Reward { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class RewardData
            {
                [JsonProperty("currencies")]
                public JToken Currencies { get; set; }

                [JsonProperty("prizeKey")]
                public JToken PrizeKey { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class SoltanDuelHistoryRequest
    {
        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class SoltanDuelHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<ItemsItem> Items { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ItemsItem
        {
            [JsonProperty("finishedAt")]
            public string FinishedAt { get; set; }

            [JsonProperty("matchId")]
            public string MatchId { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("opponent")]
            public OpponentData Opponent { get; set; }

            [JsonProperty("points")]
            public long? Points { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("result")]
            public string Result { get; set; }

            [JsonProperty("room")]
            public string Room { get; set; }

            [JsonProperty("solved")]
            public long? Solved { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class OpponentData
            {
                [JsonProperty("avatarUrl")]
                public JToken AvatarUrl { get; set; }

                [JsonProperty("bot")]
                public JToken Bot { get; set; }

                [JsonProperty("name")]
                public JToken Name { get; set; }

                [JsonProperty("points")]
                public JToken Points { get; set; }

                [JsonProperty("userId")]
                public JToken UserId { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class SoltanDuelInfoRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class SoltanDuelInfoResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("available")]
        public JToken Available { get; set; }

        [JsonProperty("gameKey")]
        public JToken GameKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("leaderboardKey")]
        public JToken LeaderboardKey { get; set; }

        [JsonProperty("prefs")]
        public PrefsData Prefs { get; set; }

        [JsonProperty("quickChat")]
        public List<QuickChatItem> QuickChat { get; set; }

        [JsonProperty("settings")]
        public SettingsData Settings { get; set; }

        [JsonProperty("stats")]
        public StatsData Stats { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PrefsData
        {
            [JsonProperty("quickChat")]
            public bool? QuickChat { get; set; }

            [JsonProperty("voice")]
            public bool? Voice { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class QuickChatItem
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("texts")]
            public JObject Texts { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SettingsData
        {
            [JsonProperty("botAfterSeconds")]
            public JToken BotAfterSeconds { get; set; }

            [JsonProperty("botsAllowed")]
            public JToken BotsAllowed { get; set; }

            [JsonProperty("breakSeconds")]
            public long? BreakSeconds { get; set; }

            [JsonProperty("chatCooldownMs")]
            public long? ChatCooldownMs { get; set; }

            [JsonProperty("chatPerMatch")]
            public long? ChatPerMatch { get; set; }

            [JsonProperty("friendRooms")]
            public JToken FriendRooms { get; set; }

            [JsonProperty("friendWaitSeconds")]
            public JToken FriendWaitSeconds { get; set; }

            [JsonProperty("hintPenalty")]
            public long? HintPenalty { get; set; }

            [JsonProperty("hintsPerMatch")]
            public long? HintsPerMatch { get; set; }

            [JsonProperty("rooms")]
            public List<string> Rooms { get; set; }

            [JsonProperty("roundSeconds")]
            public long? RoundSeconds { get; set; }

            [JsonProperty("rounds")]
            public long? Rounds { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class StatsData
        {
            [JsonProperty("bestDuelPoints")]
            public long? BestDuelPoints { get; set; }

            [JsonProperty("bestStreak")]
            public long? BestStreak { get; set; }

            [JsonProperty("dailyStreak")]
            public long? DailyStreak { get; set; }

            [JsonProperty("duelsDrawn")]
            public long? DuelsDrawn { get; set; }

            [JsonProperty("duelsLost")]
            public long? DuelsLost { get; set; }

            [JsonProperty("duelsPlayed")]
            public long? DuelsPlayed { get; set; }

            [JsonProperty("duelsWon")]
            public long? DuelsWon { get; set; }

            [JsonProperty("level")]
            public long? Level { get; set; }

            [JsonProperty("levelsWon")]
            public long? LevelsWon { get; set; }

            [JsonProperty("maxLevel")]
            public long? MaxLevel { get; set; }

            [JsonProperty("riddlesSolved")]
            public long? RiddlesSolved { get; set; }

            [JsonProperty("totalPoints")]
            public long? TotalPoints { get; set; }

            [JsonProperty("totalStars")]
            public long? TotalStars { get; set; }

            [JsonProperty("xp")]
            public double? Xp { get; set; }

            [JsonProperty("xpForNext")]
            public double? XpForNext { get; set; }

            [JsonProperty("xpLevelStart")]
            public double? XpLevelStart { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SoltanHintRequest
    {
        [JsonProperty("found")]
        public List<string> Found { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class SoltanHintResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("boostersUsed")]
        public long? BoostersUsed { get; set; }

        [JsonProperty("completedSlots")]
        public List<long?> CompletedSlots { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("owned")]
        public OwnedData Owned { get; set; }

        [JsonProperty("paidWith")]
        public string PaidWith { get; set; }

        [JsonProperty("picks")]
        public List<PicksItem> Picks { get; set; }

        [JsonProperty("price")]
        public PriceData Price { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class OwnedData
        {
            [JsonProperty("coins")]
            public long? Coins { get; set; }

            [JsonProperty("hint")]
            public long? Hint { get; set; }

            [JsonProperty("rocket")]
            public long? Rocket { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PicksItem
        {
            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("letter")]
            public string Letter { get; set; }

            [JsonProperty("slot")]
            public long? Slot { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PriceData
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SoltanLevelCompleteRequest
    {
        [JsonProperty("bonus")]
        public List<BonusItem> Bonus { get; set; }

        [JsonProperty("found")]
        public List<FoundItem> Found { get; set; }

        [JsonProperty("giveUp")]
        public bool? GiveUp { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        public sealed class BonusItem
        {
            [JsonProperty("atMs")]
            public long? AtMs { get; set; }

            [JsonProperty("word")]
            public string Word { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class FoundItem
        {
            [JsonProperty("atMs")]
            public long? AtMs { get; set; }

            [JsonProperty("word")]
            public string Word { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SoltanLevelCompleteResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("bestStars")]
        public long? BestStars { get; set; }

        [JsonProperty("bonusFound")]
        public long? BonusFound { get; set; }

        [JsonProperty("boostersUsed")]
        public long? BoostersUsed { get; set; }

        [JsonProperty("campaign")]
        public JObject Campaign { get; set; }

        [JsonProperty("campaignError")]
        public string CampaignError { get; set; }

        [JsonProperty("chest")]
        public ChestData Chest { get; set; }

        [JsonProperty("comboMax")]
        public long? ComboMax { get; set; }

        [JsonProperty("daily")]
        public DailyData Daily { get; set; }

        [JsonProperty("extrasPaid")]
        public string ExtrasPaid { get; set; }

        [JsonProperty("firstWin")]
        public bool? FirstWin { get; set; }

        [JsonProperty("gaveUp")]
        public bool? GaveUp { get; set; }

        [JsonProperty("hearts")]
        public JToken Hearts { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("level")]
        public LevelData Level { get; set; }

        [JsonProperty("nextLevel")]
        public long? NextLevel { get; set; }

        [JsonProperty("points")]
        public long? Points { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("rewards")]
        public RewardsData Rewards { get; set; }

        [JsonProperty("serverSeconds")]
        public double? ServerSeconds { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("stars")]
        public long? Stars { get; set; }

        [JsonProperty("wallet")]
        public JObject Wallet { get; set; }

        [JsonProperty("won")]
        public bool? Won { get; set; }

        [JsonProperty("words")]
        public WordsData Words { get; set; }

        [JsonProperty("wordsFound")]
        public long? WordsFound { get; set; }

        [JsonProperty("xp")]
        public XpData Xp { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class ChestData
        {
            [JsonProperty("every")]
            public long? Every { get; set; }

            [JsonProperty("opened")]
            public long? Opened { get; set; }

            [JsonProperty("progress")]
            public long? Progress { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class DailyData
        {
            [JsonProperty("bestStreak")]
            public long? BestStreak { get; set; }

            [JsonProperty("day")]
            public string Day { get; set; }

            [JsonProperty("rewarded")]
            public bool? Rewarded { get; set; }

            [JsonProperty("streak")]
            public long? Streak { get; set; }

            [JsonProperty("streakBonus")]
            public bool? StreakBonus { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LevelData
        {
            [JsonProperty("clue")]
            public string Clue { get; set; }

            [JsonProperty("difficulty")]
            public string Difficulty { get; set; }

            [JsonProperty("number")]
            public long? Number { get; set; }

            [JsonProperty("theme")]
            public string Theme { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RewardsData
        {
            [JsonProperty("bonus")]
            public long? Bonus { get; set; }

            [JsonProperty("chest")]
            public List<JToken> Chest { get; set; }

            [JsonProperty("combo")]
            public long? Combo { get; set; }

            [JsonProperty("daily")]
            public List<JToken> Daily { get; set; }

            [JsonProperty("prizes")]
            public List<JObject> Prizes { get; set; }

            [JsonProperty("stage")]
            public List<JToken> Stage { get; set; }

            [JsonProperty("total")]
            public List<JToken> Total { get; set; }

            [JsonProperty("words")]
            public long? Words { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class WordsData
        {
            [JsonProperty("bonus")]
            public List<string> Bonus { get; set; }

            [JsonProperty("targets")]
            public List<List<JToken>> Targets { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class XpData
        {
            [JsonProperty("from")]
            public long? From { get; set; }

            [JsonProperty("gained")]
            public double? Gained { get; set; }

            [JsonProperty("levelUp")]
            public bool? LevelUp { get; set; }

            [JsonProperty("rewards")]
            public List<JToken> Rewards { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SoltanLevelStartRequest
    {
        [JsonProperty("daily")]
        public bool? Daily { get; set; }

        [JsonProperty("level")]
        public long? Level { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public sealed class SoltanLevelStartResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("attemptId")]
        public string AttemptId { get; set; }

        [JsonProperty("bonusCount")]
        public long? BonusCount { get; set; }

        [JsonProperty("boostersUsed")]
        public long? BoostersUsed { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("foundSlots")]
        public List<long?> FoundSlots { get; set; }

        [JsonProperty("hashes")]
        public HashesData Hashes { get; set; }

        [JsonProperty("hearts")]
        public JToken Hearts { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("letters")]
        public List<string> Letters { get; set; }

        [JsonProperty("level")]
        public LevelData Level { get; set; }

        [JsonProperty("owned")]
        public OwnedData Owned { get; set; }

        [JsonProperty("playCost")]
        public JObject PlayCost { get; set; }

        [JsonProperty("prices")]
        public PricesData Prices { get; set; }

        [JsonProperty("resumed")]
        public bool? Resumed { get; set; }

        [JsonProperty("revealed")]
        public List<RevealedItem> Revealed { get; set; }

        [JsonProperty("rows")]
        public List<List<RowsItemItem>> Rows { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class HashesData
        {
            [JsonProperty("bonus")]
            public List<string> Bonus { get; set; }

            [JsonProperty("slots")]
            public List<JToken> Slots { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LevelData
        {
            [JsonProperty("clue")]
            public string Clue { get; set; }

            [JsonProperty("difficulty")]
            public string Difficulty { get; set; }

            [JsonProperty("number")]
            public long? Number { get; set; }

            [JsonProperty("theme")]
            public string Theme { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class OwnedData
        {
            [JsonProperty("coins")]
            public long? Coins { get; set; }

            [JsonProperty("hint")]
            public long? Hint { get; set; }

            [JsonProperty("rocket")]
            public long? Rocket { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PricesData
        {
            [JsonProperty("heartRefill")]
            public JToken HeartRefill { get; set; }

            [JsonProperty("hintCoins")]
            public long? HintCoins { get; set; }

            [JsonProperty("rocketCoins")]
            public long? RocketCoins { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RevealedItem
        {
            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("letter")]
            public string Letter { get; set; }

            [JsonProperty("slot")]
            public long? Slot { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class RowsItemItem
        {
            [JsonProperty("length")]
            public JToken Length { get; set; }

            [JsonProperty("slot")]
            public JToken Slot { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class SoltanMapSeenRequest
    {
        [JsonProperty("level")]
        public long? Level { get; set; }
    }

    public sealed class SoltanMapSeenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("mapSeen")]
        public long? MapSeen { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SoltanPrefsRequest
    {
        [JsonProperty("quickChat")]
        public bool? QuickChat { get; set; }

        [JsonProperty("voice")]
        public bool? Voice { get; set; }
    }

    public sealed class SoltanPrefsResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("quickChat")]
        public bool? QuickChat { get; set; }

        [JsonProperty("voice")]
        public bool? Voice { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class SoltanRocketRequest
    {
        [JsonProperty("found")]
        public List<string> Found { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public sealed class SoltanRocketResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("boostersUsed")]
        public long? BoostersUsed { get; set; }

        [JsonProperty("completedSlots")]
        public List<long?> CompletedSlots { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("owned")]
        public OwnedData Owned { get; set; }

        [JsonProperty("paidWith")]
        public string PaidWith { get; set; }

        [JsonProperty("picks")]
        public List<PicksItem> Picks { get; set; }

        [JsonProperty("price")]
        public PriceData Price { get; set; }

        [JsonProperty("replayed")]
        public bool? Replayed { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class OwnedData
        {
            [JsonProperty("coins")]
            public long? Coins { get; set; }

            [JsonProperty("hint")]
            public long? Hint { get; set; }

            [JsonProperty("rocket")]
            public long? Rocket { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PicksItem
        {
            [JsonProperty("index")]
            public long? Index { get; set; }

            [JsonProperty("letter")]
            public string Letter { get; set; }

            [JsonProperty("slot")]
            public long? Slot { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class PriceData
        {
            [JsonProperty("amount")]
            public long? Amount { get; set; }

            [JsonProperty("currencyKey")]
            public string CurrencyKey { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class TrophyHistoryRequest
    {
        [JsonProperty("limit")]
        public long? Limit { get; set; }
    }

    public sealed class TrophyHistoryResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("items")]
        public List<JObject> Items { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }

    public sealed class TrophyLeaguesRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class TrophyLeaguesResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("best")]
        public JToken Best { get; set; }

        [JsonProperty("leagues")]
        public List<LeaguesItem> Leagues { get; set; }

        [JsonProperty("season")]
        public SeasonData Season { get; set; }

        [JsonProperty("trophies")]
        public JToken Trophies { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class LeaguesItem
        {
            [JsonProperty("color")]
            public JToken Color { get; set; }

            [JsonProperty("current")]
            public bool? Current { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("floor")]
            public JToken Floor { get; set; }

            [JsonProperty("iconUrl")]
            public JToken IconUrl { get; set; }

            [JsonProperty("key")]
            public JToken Key { get; set; }

            [JsonProperty("maxTrophies")]
            public JToken MaxTrophies { get; set; }

            [JsonProperty("metadata")]
            public JToken Metadata { get; set; }

            [JsonProperty("minTrophies")]
            public JToken MinTrophies { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("prize")]
            public JToken Prize { get; set; }

            [JsonProperty("reached")]
            public bool? Reached { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SeasonData
        {
            [JsonProperty("endsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("number")]
            public JToken Number { get; set; }

            [JsonProperty("startedAt")]
            public string StartedAt { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class TrophyMeRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public sealed class TrophyMeResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("amounts")]
        public AmountsData Amounts { get; set; }

        [JsonProperty("best")]
        public long? Best { get; set; }

        [JsonProperty("draws")]
        public long? Draws { get; set; }

        [JsonProperty("enabled")]
        public JToken Enabled { get; set; }

        [JsonProperty("league")]
        public LeagueData League { get; set; }

        [JsonProperty("losses")]
        public long? Losses { get; set; }

        [JsonProperty("nextLeague")]
        public JObject NextLeague { get; set; }

        [JsonProperty("pendingPrizes")]
        public long? PendingPrizes { get; set; }

        [JsonProperty("season")]
        public SeasonData Season { get; set; }

        [JsonProperty("seasonBest")]
        public long? SeasonBest { get; set; }

        [JsonProperty("trophies")]
        public long? Trophies { get; set; }

        [JsonProperty("wins")]
        public long? Wins { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class AmountsData
        {
            [JsonProperty("draw")]
            public JToken Draw { get; set; }

            [JsonProperty("loss")]
            public JToken Loss { get; set; }

            [JsonProperty("scaled")]
            public JToken Scaled { get; set; }

            [JsonProperty("win")]
            public JToken Win { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class LeagueData
        {
            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("iconUrl")]
            public string IconUrl { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("minTrophies")]
            public long? MinTrophies { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class SeasonData
        {
            [JsonProperty("endsAt")]
            public JToken EndsAt { get; set; }

            [JsonProperty("number")]
            public JToken Number { get; set; }

            [JsonProperty("startedAt")]
            public string StartedAt { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class TrophyPlayersRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("userIds")]
        public List<string> UserIds { get; set; }
    }

    public sealed class TrophyPlayersResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("players")]
        public List<PlayersItem> Players { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }

        public sealed class PlayersItem
        {
            [JsonProperty("best")]
            public long? Best { get; set; }

            [JsonProperty("league")]
            public LeagueData League { get; set; }

            [JsonProperty("trophies")]
            public long? Trophies { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }

            public sealed class LeagueData
            {
                [JsonProperty("color")]
                public string Color { get; set; }

                [JsonProperty("iconUrl")]
                public string IconUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("minTrophies")]
                public long? MinTrophies { get; set; }

                [JsonProperty("name")]
                public JToken Name { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
            }
        }
    }

    public sealed class VoiceTokenRequest
    {
        [JsonProperty("gameKey")]
        public string GameKey { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("partyId")]
        public string PartyId { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }
    }

    public sealed class VoiceTokenResponse : IRawResponse
    {
        [JsonIgnore]
        public JObject Raw { get; set; }

        [JsonProperty("canPublish")]
        public JToken CanPublish { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty("gameKey")]
        public string GameKey { get; set; }

        [JsonProperty("identity")]
        public JToken Identity { get; set; }

        [JsonProperty("provider")]
        public JToken Provider { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("room")]
        public JToken Room { get; set; }

        [JsonProperty("staffMuted")]
        public bool? StaffMuted { get; set; }

        [JsonProperty("token")]
        public JToken Token { get; set; }

        [JsonProperty("url")]
        public JToken Url { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }
}
