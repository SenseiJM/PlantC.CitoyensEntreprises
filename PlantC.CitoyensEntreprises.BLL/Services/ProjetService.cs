using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class ProjetService {

        private readonly ProjetRepository _projetRepository;

        public ProjetService(ProjetRepository projetRepository) {
            _projetRepository = projetRepository;
        }

        public IEnumerable<ProjetModel> Get() {
            return _projetRepository.GetAll().Select(p => p.ToSimpleModel());
        }

    }
}
