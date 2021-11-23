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
                Quantite = model.Quantite,
                Reference = model.Reference,
                TonnesCO2 = model.TonnesCO2,
                UniteDeMesure = model.UniteDeMesure
            };
        }

        public static ProjetModel ToModel(this ProjetAddDTO dto) {
            return new ProjetModel {
                CoutDuProjet = dto.CoutDuProjet,
                HeuresTravail = dto.HeuresTravail,
                Id = dto.Id,
                IDLocalisation = dto.IDLocalisation,
                Infrastructure = dto.Infrastructure,
                Quantite = dto.Quantite,
                Reference = dto.Reference,
                TonnesCO2 = dto.TonnesCO2,
                UniteDeMesure = dto.UniteDeMesure
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
                Quantite = dto.Quantite,
                Reference = dto.Reference,
                TonnesCO2 = dto.TonnesCO2,
                UniteDeMesure = dto.UniteDeMesure
            };
        }

    }
}
