using PlantC.CitoyensEntreprise.DAL;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class AlbumModel {
        public int Id { get; set; }
        public int ProjetId { get; set; }
        public string URLPhoto { get; set; }
        public bool IsPublic { get; set; }
    }
}