﻿using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services
{
    public class ProjetService
    {

        private readonly ProjetRepository _projetRepository;
        private readonly TagRepository _tagRepository;

        public ProjetService(ProjetRepository projetRepository, TagRepository tagRepository) {
            _projetRepository = projetRepository;
            _tagRepository = tagRepository;
        }

        public int Create(ProjetModel model) {
            if (model.Infrastructure == "Verger") {
                if (model.NbArbres == 0 || model.NbFruits == 0 || model.Hectares == 0) {
                    throw new ArgumentException("Les champs 'Nombre d'arbre', 'Nombre d'arbres fruitiers' et 'Nombre d'hectares' sont des champs requis pour les vergers !");
                }

                if (model.NbFruits > model.NbArbres)
                {
                    throw new ArgumentException("Nombre d'arbres fruitiers trop important !");
                }

            } else if (model.Infrastructure == "Haie") {
                if (model.NbArbres == 0 || model.Metres == 0) {
                    throw new ArgumentException("Les champs 'Mètres' et 'NbArbres' sont des champs requis pour les haies !");
                }

            } else if (model.Infrastructure == "Miscanthus") {
                if (model.Hectares == 0) {
                    throw new ArgumentException("Le champ 'Hectares' est un champ requis pour le Miscanthus !");
                }
            } else if (model.Infrastructure == "Reboisement") {
                if (model.Hectares == 0 || model.NbArbres == 0) {
                    throw new ArgumentException("Les champs 'Hectares' et 'NbArbres' sont des champs requis pour le reboisement !");
                }
            }
            model.DateCreation = DateTime.Now;
            return _projetRepository.Create(model.ToEntity());
        }

        public bool DeleteProjet(int id)
        {
            return _projetRepository.DeleteProjet(id);
        }

        public bool UpdateProjet(int id, ProjetModel model)
        {
            return _projetRepository.Update(id, model.ToEntity());
        }

        public IEnumerable<ProjetResumeModel> GetAllResume() {
            return _projetRepository.GetAllResume().Select(p => p.ToSimpleModel());
        }

        public ProjetResumeModel GetResumeByID(int id) {
            return _projetRepository.GetResumeByID(id).ToSimpleModel();
        }

        public ProjetDetailsModel GetDetailsByID(int id) {
            ProjetDetailsModel temp =_projetRepository.GetDetailsByID(id).ToSimpleModel();
            temp.ListeTags = _tagRepository.GetTagByProjet(id);
            return temp;
            
        }

        public IEnumerable<MarqueurModel> GetAllMarqueurs() {
            return _projetRepository.GetAllMarqueurs().Select(m => m.ToSimpleModel());
        }

    }
}
