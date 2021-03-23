using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.commons.util;

namespace ultra_comment_viewer.src.model.websocket
{
    public class TwicasWebSocketClient : ABLiveWebSocketClient
    {

        public TwicasWebSocketClient(): base(new TimeSpan(0, 0, 10)) { }

        public override async Task DisconnectServer(WebSocketCloseStatus status, string message)
        {
            if (this.ItsOpeator.NotNull())
            {
                
                await this.ItsOpeator.DisConnectServer(status, message);

            }
        }

        protected override async IAsyncEnumerable<string> ReceiveResponse()
        {
            await foreach(var response in this.ItsOpeator.ReceiveResponseOrNullAsync(interval:10,message:""))
            {
                yield return response;
            }
        }
    }
}
