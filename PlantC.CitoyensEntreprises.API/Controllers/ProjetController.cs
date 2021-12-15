using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Projet;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;
using System.Linq;

namespace PlantC.CitoyensEntreprises.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase
    {

        private readonly ProjetService _projetService;

        public ProjetController(ProjetService projetService)
        {
            _projetService = projetService;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _projetService.DeleteProjet(id);
            return Ok(new { message = "Project deleted successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProjet(int id, ProjetUpdateRequestDTO dto) {
            _projetService.UpdateProjet(id, dto.UpdateRequestToModel());
            return Ok(new { message = "Project updated successfully" });
        }

        [HttpPost]
        public IActionResult Create(ProjetAddDTO dto)
        {
            try
            {
                return Ok(_projetService.Create(dto.ToModel()));
            }
            catch (System.ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("details/{id}")]
        public IActionResult GetDetailsByID(int id) {
            return Ok(_projetService.GetDetailsByID(id).ToDetailsDTO());
        }

        [HttpGet("resume/all")]
        public IActionResult GetAllResume() {
            return Ok(_projetService.GetAllResume().Select(r => r.ToResumeDTO()));
        }

        [HttpGet("resume/{id}")]
        public IActionResult GetResumeByID(int id) {
            return Ok(_projetService.GetResumeByID(id).ToResumeDTO());
        }

        [HttpGet("marqueurs")]
        public IActionResult GetAllMarqueurs() {
            return Ok(_projetService.GetAllMarqueurs());
        }

        [HttpGet("compteurs")]
        public IActionResult GetCompteurs() {
            return Ok(_projetService.GetCompteurs());
        }

    }
}
