using PlantC.CitoyensEntreprises.API.DTO.Tache;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class TacheMapper
    {
        public static TacheModel ToBLLAdd(this TacheAddDTO dto)
        {
            return new TacheModel
            {
                Id_Participant = dto.Id_Participant,
                Id_localisation = dto.Id_localisation,
                Id_Projet = dto.Id_Projet,
                Intitule = dto.Intitule,
                Date_Debut = dto.Date_Debut,
                Date_Fin = dto.Date_Fin,
                Type = dto.Type,
                Description = dto.Description,
            };
        }
        public static TacheModel ToBLLPut (this TacheUpdateRequestDTO dto)
        {
            return new TacheModel
            {
                Id = dto.Id,
                Id_Participant = dto.Id_Participant,
                Id_localisation = dto.Id_localisation,
                Id_Projet = dto.Id_Projet,
                Intitule = dto.Intitule,
                Date_Debut = dto.Date_Debut,
                Date_Fin = dto.Date_Fin,
                Type = dto.Type,
                Description = dto.Description,
            };
        }
        public static IEnumerable<TacheIndexDTO> ToDTOIndexList(this IEnumerable<TacheModel> taches)
        {
            List<TacheIndexDTO> result = new List<TacheIndexDTO>();
            foreach (TacheModel tache in taches)
            {
                result.Add(new TacheIndexDTO
                {
                    Id = tache.Id,
                    Id_localisation = tache.Id_localisation,
                    Id_Participant = tache.Id_Participant,
                    Id_Projet = tache.Id_Projet,
                    Intitule = tache.Intitule,
                    Date_Debut = tache.Date_Debut,
                    Date_Fin = tache.Date_Fin,
                    Description = tache.Description,
                    Type = tache.Type,
                    Est_Assigne = tache.Est_Assigne,
                    Est_Termine = tache.Est_Termine,
                });
            }
            return result;
        }
        public static TacheIndexDTO ToDTOIndexId(this TacheModel model)
        {
            return new TacheIndexDTO
            {
                Id = model.Id,
                Id_Participant = model.Id_Participant,
                Id_localisation = model.Id_localisation,
                Id_Projet = model.Id_Projet,
                Intitule = model.Intitule,
                Date_Debut = model.Date_Debut,
                Date_Fin = model.Date_Fin,
                Type = model.Type,
                Description = model.Description,
            };
        }
    }
}
