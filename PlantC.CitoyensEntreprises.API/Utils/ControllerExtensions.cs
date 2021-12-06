using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PlantC.CitoyensEntreprises.BLL.Utils
{
    public static class ControllerExtensions
    {
        public static int GetUserId(this ControllerBase controller)
        {
            string identifier = controller.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(identifier, out int userId))
            {
                return userId;
            }
            return 0;
        }
    }
}
