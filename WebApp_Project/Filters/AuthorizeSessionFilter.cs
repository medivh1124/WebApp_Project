using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp_Project.Filters
{
    public class AuthorizeSessionFilter : IAuthorizationFilter
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizeSessionFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_httpContextAccessor.HttpContext!.Session.GetString("_CurrentUserId") == null)
            {
                context.Result = new UnauthorizedObjectResult(string.Empty);
                return;
            }
        }
    }

    public class AuthorizeSessionAttribute : TypeFilterAttribute
    {
        public AuthorizeSessionAttribute() : base(typeof(AuthorizeSessionFilter))
        {
        }
    }

}
