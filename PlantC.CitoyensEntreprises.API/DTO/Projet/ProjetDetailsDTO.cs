using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet {
    public class ProjetDetailsDTO {

        public int Id { get; set; }
        public List<string> ImagesURLs { get; set; }
        public string Titre { get; set; }
        public string Localite { get; set; }
        public string Description { get; set; }
        public decimal CoutDuProjet { get; set; }
        public decimal SommeRecoltee { get; set; }
        public decimal tonnesCO2 { get; set; }

    }
}
