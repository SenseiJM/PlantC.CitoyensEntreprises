﻿namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public bool IsPublic { get; set; }
        public int IdProjet { get; set; }
        public string URLPhoto { get; set; }
    }
}
