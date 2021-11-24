using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Contact;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;
using System.Collections.Generic;
using System.Linq;

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
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            IEnumerable<ContactIndexDTO> dto = _contactService.GetAllContacts().Select(c => c.ToIndexDTO());
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ContactUpdateRequestDTO dto) {
            _contactService.Update(id, dto.UpdateRequestToModel());
            return Ok(new { message = "Contact updated succesfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _contactService.Delete(id);
            return Ok(new { message = "Contact deleted successfully" });
        }

        [HttpGet("byID/{id}")]
        public IActionResult GetByID(int id) {
            ContactIndexDTO dto = _contactService.GetByID(id).ToIndexDTO();
            return Ok(dto);
        }

    }
}
