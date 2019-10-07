using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainServ
{
    public class BalanceResponse: ResponseHeader
    {
        protected decimal Balance;
        public BalanceResponse(DateTime date, int responseCode, string responseMessage, decimal balance)    
        {
            dateTime = date;
            Balance = balance;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }
    }
}