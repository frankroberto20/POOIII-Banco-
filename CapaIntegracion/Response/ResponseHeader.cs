using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServ
{
    public class ResponseHeader
    {
        protected DateTime dateTime;
        protected int ResponseCode;
        protected string ResponseMessage;

        public ResponseHeader()
        {

        }
        public ResponseHeader(DateTime date, int responseCode, string responseMessage)
        {
            dateTime = date;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }
    }
}

