using CapaIntegracion.IntegracionDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MainServ
{
    public class DepositoRequest : RequestHeader
    {

        protected decimal Monto;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DepositoRequest(int NoCuenta, decimal monto)
        {
            CuentaOrigen = NoCuenta;
            Monto = monto;
        }

        public bool DepositoLocal()
        {
            TblClientesTableAdapter tblClientes = new TblClientesTableAdapter(); //FALTA VALIDACION DE CEDULA
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();


            log.Info($"MINICORE: Solicitud retiro de {Monto} de cuenta {CuentaOrigen}");

            if (true)
            {

            }
            decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
            //AGREGUE COLUMNA A MOVIMIENTOS 0(No se ha enviado a core), 1(si se envio)
            tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "Retiro", null, 0);
            balance += Monto;
            tblCuentas.NuevoMovimiento(balance, DateTime.Now, CuentaOrigen);
            return true;

            //if (balance >= Monto)
            //{
                

            //}
            //else
            //    return false;
        }
            /*
            public void Depositar()
            {
                log.Info($"Solicitud de deposito a cuenta {idCuentaSolicitante}");
                BancoEntities bancoEntities = new BancoEntities();
                tblCuenta tblCuenta = new tblCuenta();
                tblMovimiento tblMovimiento = new tblMovimiento();
                tblResponses tblResponses = new tblResponses();
                tblResponses.Request = "Solicitud de de deposito a cuenta";
                tblResponses.Fecha = DateTime.Now;
                try
                {
                    tblMovimiento.Monto___RD_ = monto;
                    tblMovimiento.Fecha_de_movimiento = DateTime.Now;
                    tblMovimiento.Tipo = "Deposito";
                    tblMovimiento.idCuentaSolicitante = idCuentaSolicitante;
                    bancoEntities.tblMovimientos.Add(tblMovimiento);

                    bancoEntities.Depositar(idCuentaSolicitante, monto);
                    ResponseDeposito = new ResponseDeposito("Dinero depositado con exito");
                    tblResponses.Resultado = "Satisfactorio";
                }
                catch (Exception e)
                {
                    tblResponses.Resultado = "Fallido";
                    ResponseDeposito = new ResponseDeposito($"No se pudo realizar el deposito. {e.Message}");
                }
                bancoEntities.tblResponses.Add(tblResponses);
                Console.WriteLine(ResponseDeposito.Mensaje);
                bancoEntities.SaveChanges();
            }
            */

        public DepositoResponse Deposito()
        {
            try
            {
                //webmethod del core
                DateTime date = DateTime.Now;
                log.Info($"Deposito de {Monto} a la cuenta {CuentaOrigen} a las {date}, realizado ");
                DepositoResponse depositoResponse = new DepositoResponse(date, 0, "Deposito Realizado");
                return depositoResponse;
            }
            catch (WebException e)
            {
                log.Info($"Core no disponible, utilizando base de datos local {e}");
                //RealizarRetiro();
                bool x = DepositoLocal(); //depende del mensaje de error
                //string message = "x"; //depende del mensaje de error
                if (x)
                {
                    //DateTime date = DateTime.Now;
                    //log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen} a las {date}, realizado ");(LA HORA ES INNECESARIA LOG4NET LA COLOCA POR DEFAULT)
                    log.Info($"MINICORE: Deposito realizado de {Monto} de cuenta {CuentaOrigen}");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, 0, "Retiro Realizado");
                    return depositoResponse;
                }
                else
                {
                    //DateTime date = DateTime.Now;
                    log.Info($"MINI: Deposito FALLIDO de {Monto} de cuenta {CuentaOrigen}");
                    //log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen}, no ha podido realizarse. Razon: {message}");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, 1, $"Retiro FALLIDO. Razon: {message}"); //RealizarDeposito();
                    return depositoResponse;
                }
            }
        }
    }
}