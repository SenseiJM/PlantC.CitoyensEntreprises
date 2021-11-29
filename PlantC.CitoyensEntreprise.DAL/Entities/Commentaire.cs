using System;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Commentaire
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int AlbumId { get; set; }

    }
}
