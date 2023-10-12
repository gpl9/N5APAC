using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (authorizationHeader != "un token")
            {
                context.Result = new ObjectResult(new { Message = "Ocurrió un problema al querer crear un estudiante." })
                {
                    StatusCode = 401
                };
            }
        }

    }
}
