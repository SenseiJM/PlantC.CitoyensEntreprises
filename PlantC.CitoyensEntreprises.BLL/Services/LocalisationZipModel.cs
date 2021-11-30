using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class LocalisationZipModel {
        public int Id { get; set; }
        public string CodePostal { get; set; }
        public List<string> Villes { get; set; }
    }
}