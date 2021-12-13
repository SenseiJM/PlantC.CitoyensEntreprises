using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Email;
using PlantC.CitoyensEntreprises.BLL.Services;
using System;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase {

        private readonly MailService _mailService;

        public EmailController(MailService mailService) {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO dto) {

            try {

                string content = "<div>" +
                $"<p>L'utilisateur {dto.Name} {dto.Surname} vous a envoyé le message suivant : </p>" +
                $"<p>{dto.Content}</p>" +
                "</div>";

                _mailService.SendEmailWithObject(dto.Subject, content, dto.Email, /*Insert email here -> */"");
                return Ok();

            } catch (Exception e) {

                return Problem();
            }

            
        }

    }
}
