using System;

namespace PlantC.CitoyensEntreprises.API.DTO.Tache
{
    public class TacheAddDTO
    {
        public int Id_Participant { get; set; }
        public string Intitule { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public int Id_Projet { get; set; }
        public string Type { get; set; }
        public int Id_localisation { get; set; }
        public string Description { get; set; }
    }

}
