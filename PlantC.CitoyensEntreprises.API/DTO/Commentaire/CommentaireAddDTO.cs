using PlantC.CitoyensEntreprise.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Commentaire {
    public class CommentaireAddDTO {


        [Required]
        public int Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public string Contenu { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int TaskId { get; set; }
        
        [Required]
        public int AlbumId { get; set; }

    }
}