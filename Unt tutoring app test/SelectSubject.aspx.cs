using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    public partial class SelectSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GvSubjects.DataSource = UntTutoringAppTest.DataAccess.Appointments.GetSubjects();
            GvSubjects.DataBind();
            
        }

        protected void LinkButtonSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectTutorAndTime?SubjectId=" + ((LinkButton)sender).Text);

           



        }

        protected void GvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int TutorAvailableId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/SelectTutorAndTime?SubjectId=" + (TutorAvailableId).ToString());
        }
    }

    
}