using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using PlantC.CitoyensEntreprises.BLL.Services;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class LocalisationMapper {

        public static LocalisationZipModel ToSimpleModel(this LocalisationZipView lzv) {
            return new LocalisationZipModel {
                CodePostal = lzv.CodePostal,
                Id = lzv.Id,
                Villes = lzv.Villes
            };
        }

    }
}
