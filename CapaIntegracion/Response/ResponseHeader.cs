using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaIntegracion
{
    public class ResponseHeader
    {
        public DateTime dateTime;
        public int ResponseCode;
        public string ResponseMessage;

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

