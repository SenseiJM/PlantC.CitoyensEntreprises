using PlantC.CitoyensEntreprises.API.DTO.ProjetParticipant;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ProjetParticipantMapper {

        public static ProjetParticipantModel ToModel(this ProjetParticipantAddDTO dto) {
            return new ProjetParticipantModel {
                Contribution = dto.Contribution,
                IdParticipant = dto.IdParticipant,
                IdProjet = dto.IdProjet
            };
        }

    }
}
