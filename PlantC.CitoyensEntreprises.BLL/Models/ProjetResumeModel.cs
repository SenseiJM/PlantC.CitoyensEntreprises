using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ProjetResumeModel {

        public int Id { get; set; }
        public string Titre { get; set; }
        public string FirstImageUrl { get; set; }
        public string Description { get; set; }
        public string NomLocalite { get; set; }
        public double CoutDuProjet { get; set; }
        public double MontantRecolte { get; set; }

    }
}
