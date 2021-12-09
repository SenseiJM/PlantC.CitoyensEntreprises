using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Login {
    public class RegisterDTO
    {

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        public string Telephone { get; set; }

        public int? IdAdresse { get; set; }
        public string MdpContact { get; set; }

    }
}
