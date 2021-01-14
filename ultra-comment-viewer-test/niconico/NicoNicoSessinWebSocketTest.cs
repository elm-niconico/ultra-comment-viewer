using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.model.websocket;

namespace ultra_comment_viewer_test.niconico
{
    class NicoNicoSessinWebSocketTest
    {
        //[Test]
        public async Task TestConsoleExtractResponseMessage()
        {
            var client = new NicoRestClient();
          
            TestContext.WriteLine(await client.GetWebSocketUrlAsync("lv329828386"));
        }
    }
}
