namespace PlantC.CitoyensEntreprises.API.DTO.Photo {
    public class PhotoDTO {

        public int IdProjet { get; set; }
        public bool IsPublic { get; set; } = true;
        public string URLPhoto { get; set; }

    }
}
