using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class ProjetParticipant {
        
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int ProjetId { get; set; }
        public double Contribution { get; set; }
        public DateTime DateContribution { get; set; }
    }
}
