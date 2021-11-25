using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Utils
{
    public static class ControllerExtensions
    {
        public static int GetUserId(this ControllerBase controller)
        {
            string identifier = controller.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if ( int.TryParse(identifier, out int userId))
            {
                return userId;
            }
            return 0;
        }
    }
}
