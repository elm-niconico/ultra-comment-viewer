using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.model.parser;

namespace ultra_comment_viewer_test.niconico
{
    class NicoNicoHtmlParserTest
    {


        private NicoNicoHtmlDataPropsParser _parser;

        [SetUp]
        public void SetUp()
        {
            this._parser = new NicoNicoHtmlDataPropsParser(HTML);


        }

        [Test]
        public void TestExstractDataProps()
        {
            var actual = this._parser.GetWebSocketUrl();
            var expect = @"wss://sdadadada";
            Assert.AreEqual(expect, actual);
        }

        private const string HTML = @"<html><head></head><body><script id=""embedded-data"" data-props='{""site"": { ""relive"" : { ""webSocketUrl"" : ""wss://sdadadada"" } } }'></script></body></html>";
         

    }
}
