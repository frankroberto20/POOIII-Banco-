using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class CrearCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //wsEBanking.WebServiceEbankingSoapClient webService = new wsEBanking.WebServiceEbankingSoapClient();
            //var response = webService.CreateAccount(new wsEBanking.CreateAccountRequest
            //{
            //    AccountType = Convert.ToInt32(Request.Form["sltTipoCuenta"]),
            //    Channel = "EBanking",
            //    UserName = (Session["User"] as wsEBanking.GetUserResponse).UserName,
            //    ActionTime = DateTime.Now
            //});

            //if (response.Success == false)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + response.Message + "');", true);
            //}
            //else
            //{
            //    Thread.Sleep(1000);
            //    Response.Redirect("~/Home");
            //}
        }
    }
}