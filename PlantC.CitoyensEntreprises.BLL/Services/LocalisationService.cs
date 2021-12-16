using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class LocalisationService {

        private readonly LocalisationRepository _localisationRepository;

        public LocalisationService(LocalisationRepository localisationRepository) {
            _localisationRepository = localisationRepository;
        }

        public IEnumerable<LocalisationZipModel> GetAllLocalisationZip() {
            return _localisationRepository.GetAllLocalisationByZip().Select(l => l.ToSimpleModel());
        }

        public IEnumerable<LocalisationModel> GetAllLocalisation() {
            return _localisationRepository.GetAllLocalisation().Select(l => new LocalisationModel {
                City = l.City,
                ZipCode = l.ZipCode
            });
        }

        public LocalisationGeoCodeModel GetGeoCode(string adresse, string city) {
            return _localisationRepository.GetGeocodeByAddress(adresse, city).ToSimpleModel();
        }

    }
}
