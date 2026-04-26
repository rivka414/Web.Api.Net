using Microsoft.EntityFrameworkCore;
using Clean.Core.Entities;

namespace Clean.Core.Data
{
    public class DataContext : DbContext
    {
        // הבנאי שמקבל את ההגדרות מה-Program.cs
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // טבלאות מסד הנתונים
        public DbSet<Baby> Babies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }

        // הערה: הסרנו את OnConfiguring ואת משתני ה-ID הידניים
        // החיבור מנוהל כעת באופן גלובלי דרך ה-Program.cs

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}