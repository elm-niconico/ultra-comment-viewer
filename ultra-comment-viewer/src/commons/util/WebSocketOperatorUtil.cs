using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ultra_comment_viewer.src.commons.util
{
    public class WebSocketOperatorUtil
    {
        private WebSocketOperatorUtil() { }

        public static async Task<bool> StartConnectServer(ClientWebSocket webSocketClient, string webSocketUrl)
        {
            if (webSocketClient.State != WebSocketState.Open)
         
                await webSocketClient.ConnectAsync(new Uri(webSocketUrl), CancellationToken.None);
            return webSocketClient.State == WebSocketState.Open;
        }
    }
}
