using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.viemodel.status;

namespace ultra_comment_viewer.src.viemodel
{
    public class CommentViewModel
    {
        public BitmapImage Image { get; set; }
        public string UserName   { get; set; }
        public string Comment    { get; set; }
        public SolidColorBrush CommentColor { get; set; }
        public string UserId { get; set; }
        // 配信サイトの名前
        public LiveSiteName LiveName { get; set; }

        //コメントの分類
        public ChatKind ChatKind { get; set; }

        // コメントナンバー
        public int No { get; set; }


        public static CommentViewModel BuildDisconnectModel()
        {
            return new CommentViewModel()
            {
                Image = null,
                UserName = "System",
                Comment = Messages.CLOSE_SERVER_NORMAL,
                CommentColor = new SolidColorBrush(Colors.Yellow),
                
            };
        }

        public static CommentViewModel BuildCanNotExtractCommentModel()
        {
            return new CommentViewModel()
            {
                Image = null,
                UserName = "System",
                Comment = Messages.CAN_NOT_EXTRACT_COMMNET,
                CommentColor = new SolidColorBrush(Colors.Yellow),

            };
        }


        public override string ToString()
        {
            return $"{Image} - {UserName} - {Comment}";
        }
    }
}
