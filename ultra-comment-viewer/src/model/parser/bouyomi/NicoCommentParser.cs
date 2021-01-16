using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico.comment_format;
using ultra_comment_viewer.src.model.parser.bouyomi;
using ultra_comment_viewer.src.viemodel.status;

namespace ultra_comment_viewer.src.model.parser
{
    public class NicoCommentParser : ABCommentParser
    {

        private readonly Regex _adRegex = new Regex("(?<=^/nicoad ).+$");


        private readonly Regex _emotion = new Regex("(?<=^/emotion ).+$");

        public NicoCommentParser() 
            : base("(?<=^(/info [0-9]) ).+$") { }


        public override (ChatKind, string) ParseComment(string comment)
        {
            var info = this.ItsRegex.Match(comment).Value;
            if (info.IsNotNullAndNotEmpty()) return (ChatKind.INFO, info);
            
            var emotion = _emotion.Match(comment).Value;
            if (emotion.IsNotNullAndNotEmpty()) return (ChatKind.EMOTION, emotion);

            var nicoAd = _adRegex.Match(comment).Value;
            if (nicoAd.IsNotNullAndNotEmpty())
            {
                var converter = new NicoJsonConverter();
                var adMessage = converter.ConvertToJsonModel<CommentFormatJsonModel>(nicoAd).message;
                return (ChatKind.AD, adMessage);
            }

            return (ChatKind.CHAT, comment);
        }
    }
}
