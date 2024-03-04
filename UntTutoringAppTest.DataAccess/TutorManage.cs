using System;
using System.Collections.Generic;
using System.Configuration;
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



    }
}
