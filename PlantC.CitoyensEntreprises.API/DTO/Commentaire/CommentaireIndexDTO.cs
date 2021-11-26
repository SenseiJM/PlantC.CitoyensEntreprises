using PlantC.CitoyensEntreprise.DAL.Entities;

namespace PlantC.CitoyensEntreprises.API.DTO.Commentaire {
    public class CommentaireIndexDTO {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int AlbumId { get; set; }
    }
}