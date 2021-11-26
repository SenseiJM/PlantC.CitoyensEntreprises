using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class CommentaireMapper {

        public static Commentaire ToEntity(this CommentaireModel model) {
            return new Commentaire {
                Id = model.Id,
                DateTime = model.DateTime,
                Contenu = model.Contenu,
                UserId = model.UserId,
                TaskId = model.TaskId,
                AlbumId = model.AlbumId
            };
        }
        public static CommentaireModel ToSimpleModel(this Commentaire c)
        {
            return new CommentaireModel
            {
                Id = c.Id,
                DateTime = c.DateTime,
                Contenu = c.Contenu,
                UserId = c.UserId,
                TaskId = c.TaskId,
                AlbumId = c.AlbumId
            };
        }

    }
}