using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ultra_comment_viewer.src.model.json.model.niconico;

namespace ultra_comment_viewer.src.model.json.converter
{
    public class NicoNicoJsonConverter
    {
        public DataPropsJsonModel ConverToDataPropsJsonModel(string json)
        {
            return JsonSerializer.Deserialize<DataPropsJsonModel>(json);
        }

        public LiveRoomJsonModel ConverToLiveRoomJsonModel(string json)
        {
            return JsonSerializer.Deserialize<LiveRoomJsonModel>(json);
        }
    }
}
