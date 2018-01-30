using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudLinking.Wx;
using CloudLinking.Entity.Wx;
using CloudLinking.Entity.Http;
using static CloudLinking.Entity.Common.Enum;
using CloudLinking.Utility.Http;

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

        [HttpGet]
        public string GetTicket()
        {
            var ticket = WxJSSDKAuthHelper.GetWxTicket(WxContext.Context);
            return ticket.Ticket;
        }

        [HttpGet("{url}")]
        public HttpResult<WxJSSDKConfig> GetWxJSSDKConfig(string url)
        {
            var config = WxJSSDKAuthHelper.GetWxJSSDKConfig(WxContext.Context, url);
            var statusCode = HTTP_STATUS_CODE.SUCCESS;
            var msg = "请求成功";
            if (config == null)
            {
                statusCode = HTTP_STATUS_CODE.DATAEMPTY;
                msg = "请求成功，但数据为空";
            }
            return HttpRequestUtil.GetHttpResponse(HTTP_SUCCESS.SUCCESS, statusCode, msg, config);
        }
    }
}
