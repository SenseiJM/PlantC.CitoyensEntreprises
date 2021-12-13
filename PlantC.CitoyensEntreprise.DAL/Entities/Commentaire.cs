using System;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Commentaire
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int IdParticipant { get; set; }
        public int IdTache { get; set; }
        public int IdPhoto { get; set; }
        public string Type { get; set; }
    }
}
