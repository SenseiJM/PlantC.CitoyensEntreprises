using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.BLL.Services;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LocalisationController : ControllerBase {

        private readonly LocalisationService _localisationService;

        public LocalisationController(LocalisationService localisationService) {
            _localisationService = localisationService;
        }

        [HttpGet("ByZip")]
        public IActionResult GetAllLocalisationZip() {
            return Ok(_localisationService.GetAllLocalisationZip());
        }

        [HttpGet("GeoCode/{adresse}")]
        public IActionResult GetGeoCode(string adresse) {
            return Ok(_localisationService.GetGeoCode(adresse));
        }

    }
}
