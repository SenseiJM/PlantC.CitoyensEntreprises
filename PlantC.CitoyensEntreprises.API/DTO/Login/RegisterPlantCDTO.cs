using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.API.DTO.Login
{
    public class RegisterPlantCDTO
    {

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(15)]
        public string Telephone { get; set; }
        [Required]
        public Fonction Fonction { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string AdressLine1 { get; set; }
        [MaxLength(255)]
        [MinLength(2)]
        public string? AdressLine2 { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string City { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Country { get; set; }
        [MaxLength(255)]
        [MinLength(2)]
        public string NomEntreprise { get; set; }
        [MaxLength(10)]
        [MinLength(2)]
        public string BCE { get; set; }

    }
}
