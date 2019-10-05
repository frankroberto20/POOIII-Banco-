using System;

public abstract class RequestHeader
{
    private int CuentaOrigen;
    private int Cedula;
    private decimal Monto;
    private DateTime dateTime;

	public RequestHeader()
	{
        
	}
}

public class InterbankRequest : RequestHeader
{
    private string BancoReceptor;
    private int CuentaReceptora;
}
