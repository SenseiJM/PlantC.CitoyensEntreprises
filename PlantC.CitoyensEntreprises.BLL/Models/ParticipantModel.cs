using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ParticipantModel {
        public int Id { get; set; }
        public Fonction Fonction { get; set; }
        public string NomEntreprise { get; set; }
        public uint? BCE { get; set; }
        public int IdContact { get; set; }
    }
}
