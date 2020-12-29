using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.commons.extends_mothod
{
    public static class ObjectExtends
    {
        public static bool NotNull(this object instance)
        {
            return !(instance == null);
        }
    }
}
