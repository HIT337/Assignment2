using System;
using System.Collections.Generic;

namespace Assignment2.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
    }
}
