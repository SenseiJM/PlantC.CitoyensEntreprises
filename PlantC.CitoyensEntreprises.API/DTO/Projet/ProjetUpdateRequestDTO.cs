using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet
{
    public class ProjetUpdateRequestDTO
    {

        [Required]
        public string Reference { get; set; }

        [Required]
        public string Infrastructure { get; set; }

        [Required]
        public double Quantite { get; set; }

        [Required]
        public string UniteDeMesure { get; set; }

        [Required]
        public int IDLocalisation { get; set; }

        [Required]
        public double TonnesCO2 { get; set; }

        [Required]
        public double HeuresTravail { get; set; }

        [Required]
        public double CoutDuProjet { get; set; }
        public double Contribution { get; internal set; }
        public double Hectares { get; internal set; }
        public int Metres { get; internal set; }
        public int NbFruits { get; internal set; }
        public int NbArbres { get; internal set; }
        public int Id { get; internal set; }
    }
}
