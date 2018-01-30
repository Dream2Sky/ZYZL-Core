using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLinking.Entity.Wx
{
    public class WxTicket
    {
        public string Ticket { get; set; }
        private int expires_In;
        public int Expires_In
        {
            get
            {
                return expires_In;
            }
            set
            {
                this.expires_In = value;
                this.expiresTime = DateTime.Now.AddSeconds(value);
            }
        }

        private DateTime expiresTime;

        public DateTime ExpiresTime
        {
            get { return expiresTime; }
        }
    }
}
