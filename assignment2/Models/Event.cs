using System;
using System.Collections.Generic;

namespace assignment2.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoachId { get; set; }
        public DateTime Date { get; set; }

		public virtual Coach AllocatedCoach { get; set; }
	}
}
