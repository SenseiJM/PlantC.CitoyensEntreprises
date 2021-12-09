using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
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
        public static IEnumerable<TacheModel> ToBLLModel(this IEnumerable<TacheDetails> taches)
        {
            List<TacheModel> result = new List<TacheModel>();
            foreach (TacheDetails tache in taches)
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
                    Participant = tache.Id_Participant == null ? null : new ParticipantModel {
                        Nom = tache.Nom,
                        Prenom = tache.Prenom,
                        Fonction = tache.Fonction,
                        Email = tache.Email,
                    },
                    Projet = new ProjetModel {
                        Titre = tache.Titre,
                        Reference = tache.Reference,
                        Localisation = new LocalisationModel {
                            AdressLine1 = tache.AdressLine1,
                            AdressLine2 = tache.AdressLine2,
                            Number = tache.Number,
                            ZipCode = tache.ZipCode,
                            City = tache.City,
                            Country = tache.Country,
                        }
                    }
                });
            }
            return result;
        }
        public static TacheModel ToBLLIndexId(this TacheDetails model)
        {
            return new TacheModel
            {
                Id = model.Id,
                Id_Participant = model.Id_Participant,
                Id_Projet = model.Id_Projet,
                Date_Debut = model.Date_Debut,
                Date_Fin = model.Date_Fin,
                Description = model.Description,
                Type = model.Type,
                Est_Assigne = model.Est_Assigne,
                Est_Termine = model.Est_Termine,
                Participant = model.Id_Participant == null ? null : new ParticipantModel {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Fonction = model.Fonction,
                    Email = model.Email,
                },
                Projet = new ProjetModel {
                    Titre = model.Titre,
                    Reference = model.Reference,
                    Localisation = new LocalisationModel {
                        AdressLine1 = model.AdressLine1,
                        AdressLine2 = model.AdressLine2,
                        Number = model.Number,
                        ZipCode = model.ZipCode,
                        City = model.City,
                        Country = model.Country,
                    }
                }
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
