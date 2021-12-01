using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Mappers
{
    static class TacheMapper
    {
        public static Tache ToDALAdd(this TacheModel model)
        {
            return new Tache
            {
                Id_localisation = model.Id_localisation,
                Id_Participant = model.Id_Participant,
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
