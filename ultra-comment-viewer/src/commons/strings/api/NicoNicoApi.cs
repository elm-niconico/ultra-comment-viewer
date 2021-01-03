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
        public static string GetUserLiveHtml(string liveId) => $"https://live2.nicovideo.jp/watch/{liveId}";

        public static string GetSendMessageToCommentServer(string threadId) => "[{\"ping\": {\"content\": \"rs:0\"}}, {\"ping\": {\"content\": \"ps:0\"}}, {\"thread\": {\"thread\": \""+ threadId +"\", \"version\": \"20061206\", \"user_id\": \"guest\", \"res_from\": -150, \"with_global\": 1, \"scores\": 1, \"nicoru\": 0}}, {\"ping\": {\"content\": \"pf:0\"}}, {\"ping\": {\"content\": \"rf:0\"}}]";

        /* 視聴セッションサーバ(WebSocket)からスレッドIDとコメントサーバのURLを求めるためのSENDメッセージ */
        public const string SEND_SESSION_WEB_SOCKET = @"{""type"": ""startWatching"", ""data"": { ""stream"": { ""quality"": ""high"", ""protocol"": ""hls"", ""latency"": ""low"", ""chasePlay"": false }, ""room"": { ""protocol"": ""webSocket"", ""commentable"": true }, ""reconnect"": false},}";


        public const string TEST = @"{""type"":""startWatching"",""data"":{""stream"":{""quality"":""abr"",""protocol"":""hls"",""latency"":""low"",""chasePlay"":false},""room"":{""protocol"":""webSocket"",""commentable"":true},""reconnect"":false}}";

        public const string SEND_SESSION_WEB_SOCKET_AKASIC = @"{""type"": ""getAkashic"", ""data"": { ""chasePlay"" : false }}";

    }
}
