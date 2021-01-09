using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viewLogic.log.sqlite;

namespace ultra_comment_viewer.src.viewLogic.log.logger
{
    public class Logger
    {
        public void PushLog(CommentViewModel model)
        {
            var logSql = SqliteSupport.GetInstance();
            logSql.InsertModel(model);
        }

        public List<CommentViewModel> SelectLogComment(CommentViewModel model)
        {
            var logSql = SqliteSupport.GetInstance();
            var reader = logSql.SelectLogComment(model);

            var list = new List<CommentViewModel>();
            while (reader.Read())
            {
                list.Add(new CommentViewModel() { Comment = reader["comment"] as string });
            }

            return list;
        }


    }
}
