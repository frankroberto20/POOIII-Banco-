using CapaIntegracion.IntegracionDSTableAdapters;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaIntegracion.Pruebas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Logger.Info("KLK");

            //integracion.MainServiceSoapClient integ = new integracion.MainServiceSoapClient();
            //integ.Deposito(1000, 2, 2220);

            //CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
            //var response = coreSoap.Depositar("Cesar Lopez", "11111111111", "1000025", "200");

            //ClasePrueba.Hello();


            TblCuentasTableAdapter tblClientes = new TblCuentasTableAdapter();
            tblClientes.Insert(1000035, "corriente", "12345678912", 0, DateTime.Now, DateTime.Now);


        }
    }
}