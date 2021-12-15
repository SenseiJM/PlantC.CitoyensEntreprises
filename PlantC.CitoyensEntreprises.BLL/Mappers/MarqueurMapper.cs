using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class MarqueurMapper {

        public static MarqueurModel ToModel(this Marqueurs m) {
            return new MarqueurModel {
                IdProjet = m.Id,
                Infrastructure = m.Infrastructure,
                Latitude = m.Latitude,
                Longitude = m.Longitude
            };
        }

    }
}
