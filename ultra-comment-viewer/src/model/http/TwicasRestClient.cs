using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.json;

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
            var response = await ElmHttpClient.WrapGetAsync(TwicasApi.GetMoviIdApi(userId));
            return new TwicasJsonConverter().ConverToUserInfo(response).movie.id.ToString();
        }
    }
}
