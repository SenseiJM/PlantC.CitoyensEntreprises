using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<Projet> ListProjets { get; set; }
    }
}
