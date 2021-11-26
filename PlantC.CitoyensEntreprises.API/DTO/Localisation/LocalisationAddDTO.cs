using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Localisation {
    public class LocalisationAddDTO {
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