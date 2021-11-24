using PlantC.CitoyensEntreprises.API.DTO.Participant;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ParticipantMapper {

        public static ParticipantModel ToModel(this ParticipantAddDTO dto) {
            return new ParticipantModel {
                BCE = dto.BCE,
                Fonction = dto.Fonction,
                Id = dto.Id,
                NomEntreprise = dto.NomEntreprise,
                Mail = dto.Mail,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Telephone = dto.Telephone,
                IdAdresse = dto.IdAdresse
            };
        }

        public static ParticipantIndexDTO ToIndexDTO(this ParticipantModel model) {
            return new ParticipantIndexDTO {
                BCE = model.BCE,
                Fonction = model.Fonction,
                Id = model.Id,
                NomEntreprise = model.NomEntreprise,
                Mail = model.Mail,
                IdAdresse = model.IdAdresse,
                Telephone = model.Telephone,
                Nom = model.Nom,
                Prenom = model.Prenom
            };
        }
        public static ParticipantModel UpdateRequestToModel(this UpdatePartcipantRequestDTO dto)
        {
            return new ParticipantModel
            {
                Fonction = dto.Fonction,
                NomEntreprise = dto.NomEntreprise,
                BCE = dto.BCE,
                Prenom = dto.Prenom,
                Telephone = dto.Telephone,
                IdAdresse = dto.IdAdresse,
                Nom = dto.Nom,
                Mail = dto.Mail,
                Id = dto.Id
            };
        }
    }
}
