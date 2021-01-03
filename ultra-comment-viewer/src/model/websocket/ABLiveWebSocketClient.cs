using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.util;
using ultra_comment_viewer.src.viewLogic;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.model.websocket
{
    public abstract class  ABLiveWebSocketClient
    {

        protected ClientWebSocket webSocketClient = new ClientWebSocket();

        protected WebSocketOperator ItsOpeator;

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
            await this.ItsOpeator.DisConnectServer(status, message);
        }

    
        public bool IsNotOpenConnection()
        {
            return this.webSocketClient.State != WebSocketState.Open;
        }

        public async Task<bool> OnStartConnectServer(string webSocketUrl)
        {
            this.webSocketClient = new ClientWebSocket();
            this.ItsOpeator = new WebSocketOperator(this.webSocketClient, this._observer);

            return await this.ItsOpeator.StartConnectServer(webSocketUrl);
        }

        public void DisposeInstance()
        {
            this.ItsOpeator.DisposeInstance();
        }

        protected abstract IAsyncEnumerable<string> ReceiveResponse();    }
}
