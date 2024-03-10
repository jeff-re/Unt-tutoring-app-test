using System;
using System.Collections.Generic;
using System.Data;
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
                GridBindTutorTimes();

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
            var ret = UntTutoringAppTest.DataAccess.TutorManage.AddTutorAvailable(tutorAvailable);
            Response.Redirect(Request.RawUrl);

        }

        protected void Btn_selectDate_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var rowint = GridView1.DataKeys[e.RowIndex].Value.ToString();
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int test = 0;
        }

        protected void GridBindTutorTimes()
        {
            //DataTable dt = DataAccess.DrugData.GetDriverDetails(DriverID, defaultStatus);
            DataTable dt = UntTutoringAppTest.DataAccess.TutorManage.GetTutorAvailableTimes();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}