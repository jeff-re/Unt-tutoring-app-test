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


       

        public DataContract.AppointmentsInfo getAppointment(DataContract.AppointmentsInfo appointmentsInfo)
        {
            DataContract.AppointmentsInfo appointment = new DataContract.AppointmentsInfo();
            var timeId = appointmentsInfo.TimeId;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from Drivers where Id = @Id;";
                    cmd.Parameters.AddWithValue("@Id", timeId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointment.SubjectName = (string)reader["FirstName"];

                    }
                }
            }

            return appointmentsInfo;
        }


    }
}
