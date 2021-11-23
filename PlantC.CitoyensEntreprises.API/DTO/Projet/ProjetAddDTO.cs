using PlantC.CitoyensEntreprise.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet {
    public class ProjetAddDTO {

        [Required]
        public int Id { get; set; }

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

    }
}
