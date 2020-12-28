using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ultra_comment_viewer.src.commons.extends_mothod
{
    public static class RegexExtends
    {
        
        public static bool IsNotMatch(this Regex regex, string target)
        {
            return !regex.IsMatch(target);
        }
    }
}
