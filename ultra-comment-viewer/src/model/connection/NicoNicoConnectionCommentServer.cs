using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.websocket.niconico;

namespace ultra_comment_viewer.src.model.connection
{
   

    public class NicoNicoConnectionCommentServer : ABConnectionCommentServer
    {
        private readonly Regex commentRegex = new Regex("^{\"chat\":.+$");

        private readonly Regex _servertInfoResponseRegex = new Regex("^{\"thread\":.+$");

        private readonly Regex _exitLiveRegex = new Regex("");

        private long _lastRes = 0;

        private bool _hasNotLastRes = true;

        private bool _didOverPasLog = false;


        public NicoNicoConnectionCommentServer() :
            base(
                    wb: new NicoNicoWebSocketClient(),
                    rest: new NicoNicoRestClient(),
                    converter: new NicoNicoCommentConverter()
                )
        {

        }


        protected async override Task<LiveStatus> CheckConnectionWebSocketAsync(string response)
        {
            if (_hasNotLastRes && this._servertInfoResponseRegex.IsMatch(response))
            {
                ExtractServerTime(response);
            }
            if (commentRegex.IsNotMatch(response) ) return LiveStatus.SKIP_THIS_COMMENT;

            //if (_exitLiveRegex.IsMatch(response)) return LiveStatus.EXIT;

            if (this._didOverPasLog) return LiveStatus.SUCCESS_CONNECT;

            

            return IsPastComment(response)? LiveStatus.SKIP_THIS_COMMENT :  LiveStatus.SUCCESS_CONNECT;
        }


        private bool IsPastComment(string response)
        {
            var converter = new NicoNicoJsonConverter();
            var model = converter.ConverToCommentJsonModel(response);

            return model.chat.no < this._lastRes;

        }

        private void ExtractServerTime(string response)
        {
            var converter = new NicoNicoJsonConverter();
            var model = converter.ConvertToServerJsonModel(response);
            this._lastRes = model.thread.last_res;
            _hasNotLastRes = false;
        }
    }
}
