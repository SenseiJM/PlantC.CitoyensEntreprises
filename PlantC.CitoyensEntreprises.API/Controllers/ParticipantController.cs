using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Participant;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase {

        private readonly ParticipantService _participantService;

        public ParticipantController(ParticipantService participantService) {
            _participantService = participantService;
        }

        [HttpPost]
        public IActionResult Create(ParticipantAddDTO dto) {
            return Ok(_participantService.Create(dto.ToModel()));
        }

        [HttpGet("byID/{id}")]
        public IActionResult GetByID(int id) {
            ParticipantIndexDTO dto = _participantService.GetByID(id).ToIndexDTO();
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteParticipant(int id)
        {
            _participantService.DeleteParticipant(id);
            return Ok(new { message = "Participant deleted successfully" });
        }

        [HttpGet]
        public IActionResult GetAll() {
            IEnumerable<ParticipantIndexDTO> dto = _participantService.GetAll().Select(p => p.ToIndexDTO());
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateParticipant(int id, UpdatePartcipantRequestDTO dto)
        {
            _participantService.UpdateParticipant(id, dto.UpdateRequestToModel());
            return Ok(new { message = "Participant updated successfully" });
        }
    }
}
