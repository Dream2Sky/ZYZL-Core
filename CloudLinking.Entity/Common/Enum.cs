using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLinking.Entity.Common
{
    public static class Enum
    {
        public enum HTTP_SUCCESS
        {
            SUCCESS,
            FAIL
        }

        public enum HTTP_STATUS_CODE
        {
            ERROR = -1,
            SUCCESS = 100,
            DATAEMPTY = 101
        }
    }
}
