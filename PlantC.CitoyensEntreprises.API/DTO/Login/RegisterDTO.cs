﻿using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.API.DTO.Login
{
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

        public Adresse Adresse { get; set; }
        public string MdpContact { get; set; }

    }
}
