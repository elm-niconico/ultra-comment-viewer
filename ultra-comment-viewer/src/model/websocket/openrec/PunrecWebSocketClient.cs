using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons;

namespace ultra_comment_viewer.src.model.websocket.openrec
{
    public class PunrecWebSocketClient : ABLiveWebSocketClient
    {
        public override Task DisconnectServer(WebSocketCloseStatus status, string message)
        {
            throw new NotImplementedException();
        }

        protected async override IAsyncEnumerable<string> ReceiveResponse()
        {
            var dateManager = new LiveDateManager();
            await foreach (var response in this.ItsOpeator.ReceiveResponseAsync())
            {
                await SendPing(dateManager);
                yield return response;

            }

        }

        private async Task SendPing(LiveDateManager dateManager)
        {
            if (dateManager.HasTimePassed(10))
            {
                var segement = new ArraySegment<byte>(Encoding.UTF8.GetBytes("2"));
                await ItswebSocketClient.SendAsync(segement, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
            }
        }

    }
}
