using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.userInfo
{
    public class Movie
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string last_owner_comment { get; set; }
        public string category { get; set; }
        public string link { get; set; }
        public bool is_live { get; set; }
        public bool is_recorded { get; set; }
        public int comment_count { get; set; }
        public string large_thumbnail { get; set; }
        public string small_thumbnail { get; set; }
        public string country { get; set; }
        public int duration { get; set; }
        public int created { get; set; }
        public bool is_collabo { get; set; }
        public bool is_protected { get; set; }
        public int max_view_count { get; set; }
        public int current_view_count { get; set; }
        public int total_view_count { get; set; }
        public string hls_url { get; set; }
    }

    public class Broadcaster
    {
        public string id { get; set; }
        public string screen_id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string profile { get; set; }
        public int level { get; set; }
        public string last_movie_id { get; set; }
        public bool is_live { get; set; }
        public int supporter_count { get; set; }
        public int supporting_count { get; set; }
        public int created { get; set; }
    }

    public class TwicasUserInfoDetailModelFromJson
    {
        public Movie movie { get; set; }
        public Broadcaster broadcaster { get; set; }
        public List<string> tags { get; set; }
    }
}
