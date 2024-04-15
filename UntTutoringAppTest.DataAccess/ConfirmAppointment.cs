using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntTutoringAppTest.DataAccess
{
    public class ConfirmAppointment
    {
        static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


       

        public static DataContract.AppointmentsInfo getAppointment(int timeId, int subid)
        {
            DataContract.AppointmentsInfo appointment = new DataContract.AppointmentsInfo();
            //var timeId = appointmentsInfo.TimeId;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT ta.AppointDate,ts.TimeStart + ' - ' + ts.TimeEnd AS TimeSlot,sub.SubjectName, LEFT(Email, CHARINDEX('@', Email) - 1) AS Name " +
                        "FROM [dbo].[TutorAvailable] AS ta " +
                        "INNER JOIN [dbo].[TimeSlots] AS ts  " +
                        "ON ta.TimeSlotId = ts.Id  " +
                        "INNER JOIN [dbo].[TutorSubject] AS s  " +
                        "ON ta.TutorId = s.TutorID    " +
                        "INNER JOIN [dbo].[Subject] as sub  " +
                        "ON s.SubjectID = sub.Id  " +
                        "INNER JOIN [dbo].[AspNetUsers] as u " +
                        "ON ta.TutorId = u.Id WHERE ta.Id = @Id AND sub.Id = @SubId;";
                    cmd.Parameters.AddWithValue("@Id", timeId);
                    cmd.Parameters.AddWithValue("@SubId", subid);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointment.TimeId = timeId;
                        appointment.SubjectName = (string)reader["SubjectName"];
                        appointment.TimeSlot = (string)reader["TimeSlot"];
                        appointment.TutorName = (string)reader["Name"];
                        appointment.Date = Convert.IsDBNull(reader["AppointDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["AppointDate"]);

                    }
                }
            }

            return appointment;
        }


        public static int Create(DataContract.AppointmentsInfo appointment)
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Appointments (TimeId,StudentId,SubjectId,Time,Subject,Tutor) output INSERTED.Id" +
                        " VALUES (@TimeId,@StudentId,@SubjectId,@Time,@Subject,@Tutor)";
                    cmd.Parameters.AddWithValue("@TimeId", appointment.TimeId);
                    cmd.Parameters.AddWithValue("@StudentId", appointment.StudentId);
                    cmd.Parameters.AddWithValue("@SubjectId", appointment.SubjectId);
                    cmd.Parameters.AddWithValue("@Time", appointment.TimeSlot);
                    cmd.Parameters.AddWithValue("@Subject", appointment.SubjectName);
                    cmd.Parameters.AddWithValue("@Tutor", appointment.TutorName);

                    int success = (int)cmd.ExecuteScalar();
                    if (success > 0)
                    {
                        UpdateBooked(appointment.TimeId);

                    }


                    return success;
                }
            }

        }

        public static void UpdateBooked(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("UPDATE [dbo].[TutorAvailable]");
                    sb.AppendLine("SET IsBooked = 1");
                    sb.AppendLine(" WHERE Id = @Id ");

                    cmd.CommandText = sb.ToString();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }


    }
}
