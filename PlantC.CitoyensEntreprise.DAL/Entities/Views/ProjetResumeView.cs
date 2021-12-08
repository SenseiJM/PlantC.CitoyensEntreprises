﻿namespace PlantC.CitoyensEntreprise.DAL.Entities.Views {
    public class ProjetResumeView {

        public int Id { get; set; }
        public string Titre { get; set; }
        public string FirstImageUrl { get; set; }
        public string Description { get; set; }
        public string NomLocalite { get; set; }
        public decimal CoutDuProjet { get; set; }
        public decimal MontantRecolte { get; set; }
        public string Infrastructure { get; set; }

    }
}
