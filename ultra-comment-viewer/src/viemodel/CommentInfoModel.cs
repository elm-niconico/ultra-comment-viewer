using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ultra_comment_viewer.src.viemodel
{
    public class CommentInfoModel
    {
        public BitmapImage Image { get; set; }
        public string UserName   { get; set; }
        public string Comment    { get; set; }

        public override string ToString()
        {
            return $"{Image} - {UserName} - {Comment}";
        }
    }
}
