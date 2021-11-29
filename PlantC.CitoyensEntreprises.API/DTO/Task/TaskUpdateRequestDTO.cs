using PlantC.CitoyensEntreprise.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Task {
    public class TaskUpdateRequestDTO {

        [Required]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int ProjetId { get; set; }
        
        [Required]
        public string NomTache { get; set; }
        
        [Required]
        public TaskType TaskType { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

    }
}