using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities.Views {
    public class ProjetDetailsView {

        public IEnumerable<string> ImagesURLs { get; set; }
        public string Titre { get; set; }
        public string Localite { get; set; }
        public string Description { get; set; }
        public double CoutDuProjet { get; set; }
        public double SommeRecoltee { get; set; }
        public double TonnesCO2 { get; set; }

    }
}
