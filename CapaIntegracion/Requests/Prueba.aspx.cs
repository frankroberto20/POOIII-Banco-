using CapaIntegracion.IntegracionDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaIntegracion.Requests
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //SIMPLEMENTE PRUEBA Para probar azure y dataset

            PruebaTableAdapter ts = new PruebaTableAdapter();
            ts.Insert("Cesar");
            

        }
    }
}