using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class LocalisationMapper {

        public static LocalisationZipModel ToSimpleModel(this LocalisationZipView lzv) {
            return new LocalisationZipModel {
                CodePostal = lzv.CodePostal,
                Id = lzv.Id,
                Villes = lzv.Villes
            };
        }

        public static LocalisationGeoCodeModel ToSimpleModel(this LocalisationGeoCode geo) {
            return new LocalisationGeoCodeModel {
                DisplayName = geo.DisplayName,
                Latitude = geo.Lat,
                Longitude = geo.Lon
            };
        }

    }
}
