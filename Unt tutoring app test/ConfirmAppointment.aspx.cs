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
            var Appointment = UntTutoringAppTest.DataAccess.ConfirmAppointment.getAppointment(DateId,subId);
            if (Appointment != null)
            {
                LbDate.Text = Appointment.Date.ToShortDateString();
                LbTimeSlot.Text = Appointment.TimeSlot.ToString();
                LbSubject.Text = Appointment.SubjectName.ToString();
                LbTutor.Text = Appointment.TutorName.ToString();
            }





        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectSubject", true);
        }
    }
}