
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Media.Imaging;

namespace ultra_comment_viewer.src.viemodel
{
    public class MainWindowViewModel :BindableBase
    {
        private BouyomiSettingsModel _bouyomiModel;
        public MainWindowViewModel()
        {
            this._bouyomiModel = BouyomiSettingsModel.GetInstance();
            this.BouyomiChanIcon = _bouyomiModel.BoyomiIcon;
        }
         //============================= ツイキャスのViewModel ================================================

        private bool _isConnectTwicasLive = false;
      
        private string _twicasUserId = String.Empty;

        private string _liveUrlWrittenByTwicasForm = String.Empty;


        private bool _IsWriteUrl;

        private  BitmapImage _boyomiChanIcon;


        public BitmapImage BouyomiChanIcon
        {
            get => this._boyomiChanIcon;
            set => SetProperty(ref this._boyomiChanIcon, this._bouyomiModel.BoyomiIcon);
        }

        public string LiveUrlWrittenByTwicasForm
        {
            get => this._liveUrlWrittenByTwicasForm;
            set => SetProperty(ref this._liveUrlWrittenByTwicasForm, value);
        }


        public bool IsWriteUrl
        {
            get => this._IsWriteUrl;
            set => SetProperty(ref _IsWriteUrl, value && !IsConnectTwicasLive);
        }


        public string TwicasUserId
        {
            get => this._twicasUserId;
            set => SetProperty(ref _twicasUserId, value);
        }



        public bool IsConnectTwicasLive {
            get => this._isConnectTwicasLive;
            set{
                SetProperty(ref _isConnectTwicasLive, value);
                if(value) this.IsWriteUrl = false; 
            }
        }


//====================================== ニコニコ動画のViewModel ==============================================

        // 放送に接続しているか
        private bool _isConnectNicoLive = false;
        //userId
        private string _niconicoLiveId = String.Empty;

        private string _liveUrlWrittenByNicoNicoForm = String.Empty;


        private bool _isWriteNicoNicoUrl;

        public bool IsConnectNicoLive
        {
            get => this._isConnectNicoLive;
            set
            {
                SetProperty(ref _isConnectNicoLive, value);
                if(value) this.IsWriteNicoNicoUrl = false;
            }
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
            set => SetProperty(ref this._isWriteNicoNicoUrl, value && !IsConnectNicoLive);
        }

    }
}
