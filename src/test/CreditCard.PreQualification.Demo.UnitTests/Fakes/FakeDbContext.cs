using CreditCard.PreQualification.Demo.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CreditCard.PreQualification.Demo.UnitTests.Fakes
{
    public class FakeDbContext : DbContext, IDbContext
    {
        public DbSet<CustomerApplication> CustomerApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            base.OnConfiguring(optionsBuilder);
        }

        public override void Dispose()
        {
            Database.EnsureDeleted();
            base.Dispose();
        }
    }
}
