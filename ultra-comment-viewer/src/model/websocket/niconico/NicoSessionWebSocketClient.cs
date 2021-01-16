using System;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.commons.util;
using ultra_comment_viewer.src.model.observer.niconico;
using WebSocketSharp;
using WebSocketSharp.NetCore;

namespace ultra_comment_viewer.src.model.websocket
{
    public class NicoSessionWebSocketClient
    {
        private readonly WebSocket _webSocketClient;

        private string response = null;

        private readonly Regex _roomRegex = new Regex(@"^{""type"":""room"",.+$");

        private readonly Regex _dataRegex = new Regex(@"^{""type"":""statistics"".+$");

        private readonly Regex _pingRegex = new Regex(@"^{""type"":""ping"".+$");

        private const string PONG = "{\"type\":\"pong\"}";

        private const string KEEP_SEAT = "{\"type\":\"keepSeat\"}";



        public NicoSessionWebSocketClient(string webSocketUrl, NicoLiveVisiter visitor)
        {
            try
            {
                
                this._webSocketClient = new WebSocket(webSocketUrl);
                this._webSocketClient.OnMessage += (sender, e) =>
                {
                    
                    var message = e.Data;
                    if (_roomRegex.IsMatch(message))
                    {
                        this.response = message;
                        return;
                    }
                        

                    if (_dataRegex.IsMatch(message))
                    {
                        visitor.NotifyUpdateLiveStatus(message);
                        return;
                    }


                    if (_pingRegex.IsMatch(message))
                    {
                        SendPong();
                    }

                };
            }
            catch (Exception)
            {

            }
             
        }

        private void SendPong()
        {
            _webSocketClient.Send(PONG);
            _webSocketClient.Send(KEEP_SEAT);
        }

        public string ExtractResponseMessage()
        {
            try
            {

                this._webSocketClient.Connect();
               
                SendMessage();
            
                while (true)
                {
                    if (this.response != null) break;
                }    
                
                return response;
            }
            catch
            {
                return null;
            }
        }

        private void SendMessage()
        {
            this._webSocketClient.Send(NicoApi.TEST); 
        }

        public void Disconnect()
        {
            this._webSocketClient.Close();
        }
    }
}
