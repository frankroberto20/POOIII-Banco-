using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainServ
{
    public class RetiroRequest: RequestHeader
    {
        public RetiroResponse Retiro()
        {
            RetiroResponse retiroResponse = new RetiroResponse();
            return retiroResponse;
        }



    }
}