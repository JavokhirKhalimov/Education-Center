using EducationalCenterAPI.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EducationalCenterAPI.Entitys
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? token = context.HttpContext.Request.Headers["usertoken"];
            if (token == null)
            {
                throw new UnauthorizedAccessException("Tizimga kirilmagan!");
            }
            var dataContext = context.HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            bool isActive = dataContext.Users.Any(user => user.UserToken == token);
            if (!isActive)
            {
                throw new UnauthorizedAccessException("Tizimga kirilmagan!");
            }
        }
    }
}
