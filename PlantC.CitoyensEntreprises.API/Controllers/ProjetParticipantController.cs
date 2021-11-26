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
    public class ProjetParticipantController : ControllerBase {

    private readonly ProjetParticipantService _projetParticipantService;

        public ProjetParticipantController(ProjetParticipantService projetParticipantService) {
            _projetParticipantService = projetParticipantService;
        }

        [HttpPost]
        public IActionResult Create(ProjetParticipantAddDTO dto) {
            return Ok(_projetParticipantService.Create(dto.ToModel()));
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<ProjetParticipantIndexDTO> dto = _projetParticipantService.GetAll().Select(c => c.ToIndexDTO());
            return Ok(dto);
        }
        
        [HttpGet("byID/{id}")]
        public IActionResult GetByID(int id) {
            ProjetParticipantIndexDTO dto = _projetParticipantService.GetByID(id).ToIndexDTO();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProjetParticipantUpdateRequestDTO dto) {
            _projetParticipantService.Update(id, dto.UpdateRequestToModel());
            return Ok(new { message = "ProjetParticipant updated succesfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _projetParticipantService.Delete(id);
            return Ok(new { message = "ProjetParticipant deleted successfully" });
        }

    }
}