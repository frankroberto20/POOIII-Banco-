using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Transferencias : System.Web.UI.Page
    {
        //protected decimal maxValue = 100;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

            txtMonto.Attributes["max"] = "100";
            
            //sltCuentaOrigen.Items.Add();
        }
    }
}