using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ultra_comment_viewer.src.model.xml.converter
{
    public class MylistXmlConverter
    {
        private readonly string _xml;

        public MylistXmlConverter(string xml)
        {
            var regex = new Regex("<mylistgroup>.+</mylistgroup>");
            this._xml = regex.Match(xml.Replace("\n", "")).Value;
        }

        public string ExtractMyListName()
        {
            return Regex.Match(_xml, "(?<=<name>).+(?=(</name>)?)").Value;
        }

        public string ExtractMyListThumbnail() => Regex.Match(_xml, "<thumbnail_url>.+</thumbnail_url>").Value;

        

    }
}
