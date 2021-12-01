using System;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Tache
{
    public class TacheAddDTO
    {
        [Required]
        public int Id_Participant { get; set; }
        [Required]
        public string Intitule { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        [Required]
        public int Id_Projet { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Id_localisation { get; set; }
        [Required]
        public string Description { get; set; }
    }

}
