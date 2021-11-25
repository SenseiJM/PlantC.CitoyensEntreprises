using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.API.Attribut
{
    public class ApiAuthorizationAttribute : Attribute
    {
        private string[] _roles { get; set; }
        public ApiAuthorizationAttribute(params string[] lvlUsers)
        {
            _roles = lvlUsers;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            foreach (string role in _roles)
            {
                if (context.HttpContext.User.IsInRole(role)) 
                {
                    return; 
                }
            }
            context.Result = new UnauthorizedResult(); 
        }
    }
}
