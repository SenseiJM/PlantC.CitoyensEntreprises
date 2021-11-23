using PlantC.CitoyensEntreprise.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Participant {
    public class ParticipantAddDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        public Fonction Fonction { get; set; }

        [Required]
        public string NomEntreprise { get; set; }

        public uint? BCE { get; set; }

        [Required]
        public int IdContact { get; set; }

    }
}
