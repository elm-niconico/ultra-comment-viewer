using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.openrec.comment
{
    public class Data
    {
        public int movie_id { get; set; }
        public int live_type { get; set; }
        public int onair_status { get; set; }
        public int user_id { get; set; }
        public int openrec_user_id { get; set; }
        public string user_name { get; set; }
        public string user_type { get; set; }
        public string user_key { get; set; }
        public string user_identify_id { get; set; }
        public int user_rank { get; set; }
        public int chat_id { get; set; }
        public int item { get; set; }
        public int golds { get; set; }
        public string message { get; set; }
        public string cre_dt { get; set; }
        public string message_dt { get; set; }
        public int is_fresh { get; set; }
        public int is_warned { get; set; }
        public int is_moderator { get; set; }
        public int is_premium { get; set; }
        public int is_authenticated { get; set; }
        public int has_banned_word { get; set; }
        public object stamp { get; set; }
        public int quality_type { get; set; }
        public string user_icon { get; set; }
        public int supporter_rank { get; set; }
        public int is_creaters { get; set; }
        public string user_color { get; set; }
        public int is_premium_hidden { get; set; }
        public int is_official_hidden { get; set; }
        public int is_subs_badge_hidden { get; set; }
        public int is_subs_duration_hidden { get; set; }
        public object yell { get; set; }
        public object yell_type { get; set; }
        public object to_user { get; set; }
        public object capture { get; set; }
        public object item_data { get; set; }
        public string display_dt { get; set; }
        public int del_flg { get; set; }
        public List<object> badges { get; set; }
    }

    public class PunrecCommentJsonModel
    {
        public int type { get; set; }
        public string room { get; set; }
        public Data data { get; set; }
    }



}
