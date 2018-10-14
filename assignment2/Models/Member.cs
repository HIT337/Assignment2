using System;
using System.Collections.Generic;

namespace assignment2.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
		public String UserId { get; set; }
	}
}
