using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Participant;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;

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

    }
}
