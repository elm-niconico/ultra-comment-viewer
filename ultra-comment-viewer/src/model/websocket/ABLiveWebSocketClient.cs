using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.viewLogic;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.model.websocket
{
    public abstract class  ABLiveWebSocketClient
    {

        protected ClientWebSocket webSocketClient;



        private DisconnectObserver _observer;

        public async IAsyncEnumerable<string> ReadCommentFromServerAsync(string webSocketUrl, DisconnectObserver observer)
        {
            if (this._observer == null) this._observer = observer;

            if(await OnStartConnectServer(webSocketUrl))
            {
                await foreach(var comment in ReceiveResponse())
                {

                    yield return comment;
                }
            }
        }



        public async Task DisconnectServer(WebSocketCloseStatus status, string message)
        {
            await webSocketClient.CloseAsync(status, message, CancellationToken.None);
            DisposeInstance();
        }

        public void DisposeInstance()
        {
            webSocketClient.Dispose();
            this.webSocketClient = null;
            this._observer.Notify();

        }

        public bool IsNotOpenConnection()
        {
            return this.webSocketClient.State != WebSocketState.Open;
        }

        public async Task<bool> OnStartConnectServer(string url)
        {
            this.webSocketClient = new ClientWebSocket();
            return await StartConnectServer(url);
        }

        protected abstract Task<bool> StartConnectServer(string webSocketUrl);

        protected abstract IAsyncEnumerable<string> ReceiveResponse();    }
}
