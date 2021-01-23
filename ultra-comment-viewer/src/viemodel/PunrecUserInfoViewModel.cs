using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ultra_comment_viewer.src.viemodel
{
    public class PunrecUserInfoViewModel :BindableBase
    {
        private string _userName;
        private int _follower;
        private int _supporter;
        private string _description;
        private BitmapImage _userIcon;
        private string _userId;
        private BitmapImage _cover;

        public string ProfileDescription
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }


        public BitmapImage CoverImage
        {
            get => _cover;
            set => SetProperty(ref _cover, value);
        }


        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        public BitmapImage UserIcon
        {
            get => _userIcon;
            set => SetProperty(ref _userIcon, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public int Follower
        {
            get => _follower;
            set => SetProperty(ref _follower, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public int Supporter
        {
            get => _supporter;
            set => SetProperty(ref _supporter, value);
        }
    }
}
