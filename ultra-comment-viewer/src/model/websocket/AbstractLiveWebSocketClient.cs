using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ultra_comment_viewer.src.model.websocket
{
    public abstract class  AbstractLiveWebSocketClient
    {
        public async IAsyncEnumerable<string> ReadCommentFromServerAsync(string webSocketUrl)
        {
            if(await StartConnectServer(webSocketUrl))
            {
                await foreach(var comment in ReceiveResponse())
                {
                    yield return comment;
                }
            }
        }

        protected abstract Task<bool> StartConnectServer(string webSocketUrl);

        protected abstract IAsyncEnumerable<string> ReceiveResponse();
    }
}
