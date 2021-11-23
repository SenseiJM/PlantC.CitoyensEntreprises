﻿using PlantC.CitoyensEntreprise.DAL.Entities;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ContactModel {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public Adresse Adresse { get; set; }
    }
}