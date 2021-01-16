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
using ultra_comment_viewer.src.model.observer.niconico;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.model.websocket;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.http
{
    public class NicoRestClient : ILiveRestClient
    {


        private readonly NicoLiveVisiter _visiter;

        private NicoNicoSessionConnector _connector;

        private MainWindowViewModel _model;
        public NicoRestClient()
        {

        }

        public NicoRestClient(NicoLiveVisiter visiter, MainWindowViewModel model)
        {
            this._visiter = visiter;
            this._model = model;
        }

        public async Task<string> GetWebSocketUrlAsync(string liveId)
        {
            var html = await LoadUserLiveHtmlAsync(liveId);
            var parser = new NicoNicoHtmlDataPropsParser(html);

            _model.NicoLiveTitle = new NicoLiveHtmlParser(html).Title;

            var webSocketUrl = parser.GetWebSocketUrl();
            // 限定配信は視聴セッションのWebSocektUrlが空文字になる
            if (String.IsNullOrEmpty(webSocketUrl)) return null;

            _connector = new NicoNicoSessionConnector(webSocketUrl, this._visiter);
           
            return _connector.FetchCommentServerUrl();
        }
        
        public void DisConnectSessionServer()
        {
            this._connector.DisconnectSessionServer();
        }



        private async Task<string> LoadUserLiveHtmlAsync(string liveId)
        {
            return await ElmHttpClientUtil.WrapBaseWithHeaderAsync(api: NicoApi.GET_USER_LIVE_ID(liveId),
                                                                   method: HttpMethod.Get,
                                                                   headerKey: "Cookie",
                                                                   headerValue: "player_version=leo");
        }


        public async Task<string> ExtractUseNickNameXmlAsync(string userId) 
           => await ElmHttpClientUtil.WrapGetAsync(NicoApi.GET_USER_NICKNAME_API(userId));

        public async Task<string> ExtractUserIconAsync(int userId)
            => await ElmHttpClientUtil.WrapGetAsync(NicoApi.GET_USER_ICON(userId));

        public async Task<string> LoadUserMyPageHtmlAsync(int userId)
            => await ElmHttpClientUtil.WrapGetAsync(NicoApi.GET_USER_MY_PAGE(userId));

        public async Task<string> GetUserLiveHtmlAsync(string id)
           => await ElmHttpClientUtil.WrapGetAsync(NicoApi.GET_LIVE_HTML(id));

        public async Task<string> GetUserMyList(string userId)
            => await ElmHttpClientUtil.WrapGetAsync(NicoApi.GET_USER_MYLIST(userId));

        public async Task<bool> IsExsitsUserIcon(string userId)
        {

            if (!int.TryParse(userId, out int id)) return false;

            var reponse = await ElmHttpClientUtil.WrapGetResponseMessageAsync(NicoApi.GET_USER_ICON(id));

            return reponse.IsSuccessStatusCode;
        }
    }
}
