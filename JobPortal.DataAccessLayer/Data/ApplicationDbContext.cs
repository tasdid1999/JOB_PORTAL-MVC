using JobPortal.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Catagory> catagories { get; set; }

        public DbSet<Job> jobs { get; set; }

        public DbSet<Apply> jobapplication { get; set; }

        public DbSet<SeekerProfile> seekerprofile { get; set; }
    }
}
