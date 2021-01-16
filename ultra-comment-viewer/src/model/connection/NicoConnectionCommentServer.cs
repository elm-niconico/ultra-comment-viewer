using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.observer.niconico;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.model.websocket.niconico;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.connection
{


    public class NicoConnectionCommentServer : ABConnectionCommentServer
    {
        private readonly Regex commentRegex = new Regex("^{\"chat\":.+$");

        private readonly Regex _exitLiveRegex = new Regex("{\\\"chat\\\":{\\\"thread\\\".+\\\"content\\\":\\\"/disconnect\\\"}}");
        
        private bool _isPastChat = true;

        private byte _pingStack = 0;

        public NicoConnectionCommentServer(MainWindowViewModel model) : base(model)
        {

            ItsRest = new NicoRestClient(new NicoLiveVisiter(this), model);
            ItsConverter = new NicoCommentConverter();
            ItsWebSocket = new NicoWebSocketClient((NicoRestClient)ItsRest);
        }

        public void UpdateToLiveInfo(string json)
        {
            var parser = new NicoJsonConverter();
            var data = parser.ConvertToDataJsonModel(json);

            ItsMainModel.NicoViewer = data.data.viewers.ToString();
            ItsMainModel.NicoCommentCount = data.data.comments.ToString();
            ItsMainModel.NicoGiftPoint = data.data.giftPoints.ToString();
            ItsMainModel.NicoAdPoint = data.data.adPoints.ToString();
        }


        protected override Task<LiveStatus> CheckConnectionWebSocketAsync(string response)
        {
            if (_isPastChat)
            {
                CheckPastChat(response);
                return Task.FromResult(LiveStatus.SKIP_THIS_COMMENT);
            }
            if (IsNotUserChat(response)) return Task.FromResult(LiveStatus.SKIP_THIS_COMMENT);

            if (_exitLiveRegex.IsMatch(response))
            {
                if(IsExitComment(response))
                    return Task.FromResult(LiveStatus.EXIT);
            }

            return Task.FromResult(LiveStatus.SUCCESS_CONNECT);

            
        }

        private bool IsExitComment(string response)
        {
            var json = new NicoJsonConverter();
            var model = json.ConverToCommentJsonModel(response);
            return model.chat.premium == 2;
        }

        private bool IsNotUserChat(string response)
            => !response.StartsWith("{\"chat\":", StringComparison.Ordinal);


        private void CheckPastChat(string response)
        {
            if (response.StartsWith("{\"ping\":"))
                this._pingStack++;

            if(_pingStack >= 4)
                this._isPastChat = false;
        }

   




    }
}
