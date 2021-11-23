using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Projet;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase {

        private readonly ProjetService _projetService;

        public ProjetController(ProjetService projetService) {
            _projetService = projetService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            IEnumerable<ProjetIndexDTO> dto = _projetService.GetAll().Select(p => p.ToIndexDTO());
            return Ok(dto);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projetService.DeleteProjet(id);
            return Ok(new { message = "Project deleted successfully" });
        }

        [HttpGet("byID/{id}")]
        public IActionResult GetByID(int id) {
            ProjetIndexDTO dto = _projetService.GetByID(id).ToIndexDTO();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProjet(int id, ProjetUpdateRequestDTO)
        {
            _projetService.UpdateProjet(id, dto);
            return Ok(new { message = "User updated successfully" });
        }
    }
}
