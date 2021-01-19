using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.util;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;
using ultra_comment_viewer.src.model.observer.niconico;
using ultra_comment_viewer.src.model.websocket;

namespace ultra_comment_viewer.src.model.connection
{
    public class NicoNicoSessionConnector
    {
        public DataPropsJsonModel ItsDataProps { get; private set; }

        private readonly NicoSessionWebSocketClient _client;

        public NicoNicoSessionConnector(string webSocketUrl, NicoLiveVisiter visitor)
        {
            _client = new NicoSessionWebSocketClient(webSocketUrl, visitor);
        }

        public string FetchCommentServerUrl()
        {
            
            var roomJson = _client.ExtractResponseMessage();

            if (String.IsNullOrEmpty(roomJson)) return null;

            var converter = new ElmJsonConverter();
            var model = converter.ConverToLiveRoomJsonModel(roomJson);

            NicoNicoLiveRoomInfo.NewCreateRoomInfo(model);

            return model.data.messageServer.uri;
        }

        public void DisconnectSessionServer()
        {
            _client.Disconnect();
        }
    }
}
