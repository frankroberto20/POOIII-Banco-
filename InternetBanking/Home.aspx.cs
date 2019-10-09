using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

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
            if (!IsPostBack)
            {
                CuentaInfo.Visible = false;
            }
            //lblTipoCuenta.Text = "Cuenta de Ahorro";
            //lblID.Text = "123456";
            //lblFechaApertura.Text = $"{DateTime.Now.ToString()}";

            List<Cuentas> cuentas = new List<Cuentas>();
            cuentas.Add(new Cuentas { ID = 1, TipoCuenta = "Ahorro", FechaApertura = DateTime.Now, Balance = 1000.95 });
            cuentas.Add(new Cuentas { ID = 2, TipoCuenta = "Corriente", FechaApertura = DateTime.Now, Balance = 2300.90 });

            grdCuentas.DataSource = cuentas;
            grdCuentas.DataBind();

        }

        protected void grdCuentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCuentas, "Select$" + e.Row.RowIndex);
            }
        }

        protected void grdCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CuentaInfo.Visible = true;

            foreach (GridViewRow row in grdCuentas.Rows)
            {
                if (row.RowIndex == grdCuentas.SelectedIndex)
                {
                    row.ToolTip = string.Empty;
                    String balance = row.Cells[3].Text;

                    lblBalance.Text = balance;
                }
                else
                {
                    //row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    //row.ToolTip = "Click to select this row.";
                }
            }
        }
    }
}