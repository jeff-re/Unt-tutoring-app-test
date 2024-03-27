using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    
    public partial class ConfirmAppointment : System.Web.UI.Page
    {
        private int subId;
        private int DateId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                subId = Convert.ToInt32(Request.QueryString["SubjectId"]);
                DateId = Convert.ToInt32(Request.QueryString["DateId"]);

                if ((DateId <= 0) || (subId <=0))
                {
                    Response.Redirect("~/SelectSubject", true);
                }


            }

        }

        public void Display()
        {
            var appTime = new UntTutoringAppTest.DataContract.AppointmentsInfo();

            

        }

    }
}