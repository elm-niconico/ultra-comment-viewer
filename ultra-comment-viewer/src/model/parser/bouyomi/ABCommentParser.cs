using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.commons.extends_mothod;

namespace ultra_comment_viewer.src.model.parser.bouyomi
{
    public abstract class ABCommentParser
    {


        protected Regex ItsRegex;

        public ABCommentParser(string regex)
        {
            this.ItsRegex = new Regex(regex);
        }

        public abstract string ParseComment(string comment);

        

    }
}
