using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ultra_comment_viewer.src.model.json;
using ultra_comment_viewer.src.model.json.model;
using ultra_comment_viewer.src.model.websocket;
using ultra_comment_viewer.src.viemodel;
using System.Text.RegularExpressions;
using System.Net.WebSockets;
using ultra_comment_viewer.src.viewLogic.observer;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.commons.extends_mothod;
using System.Diagnostics;

namespace ultra_comment_viewer.src.model
{
    public class ConnectionCommentServer
    {
        private readonly Regex _responseEmpty = new Regex("^\\[\\]$");

        private readonly ABLiveWebSocketClient _webSocket;

        private readonly ILiveRestClient _rest;

        private readonly ABLiveInfoConverter _converter;

        private int _emptyResponseCount = 0;

        public ConnectionCommentServer(ABLiveWebSocketClient ws,
                                       ILiveRestClient rest,
                                       ABLiveInfoConverter converter                                
                                  )
        {
            this._webSocket = ws;
            this._rest = rest;
            this._converter = converter;
             
        }

        public async IAsyncEnumerable<CommentModel> FetchCommentAsync(string userId, DisconnectObserver observer)
        {
            var webSocketUrl = await _rest.GetWebSocketUrlAsync(userId);
            var restClient = new TwicasRestClient();

            await foreach(var response in _webSocket.ReadCommentFromServerAsync(webSocketUrl, observer))
            {
                Debug.WriteLine(response);
                if (this._responseEmpty.IsNotMatch(response))
                {
                    yield return _converter.CovertToCommentModelFromJson(response);
                    continue;  
                }

                //配信が終了してもWebSocketからの接続は切れないため、自分で切断する
                if (await restClient.GetUserIsNotOnLive(userId))
                {
                    await DisconnectServerASync();
                    yield break;
                   
                }

                //空のレスポンスが5分ほど続くと自動でWebSocketから切断されるため、再接続する必要がある
                if (++this._emptyResponseCount >= 50 && this._webSocket.IsNotOpenConnection())
                {
                    await ReConnectionServer(webSocketUrl);
                }
            }
           
        }

        private async Task ReConnectionServer(string webSocketUrl)
        {
            this._webSocket.DisposeInstance();
            await this._webSocket.OnStartConnectServer(webSocketUrl);
            this._emptyResponseCount = 0;
        }


        public async Task DisconnectServerASync()
        {
            await this._webSocket.DisconnectServer(
                WebSocketCloseStatus.NormalClosure,
                Mesasge.CLOSE_SERVER_NORMAL
                );
        }

     


    }
}
