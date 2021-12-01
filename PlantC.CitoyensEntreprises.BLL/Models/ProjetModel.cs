using System;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ProjetModel {

        public int Id { get; set; }
        public int IDLocalisation { get; set; }
        public string Reference { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Infrastructure { get; set; }
        public int? NbArbres { get; set; }
        public int? NbFruits { get; set; }
        public int? Metres { get; set; }
        public double? Hectares { get; set; }
        public double TonnesCO2 { get; set; }
        public double HeuresTravail { get; set; }
        public double CoutDuProjet { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
