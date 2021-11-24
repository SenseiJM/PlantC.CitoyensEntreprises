using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ParticipantModel {
        public int Id { get; set; }
        public Fonction Fonction { get; set; }
        public string NomEntreprise { get; set; }
        public int? BCE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public int? IdAdresse { get; set; }
    }
}
