using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class TaskService {

        private readonly TaskRepository _taskRepository;

        public TaskService(TaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }

        public int Create(TaskModel model) {
            return _taskRepository.Create(model.ToEntity());
        }
        
        public IEnumerable<TaskModel> GetAll() {
            return _taskRepository.GetAll().Select(p => p.ToSimpleModel());
        }

        public TaskModel GetByID(int id) {
            return _taskRepository.GetByID(id).ToSimpleModel();
        }
        
        public bool Update(int id, TaskModel model) {
            return _taskRepository.Update(id, model.ToEntity());
        }

        public bool Delete(int id) {
            return _taskRepository.Delete(id);
        }
    }
}