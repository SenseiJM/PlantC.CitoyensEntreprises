using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet {
    public class ProjetIndexDTO {

        public string Titre { get; set; }
        public string Localite { get; set; }
        public TypeProjet TypeProjet { get; set; }
        public StatutProjet StatutProjet { get; set; }
        public double ObjectifMonetaire { get; set; }
        public double SommeRecoltee { get; set; }

    }
}
