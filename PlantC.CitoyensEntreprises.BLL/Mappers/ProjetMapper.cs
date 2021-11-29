using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

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
                NbArbres = p.NbArbres,
                Contribution = p.Contribution
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
                Contribution = model.Contribution
            };
        }

    }
}
