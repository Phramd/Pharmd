using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Models
{
    public class PhramdContext : DbContext
    {
        public PhramdContext(DbContextOptions<PhramdContext> options) : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<CalendarModel> CalendarModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<CalendarModel>().ToTable("CalendarModel");
        }
    }
}