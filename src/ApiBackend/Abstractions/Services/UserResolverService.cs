using Microsoft.AspNetCore.Http;

namespace apibackend.Abstractions.Services
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
