﻿using PlantC.CitoyensEntreprise.DAL.Entities;
using System.Collections.Generic;

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
        public IEnumerable<Tag> ListeTags { get; set; }
    }
}
