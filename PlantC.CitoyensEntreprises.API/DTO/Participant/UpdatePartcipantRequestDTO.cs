using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.API.DTO.Participant
{
    public class UpdatePartcipantRequestDTO
    {
        [Required]
        public Fonction Fonction { get; set; }

        [Required]
        public string NomEntreprise { get; set; }

        public uint? BCE { get; set; }

        [Required]
        public int IdContact { get; set; }
    }
}
