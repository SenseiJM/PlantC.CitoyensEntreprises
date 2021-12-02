namespace PlantC.CitoyensEntreprise.DAL.Entities {
    public class Localisation {
        public int Id { get; set; }
        public string NomLocalite { get; set; }
        public short CodePostal { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
