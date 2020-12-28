using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.view.validater;

namespace ultra_comment_viewer_test
{
    class UrlValidaterTest
    {
        MainWindowViewModel model;

        [SetUp]
        public void SetUp()
        {
            model = new MainWindowViewModel();
        }

        [TestCase("https://twitcasting.tv/elm03211114/broadcastertool","elm03211114")]
        [TestCase("https://twitcasting.tv/c:riinukun","c:riinukun")]
        public void SuccessSuccesValidate(string url, string expect)
        {
            model.Url = url;
            var validater = new TwiacasUrlValidater();
            var actual = validater.IsValidUrl(model);
            Assert.AreEqual(true, actual);
            var userId = model.UserId;
            Assert.AreEqual(expect, userId);
        }

        [TestCase("elm03211114/broadcastertool", "elm03211114")]
        [TestCase("c:riinukun", "c:riinukun")]
        public void ErrorSuccesValidate(string url, string expect)
        {
            model.Url = url;
            var validater = new TwiacasUrlValidater();
            var actual = validater.IsValidUrl(model);
            Assert.AreEqual(false, actual);
            var userId = model.UserId;
            Assert.AreEqual(String.Empty, userId);
        }


    }
}
