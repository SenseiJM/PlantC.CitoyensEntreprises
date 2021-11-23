using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class ParticipantMapper {

        public static Participant ToEntity(this ParticipantModel model) {
            return new Participant {
                BCE = model.BCE,
                Fonction = model.Fonction,
                Id = model.Id,
                IdContact = model.IdContact,
                NomEntreprise = model.NomEntreprise
            };
        }

    }
}
