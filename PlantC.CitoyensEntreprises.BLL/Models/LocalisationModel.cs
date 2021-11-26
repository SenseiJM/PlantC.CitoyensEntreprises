using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class LocalisationModel {
        public int Id { get; set; }
        public string NomLocalite { get; set; }
        public uint CodePostal { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
