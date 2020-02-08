using Microsoft.EntityFrameworkCore;

namespace CreditCard.PreQualification.Demo.Web.Data
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<CustomerApplication> CustomerApplications { get; set; }
    }
}
