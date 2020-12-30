using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.commons
{
    public class StringsGenerator
    {
        private StringsGenerator() { }

        public static string GenerateGuId()
        {
            return new Guid().ToString();
        }

    }
}
