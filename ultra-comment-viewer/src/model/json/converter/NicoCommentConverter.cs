using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.xml.converter;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.json.converter
{
    public class NicoCommentConverter : ABLiveInfoConverter
    {
        private readonly Regex _not184Regex = new Regex("^[0-9]+$");

        private readonly BitmapImage defaultUserIcon = new BitmapImage(new Uri("Resources\\guest_nico.jpg", UriKind.Relative));


        public  override CommentViewModel CovertToCommentViewModel(string responseJson)
        {
            var jsonConverter = new NicoJsonConverter();
            var model = jsonConverter.ConverToCommentJsonModel(responseJson);
            
            var userId = model.chat.user_id;

            string nickName = ExtractUserNickName(userId);

            var userIcon = ExtractUserIcon(userId);

            return new CommentViewModel()
            {
                UserId = model.chat.user_id,
                UserName = nickName,
                Comment = model.chat.content,
                CommentColor = new SolidColorBrush(Colors.Violet),
                LiveName = LiveSiteName.NICONICO,
                Image = userIcon
                
            };
        }

        public BitmapImage ExtractUserIcon(string userId)
        {
            var is184 = !int.TryParse(userId, out int id);

            if (is184) return new BitmapImage(new Uri("Resources\\guest_nico.jpg", UriKind.Relative));
               
            
            try
            {
                return new BitmapImage(new Uri(NicoNicoApi.GET_USER_ICON(id)));

            }
            catch(Exception)
            {
                return this.defaultUserIcon;
            }
        }

        public string ExtractUserNickName(string userId)
        {
            if (this._not184Regex.IsNotMatch(userId)) return userId;

            var rest = new NicoRestClient();
            string xml = null;
            Task.Run(() =>
            {
                 var task = rest.ExtractUseNickNameXmlAsync(userId);
                 task.Wait();
                 xml = task.Result;
            }).Wait();
            
            var converter = new NicoNicoXmlConverter();
            
            var user = converter.ConvertToNickNameModel(xml).User;
            if (user == null) return "ゲスト";

            return user.Nickname;
        }
    }
}
