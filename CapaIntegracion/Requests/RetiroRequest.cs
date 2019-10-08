﻿using CapaIntegracion.IntegracionDSTableAdapters;
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

        
        public bool RealizarRetiroLocal()
        {
            TblClientesTableAdapter tblClientes = new TblClientesTableAdapter(); //FALTA VALIDACION DE CEDULA
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();


            log.Info($"MINICORE: Solicitud retiro de {Monto} de cuenta {CuentaOrigen}");
            decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
            if (balance >= Monto)
            {
                //AGREGUE COLUMNA A MOVIMIENTOS 0(No se ha enviado a core), 1(si se envio)
                tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "Retiro", null, 0);
                balance -= Monto;
                tblCuentas.NuevoMovimiento(balance, DateTime.Now, CuentaOrigen);
                return true;

            }
            else
                return false;
        }
        

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
                bool x = RealizarRetiroLocal(); //depende del mensaje de error
                //string message = "x"; //depende del mensaje de error
                if (x)
                {
                    //DateTime date = DateTime.Now;
                    //log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen} a las {date}, realizado ");(LA HORA ES INNECESARIA LOG4NET LA COLOCA POR DEFAULT)
                    log.Info($"MINICORE: Retiro realizado de {Monto} de cuenta {CuentaOrigen}");
                    RetiroResponse retiroResponse = new RetiroResponse(DateTime.Now, 0, "Retiro Realizado");
                    return retiroResponse;
                }
                else
                {
                    //DateTime date = DateTime.Now;
                    log.Info($"MINICORE: Retiro FALLIDO de {Monto} de cuenta {CuentaOrigen}");
                    //log.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen}, no ha podido realizarse. Razon: {message}");
                    RetiroResponse retiroResponse = new RetiroResponse(DateTime.Now, 1, $"Retiro FALLIDO. Razon: {message}"); //RealizarDeposito();
                    return retiroResponse;
                }
            }
        }
    }
}