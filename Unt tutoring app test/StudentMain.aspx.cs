using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    public partial class StudentMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSchedule_Appointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectSubject", true);

        }

        protected void BtnChange_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutormanage", true);

        }
    }
}