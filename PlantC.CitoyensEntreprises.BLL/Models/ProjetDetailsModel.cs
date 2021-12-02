﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ProjetDetailsModel {
        public int Id { get; set; }
        public List<string> ImagesURLs { get; set; }
        public string Titre { get; set; }
        public string Localite { get; set; }
        public string Description { get; set; }
        public decimal CoutDuProjet { get; set; }
        public decimal SommeRecoltee { get; set; }
        public decimal TonnesCO2 { get; set; }
    }
}
