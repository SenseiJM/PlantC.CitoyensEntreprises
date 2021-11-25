using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Localisation {
        public int Id { get; set; }
        public string NomLocalite { get; set; }
        public uint CodePostal { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
