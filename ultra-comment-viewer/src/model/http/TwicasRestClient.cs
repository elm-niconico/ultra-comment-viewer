using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.json;
using ultra_comment_viewer.src.model.json.model;
using ultra_comment_viewer.src.model.json.model.userInfo;
using ultra_comment_viewer.src.model.json.model.userInfo2;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.http
{
    public class TwicasRestClient : ILiveRestClient
    {

        public async Task<string> GetWebSocketUrlAsync(string userId)
        {
            var movieId = await GetMovieIdAsync(userId);
            var response = await ElmHttpClient.WrapPostAsync(TwicasApi.GET_WEB_SOCKET_URL, "movie_id", movieId.ToString());
            var converter = new TwicasJsonConverter();
            return converter.ConvertToWebSocketUrl(response).url;
        }

        private async Task<string> GetMovieIdAsync(string userId)
        {
            var userInfo = await GetUserLiveInfoAsync(userId);
            return userInfo.movie.id.ToString();
        }

        public async Task<bool> GetUserIsNotOnLive(string userId)
        {
            var userInfo = await GetUserLiveInfoAsync(userId);
            return !userInfo.movie.is_on_live;
        }

        public async Task<TwicasUserInfoDetailFromJson> GetUserInfoAsync(string userId, string acceessToken)
        {
            var response = await ElmHttpClient.WrapGetWithHeaderAsync(TwicasApi.GetUserInfoUrl(userId), acceessToken);
            
            return new TwicasJsonConverter().ConvertToUserInfoDetailModel(response);
        }


        //TODO MovieId取得処理メソッド名の変更？
        private async Task<TwicasLiveInfoFromJson> GetUserLiveInfoAsync(string userId)
        {
            var response = await ElmHttpClient.WrapGetAsync(TwicasApi.GetMoviIdApi(userId));
            return new TwicasJsonConverter().ConverToUserInfo(response);
        }

        
        
    }
}
