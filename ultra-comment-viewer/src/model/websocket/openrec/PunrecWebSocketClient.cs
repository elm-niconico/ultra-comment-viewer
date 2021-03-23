using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.commons.extends_mothod;

namespace ultra_comment_viewer.src.model.websocket.openrec
{
    public class PunrecWebSocketClient : ABLiveWebSocketClient
    {

        public PunrecWebSocketClient() : base(new TimeSpan(0, 0, 10)) { }
        public async override Task DisconnectServer(WebSocketCloseStatus status, string message) 
        {
            if (ItsOpeator.NotNull())
            {
                await ItsOpeator.DisConnectServer(WebSocketCloseStatus.NormalClosure, Messages.CLOSE_SERVER_NORMAL);
            }
        }

        protected async override IAsyncEnumerable<string> ReceiveResponse()
        {
            await foreach (var response in this.ItsOpeator.ReceiveResponseOrNullAsync(interval:10, message:"2"))
            {
                yield return response;
            }

        }

        

    }
}
