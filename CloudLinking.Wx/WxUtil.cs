using CloudLinking.Entity.Wx;
using CloudLinking.Utility.Encrypt;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLinking.Wx
{
    public class WxUtil
    {
        public static string GetSignture(WxContext context, string currentUrl, string timeStamp)
        {
            var str = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}",context.Ticket.Ticket, context.NonceStr,timeStamp,currentUrl);
            return EncryptHelper.Sha1(str,Encoding.UTF8);
        }
    }
}
