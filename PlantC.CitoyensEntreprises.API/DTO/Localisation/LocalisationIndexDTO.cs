using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;

namespace PlantC.CitoyensEntreprises.API.DTO.Localisation {
    public class LocalisationIndexDTO {
        public int Id { get; set; }
        public string NomLocalite { get; set; }
        public uint CodePostal { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}