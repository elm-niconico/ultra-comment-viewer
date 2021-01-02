using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.model.websocket;

namespace ultra_comment_viewer.src.model.http
{
    public class NicoNicoRestClient : ILiveRestClient
    {

        private Regex _quotRegex = new Regex("&quot;");

        public DataPropsJsonModel ItsDataProps { get; private set; }

        private LiveRoomJsonModel _model;

        public async Task<string> GetWebSocketUrlAsync(string liveId)
        {
            var html = await LoadUserLiveHtmlAsync(liveId);
            var parser = new NicoNicoHtmlDataPropsParser(html);
            var propsValue = parser.GetWebSocketUrl();

            var webSocket = new NicoNicoSessionWebSocketClient(propsValue);
            var roomJson  = webSocket.ExtractResponseMessage();

            var converter = new NicoNicoJsonConverter();
            this._model = converter.ConverToLiveRoomJsonModel(roomJson);

            return this._model.data.messageServer.uri;
        }




        private async Task<string> LoadUserLiveHtmlAsync(string liveId)
        {
            return await ElmHttpClientUtil.WrapBaseWithHeaderAsync(api: NicoNicoApi.GetUserLiveHtml(liveId),
                                                                   method: HttpMethod.Get,
                                                                   headerKey: "Cookie",
                                                                   headerValue: "player_version=leo"
                );
        }
    }
}
