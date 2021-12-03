using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet {
    public class ProjetAddDTO {

        [Required]
        public int Id { get; set; }

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
        public double? Hectares { get; set; }

        [Required]
        public double TonnesCO2 { get; set; }

        [Required]
        public double HeuresTravail { get; set; }

        [Required]
        public double CoutDuProjet { get; set; }
    }
}
