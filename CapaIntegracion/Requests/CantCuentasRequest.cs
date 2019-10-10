using log4net;
using CapaIntegracion.IntegracionDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class CantCuentasRequest
    { 
        protected string Cedula;
        protected int ResponseCode;
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        
        public CantCuentasResponse CantidadCuentas()
        {
            DataTable Cuentas = new DataTable();
            try
            {
                CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                var Objeto = coreSoap.Mostrar_cuentas_del_cliente(Cedula);
                try
                {
                    //Cuentas = Objeto.DataTable;
                    ResponseCode = 0;
                }
                catch (Exception e)
                {
                    ResponseCode = 1;
                }
            }
            catch(Exception e)
            {
                Logger.Info($"Core no disponible, utilizando base de datos local {e.Message}");
                TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
                Cuentas = tblCuentas.GetDataByCedula(Cedula);
                if (Cuentas.Rows.Count == 0)
                {
                    ResponseCode = 1;
                }
                else ResponseCode = 0;
            }
            CantCuentasResponse cantCuentasResponse = new CantCuentasResponse(Cuentas, ResponseCode);
            return cantCuentasResponse;
        }
        public CantCuentasRequest(string cedula)
        {
            this.Cedula = cedula;
        }
    }
}