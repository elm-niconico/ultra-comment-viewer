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
        private readonly LiveDateManager _manager = new LiveDateManager();

        private readonly BitmapImage _premiumIcon = new BitmapImage(new Uri("Resourcespremium.png",UriKind.Relative));
        
        public override async Task<CommentViewModel> CovertToCommentViewModel(string responseJson)
        {
            var jsonConverter = new ElmJsonConverter();
            var model = jsonConverter.ConverToCommentJsonModel(responseJson);

            var parser = new NicoCommentParser(model.chat.premium);

            var commentAndKind = parser.ParseComment(model.chat.content);
            ChatKind commentKind = commentAndKind.Item1;
            string comment = commentAndKind.Item2;

            var userId = model.chat.user_id;

            var style = await NicoCommentStyle.BuildCommentStyle(commentKind, userId);
            var postTime = _manager.FromUnixTime(model.chat.date);

            return new CommentViewModel()
            {
                UserId = userId,
                UserName = style.NickName,
                Comment = comment,
                CommentColor = style.CommentColor,
                LiveName = LiveSiteName.NICONICO,
                ChatKind = commentKind,
                Image = style.UserIcon,
                No = model.chat.no,
                PostTime = postTime,
                PostTimeString = postTime.ToString(),
                Status = GetStatus(model.chat.premium),
                PremiumICon =  (model.chat.premium == 3)? _premiumIcon : null
            };
        }

        private ListenerStatus GetStatus(int status)
        {
            if (status == 0) return ListenerStatus.GENERAL;
            else if (status == 1) return ListenerStatus.PREMIUM;
            else return ListenerStatus.GENERAL;
        }

    }
}
