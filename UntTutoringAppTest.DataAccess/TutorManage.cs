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
    public class TutorManage
    {
        static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //test

        public static List<DataContract.TimeSlotsInfo> GetAllTimes()
        {
            var Timeslots = new List<DataContract.TimeSlotsInfo>();

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Id from TimeSlots";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var state = new DataContract.TimeSlotsInfo();
                        state.Id = (int)reader["Id"];

                        Timeslots.Add(state);
                    }
                }
            }

            return Timeslots;
        }

        public static int Create(DataContract.TutorManageInfo tutorAvailable)
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO [dbo].[TutorAvailable]([TutorId],[TimeSlotId],[AppointDate]) output INSERTED.Id" +
                        " VALUES (@TutorId,@TimeSlotId,@AppointDate)";
                    cmd.Parameters.AddWithValue("@TutorId", tutorAvailable.TutorId);
                    cmd.Parameters.AddWithValue("@TimeSlotId", tutorAvailable.TimeslotId);
                    cmd.Parameters.AddWithValue("@AppointDate", tutorAvailable.AppointDate);
              
                    return (int)cmd.ExecuteScalar();
                }
            }

        }

        public static int AddTutorAvailable(DataContract.TutorManageInfo tutorAvailable)
        {
            int cmd = 0;
            var timeSlots = GetAllTimes();


            foreach ( var timeslot in timeSlots)
            {
                tutorAvailable.TimeslotId = (int)timeslot.Id;
                 cmd = Create(tutorAvailable);
            }

            return cmd;
        }

        public static DataTable GetTutorAvailableTimes()
        {
            DateTime CurrentDate = DateTime.Today;
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT ta.Id,ta.AppointDate, ts.TimeStart + ' - ' + ts.TimeEnd As TimeSlot " +
                        "FROM [dbo].[TutorAvailable] AS ta " +
                        "INNER JOIN [dbo].[TimeSlots] AS ts " +
                        " ON ta.TimeSlotId = ts.Id " +
                        "WHERE ta.IsActive = 1 and ta.AppointDate >= @CurrentDate";
                   
                    cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);

                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }


        public static void UpdateTutorStatus(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("UPDATE dbo.TutorAvailable");
                    sb.AppendLine("SET IsActive = 0 ");
                    sb.AppendLine(" WHERE Id = @Id ");

                    cmd.CommandText = sb.ToString();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }


        public static DataTable GetPreferedSubjects(DataContract.TutorManageInfo tutorId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT ts.Id, s.SubjectName FROM [dbo].[TutorSubject] AS ts INNER JOIN [dbo].[Subject] AS s ON ts.SubjectID = s.Id";

                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }

        public static int CreatePreferedSubject(DataContract.TutorManageInfo tutorAvailable)
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO TutorSubject ([TutorId],[SubjectID]) output INSERTED.Id" +
                        " VALUES (@TutorId,@SubjectID)";
                    cmd.Parameters.AddWithValue("@TutorId", tutorAvailable.TutorId);
                    cmd.Parameters.AddWithValue("@SubjectID", tutorAvailable.SubjectId);
             

                    return (int)cmd.ExecuteScalar();
                }
            }

        }

        public static void DeleteSubject(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("DELETE FROM TutorSubject");
                
                    sb.AppendLine("WHERE Id = @Id ");

                    cmd.CommandText = sb.ToString();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }





    }
}
