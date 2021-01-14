using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.validater
{
    public class NicoNicoLiveUrlValidater : ABUrlValidater
    {
        public NicoNicoLiveUrlValidater() : base("lv[0-9]{9}") { }

        public override bool IsValidUrl(MainWindowViewModel model)
        {
            var liveId = ExtractMatchRegexUrl(model.LiveUrlWrittenByNicoNicoForm);

            if (String.IsNullOrEmpty(liveId)) return false;

            model.NiconicoLiveId = liveId;

            return true;
        }

        private string ExtractMatchRegexUrl(string url)
        {
            return this.ItsRegex.Match(url).Value;
        }
    }
}
