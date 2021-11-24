using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class TaskService {

        private readonly TaskRepository _taskRepository;

        public TaskService(TaskRepository TaskRepository) {
            _TaskRepository = TaskRepository;
        }

        public int Create(TaskModel model) {
            return _taskRepository.Create(model.ToEntity());
        }

        public bool Delete(int id) {
            return _taskRepository.Delete(id);
        }
    }
}