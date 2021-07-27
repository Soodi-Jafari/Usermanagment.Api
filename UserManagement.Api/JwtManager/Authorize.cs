using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthManager
{
    public class Authorize : IAuthorizationFilter
    {
		public Authorize()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (!JwtManager.ValidateCurrentToken(filterContext.HttpContext.Request.Headers["Authorization"]))
            {
                filterContext.Result = new UnauthorizedResult();
                //throw new UnauthorizedAccessException();
            }
		}	
	}
}
