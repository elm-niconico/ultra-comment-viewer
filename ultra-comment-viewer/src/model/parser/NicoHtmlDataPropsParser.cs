using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.niconico;

namespace ultra_comment_viewer.src.model.parser
{
    public class NicoHtmlDataPropsParser
    {

        private DataPropsJsonModel _dataPropsModel;

        public NicoHtmlDataPropsParser(string html)
        {
            ParseDataPropsValue(html);
        }

       

        private void ParseDataPropsValue(string html)
        {
            var parser = new HtmlParser();
            var emvedded = parser.ParseDocument(html).Body.QuerySelector("#embedded-data");

            if (emvedded.IsNull()) return; 

            string datapropsJson =  emvedded.GetAttribute("data-props");

            var converter = new ElmJsonConverter();
            this._dataPropsModel = converter.ConverToDataPropsJsonModel(datapropsJson);
        }

        public string GetWebSocketUrl()
        {
            if (_dataPropsModel.IsNull()) return null;

            return this._dataPropsModel.site.relive.webSocketUrl;
        }

        public BitmapImage ExtractComunityThumbnail()
        {
            try
            {
                return new BitmapImage(new Uri(_dataPropsModel.socialGroup.thumbnailImageUrl));
            }
            catch
            {
                return null;
            }
        }

        public int GetBeginTime()
        {
            return _dataPropsModel.program.beginTime;
        }

    }
}
