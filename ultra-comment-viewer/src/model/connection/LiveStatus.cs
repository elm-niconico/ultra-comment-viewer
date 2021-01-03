using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.model.connection
{
    public enum LiveStatus
    {
        /* ライブに接続されている状態 */
        SUCCESS_CONNECT,
        /* このコメントはコンバートせずにスキップします */
        SKIP_THIS_COMMENT,
        /* ライブ配信が終了している状態です */
        EXIT
    }
}
