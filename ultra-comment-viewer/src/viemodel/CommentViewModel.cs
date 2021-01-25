using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.viemodel.status;

namespace ultra_comment_viewer.src.viemodel
{
    public class CommentViewModel :BindableBase
    {
        private int _size = 11;

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

        //投稿日時
        public DateTime PostTime { get; set; }

        //ユーザーのステータス(プレミアムや一般)
        public ListenerStatus Status { get; set; }
        
        public BitmapImage PremiumICon { get; set; }

        public string PostTimeString { get; set; }

      
        public int CommentSize 
        {
            
            get => _size;
            set => SetProperty(ref _size, value);
        }

        public FontWeight CommentWeight { get; set; }

        
        
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
