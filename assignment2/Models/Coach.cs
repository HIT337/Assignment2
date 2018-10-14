using System;
using System.Collections.Generic;

namespace assignment2.Models
{
    public partial class Coach
    {
        public int CoachId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Dob { get; set; }
        public string Biography { get; set; }
		public String UserId { get; set; }
	}
}
