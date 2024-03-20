using System;
using System.Collections.Generic;
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
            //CurrentDate = DateTime.Today;

        }
        protected void Cal_Appoitments_DayRender(object sender, DayRenderEventArgs e)
        {
            
            DateTime thisDay = DateTime.Today;
            DateTime ndays = thisDay.AddDays(14);


            if (( (e.Day.Date) < (thisDay)) || ((e.Day.Date) > (ndays)))
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
            Response.Write(SelectedDate2);
            Response.Write("\n time");
            string SelectedTime = DdlTimes.SelectedValue;
            Response.Write(SelectedTime);
            Response.Write("\n tutor");
            string SelectedTutor = DdlTutors.SelectedValue;
            Response.Write(SelectedTutor);
            




        }

        protected void DdlTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime SelectedDate = Cal_Appoitments.SelectedDate;
            string SelectedDate2 = SelectedDate.Date.ToShortDateString();
            Response.Write(SelectedDate2);
            Response.Write("\n time");
            string SelectedTime = DdlTimes.SelectedValue;
            Response.Write(SelectedTime);
            Response.Write("\n tutor");
            string SelectedTutor = DdlTutors.SelectedValue;
            Response.Write(SelectedTutor);

        }

        protected void DdlTutors_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime SelectedDate = Cal_Appoitments.SelectedDate;
            string SelectedDate2 = SelectedDate.Date.ToShortDateString();
            Response.Write(SelectedDate2);
            Response.Write("\n time");
            string SelectedTime = DdlTimes.SelectedValue;
            Response.Write(SelectedTime);
            Response.Write("\n tutor");
            string SelectedTutor = DdlTutors.SelectedValue;
            Response.Write(SelectedTutor);

        }
    }
}