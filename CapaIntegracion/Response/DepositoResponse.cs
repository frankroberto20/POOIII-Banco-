using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServ
{
    public class DepositoResponse: ResponseHeader
    {
       
        public DepositoResponse(DateTime date, int responseCode, string responseMessage) : base(date, responseCode, responseMessage)
        {
            dateTime = date;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }
    }
}
