using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.json.model.niconico;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.model.xml.converter;
using ultra_comment_viewer.src.model.xml.model;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viemodel.status;



namespace ultra_comment_viewer.src.model.json.converter
{
    public class NicoCommentConverter : ABLiveInfoConverter
    {
      
        public override CommentViewModel CovertToCommentViewModel(string responseJson)
        {
            var jsonConverter = new NicoJsonConverter();
            var model = jsonConverter.ConverToCommentJsonModel(responseJson);

            var parser = new NicoCommentParser();

            var commentAndKind = parser.ParseComment(model.chat.content);
            ChatKind commentKind = commentAndKind.Item1;
            string comment = commentAndKind.Item2;

            var userId = model.chat.user_id;

            var style = NicoCommentStyle.BuildCommentStyle(commentKind, userId);


            return new CommentViewModel()
            {
                UserId = userId,
                UserName = style.NickName,
                Comment = comment,
                CommentColor = style.CommentColor,
                LiveName = LiveSiteName.NICONICO,
                ChatKind = commentKind,
                Image = style.UserIcon
            };
        }

    }
}
