using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainServ
{
    public class BalanceRequest: RequestHeader
    {
        public BalanceResponse Balance()
        {
            BalanceResponse balanceResponse = new BalanceResponse();
            return balanceResponse;
        }


    }
}