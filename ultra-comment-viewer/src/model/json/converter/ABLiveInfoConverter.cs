﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ultra_comment_viewer.src.model.json.model;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.json
{
    public abstract class ABLiveInfoConverter
    {
        public abstract CommentViewModel CovertToCommentViewModel(string responseJson);
        

    }
}
