using Microsoft.Ajax.Utilities;
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
                GridBindSubjects();

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

        



        protected void GridBindTutorTimes()
        {
            //DataTable dt = DataAccess.DrugData.GetDriverDetails(DriverID, defaultStatus);
            DataTable dt = UntTutoringAppTest.DataAccess.TutorManage.GetTutorAvailableTimes();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Remove")
            {
                int TutorAvailableId = Convert.ToInt32(e.CommandArgument);
                UntTutoringAppTest.DataAccess.TutorManage.UpdateTutorStatus(TutorAvailableId);
                GridBindTutorTimes();


            }
       
            
        }


        protected void GridBindSubjects()
        {
            var tutor = new UntTutoringAppTest.DataContract.TutorManageInfo();
            tutor.TutorId = Convert.ToString(Session["UserId"]);
            DataTable dt = UntTutoringAppTest.DataAccess.TutorManage.GetPreferedSubjects(tutor);
            if(dt.Rows.Count > 0)
            {
                GvPrefered_subject.DataSource = dt;
                GvPrefered_subject.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                GvPrefered_subject.DataSource = dt;
                GvPrefered_subject.DataBind();
    
                GvPrefered_subject.Rows[0].Cells.Clear();
                GvPrefered_subject.Rows[0].Cells.Add(new TableCell());
                GvPrefered_subject.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GvPrefered_subject.Rows[0].Cells[0].Text = "Prefered Subjects Not set";
                GvPrefered_subject.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
             
                GvPrefered_subject.Rows[1].Cells.Clear();
                GvPrefered_subject.Rows[1].Cells.Add(new TableCell());
                GvPrefered_subject.Rows[1].Cells[0].ColumnSpan = dt.Columns.Count;
                GvPrefered_subject.Rows[1].Cells[0].Text = "Please add prefered subjects";
                GvPrefered_subject.Rows[1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            
            }
           
        }

        protected void GvPrefered_subject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {
                var Tutor = new UntTutoringAppTest.DataContract.TutorManageInfo();
                var subid = (GvPrefered_subject.FooterRow.FindControl("Ddl_subjects") as DropDownList).SelectedValue;
                
                    Tutor.SubjectId = Convert.ToInt32(subid);
                if (Tutor.SubjectId > 0)
                {
                    Tutor.TutorId = Convert.ToString(Session["UserId"]);
                    var ret = UntTutoringAppTest.DataAccess.TutorManage.CreatePreferedSubject(Tutor);
                    GridBindSubjects();
                }

            }
        }

        protected void GvPrefered_subject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var Id = Convert.ToInt32(GvPrefered_subject.DataKeys[e.RowIndex].Value.ToString());
            UntTutoringAppTest.DataAccess.TutorManage.DeleteSubject(Id);
            GridBindSubjects();


        }
    }
}