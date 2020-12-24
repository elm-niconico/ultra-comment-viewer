using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model
{
    public class TwicasApi
    {
        public static string GetMoviIdApi(string userId) => $"https://frontendapi.twitcasting.tv/users/{userId}/latest-movie";
        public const string GET_WEB_SOCKET_URL = "https://twitcasting.tv/eventpubsuburl.php";
    }
}
