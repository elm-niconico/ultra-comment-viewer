using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ultra_comment_viewer.src.model.json.model.niconico
{
      public class Akashic    {
        public string trustedChildOrigin { get; set; } 
    }

    public class TrackingParams    {
        public string siteId { get; set; } 
        public string pageId { get; set; } 
        public string mode { get; set; } 
        public string programStatus { get; set; } 
    }

    public class Account    {
        public string accountRegistrationPageUrl { get; set; } 
        public string loginPageUrl { get; set; } 
        public string logoutPageUrl { get; set; } 
        public string premiumMemberRegistrationPageUrl { get; set; } 
        public TrackingParams trackingParams { get; set; } 
        public string profileRegistrationPageUrl { get; set; } 
        public string contactsPageUrl { get; set; } 
        public string verifyEmailsPageUrl { get; set; } 
        public string accountSettingPageUrl { get; set; } 
        public string currentPageUrl { get; set; } 
    }

    public class App    {
        public string topPageUrl { get; set; } 
    }

    public class Atsumaru    {
        public string topPageUrl { get; set; } 
    }

    public class Blomaga    {
        public string topPageUrl { get; set; } 
    }

    public class Channel    {
        public string topPageUrl { get; set; } 
        public string forOrganizationAndCompanyPageUrl { get; set; } 
    }

    public class Commons    {
        public string topPageUrl { get; set; } 
    }

    public class Community    {
        public string topPageUrl { get; set; } 
    }

    public class Denfaminicogamer    {
        public string topPageUrl { get; set; } 
    }

    public class Dic    {
        public string topPageUrl { get; set; } 
    }

    public class Help    {
        public string liveHelpPageUrl { get; set; } 
        public string systemRequirementsPageUrl { get; set; } 
    }

    public class Ichiba    {
        public string configBaseUrl { get; set; } 
        public string scriptUrl { get; set; } 
        public string topPageUrl { get; set; } 
    }

    public class Jk    {
        public string topPageUrl { get; set; } 
    }

    public class Mastodon    {
        public string topPageUrl { get; set; } 
    }

    public class News    {
        public string topPageUrl { get; set; } 
    }

    public class Nicoad    {
        public string topPageUrl { get; set; } 
        public string apiBaseUrl { get; set; } 
    }

    public class Niconico    {
        public string topPageUrl { get; set; } 
        public string userPageBaseUrl { get; set; } 
    }

    public class NiconicoQ    {
        public string topPageUrl { get; set; } 
    }

    public class Point    {
        public string topPageUrl { get; set; } 
        public string purchasePageUrl { get; set; } 
    }

    public class Seiga    {
        public string topPageUrl { get; set; } 
        public string seigaPageBaseUrl { get; set; } 
        public string comicPageBaseUrl { get; set; } 
    }

    public class Site2    {
        public string serviceListPageUrl { get; set; } 
        public string salesAdvertisingPageUrl { get; set; } 
        public string liveAppDownloadPageUrl { get; set; } 
    }

    public class Solid    {
        public string topPageUrl { get; set; } 
    }

    public class Uad    {
        public string topPageUrl { get; set; } 
    }

    public class Video    {
        public string topPageUrl { get; set; } 
        public string myPageUrl { get; set; } 
        public string watchPageBaseUrl { get; set; } 
    }

    public class Faq    {
        public string pageUrl { get; set; } 
    }

    public class Bugreport    {
        public string pageUrl { get; set; } 
    }

    public class RightsControlProgram    {
        public string pageUrl { get; set; } 
    }

    public class LicenseSearch    {
        public string pageUrl { get; set; } 
    }

    public class Info    {
        public string warnForPhishingPageUrl { get; set; } 
        public string smartphoneSdkPageUrl { get; set; } 
        public string nintendoGuidelinePageUrl { get; set; } 
    }

    public class Search    {
        public string suggestionApiUrl { get; set; } 
    }

    public class Nicoex    {
        public string apiBaseUrl { get; set; } 
    }

    public class Akashic2    {
        public string untrustedFrameUrl { get; set; } 
    }

    public class Superichiba    {
        public string apiBaseUrl { get; set; } 
        public string launchApiBaseUrl { get; set; } 
        public string oroshiuriIchibaBaseUrl { get; set; } 
    }

    public class NAir    {
        public string topPageUrl { get; set; } 
    }

    public class PrizeBox    {
        public string topPageUrl { get; set; } 
    }

    public class Emotion    {
        public string baseUrl { get; set; } 
    }

    public class FamilyService    {
        public Account account { get; set; } 
        public App app { get; set; } 
        public Atsumaru atsumaru { get; set; } 
        public Blomaga blomaga { get; set; } 
        public Channel channel { get; set; } 
        public Commons commons { get; set; } 
        public Community community { get; set; } 
        public Denfaminicogamer denfaminicogamer { get; set; } 
        public Dic dic { get; set; } 
        public Help help { get; set; } 
        public Ichiba ichiba { get; set; } 
        public Jk jk { get; set; } 
        public Mastodon mastodon { get; set; } 
        public News news { get; set; } 
        public Nicoad nicoad { get; set; } 
        public Niconico niconico { get; set; } 
        public NiconicoQ niconicoQ { get; set; } 
        public Point point { get; set; } 
        public Seiga seiga { get; set; } 
        public Site2 site { get; set; } 
        public Solid solid { get; set; } 
        public Uad uad { get; set; } 
        public Video video { get; set; } 
        public Faq faq { get; set; } 
        public Bugreport bugreport { get; set; } 
        public RightsControlProgram rightsControlProgram { get; set; } 
        public LicenseSearch licenseSearch { get; set; } 
        public Info info { get; set; } 
        public Search search { get; set; } 
        public Nicoex nicoex { get; set; } 
        public Akashic2 akashic { get; set; } 
        public Superichiba superichiba { get; set; } 
        public NAir nAir { get; set; } 
        public PrizeBox prizeBox { get; set; } 
        public Emotion emotion { get; set; } 
    }

    public class Environments    {
        public string runningMode { get; set; } 
    }

    public class Relive    {
        public string apiBaseUrl { get; set; } 
        public string webSocketUrl { get; set; } 
        public string csrfToken { get; set; } 
        public string audienceToken { get; set; } 
    }

    public class Information    {
        public string html5PlayerInformationPageUrl { get; set; } 
        public string flashPlayerInstallInformationPageUrl { get; set; } 
        public string maintenanceInformationPageUrl { get; set; } 
    }

    public class Rule    {
        public string agreementPageUrl { get; set; } 
        public string guidelinePageUrl { get; set; } 
    }

    public class Spec    {
        public string watchUsageAndDevicePageUrl { get; set; } 
        public string broadcastUsageDevicePageUrl { get; set; } 
        public string minogashiProgramPageUrl { get; set; } 
        public string cruisePageUrl { get; set; } 
    }

    public class Ad    {
        public string adsApiBaseUrl { get; set; } 
    }

    public class Program    {
        public int liveCount { get; set; } 
    }

    public class Tag    {
        public int revisionCheckIntervalMs { get; set; } 
        public string registerHelpPageUrl { get; set; } 
        public int userRegistrableMax { get; set; } 
        public int textMaxLength { get; set; } 
    }

    public class Coe    {
        public string resourcesBaseUrl { get; set; } 
        public string coeContentBaseUrl { get; set; } 
    }

    public class Timeshift    {
        public string reservationDetailListApiUrl { get; set; } 
    }

    public class NiconicoLiveEncoder    {
        public string downloadPageUrl { get; set; } 
    }

    public class Nair2    {
        public string downloadPageUrl { get; set; } 
    }

    public class Broadcast    {
        public string usageHelpPageUrl { get; set; } 
        public string stableBroadcastHelpPageUrl { get; set; } 
        public NiconicoLiveEncoder niconicoLiveEncoder { get; set; } 
        public Nair2 nair { get; set; } 
        public string broadcasterStreamHelpPageUrl { get; set; } 
    }

    public class Enquete    {
        public string usageHelpPageUrl { get; set; } 
    }

    public class TrialWatch    {
        public string usageHelpPageUrl { get; set; } 
    }

    public class VideoQuote    {
        public string usageHelpPageUrl { get; set; } 
    }

    public class AutoExtend    {
        public string usageHelpPageUrl { get; set; } 
    }

    public class Nicobus    {
        public string publicApiBaseUrl { get; set; } 
    }

    public class WebRtc    {
        public List<object> stunServerUrls { get; set; } 
    }

    public class Dmc    {
        public WebRtc webRtc { get; set; } 
    }

    public class Gift    {
        public string cantOpenPageCausedAdBlockHelpPageUrl { get; set; } 
    }

    public class CreatorPromotionProgram    {
        public string registrationHelpPageUrl { get; set; } 
    }

    public class Stream    {
        public string lowLatencyHelpPageUrl { get; set; } 
    }

    public class CommentRender    {
        public string liteModeHelpPageUrl { get; set; } 
    }

    public class Performance    {
        public CommentRender commentRender { get; set; } 
    }

    public class Nico    {
        public string webPushNotificationReceiveSettingHelpPageUrl { get; set; } 
    }

    public class Akashic3    {
        public string switchRenderHelpPageUrl { get; set; } 
    }

    public class Device    {
        public string watchOnPlayStation4HelpPageUrl { get; set; } 
        public string safariCantWatchHelpPageUrl { get; set; } 
    }

    public class Site    {
        public string locale { get; set; } 
        public long serverTime { get; set; } 
        public string frontendVersion { get; set; } 
        public string apiBaseUrl { get; set; } 
        public string staticResourceBaseUrl { get; set; } 
        public string topPageUrl { get; set; } 
        public string programCreatePageUrl { get; set; } 
        public string programEditPageUrl { get; set; } 
        public string programWatchPageUrl { get; set; } 
        public string recentPageUrl { get; set; } 
        public string programArchivePageUrl { get; set; } 
        public string historyPageUrl { get; set; } 
        public string myPageUrl { get; set; } 
        public string rankingPageUrl { get; set; } 
        public string searchPageUrl { get; set; } 
        public string focusPageUrl { get; set; } 
        public string timetablePageUrl { get; set; } 
        public string followedProgramsPageUrl { get; set; } 
        public int frontendId { get; set; } 
        public FamilyService familyService { get; set; } 
        public Environments environments { get; set; } 
        public Relive relive { get; set; } 
        public Information information { get; set; } 
        public Rule rule { get; set; } 
        public Spec spec { get; set; } 
        public Ad ad { get; set; } 
        public Program program { get; set; } 
        public Tag tag { get; set; } 
        public Coe coe { get; set; } 
        public Timeshift timeshift { get; set; } 
        public Broadcast broadcast { get; set; } 
        public Enquete enquete { get; set; } 
        public TrialWatch trialWatch { get; set; } 
        public VideoQuote videoQuote { get; set; } 
        public AutoExtend autoExtend { get; set; } 
        public Nicobus nicobus { get; set; } 
        public Dmc dmc { get; set; } 
        public string frontendPublicApiUrl { get; set; } 
        public string commonResourcesBaseUrl { get; set; } 
        public Gift gift { get; set; } 
        public CreatorPromotionProgram creatorPromotionProgram { get; set; } 
        public Stream stream { get; set; } 
        public Performance performance { get; set; } 
        public Nico nico { get; set; } 
        public Akashic3 akashic { get; set; } 
        public Device device { get; set; } 
        public string nicoCommonHeaderResourceBaseUrl { get; set; } 
    }

    public class Superichiba2    {
        public bool deletable { get; set; } 
        public bool hasBroadcasterRole { get; set; } 
    }

    public class User    {
        public bool isExplicitlyLoginable { get; set; } 
        public bool isMobileMailAddressRegistered { get; set; } 
        public bool isMailRegistered { get; set; } 
        public bool isProfileRegistered { get; set; } 
        public bool isLoggedIn { get; set; } 
        public string accountType { get; set; } 
        public bool isOperator { get; set; } 
        public bool isBroadcaster { get; set; } 
        public string premiumOrigin { get; set; } 
        public List<object> permissions { get; set; } 
        public string nicosid { get; set; } 
        public Superichiba2 superichiba { get; set; } 
    }

    public class Allegation    {
        public string commentAllegationApiUrl { get; set; } 
    }

    public class Thumbnail    {
        public string small { get; set; } 
    }

    public class UrlSet    {
        public string large { get; set; } 
        public string middle { get; set; } 
        public string small { get; set; } 
        public string micro { get; set; } 
    }

    public class Screenshot    {
        public UrlSet urlSet { get; set; } 
    }

    public class NicopediaArticle    {
        public string pageUrl { get; set; } 
        public bool exists { get; set; } 
    }

    public class Icons    {
        public string uri50x50 { get; set; } 
        public string uri150x150 { get; set; } 
    }

    public class Supplier    {
        public string name { get; set; } 
        public string pageUrl { get; set; } 
        public NicopediaArticle nicopediaArticle { get; set; } 
        public string programProviderId { get; set; } 
        public Icons icons { get; set; } 
        public int level { get; set; } 
        public string accountType { get; set; } 
    }

    public class Substitute    {
    }

    public class List    {
        public string text { get; set; } 
        public bool existsNicopediaArticle { get; set; } 
        public string nicopediaArticlePageUrl { get; set; } 
        public string type { get; set; } 
        public bool isLocked { get; set; } 
        public bool isDeletable { get; set; } 
    }

    public class Tag2    {
        public string updateApiUrl { get; set; } 
        public string lockApiUrl { get; set; } 
        public string reportApiUrl { get; set; } 
        public List<List> list { get; set; } 
        public bool isLocked { get; set; } 
    }

    public class Links    {
        public string feedbackPageUrl { get; set; } 
        public string contentsTreePageUrl { get; set; } 
        public string programReportPageUrl { get; set; } 
    }

    public class Banner    {
        public string apiUrl { get; set; } 
    }

    public class Player    {
        public string embedUrl { get; set; } 
        public Banner banner { get; set; } 
    }

    public class Zapping    {
        public string listApiUrl { get; set; } 
        public int listUpdateIntervalMs { get; set; } 
    }

    public class Report    {
        public string imageApiUrl { get; set; } 
    }

    public class CueSheet    {
        public string eventsApiUrl { get; set; } 
    }

    public class Nicoad2    {
        public int totalPoint { get; set; } 
        public List<object> ranking { get; set; } 
    }

    public class Stream2    {
        public string maxQuality { get; set; } 
    }

    public class Superichiba3    {
        public bool allowAudienceToAddNeta { get; set; } 
        public bool canSupplierUse { get; set; } 
    }

    public class Statistics    {
        public int watchCount { get; set; } 
        public int commentCount { get; set; } 
    }

    public class Program2    {
        public Allegation allegation { get; set; } 
        public string nicoliveProgramId { get; set; } 
        public string reliveProgramId { get; set; } 
        public string providerType { get; set; } 
        public string visualProviderType { get; set; } 
        public string title { get; set; } 
        public Thumbnail thumbnail { get; set; } 
        public Screenshot screenshot { get; set; } 
        public Supplier supplier { get; set; } 
        public int openTime { get; set; } 
        public int beginTime { get; set; } 
        public int vposBaseTime { get; set; } 
        public int endTime { get; set; } 
        public int scheduledEndTime { get; set; } 
        public string status { get; set; } 
        public string description { get; set; } 
        public Substitute substitute { get; set; } 
        public Tag2 tag { get; set; } 
        public Links links { get; set; } 
        public Player player { get; set; } 
        public string watchPageUrl { get; set; } 
        public string gatePageUrl { get; set; } 
        public string mediaServerType { get; set; } 
        public bool isPrivate { get; set; } 
        public bool isTest { get; set; } 
        public bool isSdk { get; set; } 
        public Zapping zapping { get; set; } 
        public Report report { get; set; } 
        public bool isFollowerOnly { get; set; } 
        public CueSheet cueSheet { get; set; } 
        public Nicoad2 nicoad { get; set; } 
        public bool isGiftEnabled { get; set; } 
        public Stream2 stream { get; set; } 
        public Superichiba3 superichiba { get; set; } 
        public bool isChasePlayEnabled { get; set; } 
        public Statistics statistics { get; set; } 
        public bool isPremiumAppealBannerEnabled { get; set; } 
        public bool isRecommendEnabled { get; set; } 
        public bool isEmotionEnabled { get; set; } 
    }

    public class SocialGroup    {
        public string type { get; set; } 
        public string id { get; set; } 
        public string broadcastHistoryPageUrl { get; set; } 
        public string description { get; set; } 
        public string name { get; set; } 
        public string socialGroupPageUrl { get; set; } 
        public string thumbnailImageUrl { get; set; } 
        public string thumbnailSmallImageUrl { get; set; } 
        public int level { get; set; } 
        public bool isFollowed { get; set; } 
        public bool isJoined { get; set; } 
    }

    public class Player2    {
        public string name { get; set; } 
        public string audienceToken { get; set; } 
        public bool isJumpDisabled { get; set; } 
        public bool disablePlayVideoAd { get; set; } 
        public bool isRestrictedCommentPost { get; set; } 
        public string streamAllocationType { get; set; } 
    }

    public class Ad2    {
        public bool isBillboardEnabled { get; set; } 
        public bool isSiteHeaderBannerEnabled { get; set; } 
        public bool isProgramInformationEnabled { get; set; } 
        public bool isFooterEnabled { get; set; } 
        public string adsJsUrl { get; set; } 
    }

    public class Billboard    {
    }

    public class Scripts    {
        public string vendor { get; set; } 
        public string nicolib { get; set; } 
        [JsonPropertyName("broadcaster-tool")]
        public string BroadcasterTool { get; set; } 
        public string ichiba { get; set; } 
        [JsonPropertyName("operator-tools")]
        public string OperatorTools { get; set; } 
        [JsonPropertyName("pc-watch")]
        public string PcWatch { get; set; } 
        [JsonPropertyName("pc-watch.all")]
        public string PcWatchAll { get; set; } 
        public string polyfill { get; set; } 
    }

    public class Stylesheets    {
        [JsonPropertyName("broadcaster-tool")]
        public string BroadcasterTool { get; set; } 
        public string ichiba { get; set; } 
        [JsonPropertyName("operator-tools")]
        public string OperatorTools { get; set; } 
        [JsonPropertyName("pc-watch")]
        public string PcWatch { get; set; } 
        [JsonPropertyName("pc-watch.all")]
        public string PcWatchAll { get; set; } 
    }

    public class Assets    {
        public Scripts scripts { get; set; } 
        public Stylesheets stylesheets { get; set; } 
    }

    public class NicoEnquete    {
        public bool isEnabled { get; set; } 
    }

    public class Community2    {
        public string id { get; set; } 
        public string followPageUrl { get; set; } 
        public string unfollowPageUrl { get; set; } 
    }

    public class CommunityFollower    {
        public List<object> records { get; set; } 
    }

    public class UserProgramWatch    {
        public List<string> rejectedReasons { get; set; } 
        public object expireTime { get; set; } 
        public bool canAutoRefresh { get; set; } 
    }

    public class UserProgramReservation    {
        public bool isReserved { get; set; } 
    }

    public class Condition    {
        public bool needLogin { get; set; } 
    }

    public class ProgramWatch    {
        public Condition condition { get; set; } 
    }

    public class PremiumAppealBanner    {
        public string premiumRegistrationUrl { get; set; } 
    }

    public class Onair    {
        public string programId { get; set; } 
        public string programUrl { get; set; } 
    }

    public class SupplierProgram    {
        public Onair onair { get; set; } 
    }

    public class Condition2    {
        public bool isWithinUserTestTime { get; set; } 
    }

    public class UserTest    {
        public Condition2 condition { get; set; } 
    }

    public class Fmp4    {
        public bool enabled { get; set; } 
        public UserTest userTest { get; set; } 
    }

    public class Stream3    {
        public Fmp4 fmp4 { get; set; } 
    }

    public class KonomiTag    {
        public string text { get; set; } 
        public int nicopediaArticleId { get; set; } 
        public string nicopediaArticleUrl { get; set; } 
    }

    public class ProgramBroadcaster    {
        public List<KonomiTag> konomiTags { get; set; } 
    }

    public class ProgramSuperichiba    {
        public bool programIsPermittedToRequestSpecificNeta { get; set; } 
    }

    public class DataPropsJsonModel    {
        public Akashic akashic { get; set; } 
        public Site site { get; set; } 
        public User user { get; set; } 
        public Program2 program { get; set; } 
        public SocialGroup socialGroup { get; set; } 
        public Player2 player { get; set; } 
        public Ad2 ad { get; set; } 
        public Billboard billboard { get; set; } 
        public Assets assets { get; set; } 
        public NicoEnquete nicoEnquete { get; set; } 
        public Community2 community { get; set; } 
        public CommunityFollower communityFollower { get; set; } 
        public UserProgramWatch userProgramWatch { get; set; } 
        public UserProgramReservation userProgramReservation { get; set; } 
        public ProgramWatch programWatch { get; set; } 
        public PremiumAppealBanner premiumAppealBanner { get; set; } 
        public SupplierProgram supplierProgram { get; set; } 
        public Stream3 stream { get; set; } 
        public ProgramBroadcaster programBroadcaster { get; set; } 
        public ProgramSuperichiba programSuperichiba { get; set; } 
    }


}
