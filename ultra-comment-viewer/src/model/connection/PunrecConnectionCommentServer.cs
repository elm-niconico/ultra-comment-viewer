using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.http.openrec;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.openrec;
using ultra_comment_viewer.src.model.websocket.openrec;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.connection
{
    class PunrecConnectionCommentServer : ABConnectionCommentServer
    {

        public PunrecConnectionCommentServer(MainWindowViewModel model) : base(model)
        {
            ItsRest = new PunrectRestClient(model);
            ItsWebSocket = new PunrecWebSocketClient();
            ItsConverter = new PunrecCommentConverter();
        }

        protected async override Task<LiveStatus> CheckConnectionWebSocketAsync(string reponse)
        {
            if (reponse.StartsWith("42[\"message\",\"{\\\"type\\\":0"))
                return LiveStatus.SUCCESS_CONNECT;
            else if (reponse.StartsWith("42[\"message\",\"{\\\"type\\\":1,"))
                UpdateViewerCount(reponse);
            return LiveStatus.SKIP_THIS_COMMENT;

        }


        private void UpdateViewerCount(string response)
        {
            var json = Regex.Unescape(response.Replace("42[\"message\",\"", "").Replace("\"]", ""));
            var cnv = new ElmJsonConverter();
            var viewer = cnv.ConvertToJsonModel<LiveViewerJsonModel>(json);

            ItsMainModel.PunrecViewers = viewer.data.live_viewers + "人";
            ItsMainModel.PunrecTotalViewers = viewer.data.viewers + "人";
        }
    }
}
