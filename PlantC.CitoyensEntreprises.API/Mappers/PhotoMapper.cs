using PlantC.CitoyensEntreprises.API.DTO.Photo;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class PhotoMapper {

        public static PhotoDTO ToDTO(this PhotoModel p) {
            return new PhotoDTO {
                IdProjet = p.IdProjet,
                IsPublic = p.IsPublic,
                URLPhoto = p.URLPhoto
            };
        }

    }
}
