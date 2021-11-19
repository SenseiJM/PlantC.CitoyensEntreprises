using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Projet_Participant {
        public int IdParticipant { get; set; }
        public int IdProjet { get; set; }
        public double Contribution { get; set; }
        public DateTime DateContribution { get; set; }
    }
}
