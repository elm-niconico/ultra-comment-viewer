using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ultra_comment_viewer.src.model.json.converter;

using ultra_comment_viewer.src.model.json.model.niconico.user_page;

namespace ultra_comment_viewer.src.model.parser
{
    public class NicoNicoHtmlDataEnvironmentParser
    {
        public DataEnvironmentJsonModel _model;

        private readonly Regex _tagRegex = new Regex("<[^>]*?>");

        private readonly Regex _brRegex = new Regex("<br(/)?>");

        public NicoNicoHtmlDataEnvironmentParser(string html)
        {
            this._model = ParseDataInitialModel(html);
        }

        private DataEnvironmentJsonModel ParseDataInitialModel(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html).QuerySelector("#js-initial-userpage-data");

            string dataInitialData = document.GetAttribute("data-initial-data");

            var converter = new NicoNicoJsonConverter();
            return converter.ConverToDataEnvironmentModel(dataInitialData);

        }

        public int GetFollowerCount() => this._model.userDetails.userDetails.user.followeeCount;

        public int GetFollowCount() => this._model.userDetails.userDetails.user.followeeCount;

        public string GetDescription()
        {
            var html = _model.userDetails.userDetails.user.description;
            var description = this._brRegex.Replace(html, "\n");
            return this._tagRegex.Replace(description, "");
        }
        

        
    }
}
