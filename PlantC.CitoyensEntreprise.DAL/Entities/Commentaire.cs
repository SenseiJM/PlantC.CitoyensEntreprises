using System;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Commentaire
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public string Auteur { get; set; }
        public int IdTache { get; set; }
        public int IdPhoto { get; set; }
        public string Type { get; set; }
    }
}
