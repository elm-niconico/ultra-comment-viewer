using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.view.validater
{
    public class TwiacasLiveUrlValidater : ABUrlValidater
    {

        public TwiacasLiveUrlValidater() : base(@"(?<=https:\/\/twitcasting\.tv\/)[^\/]*") { }


        protected override string ExtractMatchRegexUrl(string url)
        {
            return this.regex.Match(url).Value;
        }
    }
}
