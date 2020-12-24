using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ultra_comment_viewer.src.model.json.model;

namespace ultra_comment_viewer.src.model.json
{
    public class TwicasJsonConverter
    {
        public TwicasUserInfo ConverToUserInfo(string json)
        {
            return JsonSerializer.Deserialize<TwicasUserInfo>(json);
        }

        public WebSocketUrlModel ConvertToWebSocketUrl(string json)
        {
            return JsonSerializer.Deserialize<WebSocketUrlModel>(json);
        }

    }
}
