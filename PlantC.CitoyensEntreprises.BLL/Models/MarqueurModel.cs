using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class MarqueurModel {
        public int IdProjet { get; set; }
        public string Infrastructure { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
