using PlantC.CitoyensEntreprises.API.DTO.Task;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ProjetParticipantMapper {

        public static ProjetParticipantModel ToModel(this ProjetParticipantAddDTO dto) {
            return new ProjetParticipantModel {
                Id = dto.Id,
                ParticipantId = dto.ParticipantId,
                ProjetId = dto.ProjetId,
                Contribution = dto.Contribution,
                DateContribution = dto.DateContribution
            };
        }


        public static ProjetParticipantIndexDTO ToIndexDTO(this ProjetParticipantModel c)
        {
            return new ProjetParticipantIndexDTO
            {
                Id = c.Id,
                ParticipantId = c.ParticipantId,
                ProjetId = c.ProjetId,
                Contribution = c.Contribution,
                DateContribution = c.DateContribution
            };
        }
        public static ProjetParticipantModel UpdateRequestToModel(this ProjetParticipantUpdateRequestDTO dto) {
            return new ProjetParticipantModel {
                Id = dto.Id,
                ParticipantId = dto.ParticipantId,
                ProjetId = dto.ProjetId,
                Contribution = dto.Contribution,
                DateContribution = dto.DateContribution
            };
        }

    }
}
