using System;
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

        public const string CLOSE_SERVER_MESSAGE_CONNECTION_ERROR = "WebSocket接続開始処理中にエラーが発生しました";

        public const string FAILD_CONNECT_BOUYOMI_CHAN = "棒読みちゃんとの接続に失敗しました";
        
        public const string FAILD_START_BOUYOMI = "棒読みちゃんの軌道に失敗しました";
        
        public const string CAN_NOT_EXTRACT_COMMNET = "このコメントは取得できませんでした";
        
        public const string NOT_VALID_LIVE_URL = "正しいURLを入力してください";
    }
}
