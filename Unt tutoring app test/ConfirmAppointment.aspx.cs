using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UntTutoringAppTest.DataAccess;
using static Unt_tutoring_app_test.WebForm4;

namespace Unt_tutoring_app_test
{
    
    public partial class ConfirmAppointment : System.Web.UI.Page
    {
        private int subId;
        private int DateId;
        DateTime Date;
        string TimeSlot;
        string Subject;
        string Tutor;
        string student = "testtest";


        private UntTutoringAppTest.DataContract.AppointmentsInfo appointment = new UntTutoringAppTest.DataContract.AppointmentsInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                subId = Convert.ToInt32(Request.QueryString["SubjectId"]);
                DateId = Convert.ToInt32(Request.QueryString["DateId"]);

                

                appointment.TimeId = DateId;
                appointment.SubjectId = subId;
               // student = Convert.ToString(Session["UserId"]);
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
            var appointments = UntTutoringAppTest.DataAccess.ConfirmAppointment.getAppointment(DateId,subId);
            if (appointments != null)
            {
                LbDate.Text = appointments.Date.ToShortDateString();
                LbTimeSlot.Text = appointments.TimeSlot.ToString();
                LbSubject.Text = appointments.SubjectName.ToString();
                LbTutor.Text = appointments.TutorName.ToString();

            }


        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            subId = Convert.ToInt32(Request.QueryString["SubjectId"]);
            DateId = Convert.ToInt32(Request.QueryString["DateId"]);


            var testapp = UntTutoringAppTest.DataAccess.ConfirmAppointment.getAppointment(DateId, subId);
            testapp.SubjectId = subId;
            testapp.StudentId = Convert.ToString(Session["UserId"]);


            var test = UntTutoringAppTest.DataAccess.ConfirmAppointment.Create(testapp);

            Response.Redirect("~/StudentMain", true);

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectSubject", true);
        }
    }
}