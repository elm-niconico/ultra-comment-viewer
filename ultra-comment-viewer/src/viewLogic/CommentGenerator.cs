using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model;
using ultra_comment_viewer.src.model.connection;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.model.parser.bouyomi;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viewLogic.log.logger;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.viewLogic
{
    public class CommentGenerator
    {
        private ABConnectionCommentServer _server;

        private readonly ObservableCollection<CommentViewModel> _collections;

        private readonly IDisconnectObserver _observer;

        private readonly BouyomiChanClient _boyomiChan;


        public CommentGenerator(ObservableCollection<CommentViewModel> collections)
        {
            this._collections = collections;
            
            this._observer = new IDisconnectObserver(this);
            this._boyomiChan = new BouyomiChanClient();
        }

        public async Task ConnectCommentServerAsync(string userId, Action scrollChange,ABConnectionCommentServer server) 
        {
            this._server = server;
            var logger = new Logger();


            await foreach(var commentModel in _server.FetchCommentAsync(userId, this._observer))
            {

                this._boyomiChan.SendComment(commentModel.Comment);
                logger.PushLog(commentModel);
                _collections.Add(commentModel);
                scrollChange();
            }
        }

        public async Task DisConnectCommentServerAsync()
        {
            if (this._server.IsNull())
            {
                MessageBox.Show(Messages.NOT_CONNECT_SEVER);
                return;
            }
            await this._server.DisconnectServerASync();
        }

        public void AddDisconnectComment()
        {
            var disconnectComment = CommentViewModel.BuildDisconnectModel();
            this._boyomiChan.SendComment(disconnectComment.Comment);
            this._collections.Add(disconnectComment);
        }



    }
}
