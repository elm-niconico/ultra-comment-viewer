using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ultra_comment_viewer.src.model.parser
{
    class NicoNicoLiveHtmlParser
    {
        private readonly IHtmlCollection<IElement> _collection;

        public readonly string Title;
        public NicoNicoLiveHtmlParser(string html)
        {
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            var regex = new Regex("^.+(?= - [0-9]{4}/[0-9]{2}/[0-9]{2}.+ [0-9]{2}:[0-9]{2}開始 - ニコニコ生放送$)");
            Title = regex.Match(doc.Title).Value;
            this._collection = doc.Body.QuerySelectorAll(".___content___1_nBL").ToCollection();
            
        }

        public string GetViewr() => this._collection[0].Text();

        public string GetCommentCount() => this._collection[1].Text();

        public string GetGiftPoint() => this._collection[3].Text();

        public string GetAdPoint() => this._collection[2].Text();
    }
}
