using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TripodInsuranceBrokersKano.Infrastructure.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;

        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUser() => _context.HttpContext.User?.Identity?.Name ?? "Anonymous";
    }
}
