using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace InternetBanking
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblTipoCuenta.Text = "Cuenta de Ahorro";
            lblID.Text = "123456";
            lblFechaApertura.Text = $"{DateTime.Now.ToString()}";
            


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}