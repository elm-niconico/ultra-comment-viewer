using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.util;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;
using ultra_comment_viewer.src.model.websocket;

namespace ultra_comment_viewer.src.model.connection
{
    public class NicoNicoSessionConnector
    {
        public DataPropsJsonModel ItsDataProps { get; private set; }


        public string FetchCommentServerUrl(string webSocketUrl)
        {
            var webSocket = new NicoNicoSessionWebSocketClient(webSocketUrl);
            var roomJson = webSocket.ExtractResponseMessage();

            var converter = new NicoNicoJsonConverter();
            var model = converter.ConverToLiveRoomJsonModel(roomJson);

            NicoNicoLiveRoomInfo.NewCreateRoomInfo(model);

            return model.data.messageServer.uri;
        }
    }
}
