using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Cuenta : System.Web.UI.Page
    {
        public class Movimientos
        {
            public string TipoMovimiento { get; set; }
            public int IdCuenta { get; set; }
            public double Cantidad { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBalance.Text = "RD$1920.60";
            lblUltimaTransaccion.Text = "-RD$300";

            List<Movimientos> movimientos = new List<Movimientos>();
            movimientos.Add(new Movimientos { IdCuenta = 1, Cantidad= 100.00, TipoMovimiento="Retiro" });
            movimientos.Add(new Movimientos { IdCuenta = 2, Cantidad = 200.00, TipoMovimiento = "Deposito" });

            grdMovimientos.DataSource = movimientos;
            grdMovimientos.DataBind();

            grdMovimientos.UseAccessibleHeader = true;
            grdMovimientos.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}