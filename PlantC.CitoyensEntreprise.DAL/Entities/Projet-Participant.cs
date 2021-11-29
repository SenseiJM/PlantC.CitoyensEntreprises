using System;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Projet_Participant {
        public int IdParticipant { get; set; }
        public int IdProjet { get; set; }
        public double Contribution { get; set; }
        public DateTime DateContribution { get; set; }
        public bool IsFavorite { get; set; }
    }
}
