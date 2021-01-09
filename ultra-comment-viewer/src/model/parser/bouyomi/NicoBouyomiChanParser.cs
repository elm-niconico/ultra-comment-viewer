using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.model.parser.bouyomi;

namespace ultra_comment_viewer.src.model.parser
{
    public class NicoBouyomiChanParser : ABBouyomiChanParser
    {

        public NicoBouyomiChanParser() 
            : base("((?<=^(/info [0-9]|/emotion|) ).+$)|(?<=^/nicoad {\"totalAdPoint\":[0-9]+,\"message\":\")【広告貢献1位】.+が[0-9]+ptニコニ広告しました(?=\",\"version\":\"[0-9]+\"}$)") { }

        public override string ParseComment()
        {
            return this.regex.Match(ItsComment).Value;
        }
    }
}
