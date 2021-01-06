using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ultra_comment_viewer.src.model
{
    public class ElmHttpClientUtil
    {
        private ElmHttpClientUtil() { }



        private async static Task<string> WrapGetWithHeaderAsync(string api, string accessToken)
        {
            return await WrapBaseWithHeaderAsync(api, 
                                                 HttpMethod.Get, 
                                                 headerKey: "Authorization", 
                                                 headerValue: $"Bearer {accessToken}");
        }

       


        public async static Task<string>  WrapGetAsync(string api)
        {
            using var client = new HttpClient();
            
            var message = await client.GetAsync(api);
            return await message.Content.ReadAsStringAsync();
        }

        public async static Task<string> WrapBaseWidthBodyAsync(string api, HttpMethod method, string bodykey = "", string bodyValue = "")
        {
            var content = new Dictionary<string, string>() { { bodykey, bodyValue } };
            var body = new FormUrlEncodedContent(content);

            var request = new HttpRequestMessage(method, api)
            {
                Content = body
            };

            using var client = new HttpClient();

            var message = await client.SendAsync(request);
            return await message.Content.ReadAsStringAsync();
        }

        public async static Task<string> WrapPutWidthBodyAsync(string api, string bodyStr, string accessToken)
        {
            using var client = new HttpClient();
            
            var request = new HttpRequestMessage(HttpMethod.Put, api);
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            request.Content = new StringContent(bodyStr);
            
            var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }


        public async static Task<string> WrapBaseWithHeaderAsync(string api,
                                                                   HttpMethod method,
                                                                   string headerKey,
                                                                   string headerValue)
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(method, api);
            request.Headers.Add(headerKey, headerValue);

            var message = await client.SendAsync(request);
            return await message.Content.ReadAsStringAsync();
        }
    }
}
