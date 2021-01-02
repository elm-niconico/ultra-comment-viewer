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

        /* 視聴セッションサーバ(WebSocket)からスレッドIDとコメントサーバのURLを求めるためのSENDメッセージ */
        public const string SEND_SESSION_WEB_SOCKET = @"{""type"": ""startWatching"", ""data"": { ""stream"": { ""quality"": ""high"", ""protocol"": ""hls"", ""latency"": ""low"", ""chasePlay"": false }, ""room"": { ""protocol"": ""webSocket"", ""commentable"": true }, ""reconnect"": false},}";


        public const string TEST = @"{""type"":""startWatching"",""data"":{""stream"":{""quality"":""abr"",""protocol"":""hls"",""latency"":""low"",""chasePlay"":false},""room"":{""protocol"":""webSocket"",""commentable"":true},""reconnect"":false}}";

        public const string SEND_SESSION_WEB_SOCKET_AKASIC = @"{""type"": ""getAkashic"", ""data"": { ""chasePlay"" : false }}";

    }
}
