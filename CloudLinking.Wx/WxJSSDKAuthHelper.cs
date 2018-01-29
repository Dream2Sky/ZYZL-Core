using System;
using System.Collections.Generic;
using System.Text;
using CloudLinking.Entity.Wx;
using CloudLinking.Entity.Common;
using CloudLinking.Utility.Http;

namespace CloudLinking.Wx
{
    public class WxJSSDKAuthHelper
    {
        public static WxToken GetWxToken(WxContext context)
        {
            Dictionary<string, string> paramDict = new Dictionary<string, string>();
            paramDict.Add("grant_type", "client_credential");
            paramDict.Add("appid", context.AuthInfo.AppId);
            paramDict.Add("secret", context.AuthInfo.AppSercet);

            var token = HttpRequestUtil.Get<WxToken>(Const.WxTokenUrl, paramDict);
            return token;
        }
    }
}
