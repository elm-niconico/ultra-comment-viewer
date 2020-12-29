using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using ultra_comment_viewer.src.viewLogic.parser;
using ultra_comment_viewer.src.viewLogic.util;

namespace ultra_comment_viewer.src.viewLogic
{
    public class DropLogic
    {
        public void DoStartOpenBrowser(string comment)
        {
            if (String.IsNullOrEmpty(comment)) return;

            var parser = new UrlParser();
            var url = parser.ParseUrl(comment);
            ProcessSupport.OpenBrowser(url);

        }

    }
}
