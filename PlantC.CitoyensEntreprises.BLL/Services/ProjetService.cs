using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
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
            return _projetRepository.Create(model.ToEntity());
        }

    }
}
