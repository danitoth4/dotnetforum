using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetforum.Api.Requirements
{
    public class OwnerOrAdminRequirementHandler : AuthorizationHandler<OwnerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Level"))
            {
                return Task.CompletedTask;
            }
            if (context.User.Claims.Where(c => c.Type == "Level").First().Value == "Admin")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
