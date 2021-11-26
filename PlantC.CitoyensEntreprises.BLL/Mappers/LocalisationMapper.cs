using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class LocalisationMapper {

        public static Localisation ToEntity(this LocalisationModel model) {
            return new Localisation {
                Id = model.Id,
                NomLocalite = model.NomLocalite,
                CodePostal = model.CodePostal,
                Longitude = model.Longitude,
                Latitude = model.Latitude
            };
        }
        public static LocalisationModel ToSimpleModel(this Localisation c)
        {
            return new LocalisationModel
            {
                Id = c.Id,
                NomLocalite = c.NomLocalite,
                CodePostal = c.CodePostal,
                Longitude = c.Longitude,
                Latitude = c.Latitude
            };
        }

    }
}