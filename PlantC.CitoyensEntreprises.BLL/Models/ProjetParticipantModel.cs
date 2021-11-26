using PlantC.CitoyensEntreprise.DAL;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ProjetParticipantModel {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int ProjetId { get; set; }
        public double Contribution { get; set; }
        public DateTime DateContribution { get; set; }
    }
}