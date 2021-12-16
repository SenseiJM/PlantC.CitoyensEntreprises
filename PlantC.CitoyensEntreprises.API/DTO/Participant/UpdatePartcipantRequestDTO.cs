using PlantC.CitoyensEntreprise.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Participant {
    public class UpdatePartcipantRequestDTO
    {

        public Fonction Fonction { get; set; }
        [MaxLength(255)]
        [MinLength(2)]
        public string? NomEntreprise { get; set; }
        [MaxLength(10)]
        public string? BCE { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Prenom { get; set; }
        [MaxLength(15)]
        public string Telephone { get; set; }
        [MaxLength(255)]
        [MinLength(2)]
        public string AdressLine1 { get; set; }
        [MaxLength(255)]
        [MinLength(2)]
        public string? AdressLine2 { get; set; }

        public string Number { get; set; }
        [MaxLength(6)]
        public string ZipCode { get; set; }

        [MaxLength(255)]
        [MinLength(2)]
        public string City { get; set; }

        [MaxLength(255)]
        [MinLength(2)]
        public string Country { get; set; }
        public int IdAdresse { get; set; }
    }
}
