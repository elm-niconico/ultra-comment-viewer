using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using ultra_comment_viewer.src.model.json.model.openrec.comment;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.json.converter
{
    public class PunrecCommentConverter : ABLiveInfoConverter
    {
        public async override Task<CommentViewModel> CovertToCommentViewModel(string responseJson)
        {
            var json = Regex.Unescape(GetCommentJson(responseJson));
            var cnv = new ElmJsonConverter();
            var model = cnv.ConvertToJsonModel<PunrecCommentJsonModel>(json);

            var comment = new CommentViewModel()
            {
                UserId = model.data.user_key,
                UserName = model.data.user_name,
                Comment = model.data.message,
                CommentColor = new System.Windows.Media.SolidColorBrush(Colors.Yellow),
                Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(model.data.user_icon)),
                LiveName = LiveSiteName.OPENREC,
            };

            return comment;
        }
        

        public string GetCommentJson(string json)
        {
            return json.Replace("42[\"message\",\"", "").Replace("\"]", "");
        }

    }

   

}
