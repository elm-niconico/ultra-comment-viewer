
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.json.creator;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.connect_onother_app
{
    public class ComeGeneWebSocketClient
    {
        private ClientWebSocket _ws = new ClientWebSocket();
        
        private ComeGeneWebSocketClient()
        {
            
        }


        public static async Task<ComeGeneWebSocketClient> BuildAsync(string url)
        {
            var my = new ComeGeneWebSocketClient();
            await my._ws.ConnectAsync(new Uri(url), CancellationToken.None);
            return my;
        }

        public async Task SendMessage(CommentViewModel model)
        {
            var jsonCreator = new JsonCreator();
            var commentInfo = jsonCreator.CrateCommentJson(model);
            var segment = new ArraySegment<byte>(Encoding.UTF8.GetBytes(commentInfo));

            await this._ws.SendAsync(segment,
                                           WebSocketMessageType.Text,
                                           endOfMessage: true,
                                           CancellationToken.None);
        }


        

    }
}
