using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

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
        public IEnumerable<Tag> ListeTags { get; set; }
        public decimal? Hectares { get; set; }
        public decimal TonnesCO2 { get; set; }
        public decimal HeuresTravail { get; set; }
        public decimal CoutDuProjet { get; set; }
        public decimal Contribution { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
