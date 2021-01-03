using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.model.json.model.niconico;

namespace ultra_comment_viewer.src.commons.util
{
    public class NicoNicoLiveRoomInfo
    {
        private readonly LiveRoomJsonModel _roomModel;

        private NicoNicoLiveRoomInfo(LiveRoomJsonModel model)
        {
            this._roomModel = model;
        }


        private static NicoNicoLiveRoomInfo _instance;

        public static NicoNicoLiveRoomInfo GetInstance() => _instance;

        public static void NewCreateRoomInfo(LiveRoomJsonModel model)
        {
            _instance = new NicoNicoLiveRoomInfo(model);
        } 
        
        public string GetThreadId() => this._roomModel.data.threadId;
    }
}
