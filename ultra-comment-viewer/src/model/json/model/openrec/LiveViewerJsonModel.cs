using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.openrec
{
    /**
     * ライブの視聴者数を表すモデル
     * 42[message:type1]で送られる
     */
    public class LiveViewerJsonModel
    {
        public int type { get; set; }
        public string room { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string movie_id { get; set; }
        public int viewers { get; set; }
        public int live_viewers { get; set; }
    }


}
