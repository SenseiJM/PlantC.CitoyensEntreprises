using PlantC.CitoyensEntreprises.API.DTO.Projet;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ProjetMappers {

        public static ProjetIndexDTO ToIndexDTO(this ProjetModel model) {
            return new ProjetIndexDTO {
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
                ListeTags = model.ListeTags
                
            };
        }

        public static ProjetModel ToModel(this ProjetAddDTO dto) {
            return new ProjetModel {
                CoutDuProjet = dto.CoutDuProjet,
                HeuresTravail = dto.HeuresTravail,
                Id = dto.Id,
                IDLocalisation = dto.IDLocalisation,
                Infrastructure = dto.Infrastructure,
                Reference = dto.Reference,
                TonnesCO2 = dto.TonnesCO2,
                NbArbres = dto.NbArbres,
                NbFruits= dto.NbFruits,
                Metres= dto.Metres,
                Hectares= dto.Hectares,
                Contribution = dto.Contribution
            };
        }

        public static ProjetModel UpdateRequestToModel(this ProjetUpdateRequestDTO dto)
        {
            return new ProjetModel
            {
                CoutDuProjet = dto.CoutDuProjet,
                HeuresTravail = dto.HeuresTravail,
                IDLocalisation = dto.IDLocalisation,
                Infrastructure = dto.Infrastructure,
                Reference = dto.Reference,
                TonnesCO2 = dto.TonnesCO2,
                Contribution = dto.Contribution,
                Hectares = dto.Hectares,
                Metres = dto.Metres,
                NbFruits = dto.NbFruits,
                NbArbres = dto.NbArbres,
                Id = dto.Id
            };
        }

    }
}
