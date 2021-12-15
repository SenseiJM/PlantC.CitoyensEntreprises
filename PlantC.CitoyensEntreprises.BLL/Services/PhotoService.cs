using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class PhotoService {

        private readonly PhotoRepository _photoRepository;

        public PhotoService(PhotoRepository photoRepository) {
            _photoRepository = photoRepository;
        }

        public int Create(PhotoModel p) {
            return _photoRepository.Create(new Photo { IdProjet = p.IdProjet, IsPublic = p.IsPublic, URLPhoto = p.URLPhoto, IsPrincipale = _photoRepository.GetByProject(p.IdProjet).Count() == 0 });
        }

    }
}
