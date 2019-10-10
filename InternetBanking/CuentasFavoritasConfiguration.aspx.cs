using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class CuentasFavoritasConfiguration : System.Web.UI.Page
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
            //if (!IsPostBack)
            //{
            //    CuentaInfo.Visible = false;
            //}

            List<Cuentas> cuentas = new List<Cuentas>();
            cuentas.Add(new Cuentas { ID = 1, TipoCuenta = "Ahorro" });
            cuentas.Add(new Cuentas { ID = 2, TipoCuenta = "Corriente" });

            grdCuentasFavoritas.DataSource = cuentas;
            grdCuentasFavoritas.DataBind();

            #region addCuentaFavorita
            txtAddCuentaFavorita.Visible = false;
            lblAddCuentaFavorita.Visible = false;
            SubmitCuentaFavorita.Visible = false;
            #endregion

            #region DeleteCuentaFavorita
            lblDeleteCuentaFavorita.Visible = false;
            txtDeleteCuentaFavorita.Visible = false;
            SubmitCuentaDelete.Visible = false;
            #endregion


        }

        protected void grdCuentasFavoritas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCuentasFavoritas, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnAddCuentafavorita1_Click(object sender, EventArgs e)
        {
            if (txtAddCuentaFavorita.Visible == false)
            {
                txtAddCuentaFavorita.Visible = true;
                lblAddCuentaFavorita.Visible = true;
                SubmitCuentaFavorita.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteCuentaFavorita_Click(object sender, EventArgs e)
        {
            if (lblDeleteCuentaFavorita.Visible == false)
            {
                lblDeleteCuentaFavorita.Visible = true;
                txtDeleteCuentaFavorita.Visible = true;
                SubmitCuentaDelete.Visible = true;
            }
        }
    }
}