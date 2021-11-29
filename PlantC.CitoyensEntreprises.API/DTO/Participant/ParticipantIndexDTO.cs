using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprises.API.DTO.Participant {
    public class ParticipantIndexDTO {

        public int Id { get; set; }
        public Fonction Fonction { get; set; }
        public string NomEntreprise { get; set; }
        public string BCE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int? IdAdresse { get; set; }
        public string Token { get; set; }

    }
}
