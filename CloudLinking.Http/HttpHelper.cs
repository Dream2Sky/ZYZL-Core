using CloudLinking.Entity.Wx;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CloudLinking.Http
{
    public class HttpHelper
    {
        public static T Get<T>(string url, Dictionary<string, string> paramDict)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(paramDict);
            if (paramDict != null)
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                content.Headers.ContentType.CharSet = "UTF-8";
                foreach (var item in paramDict)
                {
                    content.Headers.Add(item.Key, item.Value);
                }
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };

            var res = httpClient.SendAsync(request);
            res.Wait();
            var resp = res.Result;
            Task<T> temp = resp.Content.ReadAsStringAsync(); 
            temp.Wait();
            return temp.Result;
        }
    }
}
