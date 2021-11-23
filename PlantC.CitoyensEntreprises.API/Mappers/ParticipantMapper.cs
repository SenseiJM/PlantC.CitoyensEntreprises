using PlantC.CitoyensEntreprises.API.DTO.Participant;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ParticipantMapper {

        public static ParticipantModel ToModel(this ParticipantAddDTO dto) {
            return new ParticipantModel {
                BCE = dto.BCE,
                Fonction = dto.Fonction,
                Id = dto.Id,
                IdContact = dto.IdContact,
                NomEntreprise = dto.NomEntreprise
            };
        }

        public static ParticipantIndexDTO ToIndexDTO(this ParticipantModel model) {
            return new ParticipantIndexDTO {
                BCE = model.BCE,
                Fonction = model.Fonction,
                Id = model.Id,
                IdContact = model.IdContact,
                NomEntreprise = model.NomEntreprise
            };
        }
        public static ParticipantModel UpdateRequestToModel(this UpdatePartcipantRequestDTO dto)
        {
            return new ParticipantModel
            {
                Fonction = dto.Fonction,
                NomEntreprise = dto.NomEntreprise,
                IdContact = dto.IdContact,
                BCE = dto.BCE,
            };
        }
    }
}
