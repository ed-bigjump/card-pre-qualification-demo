using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCard.PreQualification.Demo.Web.Data
{
    public class CustomerApplication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual int AnnualIncome { get; set; }

        //TODO - in future could be a Foreign key association if Cards are stored in the DB
        public virtual string RecommendedCards { get; set; }

        public virtual string IpAddress { get; set; }

        public virtual DateTime CreatedDate { get; set; }
    }
}
