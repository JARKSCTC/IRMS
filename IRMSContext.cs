using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS
{
    public class IRMSContext : DbContext
    {
        public IRMSContext(DbContextOptions<IRMSContext> options)
               : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<FamilyDetails> FamilyDetails { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Attendence> Attendence { get; set; }
        public DbSet<EmailTemplates> EmailTemplates { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Menu> Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}