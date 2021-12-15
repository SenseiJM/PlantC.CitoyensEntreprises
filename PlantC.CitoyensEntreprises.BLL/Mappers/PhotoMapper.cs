using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class PhotoMapper {

        public static PhotoModel ToModel(this Photo p) {
            return new PhotoModel {
                IsPublic = p.IsPublic,
                IdProjet = p.IdProjet,
                URLPhoto = p.URLPhoto
            };
        }

    }
}
