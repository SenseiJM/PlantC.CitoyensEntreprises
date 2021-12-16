using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.ProjetParticipant;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;
using System;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetParticipantController : ControllerBase {

        private readonly ProjetParticipantService _ppService;

        public ProjetParticipantController(ProjetParticipantService ppService) {
            _ppService = ppService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_ppService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(ProjetParticipantAddDTO dto) {
            try {

                return Ok(_ppService.Create(dto.ToModel()));

            } catch (Exception e) {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(int id, ProjetParticipantAddDTO dto) {
            return Ok(_ppService.Update(id, dto.ToModel()));
        }

        [HttpPost("validate_contribution")]
        public IActionResult ValidateContribution(int id) {
            try {

                return Ok(_ppService.ValidateContribution(id));

            } catch (Exception e) {

                return BadRequest(e.Message);
            }
        }

    }
}
