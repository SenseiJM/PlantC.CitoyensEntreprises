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

    }
}
