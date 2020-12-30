using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.commons;

namespace ultra_comment_viewer.src.model
{
    public class TwicasApi
    {

        private TwicasApi() { }


        static TwicasApi()
        {
            CSRF_TOKEN = StringsGenerator.GenerateGuId();
        }

        public const string CLIENT_ID = "1274162612133957632.c11cf15ae164a5a6835e27174ad61e915d12180bf24ed825d1b35f127ea5fa87";

        public static readonly string CSRF_TOKEN;

        public static string GetMoviIdApi(string userId) => $"https://frontendapi.twitcasting.tv/users/{userId}/latest-movie";
        
        public const string GET_WEB_SOCKET_URL = "https://twitcasting.tv/eventpubsuburl.php";

        //ユーザーの連携認証ページ遷移のためのURL
        public static string GetUrlAccessAuthenticationPage()
        {
            return $"https://apiv2.twitcasting.tv/oauth2/authorize?client_id={CLIENT_ID}&response_type=code&state={CSRF_TOKEN}";
        }

        public static string GetUserInfoUrl(string userId) => $"https://apiv2.twitcasting.tv/users/{userId}";
    }
}
