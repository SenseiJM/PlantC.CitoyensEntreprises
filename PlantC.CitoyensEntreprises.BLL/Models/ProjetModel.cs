using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ProjetModel {

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Infrastructure { get; set; }
        public double Quantite { get; set; }
        public string UniteDeMesure { get; set; }
        public int IDLocalisation { get; set; }
        public double TonnesCO2 { get; set; }
        public double HeuresTravail { get; set; }
        public double CoutDuProjet { get; set; }

    }
}
