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
            => JsonSerializer.Deserialize<DataPropsJsonModel>(json);

        public LiveRoomJsonModel ConverToLiveRoomJsonModel(string json)
            => JsonSerializer.Deserialize<LiveRoomJsonModel>(json);
        

        public NicoNicoCommentJsonModel ConverToCommentJsonModel(string json)
            => JsonSerializer.Deserialize<NicoNicoCommentJsonModel>(json);
    }
}
