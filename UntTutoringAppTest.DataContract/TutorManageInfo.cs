using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntTutoringAppTest.DataContract
{
    public class TutorManageInfo
    {
        public int Id { get; set; }
        public string TutorId { get; set; }
        public int TimeslotId { get; set; }
        public DateTime AppointDate { get; set; }

    }
}
