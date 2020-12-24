using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model
{
    public class Movie
    {
        public int id { get; set; }
        public bool is_on_live { get; set; }
    }

    public class TwicasUserInfo
    {
        public int update_interval_sec { get; set; }
        public Movie movie { get; set; }
    }


}
