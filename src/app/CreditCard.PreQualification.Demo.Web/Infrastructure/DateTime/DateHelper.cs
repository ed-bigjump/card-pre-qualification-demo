using System;

namespace CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime
{
    public class DateHelper
    {
        public static bool IsValidDateTime(int? day, int? month, int? year)
        {
            var dateString = string.Format("{0}-{1}-{2}", year, month, day);
            return System.DateTime.TryParse(dateString, out var dateTime);
        }

        internal static System.DateTime GetDateTime(int? birthDay, int? birthMonth, int? birthYear)
        {
            throw new NotImplementedException();
        }
    }
}
