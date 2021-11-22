using PlantC.CitoyensEntreprise.DAL.Entities;
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
                Quantite = p.Quantite,
                Reference = p.Reference,
                TonnesCO2 = p.TonnesCO2,
                UniteDeMesure = p.UniteDeMesure
            };
        }

    }
}
