using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.validater
{
    public abstract class ABUrlValidater
    {

        protected Regex ItsRegex;

        public ABUrlValidater(string pattern)
        {
            this.ItsRegex = new Regex(pattern);
        }

        public abstract bool IsValidUrl(MainWindowViewModel model);

    }
}
