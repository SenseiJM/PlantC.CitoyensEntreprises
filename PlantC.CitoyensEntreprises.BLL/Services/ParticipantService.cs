using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services
{
    public class ParticipantService
    {

        private readonly ParticipantRepository _participantRepository;
        private readonly AdressRepository _adressRepository;

        public ParticipantService(ParticipantRepository participantRepository, AdressRepository adressRepository)
        {
            _participantRepository = participantRepository;
            _adressRepository = adressRepository;
        }

        public int Create(ParticipantModel model)
        {
            return _participantRepository.Create(model.ToEntity());
        }

        public ParticipantModel GetByID(int id)
        {
            return _participantRepository.GetByID(id).ToSimpleModel();
        }

        public bool DeleteParticipant(int id)
        {
            return _participantRepository.DeleteParticipant(id);
        }

        public IEnumerable<ParticipantModel> GetAll()
        {
            return _participantRepository.GetAll().Select(p => p.ToSimpleModel());
        }

        public bool UpdateParticipant(int id, ParticipantModel model)
        {
            _adressRepository.UpdateAdress(new Adresse
            {
                AdressLine1 = model.Adress.AdressLine1,
                AdressLine2 = model.Adress.AdressLine2,
                City = model.Adress.City,
                Country = model.Adress.Country,
                Number = model.Adress.Number,
                ZipCode = model.Adress.ZipCode,
                Id = model.IdAdresse ?? _adressRepository.AddAdress(new Adresse
                {
                    AdressLine1 = model.Adress.AdressLine1,
                    AdressLine2 = model.Adress.AdressLine2,
                    City = model.Adress.City,
                    Country = model.Adress.Country,
                    Number = model.Adress.Number,
                    ZipCode = model.Adress.ZipCode
                })
            });
            return _participantRepository.UpdateParticipant(id, model.ToEntity());
        }
    }
}
