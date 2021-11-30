using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.API.DTO.Localisation {
    public class LocaliteCodePostalDTO {

        public int Id { get; set; }
        public string CodePostal { get; set; }
        public List<string> Villes { get; set; }

    }
}
