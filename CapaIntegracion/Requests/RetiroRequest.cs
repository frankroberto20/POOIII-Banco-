using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MainServ
{
    public class RetiroRequest: RequestHeader
    {
        protected decimal Monto;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RetiroRequest(int NoCuenta, decimal monto)
        {
            CuentaOrigen = NoCuenta;
            Monto = monto;
        }

        /*
        public bool RealizarRetiro()
        {
            log.Info($"Solicitud retiro de dinero de cuenta {idCuentaSolicitante}");
            BancoEntities bancoEntities = new BancoEntities();
            tblCuenta tblCuenta = new tblCuenta();
            tblMovimiento tblMovimiento = new tblMovimiento();
            tblResponses tblResponses = new tblResponses();
            tblResponses.Request = "Solicitud de retiro de dinero";
            tblResponses.Fecha = DateTime.Now;

            var balance = bancoEntities.BuscarBalance(idCuentaSolicitante);
            double n = 0;
            foreach (var row in balance)
            {
                n = double.Parse(row.ToString());
            }

            if (n >= monto)
            {
                tblMovimiento.Monto___RD_ = monto;
                tblMovimiento.Fecha_de_movimiento = DateTime.Now;
                tblMovimiento.Tipo = "Retiro";
                tblMovimiento.idCuentaSolicitante = idCuentaSolicitante;
                bancoEntities.tblMovimientos.Add(tblMovimiento);

                bancoEntities.RetirarDinero(monto, idCuentaSolicitante);
                tblResponses.Resultado = "Satisfactorio";
                ResponseRetiroDinero = new ResponseRetiroDinero("Retiro de dinero realizado con exito");

            }
            else
            {
                tblResponses.Resultado = "Fallida";
                bancoEntities.tblResponses.Add(tblResponses);
                ResponseRetiroDinero = new ResponseRetiroDinero("Retiro de dinero fallido. Monto de retiro excede balance en cuenta");
            }
            Console.WriteLine(ResponseRetiroDinero.Mensaje);
            bancoEntities.tblResponses.Add(tblResponses);
            bancoEntities.SaveChanges();

        }
        */

        public RetiroResponse Retiro()
        {

            try
            {
                //webmethod del core
                bool x = true; //webmethod
                string message = "x"; //webmethod
                if (x)
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen} a las {date}, realizado ");
                    RetiroResponse retiroResponse = new RetiroResponse(date, 0, "Retiro Realizado");
                    return retiroResponse;
                }
                else
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen} a las {date}, no ha podido realizarse. Razon: {message}");
                    RetiroResponse retiroResponse = new RetiroResponse(date, 1, $"Retiro no Realizado. Razon: {message}");
                    return retiroResponse;
                }
            }
            catch (WebException e)
            {
                log.Info($"Core no disponible, utilizando base de datos local {e}");
                //RealizarRetiro();
                bool x = true; //depende del mensaje de error
                string message = "x"; //depende del mensaje de error
                if (x)
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen} a las {date}, realizado ");
                    RetiroResponse retiroResponse = new RetiroResponse(date, 0, "Retiro Realizado");
                    return retiroResponse;
                }
                else
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen} a las {date}, no ha podido realizarse. Razon: {message}");
                    RetiroResponse retiroResponse = new RetiroResponse(date, 1, $"Retiro no Realizado. Razon: {message}"); //RealizarDeposito();
                    return retiroResponse;
                }
            }
        }
    }
}