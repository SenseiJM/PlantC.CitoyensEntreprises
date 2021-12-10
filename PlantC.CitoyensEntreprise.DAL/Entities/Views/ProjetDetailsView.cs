using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Entities.Views {
    public class ProjetDetailsView {

        public int Id { get; set; }
        public List<string> ImagesURLs { get; set; }
        public string Titre { get; set; }
        public string Localite { get; set; }
        public string Description { get; set; }
        public decimal CoutDuProjet { get; set; }
        public decimal MontantRecolte { get; set; }
        public decimal TonnesCO2 { get; set; }

    }
}
