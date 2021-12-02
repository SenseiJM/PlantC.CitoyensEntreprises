using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class ProjetMapper {

        public static ProjetModel ToSimpleModel(this Projet p) {
            return new ProjetModel {
                CoutDuProjet = p.CoutDuProjet,
                HeuresTravail = p.HeuresTravail,
                Id = p.Id,
                IDLocalisation = p.IDLocalisation,
                Infrastructure = p.Infrastructure,
                Reference = p.Reference,
                TonnesCO2 = p.TonnesCO2,
                Hectares = p.Hectares,
                Metres = p.Metres,
                NbFruits = p.NbFruits,
                NbArbres = p.NbArbres
            };
        }

        public static ProjetResumeModel ToSimpleModel(this ProjetResumeView p) {
            return new ProjetResumeModel {
                CoutDuProjet = p.CoutDuProjet,
                Description = p.Description,
                FirstImageUrl = p.FirstImageUrl,
                Id = p.Id,
                MontantRecolte = p.MontantRecolte,
                NomLocalite = p.NomLocalite,
                Titre = p.Titre
            };
        }

        public static ProjetDetailsModel ToSimpleModel(this ProjetDetailsView p) {
            return new ProjetDetailsModel {
                ImagesURLs = p.ImagesURLs,
                CoutDuProjet = p.CoutDuProjet,
                Description = p.Description,
                Localite = p.Localite,
                SommeRecoltee = p.SommeRecoltee,
                Titre = p.Titre,
                TonnesCO2 = p.TonnesCO2,
                Id = p.Id
            };
        }

        public static MarqueurModel ToSimpleModel(this MarqueurView m) {
            return new MarqueurModel {
                IdProjet = m.IdProjet,
                Latitude = m.Latitude,
                Infrastructure = m.Infrastructure,
                Longitude = m.Longitude
            };
        }

        public static Projet ToEntity(this ProjetModel model) {
            return new Projet {
                Id = model.Id,
                CoutDuProjet = model.CoutDuProjet,
                HeuresTravail = model.HeuresTravail,
                IDLocalisation = model.IDLocalisation,
                Infrastructure = model.Infrastructure,
                Reference = model.Reference,
                TonnesCO2 = model.TonnesCO2,
                NbArbres = model.NbArbres,
                NbFruits = model.NbFruits,
                Metres = model.Metres,
                Hectares = model.Hectares,
                DateCreation = model.DateCreation,
                Description = model.Description,
                Titre = model.Titre,
                Contribution = 0
            };
        }

    }
}
