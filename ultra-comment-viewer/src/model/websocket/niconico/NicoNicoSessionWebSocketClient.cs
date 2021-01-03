using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.commons.util;
using WebSocketSharp;

namespace ultra_comment_viewer.src.model.websocket
{
    public class NicoNicoSessionWebSocketClient
    {
        private readonly WebSocket _webSocketClient;

        private string response = null;

        private readonly Regex _roomRegex = new Regex(@"^{""type"":""room"",.+$");

        public NicoNicoSessionWebSocketClient(string webSocketUrl)
        {
            this._webSocketClient = new WebSocket(webSocketUrl);
            this._webSocketClient.OnMessage += (sender, e) =>
            {
                if(_roomRegex.IsMatch(e.Data))
                    this.response = e.Data;
              
            };
        }

        public string ExtractResponseMessage()
        {
            this._webSocketClient.Connect();

           
            SendMessage();


            while (true)
            {
                if (this.response != null) break;
            }

            this._webSocketClient.Close();
            return this.response;
           
        }

        private void SendMessage()
        {

            this._webSocketClient.Send(NicoNicoApi.TEST);
           
        }
    }
}
