using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.util;

namespace ultra_comment_viewer.src.model.websocket
{
    public class TwicasWebSocketClient : ABLiveWebSocketClient
    {

        protected override async IAsyncEnumerable<string> ReceiveResponse()
        {
            await foreach(var response in this.ItsOpeator.ReceiveResponseAsync())
            {
                yield return response;
            }
        }
    }
}
