using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ultra_comment_viewer.src.model
{
    public class ElmHttpClient
    {
        private ElmHttpClient() { }

        //TODO  HttpClientを使いまわすか検討

        public async static Task<string> WrapGetWithHeaderAsync(string api, string accessToken)
        {
            string response = null;
            using(var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, api);
                request.Headers.Add("Authorization", accessToken);
                
                var message = await client.SendAsync(request);
                response = await message.Content.ReadAsStringAsync();
            }
            return response;
        }

        public async static Task<string>  WrapGetAsync(string api)
        {
            string response = null;
            using(var client = new HttpClient())
            {
                var message = await client.GetAsync(api);
                response    = await message.Content.ReadAsStringAsync();
            }
            return response;
        }

        public async static Task<string> WrapPostAsync(string api, string bodykey = "", string bodyValue = "")
        {
            var content = new Dictionary<string, string>() { { bodykey, bodyValue } };
            var body = new FormUrlEncodedContent(content);
            string response = null;
            using(HttpClient client = new HttpClient())
            {
                var message =  await client.PostAsync(api, body);
                response = await message.Content.ReadAsStringAsync();
            }
            return response;
        }
    }
}
