using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class ParticipantService {

        private readonly ParticipantRepository _participantRepository;

        public ParticipantService(ParticipantRepository participantRepository) {
            _participantRepository = participantRepository;
        }

        public int Create(ParticipantModel model) {
            return _participantRepository.Create(model.ToEntity());
        }

        public ParticipantModel GetByID(int id) {
            return _participantRepository.GetByID(id).ToSimpleModel();
        }

    }
}
