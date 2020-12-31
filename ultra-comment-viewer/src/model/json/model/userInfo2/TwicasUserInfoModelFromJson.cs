using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.userInfo2
{
    public class User
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

    public class TwicasUserInfoDetailFromJson

    {
        public User user { get; set; }
        public int supporter_count { get; set; }
        public int supporting_count { get; set; }
    }


}
