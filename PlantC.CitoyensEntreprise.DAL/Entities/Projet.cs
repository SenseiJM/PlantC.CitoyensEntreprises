using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Projet {

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Localite { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public TypeProjet TypeDeProjet { get; set; }
        public StatutProjet Statut { get; set; }
        public ushort CodePostal { get; set; }
        public string Description { get; set; }
        public uint NbArbresTotal { get; set; }
        public uint NbParticipantsTotal { get; set; }
        public double SommeRecoltee { get; set; }
        public double ObjectifMonetaire { get; set; }
        public uint ObjectifArbres { get; set; }

    }
}
