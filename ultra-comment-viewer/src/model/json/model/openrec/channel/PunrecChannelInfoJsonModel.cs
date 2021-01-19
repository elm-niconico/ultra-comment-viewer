using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.openrec.channel
{
     public class SpriteImage    {
        public string url { get; set; } 
        public int interval { get; set; } 
        public int width { get; set; } 
        public int height { get; set; } 
        public int cols { get; set; } 
        public int rows { get; set; } 
        public int start_page { get; set; } 
        public string ext { get; set; } 
    }

    public class Media    {
        public string url { get; set; } 
        public object url_source { get; set; } 
        public string url_public { get; set; } 
        public object url_trailer { get; set; } 
        public string url_dvr { get; set; } 
        public string url_dvr_audio { get; set; } 
        public string url_audio { get; set; } 
        public string url_low_latency { get; set; } 
        public string url_ull { get; set; } 
    }

    public class SubsTrialMedia    {
        public object url { get; set; } 
        public object url_low_latency { get; set; } 
        public object url_ull { get; set; } 
        public object url_dvr { get; set; } 
        public object url_audio { get; set; } 
        public object url_dvr_audio { get; set; } 
    }

    public class Channel    {
        public string id { get; set; } 
        public bool registered_user_id { get; set; } 
        public int openrec_user_id { get; set; } 
        public int recxuser_id { get; set; } 
        public string nickname { get; set; } 
        public string introduction { get; set; } 
        public string icon_image_url { get; set; } 
        public string l_icon_image_url { get; set; } 
        public string cover_image_url { get; set; } 
        public string l_cover_image_url { get; set; } 
        public int follows { get; set; } 
        public int followers { get; set; } 
        public bool is_premium { get; set; } 
        public bool is_official { get; set; } 
        public bool is_fresh { get; set; } 
        public bool is_warned { get; set; } 
        public bool is_team { get; set; } 
        public bool is_league_yell { get; set; } 
        public bool is_live { get; set; } 
        public int live_views { get; set; } 
        public bool is_viewers_hidden { get; set; } 
        public DateTime registered_at { get; set; } 
        public DateTime last_updated_at { get; set; } 
        public object signed_in_with_facebook { get; set; } 
        public object signed_in_with_twitter { get; set; } 
        public object signed_in_with_google { get; set; } 
        public object signed_in_with_yahoo { get; set; } 
        public object signed_in_with_apple { get; set; } 
        public object user_status { get; set; } 
        public bool is_creator { get; set; } 
        public string name { get; set; } 
        public int movies { get; set; } 
        public int views { get; set; } 
        public string chat_rule { get; set; } 
        public object twitter_screen_name { get; set; } 
        public object ga_tracking_id { get; set; } 
        public List<object> blacklist { get; set; } 
        public object games { get; set; } 
        public List<object> tags { get; set; } 
        public object onair_broadcast_movies { get; set; } 
        public bool enabled_channel_stamp { get; set; } 
        public bool enabled_channel_yell { get; set; } 
    }

    public class ChatSetting    {
        public string name_color { get; set; } 
        public bool is_premium_hidden { get; set; } 
        public bool is_official_hidden { get; set; } 
        public bool limited_unsubs_member_chat { get; set; } 
        public bool limited_continuous_chat { get; set; } 
        public int continuous_chat_threshold { get; set; } 
        public bool limited_unfollower_chat { get; set; } 
        public int unfollower_chat_threshold { get; set; } 
        public bool limited_fresh_user_chat { get; set; } 
        public int fresh_user_chat_threshold { get; set; } 
        public bool limited_temporary_blacklist { get; set; } 
        public int temporary_blacklist_threshold { get; set; } 
        public bool limited_warned_user_chat { get; set; } 
        public string chat_rule { get; set; } 
        public bool chat_terms_required { get; set; } 
    }

    public class Stats    {
        public object live_views { get; set; } 
        public object movie_count { get; set; } 
        public object total_views { get; set; } 
        public object creator_count { get; set; } 
        public object last_update_at { get; set; } 
    }

    public class Game    {
        public string id { get; set; } 
        public int game_id { get; set; } 
        public string title { get; set; } 
        public string introduction { get; set; } 
        public string title_image_url { get; set; } 
        public string cover_image_url { get; set; } 
        public string app_store_url { get; set; } 
        public string play_store_url { get; set; } 
        public string schema_url { get; set; } 
        public string package_name { get; set; } 
        public int license_status { get; set; } 
        public string notice_message { get; set; } 
        public int monetize_status { get; set; } 
        public int cero_rating { get; set; } 
        public bool is_portrait { get; set; } 
        public DateTime? released_at { get; set; } 
        public object maker { get; set; } 
        public string platform_mobile { get; set; } 
        public string platform_pc { get; set; } 
        public string platform_console { get; set; } 
        public string platform_arcade { get; set; } 
        public bool is_platform_mobile { get; set; } 
        public bool is_platform_pc { get; set; } 
        public bool is_platform_console { get; set; } 
        public bool is_platform_arcade { get; set; } 
        public Stats stats { get; set; } 
    }

    public class ViewHistory    {
        public object views_at { get; set; } 
        public int play_position { get; set; } 
    }

    public class PunrecChannelInfoJsonModel   
    {
        public string id { get; set; } 
        public int movie_id { get; set; } 
        public string title { get; set; } 
        public string introduction { get; set; } 
        public bool is_hidden { get; set; } 
        public bool is_live { get; set; } 
        public int onair_status { get; set; } 
        public string movie_type { get; set; } 
        public string upload_status { get; set; } 
        public int monetize_status { get; set; } 
        public string thumbnail_url { get; set; } 
        public string l_thumbnail_url { get; set; } 
        public string s_thumbnail_url { get; set; } 
        public string l_sprite_image_url { get; set; } 
        public string s_sprite_image_url { get; set; } 
        public List<int> sprite_intervals { get; set; } 
        public SpriteImage sprite_image { get; set; } 
        public object cover_image_url { get; set; } 
        public bool is_cover_image_icon { get; set; } 
        public int live_views { get; set; } 
        public int total_views { get; set; } 
        public int total_yells { get; set; } 
        public bool is_mobile { get; set; } 
        public bool is_low_latency { get; set; } 
        public bool is_dvr { get; set; } 
        public bool is_capture { get; set; } 
        public bool is_fixed_phrase { get; set; } 
        public bool enabled_ad { get; set; } 
        public bool enabled_yell { get; set; } 
        public bool enabled_owner_yell { get; set; } 
        public bool enabled_cast_yell { get; set; } 
        public object ad { get; set; } 
        public DateTime created_at { get; set; } 
        public DateTime published_at { get; set; } 
        public DateTime started_at { get; set; } 
        public DateTime ended_at { get; set; } 
        public object will_start_at { get; set; } 
        public object will_end_at { get; set; } 
        public int start_time { get; set; } 
        public int play_time { get; set; } 
        public bool is_banned { get; set; } 
        public int ban_type { get; set; } 
        public int orientation { get; set; } 
        public int device_type { get; set; } 
        public string broadcast_type { get; set; } 
        public object width { get; set; } 
        public object height { get; set; } 
        public int connect_count { get; set; } 
        public object continue_ticket_count { get; set; } 
        public int play_list_id { get; set; } 
        public object league_id { get; set; } 
        public List<object> tags { get; set; } 
        public Media media { get; set; } 
        public SubsTrialMedia subs_trial_media { get; set; } 
        public Channel channel { get; set; } 
        public object subs_channel { get; set; } 
        public ChatSetting chat_setting { get; set; } 
        public Game game { get; set; } 
        public object next { get; set; } 
        public List<object> casts { get; set; } 
        public int popularity { get; set; } 
        public bool is_live_viewers { get; set; } 
        public bool is_viewers_hidden { get; set; } 
        public string public_type { get; set; } 
        public string chat_public_type { get; set; } 
        public string archive_public_type { get; set; } 
        public object poll { get; set; } 
        public object poll_use_target { get; set; } 
        public object playlist_use_target { get; set; } 
        public bool chat_force_websocket { get; set; } 
        public ViewHistory view_history { get; set; } 
        public List<object> chapters { get; set; } 
        public object ppv_event { get; set; } 
        public List<object> permissions { get; set; } 
        public object archive_status { get; set; } 
    }



}
