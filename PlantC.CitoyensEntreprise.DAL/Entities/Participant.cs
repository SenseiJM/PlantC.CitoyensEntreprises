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
        public uint BCE { get; set; }
        public int IdContact { get; set; }
    }
}
