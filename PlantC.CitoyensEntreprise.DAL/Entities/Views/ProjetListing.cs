using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities.Views {
    public class ProjetListing {

        public int Id { get; set; }
        public string Reference { get; set; }
        public string imageUrl { get; set; }
        public string Description { get; set; }
        public string NomLocalite { get; set; }
        public double CoutDuProjet { get; set; }
        public double MontantRecolte { get; set; }
        public string Infrastructure { get; set; }
        public bool EstNouveau { get; set; }
        public bool EstFavori { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
