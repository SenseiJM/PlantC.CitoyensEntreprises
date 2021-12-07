using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.API.DTO.Marqueurs
{
    public class MarqueursDTO
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Infrastructure { get; set; }
    }
}
