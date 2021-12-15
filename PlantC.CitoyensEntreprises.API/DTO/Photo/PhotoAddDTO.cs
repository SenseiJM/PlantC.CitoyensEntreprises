namespace PlantC.CitoyensEntreprises.API.DTO.Photo {
    public class PhotoAddDTO {

        public int IdProjet { get; set; }
        public bool IsPublic { get; set; } = true;
        public string Blob { get; set; }

    }
}
