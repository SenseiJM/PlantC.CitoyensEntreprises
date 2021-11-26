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

        public int Create(LocalisationModel model) {
            return _localisationRepository.Create(model.ToEntity());
        }


        public IEnumerable<LocalisationModel> GetAllContacts()
        {
            return _localisationRepository.GettAllContacts().Select(c => c.ToSimpleModel());
        }
        public bool Update(int id, LocalisationModel model) {
            return _localisationRepository.Update(id, model.ToEntity());
        }

        public bool Delete(int id) {
            return _localisationRepository.Delete(id);
        }

        public LocalisationModel GetByID(int id) {
            return _localisationRepository.GetByID(id).ToSimpleModel();
        }

    }
}
