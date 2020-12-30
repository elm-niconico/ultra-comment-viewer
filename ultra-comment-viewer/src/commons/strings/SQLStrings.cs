using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.commons
{
    public class SQLStrings
    {
        
        public static string DATABASE_NAME = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/comment_viewer.db";
        public const string LOG_TABLE_NAME = "comment_log";

        public static readonly string CreateDataBase = $"CREATE TABLE IF NOT EXISTS {LOG_TABLE_NAME}(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "user_id TEXT NOT NULL," +
                    "live_site_id INTEGER NOT NULL," +
                    "comment TEXT)";

        public static string GetSqlInsertLogTable(string userId, int siteName, string comment) 
            => $"INSERT INTO {LOG_TABLE_NAME}(user_id, live_site_id, comment) VALUES('{userId}', {siteName}, '{comment}')";

        public static string GetSqlSelectLogTable(string userId, int siteName)
            => $"SELECT comment FROM {LOG_TABLE_NAME} WHERE user_id='{userId}' AND live_site_id={siteName}"; 

    }
}
