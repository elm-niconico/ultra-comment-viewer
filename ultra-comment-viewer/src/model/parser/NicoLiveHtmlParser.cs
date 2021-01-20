using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace ultra_comment_viewer.src.model.parser
{
    class NicoLiveHtmlParser
    {


        public readonly string Title;

        public readonly string LiveStartTime;

        public NicoLiveHtmlParser(string html)
        {
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            
            var regex = new Regex("^.+(?= - [0-9]{4}/[0-9]{2}/[0-9]{2}.+ [0-9]{2}:[0-9]{2}開始 - ニコニコ生放送$)");
            
            Title = regex.Match(doc.Title).Value;
            LiveStartTime = Regex.Match(doc.Title, "[0-9]{4}/[0-9]{2}/[0-9]{2}.+ [0-9]{2}:[0-9]{2}").Value;

            
           
        }

 

        


    }
}
