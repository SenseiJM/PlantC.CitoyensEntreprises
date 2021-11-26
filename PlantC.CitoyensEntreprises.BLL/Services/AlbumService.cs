using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class AlbumService {

        private readonly AlbumRepository _albumRepository;

        public AlbumService(AlbumRepository AlbumRepository) {
            _albumRepository = albumRepository;
        }

        public int Create(AlbumModel model) {
            return _albumRepository.Create(model.ToEntity());
        }
        
        public IEnumerable<AlbumModel> GetAll() {
            return _albumRepository.GetAll().Select(p => p.ToSimpleModel());
        }

        public AlbumModel GetByID(int id) {
            return _albumRepository.GetByID(id).ToSimpleModel();
        }
        
        public bool Update(int id, AlbumModel model) {
            return _albumRepository.Update(id, model.ToEntity());
        }

        public bool Delete(int id) {
            return _albumRepository.Delete(id);
        }
    }
}