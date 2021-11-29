using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlantC.CitoyensEntreprises.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
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
        public IActionResult Create()
        {
            return null;
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
