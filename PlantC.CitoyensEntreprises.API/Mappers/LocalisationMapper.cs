using PlantC.CitoyensEntreprises.API.DTO.Localisation;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class LocalisationMapper {

        public static LocalisationModel ToModel(this LocalisationAddDTO dto) {
            return new LocalisationModel {
                Id = dto.Id,
                NomLocalite = dto.NomLocalite,
                CodePostal = dto.CodePostal,
                Longitude = dto.Longitude,
                Latitude = dto.Latitude
            };
        }


        public static LocalisationIndexDTO ToIndexDTO(this LocalisationModel c)
        {
            return new LocalisationIndexDTO
            {
                Id = c.Id,
                NomLocalite = c.NomLocalite,
                CodePostal = c.CodePostal,
                Longitude = c.Longitude,
                Latitude = c.Latitude
            };
        }
        public static LocalisationModel UpdateRequestToModel(this LocalisationUpdateRequestDTO dto) {
            return new LocalisationModel {
                Id = dto.Id,
                NomLocalite = dto.NomLocalite,
                CodePostal = dto.CodePostal,
                Longitude = dto.Longitude,
                Latitude = dto.Latitude
            };
        }

    }
}
