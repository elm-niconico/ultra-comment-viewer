using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.commons.strings.api
{
    public class NicoNicoApi
    {
        private NicoNicoApi() { }

        /* ユーザーのライブページのURLを取得する
         * このURLはHTMLからWebSocketのURLを取得するために使用する*/
        public static string GET_USER_LIVE_ID(string liveId) => $"https://live2.nicovideo.jp/watch/{liveId}";

        // コメントサーバに送るためのメッセージ
        public static string GET_SEND_MESSAGE_TO_COMMENT_SERVER(string threadId) => "[{\"ping\": {\"content\": \"rs:0\"}}, {\"ping\": {\"content\": \"ps:0\"}}, {\"thread\": {\"thread\": \""+ threadId +"\", \"version\": \"20061206\", \"user_id\": \"guest\", \"res_from\": -150, \"with_global\": 1, \"scores\": 1, \"nicoru\": 0}}, {\"ping\": {\"content\": \"pf:0\"}}, {\"ping\": {\"content\": \"rf:0\"}}]";

        // ユーザーIDからユーザー名を取得
        public static string GET_USER_NICKNAME_API(string userId) => $"http://seiga.nicovideo.jp/api/user/info?id={userId}";

        // ユーザーアイコン取得
        public static string GET_USER_ICON(int userId) => $@"http://usericon.nimg.jp/usericon/{userId / 10000}/{userId}.jpg";

        //ユーザーのマイページ
        public static string GET_USER_MY_PAGE(int userId) => $"https://www.nicovideo.jp/user/{userId}/mylist?ref=pc_mypage_menu";

        public static string GET_LIVE_HTML(string id) => $"https://live2.nicovideo.jp/watch/{id}";


        /* 視聴セッションサーバ(WebSocket)からスレッドIDとコメントサーバのURLを求めるためのSENDメッセージ */
        public const string SEND_SESSION_WEB_SOCKET = @"{""type"": ""startWatching"", ""data"": { ""stream"": { ""quality"": ""high"", ""protocol"": ""hls"", ""latency"": ""low"", ""chasePlay"": false }, ""room"": { ""protocol"": ""webSocket"", ""commentable"": true }, ""reconnect"": false},}";

        public const string TEST = @"{""type"":""startWatching"",""data"":{""stream"":{""quality"":""abr"",""protocol"":""hls"",""latency"":""low"",""chasePlay"":false},""room"":{""protocol"":""webSocket"",""commentable"":true},""reconnect"":false}}";

        public const string SEND_SESSION_WEB_SOCKET_AKASIC = @"{""type"": ""getAkashic"", ""data"": { ""chasePlay"" : false }}";

        
       
    }
}
