using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ultra_comment_viewer.src.viemodel
{
    public class NicoNicoUserInfoWindowViewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public BitmapImage UserIcon { get; set; }

        public string ProfileDescription { get; set; }

        public int SupportCount { get; set; }

        public int SupporterCount { get; set; }

        public bool IsLive { get; set; }

        public BitmapImage LiveThumbnail { get; set; }

        public string LiveTitle { get; set; }

        public string SubLiveTitle { get; set; }

        public Uri LiveUrl { get; set; }

        public int Level { get; set; }
    }
}
