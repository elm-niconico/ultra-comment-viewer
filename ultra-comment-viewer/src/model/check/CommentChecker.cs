using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.check
{
    public class CommentChecker
    {

        private readonly List<string> _userList = new List<string>();
        
       


        public void AddUser(string userId)
        {
            _userList.Add(userId);
        }

        private bool IsExitsUser(string userId)
       {
            return _userList.IndexOf(userId) != -1;
        }

        public CommentTextStyle CreateStyle(string userId)
        {
            if (IsExitsUser(userId)) return CommentTextStyle.NewNormal();

            AddUser(userId);

            return CommentTextStyle.NewBold();
        }

    }
}
