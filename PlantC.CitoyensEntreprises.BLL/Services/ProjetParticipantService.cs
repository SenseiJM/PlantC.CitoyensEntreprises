using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class ProjetParticipantService {

        private readonly ProjetParticipantRepository _ppRepository;

        public ProjetParticipantService(ProjetParticipantRepository ppRepository) {
            _ppRepository = ppRepository;
        }

        public int Create(ProjetParticipantModel pp) {

            pp.DateContribution = DateTime.Now;
            pp.IsValidated = false;
            pp.IsFavorite = false;

            return _ppRepository.Create(pp.ToEntity());
        }

        public bool Update(int id, ProjetParticipantModel pp) {
            return _ppRepository.Update(id, pp.ToEntity());
        }

        public IEnumerable<ProjetParticipantModel> GetAll() {
            return _ppRepository.GetAll().Select(p => p.ToModel());
        }

        public bool ValidateContribution(int id) {
            return _ppRepository.ValidateContribution(id);
        }
    }
}
