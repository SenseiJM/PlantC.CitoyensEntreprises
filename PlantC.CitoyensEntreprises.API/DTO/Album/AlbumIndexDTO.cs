using PlantC.CitoyensEntreprise.DAL.Entities;

namespace PlantC.CitoyensEntreprises.API.DTO.Album {
    public class AlbumIndexDTO {
        
        public int Id { get; set; }
        public int ProjetId { get; set; }
        public string URLPhoto { get; set; }
        public bool IsPublic { get; set; }

    }
}