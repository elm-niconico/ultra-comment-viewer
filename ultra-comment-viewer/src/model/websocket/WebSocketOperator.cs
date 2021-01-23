using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.commons.util
{
    public class WebSocketOperator
    {
        private ClientWebSocket _webSocketClient;

        
        
        private readonly ABDisconnectObserver _observer;


       

        public WebSocketOperator(ClientWebSocket client, ABDisconnectObserver observer)
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

        private bool IsOpen() => this._webSocketClient.NotNull() && this._webSocketClient.State == WebSocketState.Open; 

        public async IAsyncEnumerable<string> ReceiveResponseAsync(int interval, string message)
        {
            var buffer = new byte[10000];
            var dm = new LiveDateManager();

            await SendPing(message);
            var i = 0;



            while (IsOpen())
            {
               

                
                if (dm.HasTimePassed(interval))
                {
                    await SendPing(message);
                }
                
                var segment = new ArraySegment<byte>(buffer);


                Task<WebSocketReceiveResult> task = null;
                try
                {
       
                    task= this._webSocketClient.ReceiveAsync(segment, CancellationToken.None);
                }
                catch(Exception e)
                {

                }

                var response =  await FetchResponseMessage(task, interval, message, dm);
                if (response != null)
                {

                    if (response.MessageType == WebSocketMessageType.Close)
                    {
                        if (this._webSocketClient.State != WebSocketState.Closed)
                            await DisConnectServer(WebSocketCloseStatus.NormalClosure, Messages.CLOSE_SERVER_NORMAL);
                        yield break;
                    }

                    var res = Encoding.UTF8.GetString(buffer, 0, response.Count);
                   
                    yield return res;

                }
                else
                {
                    yield return null;
                }


            }
            
        }

        private async Task<WebSocketReceiveResult> FetchResponseMessage(Task<WebSocketReceiveResult> task,
                                                             int time,
                                                             string message,
                                                             LiveDateManager dm
                                                             )
        {
            if (task.IsNull()) return null;

            await Task.Run(async () =>
            {
                while (task.IsCompleted == false)
                {
                    if (dm.HasTimePassed(time))
                    {
                        await SendPing(message);
                    }

                }
            });
            

            return task.Result;
        }

        private async Task SendPing(string message)
        {
            var segement = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await _webSocketClient.SendAsync(segement, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
        }

        public async Task DisConnectServer(WebSocketCloseStatus status, string message)
        {
            var wc = this._webSocketClient;
            if(wc.IsNull() || wc.State == WebSocketState.Closed)
            {
                MessageBox.Show(Messages.NOT_CONNECT_SEVER);
                return;
            }

            await this._webSocketClient.CloseAsync(status, message, CancellationToken.None);
            DisposeInstance();

        }

        public void DisposeInstance()
        {
            this._webSocketClient.Dispose();
            this._observer.Notify();

        }

    }
}
