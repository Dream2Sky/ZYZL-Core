using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLinking.Entity.Wx
{
    public class WxAuthInfo
    {
        /// <summary>
        /// 微信公共号appid
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 微信公众号密钥
        /// </summary>
        public string AppSercet { get; set; }
    }
}
