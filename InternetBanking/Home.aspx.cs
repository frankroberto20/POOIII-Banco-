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
        public class Cuentas
        {
            public string TipoCuenta { get; set; }
            public int ID { get; set; }
            public DateTime FechaApertura { get; set; }
            public double Balance { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //lblTipoCuenta.Text = "Cuenta de Ahorro";
            //lblID.Text = "123456";
            //lblFechaApertura.Text = $"{DateTime.Now.ToString()}";

            List<Cuentas> cuentas = new List<Cuentas>();
            cuentas.Add(new Cuentas { ID = 1, TipoCuenta = "Ahorro", FechaApertura = DateTime.Now, Balance = 1000.95 });
            cuentas.Add(new Cuentas { ID = 2, TipoCuenta = "Corriente", FechaApertura = DateTime.Now, Balance = 2300.90 });

            grdCuentas.DataSource = cuentas;
            grdCuentas.DataBind();

        }
    }
}