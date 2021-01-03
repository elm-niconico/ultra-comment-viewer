
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ultra_comment_viewer.src.viemodel
{
    public class MainWindowViewModel :BindableBase
    {
         //============================= ツイキャスのViewModel ================================================

        // 放送に接続しているか
        private bool _isConnectTwicasLive = false;
        //userId
        private string _twicasUserId = String.Empty;

        private string _liveUrlWrittenByTwicasForm = String.Empty;


        private bool _IsWriteUrl;

        public string LiveUrlWrittenByTwicasForm
        {
            get => this._liveUrlWrittenByTwicasForm;
            set => SetProperty(ref this._liveUrlWrittenByTwicasForm, value);
        }


        public bool IsWriteUrl
        {
            get => this._IsWriteUrl;
            set => SetProperty(ref _IsWriteUrl, value);
        }


        public string TwicasUserId
        {
            get => this._twicasUserId;
            set => SetProperty(ref _twicasUserId, value);
        }



        public bool IsConnectTwicasLive {
            get => this._isConnectTwicasLive;
            set => SetProperty(ref _isConnectTwicasLive, value);
        }


//====================================== ニコニコ動画のViewModel ==============================================

        // 放送に接続しているか
        private bool _isConnectNicoNicoLive = false;
        //userId
        private string _niconicoLiveId = String.Empty;

        private string _liveUrlWrittenByNicoNicoForm = String.Empty;


        private bool _isWriteNicoNicoUrl;

        public bool IsConnectNicoNicoLive
        {
            get => this.IsConnectNicoNicoLive;
            set => SetProperty(ref _isConnectNicoNicoLive, value);
        }

        public string NiconicoLiveId
        {
            get => this._niconicoLiveId;
            set => SetProperty(ref _niconicoLiveId, value);
        }

        public string LiveUrlWrittenByNicoNicoForm
        {
            get => this._liveUrlWrittenByNicoNicoForm;
            set => SetProperty(ref this._liveUrlWrittenByNicoNicoForm, value);
        }

        public bool IsWriteNicoNicoUrl
        {
            get => this._isWriteNicoNicoUrl;
            set => SetProperty(ref this._isWriteNicoNicoUrl, value);
        }

    }
}
