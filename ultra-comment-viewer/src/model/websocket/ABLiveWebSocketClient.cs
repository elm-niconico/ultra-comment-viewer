﻿using System;
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

        public ABLiveWebSocketClient()
        {
            var timeSpan = new TimeSpan(0,01,0);
            this.webSocketClient.Options.KeepAliveInterval = timeSpan;
        }

        protected WebSocketOperator ItsOpeator;

        private IDisconnectObserver _observer;

        public async IAsyncEnumerable<string> ReadCommentFromServerAsync(string webSocketUrl, IDisconnectObserver observer)
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



        public abstract Task DisconnectServer(WebSocketCloseStatus status, string message);

    
        public bool IsNotOpenConnection()
        {
            return this.webSocketClient.State != WebSocketState.Open;
        }

        public async Task<bool> OnStartConnectServer(string webSocketUrl)
        {
            await DisconnectBeforeLive();

            this.webSocketClient = new ClientWebSocket();
            this.ItsOpeator = new WebSocketOperator(this.webSocketClient, this._observer);

            return await this.ItsOpeator.StartConnectServer(webSocketUrl);
        }

        private async Task DisconnectBeforeLive()
        {
            if (this.webSocketClient ==  null || this.webSocketClient.State != WebSocketState.Open) return;

            var ope = new WebSocketOperator(this.webSocketClient, this._observer);
            await ope.DisConnectServer(WebSocketCloseStatus.NormalClosure, Messages.CLOSE_SERVER_NORMAL);
        }


        public void DisposeInstance()
        {
            this.ItsOpeator.DisposeInstance();
        }

        protected abstract IAsyncEnumerable<string> ReceiveResponse();    }
}
