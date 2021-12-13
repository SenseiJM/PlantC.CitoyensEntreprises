using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Tache;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;
using System;
using System.Linq;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase {
        private readonly TacheService _tacheService;
        public TacheController(TacheService tacheService) {
            _tacheService = tacheService;
        }
        // GET: TacheController
        [HttpGet]
        public IActionResult GetAll() {
            try {
                if (_tacheService.GetAll().ToDTOIndexList().Count() == 0) {
                    return NotFound("Pas de données");
                }
                return Ok(_tacheService.GetAll().ToDTOIndexList());
            } catch (Exception e) {
                return Problem(e.Message);
            }
        }
        // GET: TacheController/GetById
        [HttpGet("ByID/{id}")]
        public IActionResult GetById(int id) {
            try {
                if (_tacheService.GetById(id) == null) {
                    return NotFound("Pas de données");
                }
                return Ok(_tacheService.GetById(id).ToDTOIndexId());
            } catch (Exception e) {
                return Problem(e.Message);
            }
        }
        // GET: TacheController/GetByProjectId
        [HttpGet("ByProjectID/{id}")]
        public IActionResult GetByProjetId(int id) {
            try {
                if (_tacheService.GetByProjectId(id).Count() == 0) {
                    return NotFound("Pas de données");
                }
                return Ok(_tacheService.GetByProjectId(id).ToDTOIndexList());
            } catch (Exception e) {
                return Problem(e.Message);
            }
        }
        // GET: TacheController/GetByParticipantId
        [HttpGet("ByParticipantID/{id}")]
        public IActionResult GetByParticipantId(int id) {
            try {
                if (_tacheService.GetByParticipantId(id).Count() == 0) {
                    return NotFound("Pas de données");
                }
                return Ok(_tacheService.GetByParticipantId(id).ToDTOIndexList());
            } catch (Exception e) {
                return Problem(e.Message);
            }
        }
        // POST: TacheController/Create
        [HttpPost]
        public IActionResult Create(TacheAddDTO dto) {
            try {
                return Ok(_tacheService.Create(dto.ToBLLAdd()));
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        // POST: TacheController/Edit
        [HttpPut]
        public IActionResult Edit(TacheUpdateRequestDTO dto) {
            try {
                if (!_tacheService.UpDate(dto.ToBLLPut())) {
                    return NotFound("La tache que vous voulez modifier n'existe pas");
                }
                return Ok(_tacheService.UpDate(dto.ToBLLPut()));
            } catch (Exception e) {
                return Problem(e.Message);
            }
        }
        // DELETE: TacheController/Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                if (!_tacheService.Delete(id)) {
                    return NotFound("Pas de donnée à supprimer");
                }
                return Ok(_tacheService.Delete(id));
            } catch (Exception e) {
                return Problem(e.Message);
            }
        }
    }
}
