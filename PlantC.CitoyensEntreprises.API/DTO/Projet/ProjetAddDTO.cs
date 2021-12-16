﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet
{
    public class ProjetAddDTO
    {

        [Required]
        public string Localite { get; set; }

        [Required]
        public string Rue { get; set; }

        [Required]
        public string NumeroRue { get; set; }

        [Required]
        public string CodePostal { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Infrastructure { get; set; }

        public int? NbArbres { get; set; }

        public int? NbFruits { get; set; }
        public int Metres { get; set; }
        public decimal? Hectares { get; set; }

        [Required]
        public decimal TonnesCO2 { get; set; }

        [Required]
        public decimal HeuresTravail { get; set; }

        [Required]
        public decimal CoutDuProjet { get; set; }

        public decimal Contribution { get; set; }

        public string[] Tag { get; set; }
    }
}
