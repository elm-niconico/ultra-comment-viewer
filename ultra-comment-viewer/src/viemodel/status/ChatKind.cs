using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.viemodel.status
{
    public enum ChatKind
    {
        CHAT,
        
        //アプリ側の通知
        SYSTEM,
        
        EMOTION,
        
        INFO,
        
        //広告コメント
        AD,

        //引用コメント
        QUOTE,

        EXIT

       
    }
}
