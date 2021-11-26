using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;

namespace PlantC.CitoyensEntreprises.API.DTO.ProjetParticipant {
    public class ProjetParticipantIndexDTO {
        
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int ProjetId { get; set; }
        public double Contribution { get; set; }
        public DateTime DateContribution { get; set; }

    }
}