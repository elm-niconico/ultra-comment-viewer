
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using ultra_comment_viewer.src.viemodel;
using static ultra_comment_viewer.src.commons.SQLStrings;

namespace ultra_comment_viewer.src.viewLogic.log.sqlite
{
    public class SqliteSupport
    {
        private  SQLiteConnection _connectionDb;


        private static readonly SqliteSupport Instance;
  
  


        static SqliteSupport()
        {
            Instance = new SqliteSupport();
        }


        public static SqliteSupport GetInstance() => Instance; 


        private SqliteSupport()
        {
            ConnecitonDataBase();
            CreateCommentLogTable();
        }


        public void InsertModel(CommentViewModel model)
        {
            SQLiteTransaction transaction = null;
            try
            {
                transaction =  this._connectionDb.BeginTransaction();
                using var command = new SQLiteCommand(this._connectionDb)
                {
                    CommandText = GetSqlInsertLogTable(model.UserId, (int)model.LiveName, model.Comment)
                };
                command.ExecuteNonQuery();
                transaction.Commit();
            }catch (Exception)
            {
                
                transaction.Rollback();
            }

           
        }

        public SQLiteDataReader SelectLogComment(CommentViewModel model)
        {
            using var command = new SQLiteCommand(this._connectionDb)
            {
                CommandText = GetSqlSelectLogTable(model.UserId, (int)model.LiveName)
            };
            return command.ExecuteReader();
        }

        private void ConnecitonDataBase()
        {

            var sb = new SQLiteConnectionStringBuilder() { DataSource = DATABASE_NAME };
            this._connectionDb = new SQLiteConnection(sb.ToString());
            this._connectionDb.Open();
        }



        private void CreateCommentLogTable()
        {
            using var command = new SQLiteCommand(this._connectionDb)
            {
                CommandText = CreateDataBase
            };
            
            command.ExecuteNonQuery();
        }




    }
}
