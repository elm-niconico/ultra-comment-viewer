using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.commons.util;
using ultra_comment_viewer.src.model.connection;
using ultra_comment_viewer.src.model.http;

namespace ultra_comment_viewer.src.model.websocket.niconico
{
    class NicoWebSocketClient : ABLiveWebSocketClient
    {
        private readonly NicoRestClient _rest;

        public NicoWebSocketClient(NicoRestClient client)
        {
            this._rest = client;
            this.webSocketClient.Options.SetRequestHeader("Sec-WebSocket-Extensions", "permessage-deflate; client_max_window_bits");
            this.webSocketClient.Options.SetRequestHeader("Sec-WebSocket-Protocol", "msg.nicovideo.jp#json");
        }



        protected async override IAsyncEnumerable<string> ReceiveResponse()
        {
  
            await SendMessageToCommentServerAsync();
            var dateManager = new LiveDateManager();
            await foreach(var response in this.ItsOpeator.ReceiveResponseAsync())
            {
                SendPing(dateManager);
                yield return response;

            }
        }

        private void SendPing(LiveDateManager manager)
        {
          
            if (manager.HasTimePassed(60))
            {
                var segment = new ArraySegment<byte>(Encoding.UTF8.GetBytes(""));

                this.webSocketClient.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private long ExtractCurrentTime()
        {
            var time = DateTime.Now;
            return (time.Day * 360 * 24) + (time.Hour * 360) + (time.Minute * 60) + (time.Second);
        }

        private async Task SendMessageToCommentServerAsync()
        {
            var liveRoom = NicoNicoLiveRoomInfo.GetInstance();

            var sendMessage = NicoApi.GET_SEND_MESSAGE_TO_COMMENT_SERVER(liveRoom.GetThreadId());
            var segment = new ArraySegment<byte>(Encoding.UTF8.GetBytes(sendMessage));

            await this.webSocketClient.SendAsync(segment,
                                           WebSocketMessageType.Text,
                                           endOfMessage: true,
                                           CancellationToken.None);
        }

        public override async Task DisconnectServer(WebSocketCloseStatus status, string message)
        {

            if (this.ItsOpeator.NotNull())
            {
                this._rest.DisConnectSessionServer();
                await this.ItsOpeator.DisConnectServer(status, message);

            }
               
        }
    }
}
