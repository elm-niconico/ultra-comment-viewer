
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
        // 放送に接続しているか
        private bool _isConnect = false;
        //userId
        private string _userId = String.Empty;

        private string _url = String.Empty;

        private bool _IsWriteUrl;

        public string Url
        {
            get => this._url;
            set => SetProperty(ref this._url, value);
        }


        public bool IsWriteUrl
        {
            get => this._IsWriteUrl;
            set => SetProperty(ref _IsWriteUrl, value);
        }


        public string UserId
        {
            get => this._userId;
            set => SetProperty(ref _userId, value);
        }



        public bool IsConnect {
            get => this._isConnect;
            set => SetProperty(ref _isConnect, value);
        }

        

       
    }
}
