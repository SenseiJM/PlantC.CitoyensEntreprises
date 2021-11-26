using PlantC.CitoyensEntreprise.DAL;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class CommentaireModel {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int AlbumId { get; set; }
    }
}