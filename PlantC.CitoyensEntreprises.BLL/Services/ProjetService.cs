using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services
{
    public class ProjetService {

        private readonly ProjetRepository _projetRepository;

        public ProjetService(ProjetRepository projetRepository) {
            _projetRepository = projetRepository;
        }

        public IEnumerable<ProjetModel> GetAll() {
            return _projetRepository.GetAll().Select(p => p.ToSimpleModel());
        }

        public int Create(ProjetModel model) {
            if (model.Infrastructure == "Verger") {
                if (model.NbArbres is null || model.NbFruits is null || model.Hectares is null) {
                    throw new ArgumentException("Les champs 'Nombre d'arbre', 'Nombre d'arbres fruitiers' et 'Nombre d'hectares' sont des champs requis pour les vergers !");
                }

                if (model.NbFruits > model.NbArbres) {
                    throw new ArgumentException("Nombre d'arbres fruitiers trop important !");
                }
            } else if (model.Infrastructure == "Haie") {
                if (model.Hectares != null) {
                    throw new ArgumentException("Les haies ne se mesurent pas en hectares !");
                }
            } else if (model.Infrastructure == "Miscanthus") {
                if (model.NbArbres != null) {
                    throw new ArgumentException("Le Miscanthus ne peut pas avoir un nombre d'arbres !");
                }

                if (model.Metres != null) {
                    throw new ArgumentException("Le Miscanthus ne se mesure pas en Mètres !");
                }

                if (model.NbFruits != null) {
                    throw new ArgumentException("Le Miscanthus ne comporte pas d'arbres fruitiers !");
                }
            } else if (model.Infrastructure == "Reboisement") {
                if (model.NbFruits != null) {
                    throw new ArgumentException("Pas d'arbres fruitiers dans le reboisement !");
                }

                if (model.Metres != null) {
                    throw new ArgumentException("Le reboisement ne se mesure pas en Mètres !");
                }
            }
            return _projetRepository.Create(model.ToEntity());
        }

        public bool DeleteProjet(int id)
        {
            return _projetRepository.DeleteProjet(id);
        }

        public ProjetModel GetByID(int id) {
            return _projetRepository.GetByID(id).ToSimpleModel();
        }

        public bool UpdateProjet(int id, ProjetModel model)
        {
            return _projetRepository.UpdateProjet(id, model.ToEntity());
        }

    }
}
