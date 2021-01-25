using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ultra_comment_viewer.src.viemodel
{
    public class CommentTextStyle
    {
        public int FontSize { get; set; }
        public FontWeight Weight { get; set; }
        

        public static CommentTextStyle NewNormal()
        {
            return new CommentTextStyle()
            {
                FontSize = 11,
                Weight = FontWeights.Normal
            };
        }

        public static CommentTextStyle NewBold()
        {
            return new CommentTextStyle()
            {
                FontSize = 15,
                Weight = FontWeights.ExtraBold
            };
        }
    }
}
