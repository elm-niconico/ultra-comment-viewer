using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.xml.converter;
using ultra_comment_viewer.src.model.xml.model;
using ultra_comment_viewer.src.viemodel.status;

namespace ultra_comment_viewer.src.commons
{
    public class NicoCommentStyle
    {

        public string NickName { get; private set; }

        public BitmapImage UserIcon { get; private set; }

        public SolidColorBrush CommentColor { get; private set; }


        public NicoCommentStyle(string nickName, BitmapImage icon, SolidColorBrush color)
        {
            NickName = nickName;
            UserIcon = icon;
            CommentColor = color;
        }
        private readonly static Regex NOT_184_REGEX;

        private readonly static BitmapImage DEFAULT_USER_ICON;

        static NicoCommentStyle()
        {
            NOT_184_REGEX = new Regex("^[0-9]+$");
            DEFAULT_USER_ICON = new BitmapImage(new Uri("Resources\\guest_nico.jpg", UriKind.Relative));
        }

        //============= システムユーザー名 ===============
        private const string AD = "ニコニコ広告";

        private const string EMOTION = "エモーション";

        private const string INFO = "配信情報";

        private const string GIFT = "ギフト";

        //============= システムアイコン ===================
        private readonly static BitmapImage AD_IMAGE = new BitmapImage(new Uri("Resources\\ニコニテレビ君-orange.png", UriKind.Relative));

        private readonly static BitmapImage EMOTION_IMAGE = new BitmapImage(new Uri("Resources\\ニコニテレビ君-green.png", UriKind.Relative));

        private readonly static BitmapImage INFO_IMAGE = new BitmapImage(new Uri("Resources\\ニコニテレビ君-blue.png", UriKind.Relative));

        private readonly static BitmapImage GIFT_IMAGE = new BitmapImage(new Uri("Resources\\ニコニテレビ君-gray.png", UriKind.Relative));

        //============ コメントカラー ======================
        private readonly static SolidColorBrush CHAT_COLOR = new SolidColorBrush(Colors.Violet);

        private readonly static SolidColorBrush AD_COLOR = new SolidColorBrush(Colors.Orange);

        private readonly static SolidColorBrush INFO_COLOR = new SolidColorBrush(Colors.AliceBlue);

        private readonly static SolidColorBrush GIFT_COLOR = new SolidColorBrush(Colors.Gray);

         private readonly static SolidColorBrush EMOTION_COLOR = new SolidColorBrush(Colors.YellowGreen);

        public static NicoCommentStyle BuildAdCommentSyle()
            => new NicoCommentStyle(AD, AD_IMAGE, AD_COLOR);

        private static NicoCommentStyle BuildInfoCommentSyle()
            => new NicoCommentStyle(INFO, INFO_IMAGE, INFO_COLOR);

        private static NicoCommentStyle BuildGiftCommentSyle()
            => new NicoCommentStyle(GIFT, GIFT_IMAGE, GIFT_COLOR);

        private static NicoCommentStyle BuildEmotionCommentSyle()
            => new NicoCommentStyle(EMOTION, EMOTION_IMAGE, EMOTION_COLOR);


        public static NicoCommentStyle BuildCommentStyle(ChatKind commentKind, string userId)
        {
            switch (commentKind)
            {
                case ChatKind.CHAT:
                    return new NicoCommentStyle(ExtractUserNickName(userId), ExtractUserIcon(userId), CHAT_COLOR);
                case ChatKind.AD:
                    return BuildAdCommentSyle();
                case ChatKind.EMOTION:
                    return BuildEmotionCommentSyle();
                case ChatKind.INFO:
                    return BuildInfoCommentSyle();
                case ChatKind.SYSTEM:
                    return BuildInfoCommentSyle();
                default:
                    return BuildInfoCommentSyle();
            }
        }


        private static BitmapImage ExtractUserIcon(string userId)
        {
            var is184 = !int.TryParse(userId, out int id);

            if (is184) return new BitmapImage(new Uri("Resources\\guest_nico.jpg", UriKind.Relative));


            try
            {
                return new BitmapImage(new Uri(NicoApi.GET_USER_ICON(id)));

            }
            catch (Exception)
            {
                return DEFAULT_USER_ICON;
            }
        }

        private static string ExtractUserNickName(string userId)
        {
            if (NOT_184_REGEX.IsNotMatch(userId)) return userId;

            var rest = new NicoRestClient();
            string xml = null;
            Task.Run(() =>
            {
                var task = rest.ExtractUseNickNameXmlAsync(userId);
                task.Wait();
                xml = task.Result;
            }).Wait();

            var converter = new NicoXmlConverter();

            var user = converter.ConvertToNickNameModel<UserNickNameXmlModel>(xml).User;
            if (user == null) return "ゲスト";

            return user.Nickname;
        }

    }
}
