﻿using PlantC.CitoyensEntreprises.API.DTO.Participant;
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

    }
}