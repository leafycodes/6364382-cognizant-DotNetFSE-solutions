using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using System;

namespace YourProjectName.Filters
{
    public class BearerAuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new UnauthorizedObjectResult("Authorization header is missing");
                return;
            }

            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new UnauthorizedObjectResult("Bearer token is missing");
                return;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult("Token is empty");
            }

            base.OnActionExecuting(context);
        }
    }
}