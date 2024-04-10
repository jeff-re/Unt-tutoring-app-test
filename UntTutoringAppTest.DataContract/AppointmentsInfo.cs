﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntTutoringAppTest.DataContract
{
    public class AppointmentsInfo
    {
        public int SubjectId {  get; set; }
        public int TimeId { get; set; }
        public string SubjectName { get; set; }
        public string TimeSlot { get; set; }
        public DateTime Date { get; set; }
        public string TutorName { get; set; }   
        public string StudentId { get; set;}
    }
}
