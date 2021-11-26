using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class AlbumMapper {

        public static Album ToEntity(this AlbumModel model) {
            return new Album {
                Id = model.Id,
                ProjetId = model.ProjetId,
                URLPhoto = model.URLPhoto,
                IsPublic = model.IsPublic
            };
        }
        public static AlbumModel ToSimpleModel(this Album c)
        {
            return new AlbumModel
            {
                Id = c.Id,
                ProjetId = c.ProjetId,
                URLPhoto = c.URLPhoto,
                IsPublic = c.IsPublic
            };
        }

    }
}