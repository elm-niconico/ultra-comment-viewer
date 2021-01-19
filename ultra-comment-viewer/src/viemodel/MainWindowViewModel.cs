
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons;
using Brush = System.Windows.Media.Brush;

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

        private Brush _accountColor = ElmBackgroundUtil.WHITE;

        private Brush _logColor = ElmBackgroundUtil.WHITE;

        private Brush _webColor = ElmBackgroundUtil.WHITE;

        private Brush _clipColor = ElmBackgroundUtil.WHITE;

        public Brush AccountColor
        {
            get => this._accountColor;
            set => SetProperty(ref this._accountColor, value);
        }

        public Brush WebColor
        {
            get => this._webColor;
            set => SetProperty(ref this._webColor, value);
        }


        public Brush LogColor
        {
            get => this._logColor;
            set => SetProperty(ref this._logColor, value);
        }

        public Brush ClipColor
        {
            get => this._clipColor;
            set => SetProperty(ref this._clipColor, value);
        }

 
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
            set => SetProperty(ref _IsWriteUrl, value && !IsNotConnectTwicasLive);
        }


        public string TwicasUserId
        {
            get => this._twicasUserId;
            set => SetProperty(ref _twicasUserId, value);
        }




        public bool IsNotConnectTwicasLive {
            get => this._isConnectTwicasLive;
            set{
                SetProperty(ref _isConnectTwicasLive, value);
                if(value) this.IsWriteUrl = false; 
            }
        }


//====================================== ニコニコ動画のViewModel ==============================================

        // 放送に接続しているか
        private bool _isNotConnectNicoLive = true;
        //userId
        private string _niconicoLiveId = String.Empty;

        private string _liveUrlWrittenByNicoNicoForm = String.Empty;


        private bool _isWriteNicoNicoUrl;

        private string _nicoLiveTitle;

        private string _nicoGiftPoint;

        private string _nicoCommentCount;

        private string _nicoAdPoint;

        private string _nicoViewer;

        public string NicoViewer
        {
            get => this._nicoViewer;
            set => SetProperty(ref _nicoViewer, $"{value}人");
        }

        public string NicoLiveTitle
        {
            get => this._nicoLiveTitle;
            set => SetProperty(ref _nicoLiveTitle, value);
        }

        public string NicoGiftPoint
        {
            get => this._nicoGiftPoint;
            set => SetProperty(ref _nicoGiftPoint, $"{value}P");
        }

        public string NicoCommentCount
        {
            get => this._nicoCommentCount;
            set => SetProperty(ref _nicoCommentCount, value);
        }

        public string NicoAdPoint
        {
            get => this._nicoAdPoint;
            set => SetProperty(ref _nicoAdPoint, $"{value}P");
        }



        public bool IsNotConnectNicoLive
        {
            get => this._isNotConnectNicoLive;
            set
            {
                SetProperty(ref _isNotConnectNicoLive, value);
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
            set => SetProperty(ref this._isWriteNicoNicoUrl, value && !IsNotConnectNicoLive);
        }


    //================ オープンレックのモデル ==============================
        private string _punrecLiveTitle;

        private string _punrecViewers;

        private string _punrectTotalViewers = "test";

        private BitmapImage _punrecThumbnail;

        public BitmapImage PunrecThumbnail
        {
            get => _punrecThumbnail;
            set => SetProperty(ref _punrecThumbnail, value);
        }

        public string PunrecLiveTitle
        {
            get => this._punrecLiveTitle;
            set => SetProperty(ref _punrecLiveTitle, value);
        }

        public string PunrecViewers
        {
            get => _punrecViewers;
            set => SetProperty(ref _punrecViewers, value);
        }

        public string PunrecTotalViewers
        {
            get => _punrectTotalViewers;
            set => SetProperty(ref _punrectTotalViewers, value);
        }

    }
}
