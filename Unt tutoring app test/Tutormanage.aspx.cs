using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    public partial class Tutormanage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Calendar1.Visible = false;
                Btn_addDate.Visible = false;

            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("d");
            Btn_addDate.Visible = true;
            Calendar1.Visible=false;
        }

        protected void Btn_addDate_Click(object sender, EventArgs e)
        {
            var tutorAvailable = new UntTutoringAppTest.DataContract.TutorManageInfo();
            tutorAvailable.AppointDate = Calendar1.SelectedDate;
            tutorAvailable.TutorId = Convert.ToString(Session["UserId"]);
            var ret = UntTutoringAppTest.DataAccess.TutorManage.Create(tutorAvailable);

        }

        protected void Btn_selectDate_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            
        }
    }
}