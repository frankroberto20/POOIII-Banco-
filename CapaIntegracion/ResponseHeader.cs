using System;
using System.Web.Services.Protocols;

public abstract class ResponseHeader
{
    private int ID;
    private DateTime dateTime;
    private int ResponseCode;
    private string ResponseMessage;

    public ResponseHeader()
	{

	}
}

public class IntrabankResponse : ResponseHeader
{

}

