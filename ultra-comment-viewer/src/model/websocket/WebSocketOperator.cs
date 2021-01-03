using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.commons.util
{
    public class WebSocketOperator
    {
        private ClientWebSocket _webSocketClient;

        private readonly DisconnectObserver _observer;
       

        public WebSocketOperator(ClientWebSocket client, DisconnectObserver observer)
        {
            this._webSocketClient = client;
            this._observer = observer;
        }

        public async Task<bool> StartConnectServer(string webSocketUrl)
        {
            if (this._webSocketClient.State != WebSocketState.Open)
         
                await this._webSocketClient.ConnectAsync(new Uri(webSocketUrl), CancellationToken.None);
            return IsOpen();
        }

        private bool IsOpen() => this._webSocketClient.State == WebSocketState.Open; 

        public async IAsyncEnumerable<string> ReceiveResponseAsync()
        {
            var buffer = new byte[10000];

            while (IsOpen())
            {
                var segment = new ArraySegment<byte>(buffer);
                var response = await this._webSocketClient.ReceiveAsync(segment, CancellationToken.None);

                if (response.MessageType == WebSocketMessageType.Close)
                {
                    if (this._webSocketClient.State != WebSocketState.Closed)
                        await DisConnectServer(WebSocketCloseStatus.NormalClosure, Messages.CLOSE_SERVER_NORMAL);
                    yield break;
                }
                /*int EndOfMessageCount = await ReadToEndOfMessageAsync(response, buffer);
                //Messageが長すぎる場合サーバーから切断
                if (EndOfMessageCount < 0) yield break;
*/

                yield return Encoding.UTF8.GetString(buffer, 0, response.Count);


            }
        }

        public async Task DisConnectServer(WebSocketCloseStatus status, string message)
        {
            await this._webSocketClient.CloseAsync(status, message, CancellationToken.None);
            DisposeInstance();
        }

        public void DisposeInstance()
        {
            this._webSocketClient.Dispose();
            this._webSocketClient = null;
            this._observer.Notify();

        }

    }
}
