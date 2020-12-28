using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.model.json.model;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.json.converter
{
    public class TwicasCommentConverter : ABLiveInfoConverter
    {


        private TwicasCommentModelFromJson ConvertToJsonModel(string responseJson)
        {
            return JsonSerializer.Deserialize<TwicasCommentModelFromJson[]>(responseJson)[0];
        }



        public override CommentModel CovertToCommentModelFromJson(string responseJson)
        {
            var jsonModel = ConvertToJsonModel(responseJson);
            var userIcon = new BitmapImage(new Uri(jsonModel.author.profileImage));
            var model = new CommentModel()
            {
                Image = userIcon,
                UserName = jsonModel.author.name,
                Comment = jsonModel.message,
                CommentColor = new SolidColorBrush(Colors.GreenYellow)
            };
            return model;
        }
    }
}
