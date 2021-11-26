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
    public class CommentaireController : ControllerBase {

    private readonly CommentaireService _commentaireService;

        public CommentaireController(CommentaireService commentaireService) {
            _commentaireService = commentaireService;
        }

        [HttpPost]
        public IActionResult Create(CommentaireAddDTO dto) {
            return Ok(_commentaireService.Create(dto.ToModel()));
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<CommentaireIndexDTO> dto = _commentaireService.GetAll().Select(c => c.ToIndexDTO());
            return Ok(dto);
        }
        
        [HttpGet("byID/{id}")]
        public IActionResult GetByID(int id) {
            CommentaireIndexDTO dto = _commentaireService.GetByID(id).ToIndexDTO();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CommentaireUpdateRequestDTO dto) {
            _commentaireService.Update(id, dto.UpdateRequestToModel());
            return Ok(new { message = "Commentaire updated succesfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _commentaireService.Delete(id);
            return Ok(new { message = "Commentaire deleted successfully" });
        }

    }
}