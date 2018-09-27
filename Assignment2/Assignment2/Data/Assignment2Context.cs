using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

namespace Assignment2.Models
{
    public class Assignment2Context : DbContext
    {
        public Assignment2Context (DbContextOptions<Assignment2Context> options)
            : base(options)
        {
        }

        public DbSet<Assignment2.Models.Coach> Coach { get; set; }

        public DbSet<Assignment2.Models.Event> Event { get; set; }

        public DbSet<Assignment2.Models.Member> Member { get; set; }

        public DbSet<Assignment2.Models.Schedule> Schedule { get; set; }
    }
}
