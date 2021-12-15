using PlantC.CitoyensEntreprises.API.DTO.Marqueurs;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class MarqueurMapper {

        public static MarqueursDTO ToMarqueursDTO(this MarqueurModel m) {
            return new MarqueursDTO {
                Latitude = m.Latitude,
                Infrastructure = m.Infrastructure,
                Longitude = m.Longitude,
                Id = m.IdProjet
            };
        }

    }
}
