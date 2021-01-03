﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.validater
{
    public abstract class ABUrlValidater
    {
        public string UserId { get; set; }

        protected Regex regex;

        public ABUrlValidater(string pattern)
        {
            this.regex = new Regex(pattern);
        }

        public bool IsValidUrl(MainWindowViewModel model)
        {
            var userId = ExtractMatchRegexUrl(model.LiveUrlWrittenByTwicasForm);
            if (String.IsNullOrEmpty(userId)) return false;

            model.TwicasUserId = userId;
            return true;

        }

        abstract protected string ExtractMatchRegexUrl(string url);


    }
}
