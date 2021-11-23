using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Contact;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase {

        private readonly ContactService _contactService;

        public ContactController(ContactService contactService) {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult Create(ContactAddDTO dto) {
            return Ok(_contactService.Create(dto.ToModel()));
        }

    }
}
