using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Projet;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LocalisationController : ControllerBase {

    private readonly LocalisationService _localisationService;

        public LocalisationController(LocalisationService localisationService) {
            _localisationService = localisationService;
        }

        [HttpPost]
        public IActionResult Create(LocalisationAddDTO dto) {
            return Ok(_localisationService.Create(dto.ToModel()));
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<LocalisationIndexDTO> dto = _localisationService.GetAll().Select(c => c.ToIndexDTO());
            return Ok(dto);
        }
        
        [HttpGet("byID/{id}")]
        public IActionResult GetByID(int id) {
            LocalisationIndexDTO dto = _localisationService.GetByID(id).ToIndexDTO();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, LocalisationUpdateRequestDTO dto) {
            _localisationService.Update(id, dto.UpdateRequestToModel());
            return Ok(new { message = "Localisation updated succesfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _localisationService.Delete(id);
            return Ok(new { message = "Localisation deleted successfully" });
        }

    }
}