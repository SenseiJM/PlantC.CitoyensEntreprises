using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities.Views {
    public class LocalisationZipView {

        public int Id { get; set; }
        public string CodePostal { get; set; }
        public List<string> Villes { get; set; }

    }
}
