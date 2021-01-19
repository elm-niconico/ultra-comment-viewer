using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.viemodel.status
{
    public enum ListenerStatus
    {
        GENERAL,
        PREMIUM
            
    }

    public static class ListenerStatusExtend
    {
        private const string GENERAL = "一般";

        private const string PREMIUM = "プレミアム";
        
        public static string GetListenerStatus(this ListenerStatus status)
        {
            switch (status)
            {
                case ListenerStatus.GENERAL:
                    return GENERAL;
                case ListenerStatus.PREMIUM:
                    return PREMIUM;
                default:
                    return "?";
            }
        }
    }
}
