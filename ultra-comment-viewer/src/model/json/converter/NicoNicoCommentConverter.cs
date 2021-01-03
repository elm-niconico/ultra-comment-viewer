using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.json.converter
{
    public class NicoNicoCommentConverter : ABLiveInfoConverter
    {
        public override CommentViewModel CovertToCommentViewModel(string responseJson)
        {
            var jsonConverter = new NicoNicoJsonConverter();
            var model = jsonConverter.ConverToCommentJsonModel(responseJson);

            return new CommentViewModel()
            {
                UserId  = model.chat.user_id,
                UserName = "TEST",
                Comment = model.chat.content,
                CommentColor = new SolidColorBrush(Colors.Purple),
            };
        }
    }
}
