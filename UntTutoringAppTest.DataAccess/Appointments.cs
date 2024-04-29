using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntTutoringAppTest.DataAccess
{
    public class Appointments
    {

        static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetSubjects()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT Id,SubjectName FROM [dbo].[Subject]";

                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }




        public static DataTable GetAvailableAppointments(int subjectId, int timeSlotId, string tutorId,DateTime selectedDate)
        {
            
            string Date;
            DateTime thisDay = DateTime.Today;
            if (selectedDate <= thisDay)
            {
               
                Date = thisDay.Date.ToShortDateString();

            }

            else
            {
                Date = selectedDate.Date.ToShortDateString();
            }

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                if((timeSlotId <= 0) && tutorId == "0")
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT ta.Id,ta.AppointDate,t.TimeStart + ' - ' + t.TimeEnd As Time " +
                            "FROM [dbo].[TutorAvailable] AS ta " +
                            "INNER JOIN [dbo].[TutorSubject] AS ts " +
                            "ON ta.TutorId = ts.TutorID " +
                            "INNER JOIN [dbo].[TimeSlots] AS t " +
                            "ON ta.TimeSlotId = t.Id " +
                            //"WHERE ta.AppointDate = @appointmentDate ";
                            "WHERE ts.SubjectID = @subjectID AND ta.AppointDate = @appointmentDate AND ta.IsActive = 1 AND ta.IsBooked = 0 ";

                        cmd.Parameters.AddWithValue("@subjectID", subjectId);
                        cmd.Parameters.AddWithValue("@timeSlotID", timeSlotId);
                        cmd.Parameters.AddWithValue("@appointmentDate", Date);
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                        return dt;
                    }
                }

                if(timeSlotId <=0)
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT ta.Id,ta.AppointDate,t.TimeStart + ' - ' + t.TimeEnd As Time " +
                            "FROM [dbo].[TutorAvailable] AS ta " +
                            "INNER JOIN [dbo].[TutorSubject] AS ts " +
                            "ON ta.TutorId = ts.TutorID " +
                            "INNER JOIN [dbo].[TimeSlots] AS t " +
                            "ON ta.TimeSlotId = t.Id " +
                            //"WHERE ta.TutorId = @tutorID AND ta.AppointDate = @appointmentDate ";
                            "WHERE ts.SubjectID = @subjectID AND ta.TutorId = @tutorID AND ta.AppointDate = @appointmentDate AND ta.IsActive = 1 AND ta.IsBooked = 0 ";

                        cmd.Parameters.AddWithValue("@subjectID", subjectId);
                       
                        cmd.Parameters.AddWithValue("@tutorID", tutorId);
                        cmd.Parameters.AddWithValue("@appointmentDate", Date);
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                        return dt;
                    }

                }

                if(tutorId == "0")
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT ta.Id,ta.AppointDate,t.TimeStart + ' - ' + t.TimeEnd As Time " +
                            "FROM [dbo].[TutorAvailable] AS ta " +
                            "INNER JOIN [dbo].[TutorSubject] AS ts " +
                            "ON ta.TutorId = ts.TutorID " +
                            "INNER JOIN [dbo].[TimeSlots] AS t " +
                            "ON ta.TimeSlotId = t.Id " +
                            //"WHERE ta.TimeSlotId = @timeSlotID AND ta.AppointDate = @appointmentDate ";
                            "WHERE ts.SubjectID = @subjectID AND ta.TimeSlotId = @timeSlotID AND ta.AppointDate = @appointmentDate AND ta.IsActive = 1 AND ta.IsBooked = 0 ";

                        cmd.Parameters.AddWithValue("@subjectID", subjectId);
                        cmd.Parameters.AddWithValue("@timeSlotID", timeSlotId);
                        cmd.Parameters.AddWithValue("@appointmentDate", Date);
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                        return dt;
                    }
                }
                

                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT ta.Id,ta.AppointDate,t.TimeStart + ' - ' + t.TimeEnd As Time " +
                        "FROM [dbo].[TutorAvailable] AS ta " +
                        "INNER JOIN [dbo].[TutorSubject] AS ts " +
                        "ON ta.TutorId = ts.TutorID " +
                        "INNER JOIN [dbo].[TimeSlots] AS t " +
                        "ON ta.TimeSlotId = t.Id " +
                        //"WHERE ta.TimeSlotId = @timeSlotID AND ta.TutorId = @tutorID AND ta.AppointDate = @appointmentDate ";
                        "WHERE ts.SubjectID = @subjectID AND ta.TimeSlotId = @timeSlotID AND ta.TutorId = @tutorID AND ta.AppointDate = @appointmentDate AND ta.IsActive = 1 AND ta.IsBooked = 0 ";

                    cmd.Parameters.AddWithValue("@subjectID", subjectId);
                    cmd.Parameters.AddWithValue("@timeSlotID", timeSlotId);
                    cmd.Parameters.AddWithValue("@tutorID", tutorId);
                    cmd.Parameters.AddWithValue("@appointmentDate", Date);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }


        public static DataTable GetBookedAppointment(string studentId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT ta.AppointDate, a.Subject, a.Time, a.Tutor, a.Id " +
                        "FROM [Appointments] as a INNER JOIN [dbo].[TutorAvailable] AS ta " +
                        "   ON a.TimeId = ta.Id " +
                        "Where a.StudentId = @studentId and a.IsBooked = 1";

                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }

        public static void UpdateApptBooked(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("UPDATE [dbo].[Appointments]");
                    sb.AppendLine("SET IsBooked = 0");
                    sb.AppendLine(" WHERE Id = @Id ");

                    cmd.CommandText = sb.ToString();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }




    }
}
