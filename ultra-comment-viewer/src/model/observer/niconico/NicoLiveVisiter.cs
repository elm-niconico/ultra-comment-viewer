using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.model.connection;
using ultra_comment_viewer.src.model.http;

namespace ultra_comment_viewer.src.model.observer.niconico
{
    public class NicoLiveVisiter
    {
        private NicoConnectionCommentServer _server;

        public NicoLiveVisiter(NicoConnectionCommentServer server)
        {
            this._server = server;
        }

        public void NotifyUpdateLiveStatus(string json)
        {
            this._server.UpdateToLiveInfo(json);
        }

    }
}
