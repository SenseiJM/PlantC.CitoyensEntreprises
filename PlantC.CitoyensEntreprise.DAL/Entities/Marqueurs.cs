using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Marqueurs
    {
        public int Id { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Infrastructure { get; set; }
    }
}
