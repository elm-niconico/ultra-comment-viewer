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
            if (commentRegex.IsNotMatch(response)) return LiveStatus.SKIP_THIS_COMMENT;

            return LiveStatus.SUCCESS_CONNECT;
        }
    }
}
