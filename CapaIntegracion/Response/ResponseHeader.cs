using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServ
{
    public class ResponseHeader
    {
        protected int ID;
        protected DateTime dateTime;
        protected int ResponseCode;
        protected string ResponseMessage;

        public ResponseHeader()
        {

        }
    }
}

