using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model;
using ultra_comment_viewer.src.model.json.model.openrec;
using ultra_comment_viewer.src.model.parser.opnrec;

namespace ultra_comment_viewer.src.view.validater
{
    public class PunrecUrlValidater : ABUrlValidater
    {
        private const string PUNREC_URL = "https://www.openrec.tv/live/";



        public PunrecUrlValidater(): base(null) { }
        //以下の3つのケースが考えられる
        //LiveId
        //UserId
        //liveUrl
        protected override string ExtractMatchRegexUrl(string url)
        {
            if (IsNotPunrecUrl(url)) url = PUNREC_URL + url;
            return ExtractUserId(url);

        }

        private string ExtractUserId(string url)
        {
            var t = Task.Run(() => ElmHttpClientUtil.WrapGetAsync(url));

            var html = t.Result;

            var parser = new PunrectLiveHtmlParser();
            var json = parser.ExtractUserInfoJson(html);
            if (string.IsNullOrEmpty(json)) return null;

            var cvt = new ElmJsonConverter();


            try
            {
                var userInfo = cvt.ConvertToJsonModel<PunrecUserInfoJsonModel>(json);
                return userInfo.moviePageStore.movieStore.channel.id;
            }
            catch (Exception)
            {
                return null;
            }

        }


        private bool IsNotPunrecUrl(string url) => !url.StartsWith(PUNREC_URL, StringComparison.Ordinal);
    }
}
