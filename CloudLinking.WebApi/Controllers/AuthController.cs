using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudLinking.Wx;
using CloudLinking.Entity.Wx;
using CloudLinking.Entity.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudLinking.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public string GetToken()
        {
            var token = WxJSSDKAuthHelper.GetWxToken(WxContext.Context);
            return token.Access_Token;
        }
       
        [HttpGet("{url}")]
        public HttpResult<WxJSSDKConfig> GetWxJSSDKConfig(string url)
        {
            var config = WxJSSDKAuthHelper.GetWxJSSDKConfig(WxContext.Context, url);
            HttpResult<WxJSSDKConfig> result = new HttpResult<WxJSSDKConfig>();
            return result; 
        }
    }
}
