using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class ProjetService
    {

        private readonly ProjetRepository _projetRepository;
        private readonly TagRepository _tagRepository;
        private readonly LocalisationRepository _locRepository;
        private readonly AdressRepository _adRepository;

        public ProjetService(ProjetRepository projetRepository, TagRepository tagRepository, LocalisationRepository locRepository, AdressRepository adRepository)
        {
            _projetRepository = projetRepository;
            _tagRepository = tagRepository;
            _locRepository = locRepository;
            _adRepository = adRepository;
        }

        public int Create(ProjetModel model) {

            model.Reference = createReference(model);

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

            int addId = _adRepository.AddAdress(new Adresse
            {
                AdressLine1 = model.Localisation.AdressLine1,
                City = model.Localisation.City,
                Number= model.Localisation.Number,
                ZipCode= model.Localisation.ZipCode
            });

            var l = _locRepository.GetGeocodeByAddress(model.Localisation.AdressLine1, model.Localisation.City);

            int locId = _locRepository.Insert(new Localisation
                { City = model.Localisation.City, ZipCode = model.Localisation.ZipCode },
                l.Lat,l.Lon,addId
            );

            model.IDLocalisation = locId;
            int pId = _projetRepository.Create(model.ToEntity());
            foreach (var item in model.ListeTags)
            {
                _tagRepository.Insert(item, pId);
            }
            return pId;
        }

        private string createReference(ProjetModel model)
        {
            string result = model.Localisation.City.Substring(0,4);
            int count = _projetRepository.GetAllResume().Count(p => p.NomLocalite == model.Localisation.City);
            return $"{result}{("00" + (count+1)).Substring(("00" + (count + 1)).Length - 3, 3)}";
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

        public CompteursModel GetCompteurs() {

            IEnumerable<CompteursView> list = _projetRepository.GetCompteurs();

            CompteursModel model = new();
            foreach (CompteursView item in list) {
                model.NbArbres += (item.NbArbres ?? 0);
                model.TonnesCO2 += item.TonnesCO2;
                model.Fini += item.CoutDuProjet <= item.TotalContribution ? 1 : 0;
            }

            return model;
        } 

    }
}
