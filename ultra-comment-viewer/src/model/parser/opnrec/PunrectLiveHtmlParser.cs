using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ultra_comment_viewer.src.model.parser.opnrec
{
    public class PunrectLiveHtmlParser
    {

        public string ExtractUserInfoJson(string html)
        {
            var trimHtml = html.Replace("\n", "").Replace("\t", "").Replace(" ", "");


            return Regex.Match(trimHtml, @"(?<=<script>window\.stores=).*adjustStore"":{""stores"":.+}}}(?=;</script>.+)").Value;
        }


    }
}
