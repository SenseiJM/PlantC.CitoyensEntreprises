﻿namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Contact {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public Adresse Adresse { get; set; }
    }
}
