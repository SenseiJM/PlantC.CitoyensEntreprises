using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Models
{
    public class TacheModel
    {
        public int Id { get; set; }
        public int? Id_Participant { get; set; }
        public DateTime? Date_Debut { get; set; }
        public DateTime? Date_Fin { get; set; }
        public int Id_Projet { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Est_Assigne { get; set; }
        public bool Est_Termine { get; set; }
        public ProjetModel Projet { get; set; }
        public ParticipantModel Participant { get; set; }
    }
}
