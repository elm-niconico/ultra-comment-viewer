using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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
            var response = await ElmHttpClientUtil.WrapBaseWidthBodyAsync(api: TwicasApi.GET_WEB_SOCKET_URL,
                                                                         method: HttpMethod.Post,   
                                                                         bodykey: "movie_id",
                                                                         bodyValue: movieId.ToString());
            var converter = new TwicasJsonConverter();
            return converter.ConvertToWebSocketUrl(response).url;
        }

        private async Task<string> GetMovieIdAsync(string userId)
        {
            var userInfo = await GetUserLiveInfoAsync(userId);
            return userInfo.movie.id.ToString();
        }

        

        //TODO MovieId取得処理メソッド名の変更？
        public async Task<TwicasLiveInfoJsonModel> GetUserLiveInfoAsync(string userId)
        {
            var response = await ElmHttpClientUtil.WrapGetAsync(TwicasApi.GetMoviIdApi(userId));
            return new TwicasJsonConverter().ConverToUserInfo(response);
        }


// =============================================================================================================================
        public async Task<TwicasUserInfoDetailFromJson> GetUserInfoAsync(string userId, string acceessToken)
        {
            var response = await ElmHttpClientUtil.WrapBaseWithHeaderAsync(api: TwicasApi.GetUserInfoUrl(userId),
                                                                           method: HttpMethod.Get,
                                                                           headerKey: "Authorization",
                                                                           headerValue: $"Bearer {acceessToken}");
            
            return new TwicasJsonConverter().ConvertToUserInfoDetailModel(response);
        }
//============================================================================================================================================

        public async Task<TwicasSupporterJsonModel> PutRegesiteSupporter(string targetUserId)
        {
            var response = await ElmHttpClientUtil.WrapPutWidthBodyAsync(api: TwicasApi.PUT_REGESITE_SUPPORTER, 
                                                                         bodyStr: @$"{{""target_user_ids"": [""{targetUserId}""]}}",
                                                                         accessToken: "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjJlMTQyNjExYTdiYzhiZTIyZjU1MWJjYmE2ZDZhZGY0YjkyYTJiZjI4MjY5MjNhNTVmZTNkZDg2ZmQ3MGIzMTFmNjdiNWNkNDJjNTYwNWQwIn0.eyJhdWQiOiIxMjc0MTYyNjEyMTMzOTU3NjMyLmMxMWNmMTVhZTE2NGE1YTY4MzVlMjcxNzRhZDYxZTkxNWQxMjE4MGJmMjRlZDgyNWQxYjM1ZjEyN2VhNWZhODciLCJqdGkiOiIyZTE0MjYxMWE3YmM4YmUyMmY1NTFiY2JhNmQ2YWRmNGI5MmEyYmYyODI2OTIzYTU1ZmUzZGQ4NmZkNzBiMzExZjY3YjVjZDQyYzU2MDVkMCIsImlhdCI6MTYwOTQwNzQ3OSwibmJmIjoxNjA5NDA3NDc5LCJleHAiOjE2MjQ5NTk0NzksInN1YiI6IjEyNzQxNjI2MTIxMzM5NTc2MzIiLCJzY29wZXMiOlsicmVhZCIsIndyaXRlIl19.eavI1Vp4MAQds5rBwvUgx4fjczzPxbohtP1JolWpjVxZNfzy5H0YpCbpqqqQnDr56vQa7KofeexzqnqD23ScNj4b5ZtDNcTjnOrKW0xGMuw9lWpj_l7WxexNyajvwJYv5bTz_SoNObVO7K5-djHoI7WCUjrIwBB1ru0ORjkPlDZhUGW76sRsyngN2myNuoaAUGrCubx3_mgTadfJefPonxp1mGqa5oWDsZSATNQTudx6ZX8TRYrMBzIRwje8E5RgsvfZT2jlCwfuoDbRTlfAtCPhOOUksk4DcO3WFgWHp7rQdm10IyocjkTNOCWi7fdTTMZwzMPFr572uD5XCkIY_A"
                                                                         );

            return new TwicasJsonConverter().ConvertToSupporterCountModel(response);  
        }

        public Task<string> GetUserLiveHtmlAsync(string id)
        {
            //TODO LIVEHTML
            throw new NotImplementedException();
        }
    }
}
