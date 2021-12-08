using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet {
    public class ProjetUpdateRequestDTO
    {
        [Required]
        public int IDLocalisation { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Infrastructure { get; set; }
        public int? NbArbres { get; set; }
        public int? NbFruits { get; set; }
        public int? Metres { get; set; }
        public decimal? Hectares { get; set; }

        [Required]
        public decimal TonnesCO2 { get; set; }

        [Required]
        public decimal HeuresTravail { get; set; }

        [Required]
        public decimal CoutDuProjet { get; set; }
    }
}
