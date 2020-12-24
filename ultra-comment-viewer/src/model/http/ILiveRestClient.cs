using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ultra_comment_viewer.src.model
{
    public interface ILiveRestClient
    {
       
        public Task<string> GetWebSocketUrlAsync(string movieId);
    }
}
