using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.commons;

namespace ultra_comment_viewer.src.model
{
    public class TwicasApi
    {

        private TwicasApi() { }


      
        public const string CLIENT_ID = "1274162612133957632.c11cf15ae164a5a6835e27174ad61e915d12180bf24ed825d1b35f127ea5fa87";

        public const string CSRF_TOKEN = "ELM";

        /* 【PUT】 指定したユーザーのサポーターになる
        * bodyにサポーターになるユーザーIDを格納した配列を埋め込む
        * 例 : {"target_user_ids": [{target_user_id}]}*/
        public const string PUT_REGESITE_SUPPORTER = "https://apiv2.twitcasting.tv/support";
        
        public const string GET_WEB_SOCKET_URL = "https://twitcasting.tv/eventpubsuburl.php";

        public static string GetMoviIdApi(string userId) => $"https://frontendapi.twitcasting.tv/users/{userId}/latest-movie";

        //ユーザーの連携認証ページ遷移のためのURL
        public static string GetUrlAccessAuthenticationPage()
        {
            return $"https://apiv2.twitcasting.tv/oauth2/authorize?client_id={CLIENT_ID}&response_type=code&state={CSRF_TOKEN}";
        }

        
        // 【GET】 Twicasのユーザープロフいーる情報を取得するためのAPI
        public static string GetUserInfoUrl(string userId) => $"https://apiv2.twitcasting.tv/users/{userId}";

        /* 【GET】 ユーザーのライブ情報(配信していなければ録画情報), プロフィール情報を取得するAPI
         * ユーザーが配信していない && ユーザーが録画を残していない場合NotFound 404が発生するため注意*/
        public static string GetUserInfoDetailUrl(string movieId) => $"https://apiv2.twitcasting.tv/movies/{movieId}";

       

    }
}
