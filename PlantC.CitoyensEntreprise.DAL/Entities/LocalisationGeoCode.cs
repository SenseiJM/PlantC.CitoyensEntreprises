using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class LocalisationGeoCode {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
