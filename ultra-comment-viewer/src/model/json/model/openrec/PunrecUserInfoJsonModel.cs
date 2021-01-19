using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.openrec
{
     public class Capture    {
        public string id { get; set; } 
        public string title { get; set; } 
        public bool isPublic { get; set; } 
        public object publishedAt { get; set; } 
        public int startTime { get; set; } 
        public int endTime { get; set; } 
        public string source { get; set; } 
        public string thumbnail { get; set; } 
        public List<object> thumbnails { get; set; } 
        public string thumbnailUrl { get; set; } 
        public string movieStartPoint { get; set; } 
        public string capturePoint { get; set; } 
        public string chatFromAt { get; set; } 
        public string createdAt { get; set; } 
    }

    public class CaptureChannel    {
        public string id { get; set; } 
        public string nickname { get; set; } 
    }

    public class Game    {
        public string title { get; set; } 
        public string id { get; set; } 
        public int gameId { get; set; } 
        public int ceroRating { get; set; } 
    }

    public class Movie    {
        public int? onairStatus { get; set; } 
        public bool isMobile { get; set; } 
        public int orientation { get; set; } 
        public int deviceType { get; set; } 
        public string id { get; set; } 
        public string title { get; set; } 
        public int totalViews { get; set; } 
        public int liveViews { get; set; } 
        public string createdAt { get; set; } 
        public string startedAt { get; set; } 
        public Channel channel { get; set; } 
        public string leagueId { get; set; } 
        public bool enabledYell { get; set; } 
        public bool enabledCastYell { get; set; } 
        public bool isViewersHidden { get; set; } 
    }

    public class CaptureEditPageStore    {
        public string storeName { get; set; } 
        public Capture capture { get; set; } 
        public CaptureChannel captureChannel { get; set; } 
        public Game game { get; set; } 
        public Movie movie { get; set; } 
        public bool isQuiet { get; set; } 
        public List<object> _disposers { get; set; } 
    }

    public class Channel    {
        public string id { get; set; } 
        public string name { get; set; } 
        public string iconImageUrl { get; set; } 
        public bool isLeagueYell { get; set; } 
        public int openrecUserId { get; set; } 
        public int followers { get; set; } 
        public List<object> teams { get; set; } 
        public string coverImageUrl { get; set; } 
        public bool isModerating { get; set; } 
        public bool isPushEnabled { get; set; } 
        public bool isPremium { get; set; } 
        public bool isOfficial { get; set; } 
        public bool isFresh { get; set; } 
        public bool isWarned { get; set; } 
        public string twitterScreenName { get; set; } 
        public string gaTrackingId { get; set; } 
        public bool enabledChannelStamp { get; set; } 
        public bool enabledChannelYell { get; set; } 
    }

    public class ChatSetting    {
        public bool isSmallSizeStamp { get; set; } 
        public bool mutedUnauthenticatedUser { get; set; } 
        public bool mutedFreshUser { get; set; } 
        public bool mutedWarnedUser { get; set; } 
        public bool mutedBannedWord { get; set; } 
    }

    public class CaptureCells    {
        public List<object> channel { get; set; } 
        public List<object> game { get; set; } 
        public List<object> latest { get; set; } 
    }

    public class PlaylistStore    {
        public List<object> _disposerMap { get; set; } 
        public int _disposerId { get; set; } 
        public object routeStore { get; set; } 
        public bool continuousPlayback { get; set; } 
    }

    public class AdjustStore    {
        public object stores { get; set; } 
    }

    public class CapturePlayPageStore    {
        public object stores { get; set; } 
        public string storeName { get; set; } 
        public bool isCapturePlayPageEmbed { get; set; } 
        public bool published { get; set; } 
        public Capture capture { get; set; } 
        public CaptureChannel captureChannel { get; set; } 
        public Game game { get; set; } 
        public Movie movie { get; set; } 
        public ChatSetting chatSetting { get; set; } 
        public List<object> blacklistUserIds { get; set; } 
        public List<object> reactionStatsList { get; set; } 
        public List<object> chatsPool { get; set; } 
        public List<object> chats { get; set; } 
        public CaptureCells captureCells { get; set; } 
        public bool isCompletedInitReactions { get; set; } 
        public bool isBlackListed { get; set; } 
        public bool isShowBlackListCard { get; set; } 
        public bool isShowIPBanCard { get; set; } 
        public bool isIpBannedChecked { get; set; } 
        public int _status { get; set; } 
        public int _hasFetchedChatTime { get; set; } 
        public List<object> _disposers { get; set; } 
        public PlaylistStore playlistStore { get; set; } 
        public AdjustStore adjustStore { get; set; } 
    }

    public class LeagueRankStore    {
        public string storeName { get; set; } 
        public string leagueKey { get; set; } 
    }

    public class NewSuppoter    {
        public int currentTime { get; set; } 
        public int duration { get; set; } 
        public object supporter { get; set; } 
    }

    public class YellReply    {
        public int id { get; set; } 
        public string message { get; set; } 
        public string createdAt { get; set; } 
    }

    public class YellStore    {
        public object stores { get; set; } 
        public string currentTab { get; set; } 
        public NewSuppoter newSuppoter { get; set; } 
        public List<object> newSuppoterQueue { get; set; } 
        public List<object> newYells { get; set; } 
        public List<object> yellRanks { get; set; } 
        public List<object> yellRanksOfMonthly { get; set; } 
        public int pageOfNewYells { get; set; } 
        public int pageOfYellRanks { get; set; } 
        public int pageOfMonthlyYellRanks { get; set; } 
        public bool isLastPageOfNewYells { get; set; } 
        public bool isLastPageOfYellRanks { get; set; } 
        public bool isLastPageOfMonthlyYellRanks { get; set; } 
        public bool isLoading { get; set; } 
        public bool isYellLogVisible { get; set; } 
        public YellReply yellReply { get; set; } 
        public bool _isNewYellReplyVisible { get; set; } 
        public bool _isYellReplyVisible { get; set; } 
    }

    public class SplitViewStore    {
        public object stores { get; set; } 
        public List<object> notifications { get; set; } 
        public bool isOpenedSplitView { get; set; } 
        public bool isScrollingByAuto { get; set; } 
        public bool isLastPage { get; set; } 
        public bool isTracing { get; set; } 
        public object splitViewPopoutWindow { get; set; } 
        public List<object> notificationQue { get; set; } 
        public List<object> notificationPool { get; set; } 
        public bool isScrolledByAuto { get; set; } 
        public object _preLastNotificationCell { get; set; } 
        public object _preFirstNotificationCellId { get; set; } 
        public int _systemChatId { get; set; } 
        public bool _everOpenedSplitView { get; set; } 
    }

    public class CaptureResponse    {
        public string captureId { get; set; } 
        public string captureThumbnail { get; set; } 
    }

    public class SpriteImage    {
        public string url { get; set; } 
        public int interval { get; set; } 
        public int width { get; set; } 
        public int height { get; set; } 
        public int cols { get; set; } 
        public int rows { get; set; } 
        public int startPage { get; set; } 
        public string ext { get; set; } 
    }

    public class Media    {
        public string url { get; set; } 
        public string urlDvr { get; set; } 
        public string urlUll { get; set; } 
        public string urlTrailer { get; set; } 
        public string urlSource { get; set; } 
    }

    public class Owner    {
        public string id { get; set; } 
        public string nickname { get; set; } 
    }

    public class SubsChannel    {
        public string id { get; set; } 
        public string description { get; set; } 
        public string bannerImageUrl { get; set; } 
        public string defaultBadgeImageUrl { get; set; } 
        public string status { get; set; } 
        public Owner owner { get; set; } 
    }

    public class Ad    {
        public string webStream { get; set; } 
    }

    public class ViewsLimit    {
        public bool hasPermission { get; set; } 
        public bool isViewed { get; set; } 
        public int remain { get; set; } 
        public string restrictionMethod { get; set; } 
        public int secondsRemaining { get; set; } 
    }

    public class Settings    {
        public bool limitedContinuousChat { get; set; } 
        public int continuousChatThreshold { get; set; } 
        public bool limitedUnfollowerChat { get; set; } 
        public int unfollowerChatThreshold { get; set; } 
        public bool limitedFreshUserChat { get; set; } 
        public int freshUserChatThreshold { get; set; } 
        public bool limitedTemporaryBlacklist { get; set; } 
        public int temporaryBlacklistThreshold { get; set; } 
        public bool limitedWarnedUserChat { get; set; } 
        public string chatRule { get; set; } 
        public string userColor { get; set; } 
        public bool isOfficialHidden { get; set; } 
        public bool isPremiumHidden { get; set; } 
        public bool isSubsBadgeHidden { get; set; } 
        public bool isSubsDurationHidden { get; set; } 
        public bool isChatTermsRequired { get; set; } 
    }

    public class Poll    {
        public string id { get; set; } 
        public string title { get; set; } 
        public string status { get; set; } 
        public string target { get; set; } 
        public object startedAt { get; set; } 
        public object endedAt { get; set; } 
        public object totalCount { get; set; } 
        public List<object> votes { get; set; } 
    }

    public class VoteResult    {
        public int index { get; set; } 
        public string text { get; set; } 
        public int count { get; set; } 
        public int ratio { get; set; } 
        public int rank { get; set; } 
    }

    public class MovieStore    {
        public object stores { get; set; } 
        public bool isCompletedFetchMovie { get; set; } 
        public bool isCompletedFetchMovieDetail { get; set; } 
        public bool isCompletedFetchSubsProduct { get; set; } 
        public bool isCompletedFetchVoteResult { get; set; } 
        public string id { get; set; } 
        public string leagueId { get; set; } 
        public string title { get; set; } 
        public string introduction { get; set; } 
        public string thumbnailUrl { get; set; } 
        public List<object> casts { get; set; } 
        public List<object> tags { get; set; } 
        public string sSpriteImageUrl { get; set; } 
        public string lSpriteImageUrl { get; set; } 
        public object next { get; set; } 
        public SpriteImage spriteImage { get; set; } 
        public int totalViews { get; set; } 
        public int liveViews { get; set; } 
        public int totalYells { get; set; } 
        public DateTime createdAt { get; set; } 
        public DateTime publishedAt { get; set; } 
        public DateTime startedAt { get; set; } 
        public string willStartAt { get; set; } 
        public string willEndAt { get; set; } 
        public int startTime { get; set; } 
        public int playTime { get; set; } 
        public bool notFound { get; set; } 
        public string publicType { get; set; } 
        public string chatPublicType { get; set; } 
        public int monetizeStatus { get; set; } 
        public int? onairStatus { get; set; } 
        public string uploadStatus { get; set; } 
        public bool isLowLatency { get; set; } 
        public bool isUploadedMovie { get; set; } 
        public bool isMobile { get; set; } 
        public bool isDvr { get; set; } 
        public bool isCaputure { get; set; } 
        public bool enabledAd { get; set; } 
        public bool enabledYell { get; set; } 
        public bool enabledOwnerYell { get; set; } 
        public bool enabledCastYell { get; set; } 
        public int width { get; set; } 
        public int height { get; set; } 
        public int playPostion { get; set; } 
        public int orientation { get; set; } 
        public int dvrOrientation { get; set; } 
        public int deviceType { get; set; } 
        public string movieType { get; set; } 
        public int connectCount { get; set; } 
        public bool isFixedPhrase { get; set; } 
        public bool isViewersHidden { get; set; } 
        public bool chatForceWebsocket { get; set; } 
        public Media media { get; set; } 
        public Game game { get; set; } 
        public List<object> chapters { get; set; } 
        public Channel channel { get; set; } 
        public SubsChannel subsChannel { get; set; } 
        public Ad ad { get; set; } 
        public ViewsLimit viewsLimit { get; set; } 
        public Settings settings { get; set; } 
        public List<object> playableChannelIdsOnMoblie { get; set; } 
        public List<object> fesEntries { get; set; } 
        public Poll poll { get; set; } 
        public string pollUseTarget { get; set; } 
        public VoteResult voteResult { get; set; } 
        public List<object> permissions { get; set; } 
        public List<object> castYellMembers { get; set; } 
        public List<object> castYellHistory { get; set; } 
        public bool isSelectedCast { get; set; } 
        public bool isMemberTrialMessageVisible { get; set; } 
        public bool isFesEventIconClosed { get; set; } 
        public bool _isFinishedMedia { get; set; } 
        public bool _tempIsFixedPhrase { get; set; } 
    }

    public class ChatSettingStore    {
        public List<object> bannedWords { get; set; } 
        public string menuType { get; set; } 
        public bool menuVisible { get; set; } 
        public bool isEnabledXHRPolling { get; set; } 
        public bool delayChat { get; set; } 
        public bool muteFreshUser { get; set; } 
        public bool muteWarnedUser { get; set; } 
        public bool muteForbiddenWord { get; set; } 
        public bool muteUnAuthenticatedUser { get; set; } 
        public bool isPremiumHidden { get; set; } 
        public bool isOfficialHidden { get; set; } 
        public string userColor { get; set; } 
        public bool limitedContinuousChat { get; set; } 
        public int continuousChatThreshold { get; set; } 
        public bool limitedUnfollowerChat { get; set; } 
        public int unfollowerChatThreshold { get; set; } 
        public bool limitedFreshUserChat { get; set; } 
        public int freshUserChatThreshold { get; set; } 
        public bool limitedTemporaryBlacklist { get; set; } 
        public int temporaryBlacklistThreshold { get; set; } 
        public bool limitedWarnedUserChat { get; set; } 
        public bool isChatTermsRequired { get; set; } 
        public string chatRule { get; set; } 
        public bool isSmallSizeStamp { get; set; } 
        public bool isFixedPhraseHidden { get; set; } 
        public bool isSubsBadgeHidden { get; set; } 
        public bool isSubsDurationHidden { get; set; } 
    }

    public class ChatStore    {
        public object stores { get; set; } 
        public List<object> chats { get; set; } 
        public object latestChat { get; set; } 
        public bool isReproducingChatInDvr { get; set; } 
        public List<object> moderator { get; set; } 
        public List<object> bannedWords { get; set; } 
        public bool chatScrollEnable { get; set; } 
        public bool isLastPage { get; set; } 
        public bool isPopout { get; set; } 
        public bool isTracing { get; set; } 
        public List<object> yellProductGroup { get; set; } 
        public bool isChatVisible { get; set; } 
        public bool isChatTransitioning { get; set; } 
        public List<object> fixedPhrases { get; set; } 
        public bool isFixedPhraseChatVisible { get; set; } 
        public bool isFixedPhraseListVisible { get; set; } 
        public string currentYellGroupId { get; set; } 
        public bool enabledChatInDvr { get; set; } 
        public bool isScrollingByAuto { get; set; } 
        public List<object> chatQue { get; set; } 
        public List<object> systemChatQue { get; set; } 
        public List<object> archiveChatQue { get; set; } 
        public bool chatLoading { get; set; } 
        public bool archiveChatLoading { get; set; } 
        public bool nextArchiveChatExists { get; set; } 
        public bool forcedScrollBottom { get; set; } 
        public bool isScrolledByAuto { get; set; } 
        public int forcedAutoScrollCount { get; set; } 
        public object _preLastChatCell { get; set; } 
        public object _preFirstChatCellId { get; set; } 
        public int _systemChatId { get; set; } 
        public ChatSettingStore chatSettingStore { get; set; } 
    }

    public class ChatModeratorStore    {
        public object stores { get; set; } 
        public List<object> chatModerators { get; set; } 
        public object latestMessage { get; set; } 
        public List<object> moderators { get; set; } 
        public bool chatScrollEnable { get; set; } 
        public bool isLastPage { get; set; } 
        public bool isChatVisible { get; set; } 
        public bool isCompletedInicialFetch { get; set; } 
        public bool enabledChatInDvr { get; set; } 
        public bool isScrollingByAuto { get; set; } 
        public List<object> chatModeratorQue { get; set; } 
        public bool chatLoading { get; set; } 
        public int scrollTop { get; set; } 
        public int scrollEnd { get; set; } 
        public int preScrollEnd { get; set; } 
        public bool forcedScrollBottom { get; set; } 
        public bool isScrolledByAuto { get; set; } 
        public int forcedAutoScrollCount { get; set; } 
        public bool _isLoadedChatModerator { get; set; } 
        public object _preLastChatCellId { get; set; } 
        public ChatSettingStore chatSettingStore { get; set; } 
    }

    public class CommentStore    {
        public object stores { get; set; } 
        public List<object> comments { get; set; } 
    }

    public class UserCard    {
        public object element { get; set; } 
        public object blacklistElement { get; set; } 
        public object ipBanElement { get; set; } 
        public string userId { get; set; } 
        public string userName { get; set; } 
        public bool followed { get; set; } 
        public bool blacklisted { get; set; } 
        public bool moderated { get; set; } 
        public string userIconImageUrl { get; set; } 
        public string userCoverImageUrl { get; set; } 
        public int recxuserId { get; set; } 
        public bool isAuthenticated { get; set; } 
    }

    public class UserCardStore    {
        public object stores { get; set; } 
        public UserCard userCard { get; set; } 
        public bool isOpenBlacklistCard { get; set; } 
    }

    public class LeagueStore    {
        public object stores { get; set; } 
        public List<object> toUserHistory { get; set; } 
        public List<object> leagueRanks { get; set; } 
        public List<object> leagueMembers { get; set; } 
        public bool isEnabledTeam { get; set; } 
    }

    public class PollStore    {
        public object stores { get; set; } 
        public bool isClosed { get; set; } 
        public bool isOpenedPopout { get; set; } 
    }

    public class SocketStore    {
        public object stores { get; set; } 
        public object parentWindow { get; set; } 
        public object _currentSocket { get; set; } 
        public string chatHost { get; set; } 
    }

    public class MoviePageStore    {
        public string storeName { get; set; } 
        public object stores { get; set; } 
        public YellStore yellStore { get; set; } 
        public SplitViewStore splitViewStore { get; set; } 
        public string currentPlayerType { get; set; } 
        public int playerTypeUpdateIntervalId { get; set; } 
        public bool hasAlreadyPostedViewLog { get; set; } 
        public bool isCompletedFetchRelatedMovies { get; set; } 
        public int videoWidth { get; set; } 
        public int videoHeight { get; set; } 
        public int chatArticleWidth { get; set; } 
        public List<object> popularLiveStreams { get; set; } 
        public List<object> liveStreamsOfSameGame { get; set; } 
        public List<object> relatedMovieStreams { get; set; } 
        public List<object> liveStreamsOfSameTag { get; set; } 
        public List<object> moviesOfChannel { get; set; } 
        public List<object> moviesOfSameGameOfChannel { get; set; } 
        public List<object> capturesOfMovie { get; set; } 
        public object chatPopoutWindow { get; set; } 
        public bool isChatPopoutPage { get; set; } 
        public bool isSplitViewPopoutPage { get; set; } 
        public bool isCapturePremiumDialogVisible { get; set; } 
        public bool isCapturePopupVisible { get; set; } 
        public bool isPolling { get; set; } 
        public CaptureResponse captureResponse { get; set; } 
        public List<object> aborts { get; set; } 
        public object videoWrapperEl { get; set; } 
        public object movieArticle { get; set; } 
        public bool isClickChatModerator { get; set; } 
        public object _loadArchiveChatTimeoutID { get; set; } 
        public bool _isCaptureTimeout { get; set; } 
        public bool _sentContinuousBufferStalledErrorMessage { get; set; } 
        public int RELATED_MOVIE_LIMIT { get; set; } 
        public int TEAM_LIVE_LIMIT { get; set; } 
        public int FOLLOWEE_LIVE_LIMIT { get; set; } 
        public int CHANNEL_ARCHIVE_LIMIT { get; set; } 
        public int GAME_LIVE_LIMIT { get; set; } 
        public int RELATED_MOVIE_SHOW_LIMIT { get; set; } 
        public MovieStore movieStore { get; set; } 
        public ChatSettingStore chatSettingStore { get; set; } 
        public ChatStore chatStore { get; set; } 
        public ChatModeratorStore chatModeratorStore { get; set; } 
        public CommentStore commentStore { get; set; } 
        public UserCardStore userCardStore { get; set; } 
        public LeagueStore leagueStore { get; set; } 
        public PollStore pollStore { get; set; } 
        public PlaylistStore playlistStore { get; set; } 
        public SocketStore socketStore { get; set; } 
        public AdjustStore adjustStore { get; set; } 
    }

    public class PunrecUserInfoJsonModel  {
        public CaptureEditPageStore captureEditPageStore { get; set; } 
        public CapturePlayPageStore capturePlayPageStore { get; set; } 
        public LeagueRankStore leagueRankStore { get; set; } 
        public MoviePageStore moviePageStore { get; set; } 
    }

}
