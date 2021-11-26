using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class CommentaireService {

        private readonly CommentaireRepository _commentaireRepository;

        public TaskService(CommentaireRepository commentaireRepository) {
            _commentaireRepository = commentaireRepository;
        }

        public int Create(CommentaireModel model) {
            return _commentaireRepository.Create(model.ToEntity());
        }
        
        public IEnumerable<CommentaireModel> GetAll() {
            return _commentaireRepository.GetAll().Select(p => p.ToSimpleModel());
        }

        public CommentaireModel GetByID(int id) {
            return _commentaireRepository.GetByID(id).ToSimpleModel();
        }
        
        public bool Update(int id, CommentaireModel model) {
            return _commentaireRepository.Update(id, model.ToEntity());
        }

        public bool Delete(int id) {
            return _commentaireRepository.Delete(id);
        }
    }
}