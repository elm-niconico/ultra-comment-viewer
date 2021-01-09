using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model;
using ultra_comment_viewer.src.model.connection;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viewLogic.log.logger;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.viewLogic
{
    public class CommentGenerator
    {
        private readonly ABConnectionCommentServer _server;

        private readonly ObservableCollection<CommentViewModel> _collections;

        private readonly DisconnectObserver _observer;

        private readonly BouyomiChanClient _boyomiChan;

        public CommentGenerator(ObservableCollection<CommentViewModel> collections,
                                 ABConnectionCommentServer server)
        {
            this._collections = collections;
            this._server = server;
            this._observer = new DisconnectObserver(this);
            this._boyomiChan = new BouyomiChanClient(new NicoBouyomiChanParser());
        }

        public async Task ConnectCommentServerAsync(string userId, Action scrollChange)
        {
            var logger = new Logger();


            await foreach(var commentModel in _server.FetchCommentAsync(userId, this._observer))
            {
               
                this._boyomiChan.SendComment(commentModel);
                logger.PushLog(commentModel);
                _collections.Add(commentModel);
                scrollChange();
            }
        }

        public async Task DisConnectCommentServerAsync()
        {
            await this._server.DisconnectServerASync();
        }

        public void AddDisconnectComment()
        {
            this._collections.Add(CommentViewModel.BuildDisconnectModel());
        }



    }
}
