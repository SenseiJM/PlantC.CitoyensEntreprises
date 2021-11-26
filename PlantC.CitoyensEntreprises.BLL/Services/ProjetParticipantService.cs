using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class ProjetParticipantService {

        private readonly ProjetParticipantRepository _projetParticipantRepository;

        public ProjetParticipantService(ProjetParticipantRepository projetParticipantRepository) {
            _projetParticipantRepository = projetParticipantRepository;
        }

        public int Create(ProjetParticipantModel model) {
            return _projetParticipantRepository.Create(model.ToEntity());
        }
        
        public IEnumerable<ProjetParticipantModel> GetAll() {
            return _projetParticipantRepository.GetAll().Select(p => p.ToSimpleModel());
        }

        public ProjetParticipantModel GetByID(int id) {
            return _projetParticipantRepository.GetByID(id).ToSimpleModel();
        }
        
        public bool Update(int id, ProjetParticipantModel model) {
            return _projetParticipantRepository.Update(id, model.ToEntity());
        }

        public bool Delete(int id) {
            return _projetParticipantRepository.Delete(id);
        }
    }
}