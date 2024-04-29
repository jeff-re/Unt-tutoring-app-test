using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Unt_tutoring_app_test.WebForm4;

namespace Unt_tutoring_app_test
{
    public partial class ViewBookedAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string StudentId = Convert.ToString(Session["UserId"]);
                DataTable dt = UntTutoringAppTest.DataAccess.Appointments.GetBookedAppointment(StudentId);
                GvBooked.DataSource = dt;
                GvBooked.DataBind();

            }

        }

        protected void GvBooked_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int apptid = Convert.ToInt32(e.CommandArgument);
                UntTutoringAppTest.DataAccess.Appointments.UpdateApptBooked(apptid);

                string StudentId = Convert.ToString(Session["UserId"]);
                DataTable dt = UntTutoringAppTest.DataAccess.Appointments.GetBookedAppointment(StudentId);
                GvBooked.DataSource = dt;
                GvBooked.DataBind();

            }
        }
    }
}