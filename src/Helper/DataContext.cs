using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Siemens.Entity;

namespace Siemens.Helper
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("WebApiDatabase");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Discount> Prices{get;set;}
    }
}