using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Unt_tutoring_app_test.WebForm4;

namespace Unt_tutoring_app_test
{
    
    public partial class ConfirmAppointment : System.Web.UI.Page
    {
        private int subId;
        private int DateId;

        UntTutoringAppTest.DataContract.AppointmentsInfo appointment = new UntTutoringAppTest.DataContract.AppointmentsInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                subId = Convert.ToInt32(Request.QueryString["SubjectId"]);
                DateId = Convert.ToInt32(Request.QueryString["DateId"]);

                appointment.TimeId = DateId;
                appointment.SubjectId = subId;
                Display();

                if ((DateId <= 0) || (subId <=0))
                {
                    Response.Redirect("~/SelectSubject", true);
                }


            }

        }

        public void Display()
        {
            //var appInfo = new UntTutoringAppTest.DataContract.AppointmentsInfo();
            appointment = UntTutoringAppTest.DataAccess.ConfirmAppointment.getAppointment(DateId,subId);
            if (appointment != null)
            {
                LbDate.Text = appointment.Date.ToShortDateString();
                LbTimeSlot.Text = appointment.TimeSlot.ToString();
                LbSubject.Text = appointment.SubjectName.ToString();
                LbTutor.Text = appointment.TutorName.ToString();
            }





        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            UntTutoringAppTest.DataAccess.ConfirmAppointment.Create(appointment);

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectSubject", true);
        }
    }
}