using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }



        private void BindGrid()
        {
            // Sample data for appointments
            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment { AppointmentID = 1, AppointmentTime = DateTime.Today.AddHours(9) },
                new Appointment { AppointmentID = 2, AppointmentTime = DateTime.Today.AddHours(10) },
                new Appointment { AppointmentID = 3, AppointmentTime = DateTime.Today.AddHours(11) }
            };

            GridView1.DataSource = appointments;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Book")
            {
                int appointmentID = Convert.ToInt32(e.CommandArgument);
                // Logic to book appointment with appointmentID
                // For example, redirect to a booking page with the selected appointmentID
                Response.Redirect($"BookAppointment.aspx?AppointmentID={appointmentID}");
            }
        }

        public class Appointment
        {
            public int AppointmentID { get; set; }
            public DateTime AppointmentTime { get; set; }
        }
    
}
}