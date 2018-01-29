using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLinking.Entity.Wx
{
    public sealed class WxContext
    {
        private static readonly WxContext context = null;
        static WxContext() {
            context = new WxContext();
        }
        private WxContext() {
            this.AuthInfo = new WxAuthInfo();
            this.Token = new WxToken();
            this.Ticket = new WxTicket();
        }

        public static WxContext Context
        {
            get {
                return context;
            }
        }

        private WxAuthInfo authInfo;

        public WxAuthInfo AuthInfo
        {
            get { return authInfo; }
            set { authInfo = value; }
        }

        private WxToken token;

        public WxToken Token
        {
            get { return token; }
            set { token = value; }
        }

        private WxTicket ticket;

        public WxTicket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }
    }
}
