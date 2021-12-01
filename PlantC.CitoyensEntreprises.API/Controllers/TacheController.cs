using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Tache;
using PlantC.CitoyensEntreprises.API.Mappers;
using PlantC.CitoyensEntreprises.BLL.Services;

namespace PlantC.CitoyensEntreprises.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        private readonly TacheService _tacheService;
        public TacheController(TacheService tacheService)
        {
            _tacheService = tacheService;
        }
        // GET: TacheController
        [HttpGet]
        public IActionResult GetAll()
        {
            return null;
        }

        // GET: TacheController/GetById
        [HttpGet("byID/{id}")]
        public IActionResult GetById(int id)
        {
            return null;
        }

        // GET: TacheController/GetById
        [HttpGet("byProjectID/{id}")]
        public IActionResult GetByProjetId(int id)
        {
            return null;
        }

        // POST: TacheController/Create
        [HttpPost]
        public IActionResult Create(TacheAddDTO dto )
        {
            try
            {
                return Ok(_tacheService.Create(dto.ToBLLAdd()));
            }
            catch (System.ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: TacheController/Edit
        [HttpPut("{id}")]
        public IActionResult Edit(int id)
        {
            return null;
        }

        // DELETE: TacheController/Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }

    }
}
