using Advent.Final.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advent.Final.DataAccess.Context
{
    public class MySqlContext: DbContext
    {
        private readonly string _connectionString = string.Empty;
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public MySqlContext() => _connectionString = "server=localhost;uid=root;pwd=123456789;database=advent";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => new { p.IdUser });
            modelBuilder.Entity<User>().Property(p => p.IdUser).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            base.OnModelCreating(modelBuilder);
        }
    }
}
