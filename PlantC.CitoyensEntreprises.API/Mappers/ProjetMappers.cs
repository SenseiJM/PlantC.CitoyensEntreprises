using PlantC.CitoyensEntreprises.API.DTO.Projet;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ProjetMappers {

        public static ProjetIndexDTO ToIndexDTO(this ProjetModel model) {
            return new ProjetIndexDTO {
                Localite = model.Localite,
                ObjectifMonetaire = model.ObjectifMonetaire,
                SommeRecoltee = model.SommeRecoltee,
                StatutProjet = model.StatutProjet,
                Titre = model.Titre,
                TypeProjet = model.TypeProjet
            };
        }

    }
}
