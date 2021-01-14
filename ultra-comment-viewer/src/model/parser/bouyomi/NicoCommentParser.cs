using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico.comment_format;
using ultra_comment_viewer.src.model.parser.bouyomi;

namespace ultra_comment_viewer.src.model.parser
{
    public class NicoCommentParser : ABCommentParser
    {

        private readonly Regex _adRegex = new Regex("(?<=^/nicoad ).+$");

        public NicoCommentParser() 
            : base("(?<=^(/info [0-9]|/emotion|) ).+$") { }


        public override string ParseComment(string comment)
        {
            var infoOrEmotion = this.ItsRegex.Match(comment).Value;
            if (infoOrEmotion.IsNotNullAndNotEmpty()) return infoOrEmotion;

            var nicoAd = _adRegex.Match(comment).Value;
            if (nicoAd.IsNotNullAndNotEmpty())
            {
                var converter = new NicoJsonConverter();
                return converter.ConvertToJsonModel<CommentFormatJsonModel>(nicoAd).message;
            }

            return comment;
        }
    }
}
