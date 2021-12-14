﻿using PlantC.CitoyensEntreprise.DAL.Entities;
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

        [Required]
        public string MdpContact { get; set; }
        [MaxLength(255)]
        [MinLength(2)]
        public string AdressLine1 { get; set; }
        [MaxLength(255)]
        [MinLength(2)]
        public string? AdressLine2 { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        [MaxLength(255)]
        [MinLength(2)]
        public string City { get; set; }

        [MaxLength(255)]
        [MinLength(2)]
        public string Country { get; set; }

    }
}
