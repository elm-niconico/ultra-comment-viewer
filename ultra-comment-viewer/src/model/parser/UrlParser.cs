using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ultra_comment_viewer.src.viewLogic.parser
{
    public class UrlParser
    {
        private readonly Regex _urlRegex = new Regex("https?://[\\w/:%#\\$&\\?\\(\\)~\\.=\\+\\-]+");

         public string ParseUrlOrEmpty(string comment)
        {
            return this._urlRegex.Match(comment).Value;
        }
    }
}
