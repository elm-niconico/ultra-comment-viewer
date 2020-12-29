using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viewLogic.parser;

namespace ultra_comment_viewer_test
{
    class UrlParseTest
    {
        private  UrlParser _parser;
        [SetUp]
        public void SetUp()
        {
            this._parser = new UrlParser();
        }

        //文末でURLが終了する
        [TestCase("この配信おすすめhttps://live2.nicovideo.jp/watch/lv329732401")]
        //空白でURLが区切られる
        [TestCase("この配信おすすめhttps://live2.nicovideo.jp/watch/lv329732401 まじおすすめ")]
        //改行で区切られる
        [TestCase("この配信おすすめ\nhttps://live2.nicovideo.jp/watch/lv329732401\nまじおすすめ")]
        public void ParseNormalUrl(string url)
        {
            var actual = this._parser.ParseUrl(url);
            var expect = "https://live2.nicovideo.jp/watch/lv329732401";
            TestContext.WriteLine(actual);
            Assert.AreEqual(expect, actual);
        }

     
    }
}
