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
    public class AlbumController : ControllerBase {

    private readonly AlbumService _albumService;

        public AlbumController(AlbumService albumService) {
            _albumService = albumService;
        }

        [HttpPost]
        public IActionResult Create(AlbumAddDTO dto) {
            return Ok(_albumService.Create(dto.ToModel()));
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<AlbumIndexDTO> dto = _albumService.GetAll().Select(c => c.ToIndexDTO());
            return Ok(dto);
        }
        
        [HttpGet("byID/{id}")]
        public IActionResult GetByID(int id) {
            AlbumIndexDTO dto = _albumService.GetByID(id).ToIndexDTO();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AlbumUpdateRequestDTO dto) {
            _albumService.Update(id, dto.UpdateRequestToModel());
            return Ok(new { message = "Album updated succesfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _albumService.Delete(id);
            return Ok(new { message = "Album deleted successfully" });
        }

    }
}