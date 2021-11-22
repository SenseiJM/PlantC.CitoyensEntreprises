using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprises.API.DTO.Projet {
    public class ProjetIndexDTO {

        public uint Id { get; set; }
        public string Reference { get; set; }
        public string Infrastructure { get; set; }
        public double Quantite { get; set; }
        public string UniteDeMesure { get; set; }
        public int IDLocalisation { get; set; }
        public double TonnesCO2 { get; set; }
        public double HeuresTravail { get; set; }
        public double CoutDuProjet { get; set; }

    }
}
