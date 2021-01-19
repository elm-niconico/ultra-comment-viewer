using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.validater
{
    public abstract class ABUrlValidater
    {

        protected Regex ItsRegex;

        public ABUrlValidater(string pattern)
        {
            if(pattern.NotNull())
                this.ItsRegex = new Regex(pattern);
        }

        public (bool, string) IsValidUrl(string url)
        {
            
            var liveId = ExtractMatchRegexUrl(url);

            if (String.IsNullOrEmpty(liveId))
            {
                MessageBox.Show(Messages.NOT_VALID_LIVE_URL);
                return (false,null);
            }
           
            return (true, liveId);
        }

        protected abstract string ExtractMatchRegexUrl(string url);


    }
}
