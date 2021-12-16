using PlantC.CitoyensEntreprises.API.DTO.Localisation;
using PlantC.CitoyensEntreprises.API.DTO.Projet;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Linq;

namespace PlantC.CitoyensEntreprises.API.Mappers
{
    static class ProjetMappers
    {
        public static ProjetIndexDTO ToIndexDTO(this ProjetModel model)
        {
            return new ProjetIndexDTO
            {
                CoutDuProjet = model.CoutDuProjet,
                HeuresTravail = model.HeuresTravail,
                Id = model.Id,
                IDLocalisation = model.IDLocalisation,
                Infrastructure = model.Infrastructure,
                Reference = model.Reference,
                TonnesCO2 = model.TonnesCO2,
                Hectares = model.Hectares,
                Metres = model.Metres,
                NbFruits = model.NbFruits,
                NbArbres = model.NbArbres,
                Contribution = model.Contribution,
                ListeTags = model.ListeTags,
                Localisation = model.Localisation == null ? null : new LocalisationDTO {
                    AdressLine1 = model.Localisation.AdressLine1,
                    AdressLine2 = model.Localisation.AdressLine2,
                    Number = model.Localisation.Number,
                    ZipCode = model.Localisation.ZipCode,
                    City = model.Localisation.City,
                    Country = model.Localisation.Country,
                }
            };
        }
        public static ProjetModel ToModel(this ProjetAddDTO dto)
        {
            return new ProjetModel
            {
                CoutDuProjet = dto.CoutDuProjet,
                HeuresTravail = dto.HeuresTravail,
                Infrastructure = dto.Infrastructure,
                TonnesCO2 = dto.TonnesCO2,
                NbArbres = dto.NbArbres,
                NbFruits= dto.NbFruits,
                Metres= dto.Metres,
                Hectares= dto.Hectares,
                Titre = dto.Titre,
                Description = dto.Description,
                Localisation = new LocalisationModel
                {
                    AdressLine1 = dto.Rue,
                    Number = dto.NumeroRue,
                    City = dto.Localite,
                    ZipCode = dto.CodePostal,
                },
                ListeTags = dto.Tag.Select(t => new CitoyensEntreprise.DAL.Entities.Tag
                {
                    Nom = t
                })
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
