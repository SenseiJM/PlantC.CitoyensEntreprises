using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Participant {
        public int Id { get; set; }
        public Fonction Fonction { get; set; }
        public string NomEntreprise { get; set; }
        public string BCE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int? IdAdresse { get; set; }
        public string Salt { get; set; }
        public string MdpClient { get; set; }
        public string UserLevel { get; set; }

    }
}
