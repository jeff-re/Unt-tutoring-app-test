﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login", true);
        }

        protected void btnStudentLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login", true);
        }

        protected void btnTutorLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login", true);
        }

        protected void btnStudentLogin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login", true);

        }

        protected void btnTutorLogin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login", true);
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ContactUs.aspx", true);

        }

        protected void BtnHoursOfOperation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HoursOfOperation", true);

        }
    }
}