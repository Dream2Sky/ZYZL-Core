using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLinking.Entity.Common
{
    public static class Const
    {
        public static string WxTokenUrl
        {
            get
            {
                return "https://api.weixin.qq.com/cgi-bin/token";
            }
        }

        public static string WxTicketUrl
        {
            get
            {
                return "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
            }
        }
    }
}
