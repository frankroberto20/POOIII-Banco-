using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MainServ
{
    public class TransferenciaRequest : RequestHeader
    {
        protected string BancoDestino;
        protected int CuentaDestino;
        protected int CedulaDestino;
        protected decimal Monto;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TransferenciaRequest(int cuentaOrigen, int cedula, decimal monto, string bancoDestino, int cuentaDestino, int cedulaDestino)
        {
            CuentaOrigen = cuentaOrigen;
            Cedula = cedula;
            Monto = monto;
            BancoDestino = bancoDestino;
            CuentaDestino = cuentaDestino;
            CedulaDestino = cedulaDestino;
            dateTime = DateTime.Now;
        }
        /*
        public bool NuevaTransferencia()
        {
            log.Info($"Solicitud de transaccion de dinero de cuenta {idCuentaSolicitante} a cuenta {idCuentaDestino}");
            BancoEntities bancoEntities = new BancoEntities();
            tblCuenta tblCuenta = new tblCuenta();
            tblMovimiento tblMovimiento = new tblMovimiento();
            tblResponses tblResponses = new tblResponses();
            tblResponses.Request = "Solicitud de transaccion";
            tblResponses.Fecha = DateTime.Now;

            var balance1 = bancoEntities.BuscarBalance(idCuentaSolicitante);
            var balance2 = bancoEntities.BuscarBalance(idCuentaSolicitante);

            double dinero = 0;
            foreach (var row in balance1)
            {
                dinero = double.Parse(row.ToString());
            }
            var balance3 = bancoEntities.BuscarBalance(idCuentaSolicitante);
            int numero = balance3.Count() + balance2.Count();
            if (numero == 2)
            {
                if (dinero >= monto)
                {
                    tblMovimiento.Monto___RD_ = monto;
                    tblMovimiento.Fecha_de_movimiento = DateTime.Now;
                    tblMovimiento.Tipo = "Transaccion";
                    tblMovimiento.idCuentaSolicitante = idCuentaSolicitante;
                    tblMovimiento.idCuentaDestino = idCuentaDestino;
                    bancoEntities.tblMovimientos.Add(tblMovimiento);

                    bancoEntities.Transferencia(monto, idCuentaSolicitante, idCuentaDestino);

                    tblResponses.Resultado = "Satisfactorio";

                    ResponseTransaccion = new ResponseTransaccion("Transaccion realizada con exito");
                }
                else
                {
                    tblResponses.Resultado = "Fallida";
                    ResponseTransaccion = new ResponseTransaccion("Transaccion No se pudo realizar (monto excedia al balance en cuenta)");
                }
            }
            else
            {
                tblResponses.Resultado = "Fallida";
                ResponseTransaccion = new ResponseTransaccion("Transaccion No se pudo realizar (una de las cuentas no existe)");
            }
            Console.WriteLine(ResponseTransaccion.Mensaje);
            bancoEntities.tblResponses.Add(tblResponses);
            bancoEntities.SaveChanges();
        }
    }
    */
        public TransferenciaResponse Transferencia()
        {
            try
            {
                //webmethod del core
                bool x = true; //webmethod
                string message = "x"; //webmethod
                if (x)
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, realizada");
                    TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 0, "Transferencia Realizada");
                    return transferenciaResponse;
                }
                else
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, no ha podido realizarse. Razon: {message}");
                    TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 1, $"Transferencia no Realizada. Razon: {message}");
                    return transferenciaResponse;
                }
            }
            catch (WebException e)
            {
                log.Info($"Core no disponible, utilizando base de datos local {e}");
                //NuevaTransferencia();
                bool x = true; //depende del mensaje de error
                string message = "x"; //depende del mensaje de error
                if (x)
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, realizada");
                    TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 0, "Transferencia Realizada");
                    return transferenciaResponse;
                }
                else
                {
                    DateTime date = DateTime.Now;
                    log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, no ha podido realizarse. Razon: {message}");
                    TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 1, $"Transferencia no Realizada. Razon: {message}");
                    return transferenciaResponse;
                }
            }


        }
    }
}