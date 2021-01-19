using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.niconico
{
    public class Chat
    {
        public string thread { get; set; }
        public int no { get; set; }
        /* コメントの書き込み開始位置 1vpos = 10ミリ秒 */
        public int vpos { get; set; }
        public int date { get; set; }
        public int date_usec { get; set; }
        public string user_id { get; set; }

        //エモーションの場合 先頭に/emotionがセットされる
        public string content { get; set; }
        
        //プレミアムの場合
        //配信者か/ で始まるコメントの場合3が入れられる
        public int premium { get; set; }
        
        // 184ユーザーなら184がセットされる
        public string mail { get; set; }
        
        //匿名ユーザーなら1がセットされる
        public int anonymity { get; set; }
    
       
    }

    public class NicoCommentJsonModel
    {
        public Chat chat { get; set; }
    }
}
