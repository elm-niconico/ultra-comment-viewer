using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.json.model.niconico.user_page
{
        
    /**
     * ユーザーページからフォロワー数とフォロー数と自己紹介文を取り出すためのモデル
     */
    public class DataEnvironmentJsonModel
    {
        public UserDetails2 userDetails { get; set; }
    }
    public class UserDetails2
    {
        public UserDetails userDetails { get; set; }
    } 

    public class UserLevel
    {
        public int currentLevel { get; set; }
        public int nextLevelThresholdExperience { get; set; }
        public int nextLevelExperience { get; set; }
        public int currentLevelExperience { get; set; }
    }

    public class Icons
    {
        public string small { get; set; }
        public string large { get; set; }
    }

    public class User
    {
        public string description { get; set; }
        public string strippedDescription { get; set; }
        public bool isPremium { get; set; }
        public string registeredVersion { get; set; }
        public int followeeCount { get; set; }
        public int followerCount { get; set; }
        public UserLevel userLevel { get; set; }
        public object userChannel { get; set; }
        public bool isNicorepoReadable { get; set; }
        public List<object> sns { get; set; }
        public int id { get; set; }
        public string nickname { get; set; }
        public Icons icons { get; set; }
    }

    public class FollowStatus
    {
        public bool isFollowing { get; set; }
    }

    public class UserDetails
    {
        public string type { get; set; }
        public User user { get; set; }
        public FollowStatus followStatus { get; set; }
        public UserDetails userDetails { get; set; }
    }

  



}
