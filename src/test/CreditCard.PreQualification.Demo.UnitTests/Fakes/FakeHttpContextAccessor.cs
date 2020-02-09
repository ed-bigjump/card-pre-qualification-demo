using CreditCard.PreQualification.Demo.Web.Infrastructure.IpAddress;

namespace CreditCard.PreQualification.Demo.UnitTests.Fakes
{
    public class FakeClientIpAddressService : IClientIpAddressService
    {
        private readonly string _ipAddress;

        public FakeClientIpAddressService(string ipAddress)
        {
            _ipAddress = ipAddress;
        }
        public string ClientIpAddress { get { return _ipAddress; } }
    }
}
