﻿using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ultra_comment_viewer.src.model.websocket
{
    public class TwicasWebSocketClient : ABLiveWebSocketClient
    {



        protected override async IAsyncEnumerable<string> ReceiveResponse()
        {
            var buffer = new byte[10000];

            while (IsOpen())
            {
                var segment = new ArraySegment<byte>(buffer);
                var response = await webSocketClient.ReceiveAsync(segment, CancellationToken.None);

                if (response.MessageType == WebSocketMessageType.Close)
                {
                    if(this.webSocketClient.State != WebSocketState.Closed)
                        await DisconnectServer(WebSocketCloseStatus.NormalClosure, Messages.CLOSE_SERVER_NORMAL);
                    yield break;
                }
                /*int EndOfMessageCount = await ReadToEndOfMessageAsync(response, buffer);
                //Messageが長すぎる場合サーバーから切断
                if (EndOfMessageCount < 0) yield break;
*/

                yield return Encoding.UTF8.GetString(buffer, 0, response.Count);


            }
        }

      

        protected override async Task<bool> StartConnectServer(string webSocketUrl)
        {
            if(webSocketClient.State != WebSocketState.Open)
                await webSocketClient.ConnectAsync(new Uri(webSocketUrl), CancellationToken.None);
            return IsOpen();
        }

        private bool IsOpen() => webSocketClient.State == WebSocketState.Open;

    }
}