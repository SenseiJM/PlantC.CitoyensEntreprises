using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Participant {
        public int Id { get; set; }
        public Fonction Fonction { get; set; }
        public string NomEntreprise { get; set; }
        public string BCE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public int? IdAdresse { get; set; }

    }
}
