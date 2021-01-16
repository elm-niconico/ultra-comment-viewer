using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.niconico.user_page
{
    public class NicoLiveDataJsonModel
    {
        public string type { get; set; }
        public Data data { get; set; }
    }


    public class Data
    {
        public int viewers { get; set; }
        public int comments { get; set; }
        public int adPoints { get; set; }
        public int giftPoints { get; set; }
    }

  

  
}
