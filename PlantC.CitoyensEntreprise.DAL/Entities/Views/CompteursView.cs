namespace PlantC.CitoyensEntreprise.DAL.Entities.Views {
    public class CompteursView {

        public int Id { get; set; }
        public int? NbArbres { get; set; }
        public decimal TonnesCO2 { get; set; }
        public decimal? TotalContribution { get; set; }
        public decimal CoutDuProjet { get; set; }

    }
}
