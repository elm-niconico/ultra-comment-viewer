using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.niconico
{
    public class ServerTimeJsonModel
    {
        public Thread thread { get; set; }
    }


    public class Thread
    {
        public int resultcode { get; set; }
        public string thread { get; set; }
        public int revision { get; set; }
        public int server_time { get; set; }
        public int last_res { get; set; }
        public string ticket { get; set; }
    }
}
