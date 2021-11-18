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
                TypeProjet = p.TypeDeProjet,
                Localite = p.Localite,
                ObjectifMonetaire = p.ObjectifMonetaire,
                SommeRecoltee = p.SommeRecoltee,
                StatutProjet = p.Statut,
                Titre = p.Titre
            };
        }

    }
}
