using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class ProjetParticipantMapper {

        public static Projet_Participant ToEntity(this ProjetParticipantModel model) {
            return new Projet_Participant {
                IsFavorite = model.IsFavorite,
                IsValidated = model.IsValidated,
                Contribution = model.Contribution,
                DateContribution = model.DateContribution,
                IdParticipant = model.IdParticipant,
                IdProjet = model.IdProjet
            };
        }

        public static ProjetParticipantModel ToModel(this Projet_Participant entity) {
            return new ProjetParticipantModel {
                Contribution = entity.Contribution,
                DateContribution = entity.DateContribution,
                IdParticipant = entity.IdParticipant,
                IdProjet = entity.IdProjet,
                IsFavorite = entity.IsFavorite,
                IsValidated = entity.IsValidated
            };
        }

    }
}
