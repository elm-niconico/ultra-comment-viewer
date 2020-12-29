using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ultra_comment_viewer.src.viemodel
{
    public class CommentModel
    {
        public BitmapImage Image { get; set; }
        public string UserName   { get; set; }
        public string Comment    { get; set; }
        public SolidColorBrush CommentColor { get; set; }
        public string UserId { get; set; }
        // 配信サイトの名前
        public LiveSiteName LiveName { get; set; }



        public static CommentModel BuildDisconnectModel()
        {
            return new CommentModel()
            {
                Image = null,
                UserName = "System",
                Comment = Mesasge.CLOSE_SERVER_NORMAL,
                CommentColor = new SolidColorBrush(Colors.Yellow),
                
            };
        }


        public override string ToString()
        {
            return $"{Image} - {UserName} - {Comment}";
        }
    }
}
