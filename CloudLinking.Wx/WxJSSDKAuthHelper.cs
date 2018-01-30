using System;
using System.Collections.Generic;
using System.Text;
using CloudLinking.Entity.Wx;
using CloudLinking.Entity.Common;
using CloudLinking.Utility.Http;
using CloudLinking.Utility.Time;

namespace CloudLinking.Wx
{
    public class WxJSSDKAuthHelper
    {
        public static WxToken GetWxToken(WxContext context)
        {
            if (context.Token.ExpiresTime > DateTime.Now)
            {
                return context.Token;
            }
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("grant_type", "client_credential");
            paramDict.Add("appid", context.AuthInfo.AppId);
            paramDict.Add("secret", context.AuthInfo.AppSercet);

            var token = HttpRequestUtil.Get<WxToken>(Const.WxTokenUrl, paramDict);
            context.Token = token;
            return token;
        }

        public static WxTicket GetWxTicket(WxContext context)
        {
            if (context.Ticket.ExpiresTime > DateTime.Now)
            {
                return context.Ticket;
            }
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("access_token", GetWxToken(context).Access_Token);
            paramDict.Add("type", "jsapi");

            var ticket = HttpRequestUtil.Get<WxTicket>(Const.WxTicketUrl, paramDict);
            context.Ticket = ticket;

            return ticket;
        }

        public static WxJSSDKConfig GetWxJSSDKConfig(WxContext context, string url)
        {
            WxJSSDKConfig config = new WxJSSDKConfig();
            config.AppId = context.AuthInfo.AppId;
            config.TimeStamp = Convert.ToString(DateTimeUtil.GetCurrentTimeStamp());
            config.Signature = WxUtil.GetSignture(context, url, config.TimeStamp);
            config.NonceStr = context.NonceStr;

            return config;
        }
    }
}
