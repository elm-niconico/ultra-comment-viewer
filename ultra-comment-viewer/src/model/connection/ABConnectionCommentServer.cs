using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.commons.extends_mothod;
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

        protected MainWindowViewModel ItsMainModel;

        public ABConnectionCommentServer (MainWindowViewModel model)
        {

            this.ItsMainModel = model;
        }

        public async IAsyncEnumerable<CommentViewModel> FetchCommentAsync(string id, IDisconnectObserver observer)
        {

            this.ItsId = id;
            this.ItsWebSocketUrl = await this.ItsRest.GetWebSocketUrlAsync(id);

            if (String.IsNullOrEmpty(this.ItsWebSocketUrl))
            {
                MessageBox.Show(Messages.CLOSE_SERVER_MESSAGE_CONNECTION_ERROR);
                yield break;
            }

            await foreach(var response in this.ItsWebSocket.ReadCommentFromServerAsync(ItsWebSocketUrl, observer))
            {
                if (response.IsNull())
                {
                    yield return CommentViewModel.BuildDisconnectModel();
                    continue;
                }

                LiveStatus liveStatus = await CheckConnectionWebSocketAsync(response);
 
                switch (liveStatus)
                {
                    case LiveStatus.SUCCESS_CONNECT:
                        yield return await this.ItsConverter.CovertToCommentViewModel(response);
                        break;
                    case LiveStatus.SKIP_THIS_COMMENT:
                        break;
                    case LiveStatus.EXIT:
                        await DisconnectServerASync();
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

   
