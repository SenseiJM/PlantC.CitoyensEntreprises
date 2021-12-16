using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.ProjetParticipant {
    public class ProjetParticipantAddDTO {

        [Required]
        public int IdParticipant { get; set; }

        [Required]
        public int IdProjet { get; set; }

        [Required]
        public double Contribution { get; set; }

    }
}
