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
    public class TaskController : ControllerBase {

    private readonly TaskService _taskService;

        public TaskController(TaskService taskService) {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult Create(TaskAddDTO dto) {
            return Ok(_taskService.Create(dto.ToModel()));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _taskService.Delete(id);
            return Ok(new { message = "Task deleted successfully" });
        }

    }
}