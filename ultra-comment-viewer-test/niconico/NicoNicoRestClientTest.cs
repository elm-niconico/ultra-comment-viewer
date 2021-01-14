using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.http;

namespace ultra_comment_viewer_test
{
    class NicoNicoRestClientTest
    {
        //[Test]
        public async Task ConsoleTestExtractWebSocketUrl()
        {
            var rest = new NicoRestClient();
            var liveId = "lv329838614";
            //視聴セッション用のWebSocketUrl
            var webSocketUrl = await rest.GetWebSocketUrlAsync(liveId);
            TestContext.WriteLine(webSocketUrl);
        }
    }
}
