﻿using PlantC.CitoyensEntreprises.API.DTO.Projet;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers
{
    static class ProjetMappers
    {

        public static ProjetModel ToModel(this ProjetAddDTO dto)
        {
            return new ProjetModel
            {
                CoutDuProjet = dto.CoutDuProjet,
                HeuresTravail = dto.HeuresTravail,
                IDLocalisation = dto.IDLocalisation,
                Infrastructure = dto.Infrastructure,
                Reference = dto.Reference,
                TonnesCO2 = dto.TonnesCO2,
                NbArbres = dto.NbArbres,
                NbFruits= dto.NbFruits,
                Metres= dto.Metres,
                Hectares= dto.Hectares,
                Titre = dto.Titre,
                Description = dto.Description
            };
        }

        public static ProjetModel UpdateRequestToModel(this ProjetUpdateRequestDTO dto)
        {
            return new ProjetModel
            {
                HeuresTravail = dto.HeuresTravail,
                IDLocalisation = dto.IDLocalisation,
                Infrastructure = dto.Infrastructure,
                Reference = dto.Reference,
                TonnesCO2 = dto.TonnesCO2,
                Hectares = dto.Hectares,
                Metres = dto.Metres,
                NbFruits = dto.NbFruits,
                NbArbres = dto.NbArbres,
                CoutDuProjet = dto.CoutDuProjet,
                Description = dto.Description,
                Titre = dto.Titre
            };
        }

        public static ProjetDetailsDTO ToDetailsDTO(this ProjetDetailsModel model) {
            return new ProjetDetailsDTO {
                CoutDuProjet = model.CoutDuProjet,
                Description = model.Description,
                Id = model.Id,
                ImagesURLs = model.ImagesURLs,
                Localite = model.Localite,
                MontantRecolte = model.MontantRecolte,
                Titre = model.Titre,
                TonnesCO2 = model.TonnesCO2,
                ListeTags = model.ListeTags
            };
        }

        public static ProjetResumeDTO ToResumeDTO(this ProjetResumeModel model) {
            return new ProjetResumeDTO {
                CoutDuProjet = model.CoutDuProjet,
                Description = model.Description,
                FirstImageUrl = model.FirstImageUrl,
                Id = model.Id,
                MontantRecolte = model.MontantRecolte,
                NomLocalite = model.NomLocalite,
                Titre = model.Titre,
                Infrastructure = model.Infrastructure
            };
        }

    }
}
