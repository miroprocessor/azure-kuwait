using Microsoft.EntityFrameworkCore;

namespace CosmosDemo.web.Database
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) :
            base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("employees");

            modelBuilder.Entity<Employee>()
                .ToContainer("employees")
               .HasNoDiscriminator();
        }
    }
}
