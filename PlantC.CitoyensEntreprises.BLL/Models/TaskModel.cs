using PlantC.CitoyensEntreprise.DAL;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class TaskModel {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjetId { get; set; }
        public string NomTache { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime Date { get; set; }
    }
}