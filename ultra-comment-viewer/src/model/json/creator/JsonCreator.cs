using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viemodel.status;

namespace ultra_comment_viewer.src.model.json.creator
{
    public class JsonCreator
    {
        private const string NICONICO = "ニコニコ";

        private const string TWICAS = "ツイキャス";


        public string CrateCommentJson(CommentViewModel model)
        {
            var userName = model.UserName;
            var comment = model.Comment;
            var userIcon = "";
            var no = model.No;
            var liveName = GetLiveName(model.LiveName);
            var postTime = model.PostTime;
            var status = model.Status.GetListenerStatus();
            return @$"{{""userName"":""{userName}"",""comment"":""{comment}"",""userIcon"":""{userIcon}"",""no"":""{no}"",""liveName"":""{liveName}"",""postTime"":""{postTime}"",""status"":""{status}""}}"; 
        }


        private string GetLiveName(LiveSiteName name)
        {
            switch (name)
            {
                case LiveSiteName.TWICAS:
                    return TWICAS;
                case LiveSiteName.NICONICO:
                    return NICONICO;
                default:
                    return "?";
            }
        }
    }
}
