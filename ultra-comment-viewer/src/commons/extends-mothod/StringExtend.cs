using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.commons.extends_mothod
{
    public static class StringExtend
    {
        public static bool IsNotNullAndNotEmpty(this string instance)
        {
            return instance.NotNull() && !instance.Equals("");
        }
    }
}
