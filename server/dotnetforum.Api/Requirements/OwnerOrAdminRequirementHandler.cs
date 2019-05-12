using dotnetforum.BLL.Services;
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
        private readonly IUserService userService;
        private readonly IReviewService reviewService;
        private readonly ICommentService commentService;

        public OwnerOrAdminRequirementHandler(IUserService uService, IReviewService rService, ICommentService cService)
        {
            this.userService = uService;
            this.reviewService = rService;
            this.commentService = cService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement)
        {
            if (context.User.Claims.Where(c => c.Type == "Level").SingleOrDefault()?.Value == "Admin" || await IsOwnerAsync(context.User, context.Resource))
            {
                context.Succeed(requirement);
            }
        }

        private async Task<bool> IsOwnerAsync(ClaimsPrincipal user, object resource)
        {
            if (!(resource is AuthorizationFilterContext))
                return false;
            string resName = (string)((AuthorizationFilterContext)resource).RouteData.Values["controller"];
            int resId = Int32.Parse((string)((AuthorizationFilterContext)resource).RouteData.Values["id"]);

            if (String.IsNullOrWhiteSpace(resName))
                return false;

            try
            {
                int userId = Int32.Parse(user.Claims.Where(c => c.Type == "sub").Single().Value);
                switch (resName.ToLower())
                {
                    case "review":
                        if ( (await reviewService.GetReviewAsync(resId)).UserId.Equals(userId) )
                            return true;
                        break;
                    case "comment":
                        if ((await commentService.GetCommentAsync(resId)).UserId.Equals(userId))
                            return true;
                        break;
                    case "user":
                        if ((await userService.GetUserAsync(resId)).Id.Equals(userId))
                            return true;
                        break;
                    default:
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
