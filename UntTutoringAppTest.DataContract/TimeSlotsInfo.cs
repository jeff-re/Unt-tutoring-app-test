﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntTutoringAppTest.DataContract
{
    public class TimeSlotsInfo
    {
        public int Id { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
