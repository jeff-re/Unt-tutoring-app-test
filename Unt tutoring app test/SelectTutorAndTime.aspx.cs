using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    public partial class SelectTutorAndTime : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Cal_Appoitments.SelectedDate = DateTime.Today;

            if (!IsPostBack)
            {
                DateTime CurrentDate = DateTime.Today;
                int subjectId = Convert.ToInt32(Request.QueryString["SubjectId"]);
                
                // Set the default status here
                DataTable dt = UntTutoringAppTest.DataAccess.Appointments.GetAvailableAppointments(subjectId, 0, "0", CurrentDate);
                if (dt.Rows.Count > 0)
                {
                    GvAppointment.DataSource = dt;
                    GvAppointment.DataBind();
                }
                else
                {
                    dt = new DataTable();
                    dt.Columns.Add(new DataColumn("AppointDate", typeof(string)));
                    dt.Columns.Add(new DataColumn("Time", typeof(string)));
                    dt.Columns.Add(new DataColumn("Id", typeof(string)));
                    dt.Rows.Add(dt.NewRow());
                    //dt.Rows.Add(dt.NewRow());
                    GvAppointment.DataSource = dt;
                    GvAppointment.DataBind();

                    GvAppointment.Rows[0].Cells.Clear();
                    GvAppointment.Rows[0].Cells.Add(new TableCell());
                    GvAppointment.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                    GvAppointment.Rows[0].Cells[0].Text = "Select An Available Date";
                    GvAppointment.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }


            }



        }
        protected void Cal_Appoitments_DayRender(object sender, DayRenderEventArgs e)
        {

            DateTime thisDay = DateTime.Today;
            DateTime ndays = thisDay.AddDays(14);


            if (((e.Day.Date) < (thisDay)) || ((e.Day.Date) > (ndays)))
            {
                e.Day.IsSelectable = false;
                e.Cell.ToolTip = "Day Not Available";
            }
            else
            {
                e.Cell.BackColor = System.Drawing.Color.Green;
            }


        }

        protected void Cal_Appoitments_SelectionChanged(object sender, EventArgs e)
        {

            DateTime SelectedDate = Cal_Appoitments.SelectedDate;
            string SelectedDate2 = SelectedDate.Date.ToShortDateString();

            string SelectedTime = DdlTimes.SelectedValue;

            string SelectedTutor = DdlTutors.SelectedValue;


            int subjectId = Convert.ToInt32(Request.QueryString["SubjectId"]);
            int timeSlotId = Convert.ToInt32(DdlTimes.SelectedValue);
            string tutorId = DdlTutors.SelectedValue;
            DateTime selectedDate = Cal_Appoitments.SelectedDate;


            DataTable dt = UntTutoringAppTest.DataAccess.Appointments.GetAvailableAppointments(subjectId, timeSlotId, tutorId, selectedDate);
            GvAppointment.DataSource = dt;
            GridBindTutorTimes(dt);



        }

        protected void DdlTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime SelectedDate = Cal_Appoitments.SelectedDate;
            string SelectedDate2 = SelectedDate.Date.ToShortDateString();

            string SelectedTime = DdlTimes.SelectedValue;

            string SelectedTutor = DdlTutors.SelectedValue;


            int subjectId = Convert.ToInt32(Request.QueryString["SubjectId"]);
            int timeSlotId = Convert.ToInt32(DdlTimes.SelectedValue);
            string tutorId = DdlTutors.SelectedValue;
            DateTime selectedDate = Cal_Appoitments.SelectedDate;


            DataTable dt = UntTutoringAppTest.DataAccess.Appointments.GetAvailableAppointments(subjectId, timeSlotId, tutorId, selectedDate);
            GvAppointment.DataSource = dt;
            GridBindTutorTimes(dt);

        }

        protected void DdlTutors_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime SelectedDate = Cal_Appoitments.SelectedDate;
            string SelectedDate2 = SelectedDate.Date.ToShortDateString();

            string SelectedTime = DdlTimes.SelectedValue;

            string SelectedTutor = DdlTutors.SelectedValue;


            int subjectId = Convert.ToInt32(Request.QueryString["SubjectId"]);
            int timeSlotId = Convert.ToInt32(DdlTimes.SelectedValue);
            string tutorId = DdlTutors.SelectedValue;
            DateTime selectedDate = Cal_Appoitments.SelectedDate;


            DataTable dt = UntTutoringAppTest.DataAccess.Appointments.GetAvailableAppointments(subjectId, timeSlotId, tutorId, selectedDate);
            GvAppointment.DataSource = dt;
            GridBindTutorTimes(dt);

        }

        protected void GridBindTutorTimes(DataTable dt)
        {
            
            GvAppointment.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                GvAppointment.DataSource = dt;
                GvAppointment.DataBind();
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("AppointDate", typeof(string)));
                dt.Columns.Add(new DataColumn("Time", typeof(string)));
                dt.Columns.Add(new DataColumn("Id", typeof(string)));
                dt.Rows.Add(dt.NewRow());
                //dt.Rows.Add(dt.NewRow());
                GvAppointment.DataSource = dt;
                GvAppointment.DataBind();

                GvAppointment.Rows[0].Cells.Clear();
                GvAppointment.Rows[0].Cells.Add(new TableCell());
                GvAppointment.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GvAppointment.Rows[0].Cells[0].Text = "Date Not Available";
                GvAppointment.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void GvAppointment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try { 
            int TutorAvailableId = Convert.ToInt32(e.CommandArgument);
            if (TutorAvailableId > 0)
            {
                    string subId = Request.QueryString["SubjectId"];
                Response.Redirect("~/ConfirmAppointment?DateId=" + (TutorAvailableId).ToString() + "&SubjectId=" +subId );
            }
        }catch
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("AppointDate", typeof(string)));
                dt.Columns.Add(new DataColumn("Time", typeof(string)));
                dt.Columns.Add(new DataColumn("Id", typeof(string)));
                dt.Rows.Add(dt.NewRow());
                //dt.Rows.Add(dt.NewRow());
                GvAppointment.DataSource = dt;
                GvAppointment.DataBind();

                GvAppointment.Rows[0].Cells.Clear();
                GvAppointment.Rows[0].Cells.Add(new TableCell());
                GvAppointment.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GvAppointment.Rows[0].Cells[0].Text = "Date Not Available";
                GvAppointment.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }
        }
    }
}