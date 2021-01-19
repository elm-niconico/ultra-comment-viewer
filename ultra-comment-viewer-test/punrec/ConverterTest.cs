using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.model.json.converter;

namespace ultra_comment_viewer_test.punrec
{
    public class ConverterTest
    {
        [Test]
        public void JsonGetTest()
        {
            var json = "42[\"message\",\"{\"type\":1,\"room\":\"2141429\",\"data\":{\"movie_id\":\"2141429\",\"viewers\":1800,\"live_viewers\":501}}\"]";
            var cnv = new PunrecCommentConverter();
            var acutual = cnv.GetCommentJson(json);
            var expect = "{\"type\":1,\"room\":\"2141429\",\"data\":{\"movie_id\":\"2141429\",\"viewers\":1800,\"live_viewers\":501}}";

            Assert.AreEqual(expect, acutual);
        
        }


    }
}
