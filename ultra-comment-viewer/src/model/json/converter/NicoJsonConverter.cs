using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ultra_comment_viewer.src.model.json.model.niconico;

using ultra_comment_viewer.src.model.json.model.niconico.user_page;

namespace ultra_comment_viewer.src.model.json.converter
{
    public class NicoJsonConverter
    {
        
        public DataPropsJsonModel ConverToDataPropsJsonModel(string json)
            => JsonSerializer.Deserialize<DataPropsJsonModel>(json);

        public LiveRoomJsonModel ConverToLiveRoomJsonModel(string json)
            => JsonSerializer.Deserialize<LiveRoomJsonModel>(json);
        
        public NicoCommentJsonModel ConverToCommentJsonModel(string json)
            => JsonSerializer.Deserialize<NicoCommentJsonModel>(json);

        public DataEnvironmentJsonModel ConverToDataEnvironmentModel(string json)
            => JsonSerializer.Deserialize<DataEnvironmentJsonModel>(json);

        public ServerTimeJsonModel ConvertToServerJsonModel(string json)
            => JsonSerializer.Deserialize<ServerTimeJsonModel>(json);

        public NicoLiveDataJsonModel ConvertToDataJsonModel(string json)
            => JsonSerializer.Deserialize<NicoLiveDataJsonModel>(json);

        public T ConvertToJsonModel<T>(string json)
            => JsonSerializer.Deserialize<T>(json);
    }
}
