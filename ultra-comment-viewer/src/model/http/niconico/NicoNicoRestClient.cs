using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.model.connection;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.model.websocket;

namespace ultra_comment_viewer.src.model.http
{
    public class NicoNicoRestClient : ILiveRestClient
    {


        public async Task<string> GetWebSocketUrlAsync(string liveId)
        {
            var html = await LoadUserLiveHtmlAsync(liveId);
            var parser = new NicoNicoHtmlDataPropsParser(html);
            
            var webSocketUrl = parser.GetWebSocketUrl();

            var connector = new NicoNicoSessionConnector();
            return connector.FetchCommentServerUrl(webSocketUrl);
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
