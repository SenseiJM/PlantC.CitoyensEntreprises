using PlantC.CitoyensEntreprise.DAL.Entities;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class MarqueurModel {
        public int IdProjet { get; set; }
        public string Infrastructure { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public IEnumerable<Tag> ListTags { get; set; }
    }
}
