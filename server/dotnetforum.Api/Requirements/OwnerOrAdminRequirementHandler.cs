using dotnetforum.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dotnetforum.Api.Requirements
{
    public class OwnerOrAdminRequirementHandler : AuthorizationHandler<OwnerRequirement>
    {
        private readonly Context context;

        public OwnerOrAdminRequirementHandler(Context context)
        {
            this.context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement)
        {
            /*if (!context.User.HasClaim(c => c.Type == "Level"))
            {
                return Task.CompletedTask;
            }*/
            if (/*context.User.Claims.Where(c => c.Type == "Level").First().Value == "Admin" ||*/ IsOwner(context.User, context.Resource))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool IsOwner(ClaimsPrincipal user, object resource)
        {
            if (!(resource is AuthorizationFilterContext))
                return false;
            string resName = (string)((AuthorizationFilterContext)resource).RouteData.Values["controller"];
            int resId = Int32.Parse((string)((AuthorizationFilterContext)resource).RouteData.Values["id"]);

            if (String.IsNullOrWhiteSpace(resName))
                return false;

            try
            {
                resName = resName.ToLower();
                switch (resName)
                {
                    case "review":
                        break;
                    case "comment":
                        break;
                    case "user":
                        break;
                    case "creation":
                        break;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
