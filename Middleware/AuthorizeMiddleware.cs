using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using JwtDotNetCore.Services;

namespace JwtDotNetCore.Middleware
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenService _tokenService;

        public AuthorizeMiddleware(RequestDelegate next, ITokenService tokenService)
        {
            _next = next;
            _tokenService = tokenService;
        }

        public async Task Invoke(HttpContext context)
        {
            IHeaderDictionary requestHeaders = context.Request.Headers;

            context.Response.OnStarting(() =>
            {
                if (requestHeaders.TryGetValue("Authorization", out StringValues previousHeader))
                {
                    var previousJwt = new JwtSecurityToken(previousHeader.ToString().Replace("Bearer ", string.Empty));
                    var id = previousJwt.Claims.Where(x => x.Type == "Id").First().Value;

                    var updatedToken = _tokenService.BuildToken(id);

                    context.Response.Headers.Add("Authorization", updatedToken);
                }

                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}