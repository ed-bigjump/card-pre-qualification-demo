using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CreditCard.PreQualification.Demo.Web.Infrastructure.IpAddress
{
    public class ClientIpAddressService : IClientIpAddressService
    {
        private readonly IHttpContextAccessor _accessor;

        public ClientIpAddressService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string ClientIpAddress 
        { 
            get 
            {
                //Get from X-Forwarded header when hosted behind load balancer
                var forwardedIp = string.Join(",", _accessor.HttpContext.Request.Headers["X-Forwarded-For"].Select(x => x).ToArray());
                if (!string.IsNullOrWhiteSpace(forwardedIp)) return forwardedIp;

                var remoteIp = _accessor.HttpContext.Connection.RemoteIpAddress;
                return remoteIp != null ? remoteIp.ToString() : null; 
            } 
        }
    }
}
