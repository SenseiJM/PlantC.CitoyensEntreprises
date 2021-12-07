using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class TacheMapper
    {
        public static Tache ToDALAdd(this TacheModel model)
        {
            return new Tache
            {
                Id_Participant = model.Id_Participant,
                Id_Projet = model.Id_Projet,
                Date_Debut = model.Date_Debut,
                Date_Fin = model.Date_Fin,
                Type = model.Type,
                Description = model.Description,
            };
        }
        public static IEnumerable<TacheModel> ToBLLModel(this IEnumerable<Tache> taches)
        {
            List<TacheModel> result = new List<TacheModel>();
            foreach (Tache tache in taches)
            {
                result.Add(new TacheModel
                {
                    Id = tache.Id,
                    Id_Participant = tache.Id_Participant,
                    Id_Projet = tache.Id_Projet,
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
        public static TacheModel ToBLLIndexId(this Tache model)
        {
            return new TacheModel
            {
                Id = model.Id,
                Id_Participant = model.Id_Participant,
                Id_Projet = model.Id_Projet,
                Date_Debut = model.Date_Debut,
                Date_Fin = model.Date_Fin,
                Type = model.Type,
                Description = model.Description,
            };
        }
        public static Tache ToDALPut(this TacheModel model)
        {
            return new Tache
            {
                Id= model.Id,
                Id_Participant = model.Id_Participant,
                Id_Projet = model.Id_Projet,
                Date_Debut = model.Date_Debut,
                Date_Fin = model.Date_Fin,
                Type = model.Type,
                Description = model.Description,
                Est_Termine=model.Est_Termine,
            };
        }
    }
}
