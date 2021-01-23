using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using ultra_comment_viewer.src.commons.extends_mothod;

namespace ultra_comment_viewer.src.model.parser.opnrec
{
    public class PunrecUserHtmlParser
    {

        private IDocument _docment;

        public PunrecUserHtmlParser(string html)
        { 
            var ht = new HtmlParser();
            _docment = ht.ParseDocument(html);
        }


        public string GetDescription()
        {
            var q = _docment.QuerySelector("meta[property='og:description']");
            if (q.IsNull())
            {
                return String.Empty;
            }
            else
            {
                return q.GetAttribute("content");
            }

        }


    }
}
