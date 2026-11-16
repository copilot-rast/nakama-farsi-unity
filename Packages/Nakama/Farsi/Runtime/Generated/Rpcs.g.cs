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
            Base = new BaseRpcs(caller);
            Economy = new EconomyRpcs(caller);
            Leaderboardx = new LeaderboardxRpcs(caller);
            Publication = new PublicationRpcs(caller);
        }

        public BaseRpcs Base { get; }

        public EconomyRpcs Economy { get; }

        public LeaderboardxRpcs Leaderboardx { get; }

        public PublicationRpcs Publication { get; }
    }

    public static class RpcIds
    {
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
        public const string BaseCountries = "base_countries";
        public const string BaseFriendRules = "base_friend_rules";
        public const string BaseFriendsAdd = "base_friends_add";
        public const string BaseFriendsBlock = "base_friends_block";
        public const string BaseFriendsList = "base_friends_list";
        public const string BaseFriendsRemove = "base_friends_remove";
        public const string BaseLanguages = "base_languages";
        public const string BaseMyActivity = "base_my_activity";
        public const string BaseMyReports = "base_my_reports";
        public const string BaseMyStatus = "base_my_status";
        public const string BaseMyTags = "base_my_tags";
        public const string BaseRemoteConfig = "base_remote_config";
        public const string BaseReportMessage = "base_report_message";
        public const string BaseReportPlayer = "base_report_player";
        public const string BaseReportTitles = "base_report_titles";
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
        public const string BaseUsersGet = "base_users_get";
        public const string EconomyAchievementClaim = "economy_achievement_claim";
        public const string EconomyAchievements = "economy_achievements";
        public const string EconomyAchievementsProfile = "economy_achievements_profile";
        public const string EconomyBalances = "economy_balances";
        public const string EconomyCatalog = "economy_catalog";
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
        public const string EconomyGameJoin = "economy_game_join";
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
        public const string EconomyPurchaseReview = "economy_purchase_review";
        public const string EconomyPurchaseStart = "economy_purchase_start";
        public const string EconomyPurchaseStatus = "economy_purchase_status";
        public const string EconomyPurchaseSubmit = "economy_purchase_submit";
        public const string EconomyPurchasesMine = "economy_purchases_mine";
        public const string EconomyReferralEnter = "economy_referral_enter";
        public const string EconomyReferralMe = "economy_referral_me";
        public const string EconomyRewardClaim = "economy_reward_claim";
        public const string EconomyRewardsMine = "economy_rewards_mine";
        public const string EconomyStoreConfig = "economy_store_config";
        public const string EconomyStreaks = "economy_streaks";
        public const string EconomyTaskClaim = "economy_task_claim";
        public const string EconomyTaskGroupCurrent = "economy_task_group_current";
        public const string EconomyTaskGroupNext = "economy_task_group_next";
        public const string EconomyTasksList = "economy_tasks_list";
        public const string LeaderboardxBoard = "leaderboardx_board";
        public const string LeaderboardxClaim = "leaderboardx_claim";
        public const string LeaderboardxHistory = "leaderboardx_history";
        public const string LeaderboardxList = "leaderboardx_list";
        public const string LeaderboardxSubmit = "leaderboardx_submit";
        public const string LeaderboardxWinners = "leaderboardx_winners";
        public const string PublicationBannerClick = "publication_banner_click";
        public const string PublicationBannerView = "publication_banner_view";
        public const string PublicationBanners = "publication_banners";
        public const string PublicationFaqList = "publication_faq_list";
        public const string PublicationInbox = "publication_inbox";
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
        public const string VoiceToken = "voice_token";
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

        public Task<BaseAvatarResponse> AvatarAsync(BaseAvatarRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAvatarRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<BaseAvatarResponse>(_c, RpcIds.BaseAvatar, request, ReadCall, ct);
        }

        public Task<BaseAvatarGetResponse> AvatarGetAsync(BaseAvatarGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAvatarGetRequest();
            return RpcInvoke.CallAsync<BaseAvatarGetResponse>(_c, RpcIds.BaseAvatarGet, request, ReadCall, ct);
        }

        public Task<BaseAvatarSaveResponse> AvatarSaveAsync(BaseAvatarSaveRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseAvatarSaveRequest();
            return RpcInvoke.CallAsync<BaseAvatarSaveResponse>(_c, RpcIds.BaseAvatarSave, request, WriteCall, ct);
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

        public Task<BaseUsersGetResponse> UsersGetAsync(BaseUsersGetRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new BaseUsersGetRequest();
            return RpcInvoke.CallAsync<BaseUsersGetResponse>(_c, RpcIds.BaseUsersGet, request, ReadCall, ct);
        }

        public Task<VoiceTokenResponse> VoiceTokenAsync(VoiceTokenRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new VoiceTokenRequest();
            return RpcInvoke.CallAsync<VoiceTokenResponse>(_c, RpcIds.VoiceToken, request, WriteCall, ct);
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

        public Task<EconomyBalancesResponse> BalancesAsync(EconomyBalancesRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyBalancesRequest();
            return RpcInvoke.CallAsync<EconomyBalancesResponse>(_c, RpcIds.EconomyBalances, request, ReadCall, ct);
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

        public Task<EconomyChanceCanPlayResponse> ChanceCanPlayAsync(EconomyChanceCanPlayRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceCanPlayRequest();
            return RpcInvoke.CallAsync<EconomyChanceCanPlayResponse>(_c, RpcIds.EconomyChanceCanPlay, request, WriteCall, ct);
        }

        public Task<EconomyChanceGameResponse> ChanceGameAsync(EconomyChanceGameRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChanceGameRequest();
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
            return RpcInvoke.CallAsync<EconomyChanceNextPlayTimeResponse>(_c, RpcIds.EconomyChanceNextPlayTime, request, WriteCall, ct);
        }

        public Task<EconomyChancePlayResponse> ChancePlayAsync(EconomyChancePlayRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChancePlayRequest();
            return RpcInvoke.CallAsync<EconomyChancePlayResponse>(_c, RpcIds.EconomyChancePlay, request, WriteCall, ct);
        }

        public Task<EconomyChancePlayWithTicketResponse> ChancePlayWithTicketAsync(EconomyChancePlayWithTicketRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyChancePlayWithTicketRequest();
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

        public Task<EconomyGameJoinResponse> GameJoinAsync(EconomyGameJoinRequest request = null, CancellationToken ct = default)
        {
            request = request ?? new EconomyGameJoinRequest();
            if (request.Lang == null)
            {
                request.Lang = _c.Language;
            }

            return RpcInvoke.CallAsync<EconomyGameJoinResponse>(_c, RpcIds.EconomyGameJoin, request, WriteCall, ct);
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
        public string Lang { get; set; }

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

    public sealed class BaseFriendsAddRequest
    {
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
                [JsonProperty("imageUrl")]
                public string ImageUrl { get; set; }

                [JsonProperty("key")]
                public string Key { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("ref")]
                public string Ref { get; set; }

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

    public sealed class BaseUsersGetRequest
    {
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

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class ProductsItem
        {
            [JsonProperty("bought")]
            public bool? Bought { get; set; }

            [JsonProperty("categoryKey")]
            public string CategoryKey { get; set; }

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

    public sealed class EconomyChanceCanPlayRequest
    {
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

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("intervalTime")]
            public long? IntervalTime { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("lastPlayAt")]
            public string LastPlayAt { get; set; }

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

            [JsonProperty("price")]
            public PriceData Price { get; set; }

            [JsonProperty("prize")]
            public List<PrizeItem> Prize { get; set; }

            [JsonProperty("prizeType")]
            public string PrizeType { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

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
                public JToken Group { get; set; }

                [JsonProperty("prize")]
                public PrizeData Prize { get; set; }

                [JsonProperty("prizeGroupId")]
                public JToken PrizeGroupId { get; set; }

                [JsonProperty("prizeId")]
                public JToken PrizeId { get; set; }

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

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("intervalTime")]
            public long? IntervalTime { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("lastPlayAt")]
            public string LastPlayAt { get; set; }

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

            [JsonProperty("price")]
            public PriceData Price { get; set; }

            [JsonProperty("prize")]
            public List<PrizeItem> Prize { get; set; }

            [JsonProperty("prizeType")]
            public string PrizeType { get; set; }

            [JsonProperty("sort")]
            public long? Sort { get; set; }

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
                public JToken Group { get; set; }

                [JsonProperty("prize")]
                public PrizeData Prize { get; set; }

                [JsonProperty("prizeGroupId")]
                public JToken PrizeGroupId { get; set; }

                [JsonProperty("prizeId")]
                public JToken PrizeId { get; set; }

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

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("value")]
                public JToken Value { get; set; }

                [JsonExtensionData]
                public IDictionary<string, JToken> Extra { get; set; }
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

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("nextPlayAt")]
        public string NextPlayAt { get; set; }

        [JsonProperty("nextPlayTime")]
        public long? NextPlayTime { get; set; }

        [JsonProperty("playId")]
        public JToken PlayId { get; set; }

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

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("nextPlayAt")]
        public string NextPlayAt { get; set; }

        [JsonProperty("nextPlayTime")]
        public long? NextPlayTime { get; set; }

        [JsonProperty("playId")]
        public JToken PlayId { get; set; }

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

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("nextMilestone")]
            public long? NextMilestone { get; set; }

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

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }
    }

    public sealed class EconomyInventoryRequest
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
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

        [JsonProperty("developerPayload")]
        public string DeveloperPayload { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("purchaseMessage")]
        public string PurchaseMessage { get; set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

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

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
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

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
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

        [JsonProperty("developerPayload")]
        public string DeveloperPayload { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("purchaseMessage")]
        public string PurchaseMessage { get; set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("rewards")]
        public List<RewardsItem> Rewards { get; set; }

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

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
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

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
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

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class Task_Data
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
            public JToken Refund { get; set; }

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

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public JToken Value { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Extra { get; set; }
        }

        public sealed class TaskData
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
            public JToken Refund { get; set; }

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
                public JToken Refund { get; set; }

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

        public sealed class ItemsItem
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
            public JToken Refund { get; set; }

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

    public sealed class LeaderboardxBoardRequest
    {
        [JsonProperty("around")]
        public long? Around { get; set; }

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

            [JsonProperty("createdAt")]
            public JToken CreatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("imageUrl")]
            public string ImageUrl { get; set; }

            [JsonProperty("opened")]
            public bool? Opened { get; set; }

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
        }
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

        [JsonProperty("token")]
        public JToken Token { get; set; }

        [JsonProperty("url")]
        public JToken Url { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Extra { get; set; }
    }
}
