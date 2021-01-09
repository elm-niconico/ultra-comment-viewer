using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.commons.extends_mothod;

namespace ultra_comment_viewer.src.model.parser.bouyomi
{
    public abstract class ABBouyomiChanParser
    {
        protected string ItsComment;

        protected Regex regex;

        public ABBouyomiChanParser(string regex)
        {
            this.regex = new Regex(regex);
        }

        public abstract string ParseComment();

        public bool IsNotUserComment(string comment)
        {
            this.ItsComment = comment;
            return (this.regex.IsMatch(comment));  
        }

    }
}
