using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ProjetModel {

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Localite { get; set; }
        public TypeProjet TypeProjet { get; set; }
        public StatutProjet StatutProjet { get; set; }
        public double ObjectifMonetaire { get; set; }
        public double SommeRecoltee { get; set; }

    }
}
