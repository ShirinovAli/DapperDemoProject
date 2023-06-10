using DapperDemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DapperDemoProject.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
