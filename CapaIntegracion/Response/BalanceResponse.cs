using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class BalanceResponse: ResponseHeader
    {
        public decimal Balance;
        public BalanceResponse(DateTime date, int responseCode, string responseMessage, decimal balance)    
        {
            dateTime = date;
            Balance = balance;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }
        public BalanceResponse()
        {

        }
    }
}