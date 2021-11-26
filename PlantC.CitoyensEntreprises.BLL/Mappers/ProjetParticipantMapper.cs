using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class ProjetParticipantMapper {

        public static ProjetParticipant ToEntity(this ProjetParticipantModel model) {
            return new ProjetParticipant {
                Id = model.Id,
                ParticipantId = model.ParticipantId,
                ProjetId = model.ProjetId,
                Contribution = model.Contribution,
                DateContribution = model.DateContribution
            };
        }
        public static ProjetParticipantModel ToSimpleModel(this ProjetParticipant c)
        {
            return new ProjetParticipantModel
            {
                Id = c.Id,
                ParticipantId = c.ParticipantId,
                ProjetId = c.ProjetId,
                Contribution = c.Contribution,
                DateContribution = c.DateContribution
            };
        }

    }
}