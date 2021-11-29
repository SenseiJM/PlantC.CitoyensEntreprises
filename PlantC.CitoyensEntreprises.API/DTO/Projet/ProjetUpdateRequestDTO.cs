using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet
{
    public class ProjetUpdateRequestDTO
    {

        [Required]
        public string Reference { get; set; }

        [Required]
        public string Infrastructure { get; set; }

        [Required]
        public decimal Quantite { get; set; }

        [Required]
        public string UniteDeMesure { get; set; }

        [Required]
        public int IDLocalisation { get; set; }

        [Required]
        public decimal TonnesCO2 { get; set; }

        [Required]
        public decimal HeuresTravail { get; set; }

        [Required]
        public decimal CoutDuProjet { get; set; }
        public decimal Contribution { get; internal set; }
        public decimal Hectares { get; internal set; }
        public int Metres { get; internal set; }
        public int NbFruits { get; internal set; }
        public int NbArbres { get; internal set; }
        public int Id { get; internal set; }
    }
}
