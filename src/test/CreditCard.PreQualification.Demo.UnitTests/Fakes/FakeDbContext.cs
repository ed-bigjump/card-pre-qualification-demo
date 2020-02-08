using CreditCard.PreQualification.Demo.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CreditCard.PreQualification.Demo.UnitTests.Fakes
{
    public class FakeDbContext : DbContext, IDbContext
    {
        public DbSet<CustomerApplication> CustomerApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("fake-db-context");

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Clears out entities - ensures each test starts with a clean slate
        /// </summary>
        public void Clear()
        {
            foreach (var deposit in CustomerApplications.ToArray())
                CustomerApplications.Remove(deposit);

            SaveChanges();
        }
    }
}
