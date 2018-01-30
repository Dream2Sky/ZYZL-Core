﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CloudLinking.Utility.Http
{
    public class HttpRequestUtil
    {
        public static T Get<T>(string url, Dictionary<string, string> paramDict)
        {
            if (paramDict.Count > 0)
            {
                url += "?";
                foreach (var item in paramDict)
                {
                    url += string.Format("{0}={1}&", item.Key, item.Value);
                }
            }
            HttpClient httpClient = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(paramDict);
            if (paramDict != null)
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                content.Headers.ContentType.CharSet = "UTF-8";
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };
            var res = httpClient.SendAsync(request);
            res.Wait();
            var resp = res.Result;
            Task<string> temp = resp.Content.ReadAsStringAsync();
            temp.Wait();
            return JsonConvert.DeserializeObject<T>(temp.Result);
        }
    }
}
