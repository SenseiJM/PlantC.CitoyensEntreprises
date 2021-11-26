using PlantC.CitoyensEntreprise.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Localisation {
    public class LocalisationUpdateRequestDTO {
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomLocalite { get; set; }

        [Required]
        public uint CodePostal { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }
    }
}