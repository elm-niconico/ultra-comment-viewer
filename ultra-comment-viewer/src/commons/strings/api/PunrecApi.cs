using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.commons.strings.api
{
    public class PunrecApi
    {
        private PunrecApi() { }

        public static string GET_MOVIE_ID_API(string userId) => $"https://public.openrec.tv/external/api/v5/movies?channel_ids={userId}&sort=onair_status&is_upload=false";
    }
}
