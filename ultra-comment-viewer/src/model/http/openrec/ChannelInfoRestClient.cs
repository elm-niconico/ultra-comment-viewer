using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.openrec.channel;

namespace ultra_comment_viewer.src.model.http.openrec
{
    public class ChannelInfoRestClient
    {
        public async Task<PunrecChannelInfoJsonModel> FetchChannelInfo(string id)
        {
            var json = await ElmHttpClientUtil.WrapGetAsync(PunrecApi.GET_MOVIE_ID_API(id));

            if (json.Equals("[]")) return null;
            
            var cnv = new ElmJsonConverter();
            
            return cnv.ConvertToJsonModel<List<PunrecChannelInfoJsonModel>>(json)[0];
        }

        public async Task<string> LoadToUserHtml(string id)
            => await ElmHttpClientUtil.WrapGetAsync($"https://www.openrec.tv/user/{id}");
    }
}
