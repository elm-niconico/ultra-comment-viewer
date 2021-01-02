using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.niconico
{
    public class MessageServer
    {
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class Data
    {
        public string name { get; set; }
        public MessageServer messageServer { get; set; }
        public string threadId { get; set; }
        public bool isFirst { get; set; }
        public string waybackkey { get; set; }
    }

    public class LiveRoomJsonModel
    {
        public string type { get; set; }
        public Data data { get; set; }
    }



}
