using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UntTutoringAppTest.DataAccess
{
    public class Student
    {
        static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static DataContract.StudentInfo Get(int id)
        {

            DataContract.StudentInfo student = new DataContract.StudentInfo();



            return student;
        }

        
    } 
}
