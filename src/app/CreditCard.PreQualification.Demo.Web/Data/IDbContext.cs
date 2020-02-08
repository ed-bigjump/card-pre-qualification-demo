using Microsoft.EntityFrameworkCore;

namespace CreditCard.PreQualification.Demo.Web.Data
{
    public interface IDbContext
    {
        DbSet<CustomerApplication> CustomerApplications { get; set; }

        int SaveChanges();
    }
}
