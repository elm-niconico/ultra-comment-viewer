﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src
{
    public class Messages
    {
        private Messages() { }

        public const string CLOSE_SERVER_NORMAL = "コメントサーバへの接続を終了します";

        public const string CLOSE_SERVER_MESSAGE_TO_BIG = "受信したメッセージが大きすぎます";

        public const string NOT_VALID_URL = "正しいURLではありません";

        public const string NOT_SUPPORT_WINDOW_TYPE = "このコメントはどの配信サイトにも属しません";
    }
}