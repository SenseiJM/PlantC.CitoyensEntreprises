using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.BLL.Services
{
    public class TacheService
    {
        private readonly TacheRepository _tacheRepository;
        public TacheService(TacheRepository tacheRepository)
        {
            _tacheRepository = tacheRepository;
        }
        public int Create(TacheModel tacheModel)
        {
            return _tacheRepository.Create(tacheModel.ToDALAdd());
        }
        public IEnumerable<TacheModel> GetAll()
        {
            return _tacheRepository.GetAll().ToBLLModel();
        }
        public TacheModel GetById(int id)
        {
            return _tacheRepository.GetByID(id).ToBLLIndexId();
        }
        public IEnumerable<TacheModel> GetByProjectId(int id)
        {
            return _tacheRepository.GetByProjectId(id).ToBLLModel();
        }
        public IEnumerable<TacheModel> GetByParticipantId(int id) {
            return _tacheRepository.GetByParticipantId(id).ToBLLModel();
        }
        public bool Delete(int id)
        {
            return _tacheRepository.DeleteTache(id);
        }
        public bool UpDate(TacheModel model)
        {
            return _tacheRepository.UpdateTache(model.ToDALPut());
        }
    }
}
