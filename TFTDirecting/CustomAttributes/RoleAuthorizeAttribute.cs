using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
using System.Security.Claims;
using TFTDirecting.Enums;

namespace TFTDirecting.CustomAttributes
{
    public class RoleAuthorizeAttribute: Attribute, IAuthorizationFilter
    {
        private readonly Role requiredRoles;
        public RoleAuthorizeAttribute(Role role)
        {
            requiredRoles = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == ClaimTypes.Role);
            if (hasClaim)
            {
                var userRole = (Role)Int32.Parse(context.HttpContext.User.Claims.First().Value);
                if (!requiredRoles.HasFlag(userRole))
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

    [Flags]
    public enum Role
    {
        SuperAdmin = 1,
        Director = 1 << 1,
        Actor = 1 << 2
    }
}
