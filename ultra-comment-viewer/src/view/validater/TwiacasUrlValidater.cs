using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.view.validater
{
    public class TwiacasUrlValidater : ABUrlValidater
    {

        public TwiacasUrlValidater() : base(@"(?<=https:\/\/twitcasting\.tv\/)[^\/]*") { }


        protected override string ValidateUrl(string url)
        {
            return this.regex.Match(url).Value;
        }
    }
}
