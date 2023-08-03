using Microsoft.EntityFrameworkCore;
using SampleWebapi.Models;

namespace SampleWebapi.Database
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
