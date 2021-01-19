using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.validater
{
    public class NicoLiveUrlValidater : ABUrlValidater
    {
        public NicoLiveUrlValidater() : base("lv[0-9]{9}") { }

        protected override string ExtractMatchRegexUrl(string url)
        {
             return this.ItsRegex.Match(url).Value;
        }
    }
}
