using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;

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
    }
}
