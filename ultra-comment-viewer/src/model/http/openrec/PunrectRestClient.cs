using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.commons.strings.api;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.json.model.openrec.channel;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.model.http.openrec
{
    class PunrectRestClient : ILiveRestClient
    {
        private PunrecChannelInfoJsonModel _channelInfo;

        private MainWindowViewModel _model;

        public Task<string> GetUserLiveHtmlAsync(string id)
        {
            throw new NotImplementedException();
        }

        public PunrectRestClient(MainWindowViewModel model)
        {
            _model = model;
        }

        public async Task<string> GetWebSocketUrlAsync(string id)
        {
            var cr = new ChannelInfoRestClient();
            _channelInfo = await cr.FetchChannelInfo(id); 
            SetLiveInfo();

            var movieId =  _channelInfo.movie_id.ToString();
            return $"wss://chat.openrec.tv/socket.io/?movieId={movieId}&EIO=3&transport=websocket";
        }

        private void SetLiveInfo()
        {
            BitmapImage punrecDefaultIcon = null;
           _model.PunrecLiveTitle = _channelInfo.title;
            try
            {
                punrecDefaultIcon = new BitmapImage(new Uri("https://www.openrec.tv/images/v4/default/profile.png"));
                _model.PunrecThumbnail = new BitmapImage(new Uri(_channelInfo.l_thumbnail_url));
            }
            catch
            {
                _model.PunrecThumbnail = punrecDefaultIcon;
            }
            var time = _channelInfo.started_at.ToLocalTime();
            _model.PunrecStartTime = $"{time.ToLongDateString()} {time.ToLongTimeString()}";
            _model.PunrecStartDateTime = time;

            var dm = new LiveDateManager();
            _model.PunrecUpdateTime = dm.ExtractPassStringTime(time);
        }


        public string GetUserLiveThumbnail() => _channelInfo.s_thumbnail_url;

        public string GetUserCoverUrl() => _channelInfo.cover_image_url as string;



    }
}
