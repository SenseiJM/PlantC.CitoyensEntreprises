using PlantC.CitoyensEntreprise.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Album {
    public class AlbumUpdateRequestDTO {
        
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int ProjetId { get; set; }
        
        [Required]
        public string URLPhoto { get; set; }
        
        [Required]
        public bool IsPublic { get; set; }

    }
}