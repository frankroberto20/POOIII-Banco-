using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainServ
{
    public class TransferenciaResponse: ResponseHeader
    {
        public TransferenciaResponse(DateTime date, int responseCode, string responseMessage) : base(date, responseCode, responseMessage)
        {
            dateTime = date;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }
    }
}