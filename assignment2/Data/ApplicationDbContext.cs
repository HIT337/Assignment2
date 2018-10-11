using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using assignment2.Models;

namespace assignment2.Data
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

            public DbSet<assignment2.Models.Coach> Coach { get; set; }
        public DbSet<assignment2.Models.Event> Event { get; set; }
        public DbSet<assignment2.Models.Member> Member { get; set; }
        public DbSet<assignment2.Models.Schedule> Schedule { get; set; }
    }

}
