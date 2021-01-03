using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ultra_comment_viewer.src.model.http
{
    public class TwicasRestClientExtend
    {
        private TwicasRestClient _baseClient;

        public TwicasRestClientExtend(TwicasRestClient baseClient)
        {
            this._baseClient = baseClient;
        }
        


        public async Task<bool> GetUserIsNotOnLive(string userId)
        {
            var userInfo = await this._baseClient.GetUserLiveInfoAsync(userId);
            return !userInfo.movie.is_on_live;
        }
    }
}
