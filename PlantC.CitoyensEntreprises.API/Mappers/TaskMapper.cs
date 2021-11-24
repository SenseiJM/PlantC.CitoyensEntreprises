using PlantC.CitoyensEntreprises.API.DTO.Task;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class TaskMapper {

        public static TaskModel ToModel(this TaskAddDTO dto) {
            return new TaskModel {
                Id = dto.Id,
                UserId = dto.UserId,
                ProjetId = dto.ProjetId,
                NomTache = dto.NomTache,
                TaskType = dto.TaskType,
                Date = dto.Date
            };
        }


        public static TaskIndexDTO ToIndexDTO(this TaskModel c)
        {
            return new TaskIndexDTO
            {
                Id = c.Id,
                UserId = c.UserId,
                ProjetId = c.ProjetId,
                NomTache = c.NomTache,
                TaskType = c.TaskType,
                Date = c.Date
            };
        }
        public static TaskModel UpdateRequestToModel(this TaskUpdateRequestDTO dto) {
            return new TaskModel {
                Id = dto.Id,
                UserId = dto.UserId,
                ProjetId = dto.ProjetId,
                NomTache = dto.NomTache,
                TaskType = dto.TaskType,
                Date = dto.Date
            };
        }

    }
}
