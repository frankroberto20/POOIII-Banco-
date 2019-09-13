using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsLoggedIn"] = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Login1.UserName.Equals("1"))
            {
                Session["IsLoggedIn"] = true;
            }

            Response.Redirect("~/Default.aspx");
        }
    }
}