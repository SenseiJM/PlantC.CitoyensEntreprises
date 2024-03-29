﻿using PlantC.CitoyensEntreprises.API.DTO.Participant;
using PlantC.CitoyensEntreprises.API.DTO.Projet;
using System;

namespace PlantC.CitoyensEntreprises.API.DTO.Tache
{
    public class TacheIndexDTO
    {
        public int Id { get; set; }
        public int? Id_Participant { get; set; }
        public DateTime? Date_Debut { get; set; }
        public DateTime? Date_Fin { get; set; }
        public int Id_Projet { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Est_Assigne { get; set; }
        public bool Est_Termine { get; set; }
        public ProjetIndexDTO Projet { get; set; }
        public ParticipantIndexDTO Participant { get; set; }
    }
}
