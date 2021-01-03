using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.json;
using ultra_comment_viewer.src.model.websocket;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.model.connection
{
    public abstract class ABConnectionCommentServer
    {
        protected ILiveRestClient ItsRest;

        protected ABLiveWebSocketClient ItsWebSocket;

        protected ABLiveInfoConverter ItsConverter;

        protected string ItsId;

        protected string ItsWebSocketUrl;

        public ABConnectionCommentServer(ABLiveWebSocketClient wb, ILiveRestClient rest, ABLiveInfoConverter converter)
        {
            this.ItsWebSocket = wb;
            this.ItsConverter = converter;
            this.ItsRest = rest;
        }

        public async IAsyncEnumerable<CommentViewModel> FetchCommentAsync(string id, DisconnectObserver observer)
        {

            this.ItsId = id;
            this.ItsWebSocketUrl = await this.ItsRest.GetWebSocketUrlAsync(id);
            
            await foreach(var response in this.ItsWebSocket.ReadCommentFromServerAsync(ItsWebSocketUrl, observer))
            {
                LiveStatus liveStatus = await CheckConnectionWebSocketAsync(response);
                Debug.WriteLine(response);
                switch (liveStatus)
                {
                    case LiveStatus.SUCCESS_CONNECT:
                        yield return this.ItsConverter.CovertToCommentViewModel(response);
                        break;
                    case LiveStatus.SKIP_THIS_COMMENT:
                        break;
                    case LiveStatus.EXIT:
                        yield break;           
                }
            }
        }

        public async Task DisconnectServerASync()
        {
            await this.ItsWebSocket.DisconnectServer(WebSocketCloseStatus.NormalClosure, Messages.CLOSE_SERVER_NORMAL);
        }
        protected abstract Task<LiveStatus> CheckConnectionWebSocketAsync(string reponse);
    }
}

   
