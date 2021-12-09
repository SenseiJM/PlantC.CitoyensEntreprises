using PlantC.CitoyensEntreprise.DAL.Enums;
using System;

namespace PlantC.CitoyensEntreprise.DAL.Entities.Views {
    public class TacheDetails {
        public int Id { get; set; }
        public int? Id_Participant { get; set; }
        public DateTime? Date_Debut { get; set; }
        public DateTime? Date_Fin { get; set; }
        public int Id_Projet { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Est_Assigne { get; set; }
        public bool Est_Termine { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public Fonction Fonction { get; set; }
        public string Reference { get; set; }
        public string Titre { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
