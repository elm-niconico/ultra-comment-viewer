﻿using System;
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
using ultra_comment_viewer.src.model.connection;
using ultra_comment_viewer.src.model.json.converter;

namespace ultra_comment_viewer.src.model
{
    public class TwicasConnectionCommentServer : ABConnectionCommentServer
    {
        private readonly Regex _responseEmpty = new Regex("^\\[\\]$");


        private int _emptyResponseCount = 0;


       

        private readonly TwicasRestClientExtend _extendRest;

     
        
        public TwicasConnectionCommentServer() : base(wb: new TwicasWebSocketClient(),
                                                       rest: new TwicasRestClient(),
                                                       converter: new TwicasCommentConverter()
                                                       )
        {
            
            this._extendRest = new TwicasRestClientExtend(baseClient: (TwicasRestClient)this.ItsRest);

        }
      



        protected override async Task<bool> CheckConnectionWebSocketAsync(string reponse)
        {

            //空のレスポンスが5分ほど続くと自動でWebSocketから切断されるため、再接続する必要がある
            if (++this._emptyResponseCount >= 50 && this.ItsWebSocket.IsNotOpenConnection())
            {
                await ReConnectionServer(ItsWebSocketUrl);
            }

            //配信が終了してもWebSocketからの接続は切れないため、自分で切断する
            return await this._extendRest.GetUserIsNotOnLive(ItsId);
        }

        private async Task ReConnectionServer(string webSocketUrl)
        {
            this.ItsWebSocket.DisposeInstance();
            await this.ItsWebSocket.OnStartConnectServer(webSocketUrl);
            this._emptyResponseCount = 0;
        }
    }
}
