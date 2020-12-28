﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.viewLogic
{
    public class ConnectSwitcher
    {
        private MainWindowViewModel _model;

        private CommentGenerator _generator;

        public ConnectSwitcher(MainWindowViewModel model, CommentGenerator generator)
        {
            this._model = model;
            this._generator = generator;
        }

        public async Task DoStart(Action scrollChange)
        {

            if (_model.IsConnect)
            {
                SwitchConnect();
                await this._generator.DisConnectCommentServerAsync();
            }
            else
            {
                SwitchConnect();
                await _generator.ConnectCommentServerAsync(_model.UserId, scrollChange);
            }
        }

        private void SwitchConnect()
        {
            this._model.IsConnect = !this._model.IsConnect;
        }
    }
}
