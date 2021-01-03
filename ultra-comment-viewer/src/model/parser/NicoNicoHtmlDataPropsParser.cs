﻿using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;

namespace ultra_comment_viewer.src.model.parser
{
    public class NicoNicoHtmlDataPropsParser
    {

        private DataPropsJsonModel _dataPropsModel;

        public NicoNicoHtmlDataPropsParser(string html)
        {
            ParseDataPropsValue(html);
        }

       

        private void ParseDataPropsValue(string html)
        {
            var parser = new HtmlParser();
            var emvedded = parser.ParseDocument(html).Body.QuerySelector("#embedded-data");

            var datapropsJson =  emvedded.GetAttribute("data-props");

            var converter = new NicoNicoJsonConverter();
            this._dataPropsModel = converter.ConverToDataPropsJsonModel(datapropsJson);
        }

        public string GetWebSocketUrl()
        {
            return this._dataPropsModel.site.relive.webSocketUrl;
        }

    }
}
