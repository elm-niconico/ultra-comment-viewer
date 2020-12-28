using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model
{
    
    public class Author
    {
        public string id { get; set; }
        public string name { get; set; }
        public string screenName { get; set; }
        public string profileImage { get; set; }
        public int grade { get; set; }
    }
    
    public class TwicasCommentModelFromJson
    {
        public string type { get; set; }
        public long id { get; set; }
        public string message { get; set; }
        public long createdAt { get; set; }
        public Author author { get; set; }
        public int numComments { get; set; }
    }




}
