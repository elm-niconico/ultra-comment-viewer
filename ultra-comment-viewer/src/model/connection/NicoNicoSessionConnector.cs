using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;
using ultra_comment_viewer.src.model.websocket;

namespace ultra_comment_viewer.src.model.connection
{
    public class NicoNicoSessionConnector
    {
        public DataPropsJsonModel ItsDataProps { get; private set; }

        private LiveRoomJsonModel _model;

        public string FetchCommentServerUrl(string webSocketUrl)
        {
            var webSocket = new NicoNicoSessionWebSocketClient(webSocketUrl);
            var roomJson = webSocket.ExtractResponseMessage();

            var converter = new NicoNicoJsonConverter();
            this._model = converter.ConverToLiveRoomJsonModel(roomJson);

            return this._model.data.messageServer.uri;
        }
    }
}
