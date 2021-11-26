using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprise.DAL.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public int ProjetId { get; set; }
        public string URLPhoto { get; set; }
        public bool IsPublic { get; set; }
    }
}