using System.Text.RegularExpressions;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;
using ultra_comment_viewer.src.model.json.model.niconico.comment_format;
using ultra_comment_viewer.src.model.parser.bouyomi;
using ultra_comment_viewer.src.viemodel.status;

namespace ultra_comment_viewer.src.model.parser
{
    public class NicoCommentParser : ABCommentParser
    {

        private readonly Regex _adRegex = new Regex("(?<=^/nicoad ).+$");


        private readonly Regex _emotion = new Regex("(?<=^/emotion ).+$");

        private readonly Regex _quote = new Regex("(?<=^/quote ).+$");

        private readonly int _premium;
        
        public NicoCommentParser(int premium): base("(?<=^(/info [0-9]+) ).+$") 
        {
            this._premium = premium;
        }


        public override (ChatKind, string) ParseComment(string comment)
        { 

            if (_premium == 1) return (ChatKind.CHAT, comment);

            if (_premium == 2) return (ChatKind.EXIT, null);

  
            if (comment.StartsWith("/emotion ", System.StringComparison.Ordinal)) 
                return (ChatKind.EMOTION,_emotion.Match(comment).Value);

            if (comment.StartsWith("/quote ", System.StringComparison.Ordinal))
                return (ChatKind.QUOTE, _quote.Match(comment).Value);

            
            if (comment.StartsWith("/nicoad ", System.StringComparison.Ordinal))
            {
                var nicoAd = _adRegex.Match(comment).Value;
                var converter = new ElmJsonConverter();
                var adMessage = converter.ConvertToJsonModel<CommentFormatJsonModel>(nicoAd).message;
                return (ChatKind.AD, adMessage);
            }

            if(comment.StartsWith("/info ", System.StringComparison.Ordinal))
                return (ChatKind.INFO, this.ItsRegex.Match(comment).Value);

            return (ChatKind.CHAT, comment);

        }
    }
}
