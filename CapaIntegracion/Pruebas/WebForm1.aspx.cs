using CapaIntegracion.IntegracionDSTableAdapters;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TblClientesTableAdapter tblClientes = new TblClientesTableAdapter();
            tblClientes.Insert("Cesar", "Lopez", "8096093146", "40208672472", "M", 19, DateTime.Now);
            

        }
    }
}