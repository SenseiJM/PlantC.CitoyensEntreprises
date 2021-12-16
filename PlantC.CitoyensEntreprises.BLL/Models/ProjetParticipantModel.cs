using System;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ProjetParticipantModel {

        public int IdParticipant { get; set; }
        public int IdProjet { get; set; }
        public double Contribution { get; set; }
        public DateTime DateContribution { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsValidated { get; set; }

    }
}
