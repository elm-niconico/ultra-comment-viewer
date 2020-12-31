using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ultra_comment_viewer.src.model.json.model;

using ultra_comment_viewer.src.model.json.model.userInfo2;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.json
{
    public class TwicasJsonConverter
    {
        public TwicasLiveInfoFromJson ConverToUserInfo(string json)
        {
            return JsonSerializer.Deserialize<TwicasLiveInfoFromJson>(json);
        }

        public WebSocketUrlModelFromJson ConvertToWebSocketUrl(string json)
        {
            return JsonSerializer.Deserialize<WebSocketUrlModelFromJson>(json);
        }

        public TwicasUserInfoDetailFromJson ConvertToUserInfoDetailModel(string json)
        {
            return JsonSerializer.Deserialize<TwicasUserInfoDetailFromJson>(json);
        }

        



    }
}
