﻿namespace PlantC.CitoyensEntreprises.BLL.Models
{
    public class ProjetModel
    {

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Infrastructure { get; set; }
        public int? NbArbres { get; set; }
        public int? NbFruits { get; set; }
        public int? Metres { get; set; }
        public decimal? Hectares { get; set; }
        public int IDLocalisation { get; set; }
        public decimal TonnesCO2 { get; set; }
        public decimal HeuresTravail { get; set; }
        public decimal CoutDuProjet { get; set; }
        public decimal Contribution { get; set; }

    }
}
