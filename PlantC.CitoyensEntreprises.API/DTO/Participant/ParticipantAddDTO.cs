using PlantC.CitoyensEntreprise.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Participant {
    public class ParticipantAddDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        public Fonction Fonction { get; set; }

        public string NomEntreprise { get; set; }
        public int? BCE { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        public string Mail { get; set; }
        public string Telephone { get; set; }
        public int? IdAdresse { get; set; }

    }
}
