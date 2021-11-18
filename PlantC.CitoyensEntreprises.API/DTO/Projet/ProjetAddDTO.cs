using PlantC.CitoyensEntreprise.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet {
    public class ProjetAddDTO {

        [Required]
        [MaxLength(100)]
        public string Titre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Localite { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public TypeProjet TypeDeProjet { get; set; }

        [Required]
        public StatutProjet StatutProjet { get; set; }

        [Required]
        public ushort CodePostal { get; set; }

        [Required]
        public string Description { get; set; }
        public uint NbArbresTotal { get; set; }
        public uint NbParticipantsTotal { get; set; }
        public double SommeRecoltee { get; set; }

        [Required]
        public double ObjectifMonetaire { get; set; }

        [Required]
        public uint ObjectifArbres { get; set; }

    }
}
