using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.ProjetParticipant {
    public class ProjetParticipantAddDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        public int ParticipantId { get; set; }

        [Required]
        public int ProjetId { get; set; }

        [Required]
        public double Contribution { get; set; }

        [Required]
        public DateTime DateContribution { get; set; }

    }
}