﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Boolean.Parse(Session["IsLoggedIn"].ToString()) == false)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}