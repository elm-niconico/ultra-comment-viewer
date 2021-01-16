using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.model.json.model;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.json.converter
{
    public class TwicasCommentConverter : ABLiveInfoConverter
    {


        private TwicasCommentJsonModel ConvertToJsonModel(string responseJson)
        {
            return JsonSerializer.Deserialize<TwicasCommentJsonModel[]>(responseJson)[0];
        }



        public override async  Task<CommentViewModel> CovertToCommentViewModel(string responseJson)
        {
            var jsonModel = ConvertToJsonModel(responseJson);
            var userIcon = new BitmapImage(new Uri(jsonModel.author.profileImage));
            var model = new CommentViewModel()
            {
                Image = userIcon,
                UserName = jsonModel.author.name,
                Comment = jsonModel.message,
                CommentColor = new SolidColorBrush(Colors.GreenYellow),
                UserId = jsonModel.author.id,
                LiveName = LiveSiteName.TWICAS
            };
            return model;
        }
    }
}
