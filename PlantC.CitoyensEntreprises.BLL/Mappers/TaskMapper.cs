using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class TaskMapper {

        public static Task ToEntity(this TaskModel model) {
            return new Task {
                Id = model.Id,
                UserId = model.UserId,
                ProjetId = model.ProjetId,
                NomTache = model.NomTache,
                TaskType = model.TaskType,
                Date = model.Date
            };
        }
        public static TaskModel ToSimpleModel(this Task c)
        {
            return new TaskModel
            {
                Id = c.Id,
                UserId = c.UserId,
                ProjetId = c.ProjetId,
                NomTache = c.NomTache,
                TaskType = c.TaskType,
                Date = c.Date
            };
        }

    }
}