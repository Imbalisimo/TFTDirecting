using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
using System.Security.Claims;
using TFTDirecting.Enums;

namespace TFTDirecting.CustomAttributes
{
    public class RoleAuthorizeAttribute: AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly Role requiredRole;
        public RoleAuthorizeAttribute(Role role)
        {
            requiredRole = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == ClaimTypes.Role);
            if (!hasClaim)
            {
                var userRole = (Role)Int32.Parse(context.HttpContext.User.Claims.First().Value);
                if (userRole > requiredRole)
                {
                    context.Result = new UnauthorizedObjectResult(string.Empty);
                    return;
                }
            }
            else
            {
                context.Result = new UnauthorizedObjectResult(string.Empty);
            }
        }
    }

    public enum Role
    {
        SuperAdmin = 0,
        Director = 1,
        Actor = 2
    }
}
