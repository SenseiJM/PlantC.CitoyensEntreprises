using PlantC.CitoyensEntreprises.API.DTO.Commentaire;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class CommentaireMapper {

        public static CommentaireModel ToModel(this CommentaireAddDTO dto) {
            return new CommentaireModel {
                Id = dto.Id,
                DateTime = dto.DateTime,
                Contenu = dto.Contenu,
                UserId = dto.UserId,
                TaskId = dto.TaskId,
                AlbumId = dto.AlbumId
            };
        }


        public static CommentaireIndexDTO ToIndexDTO(this CommentaireModel c)
        {
            return new CommentaireIndexDTO
            {
                Id = c.Id,
                DateTime = c.DateTime,
                Contenu = c.Contenu,
                UserId = c.UserId,
                TaskId = c.TaskId,
                AlbumId = c.AlbumId
            };
        }
        public static CommentaireModel UpdateRequestToModel(this CommentaireUpdateRequestDTO dto) {
            return new CommentaireModel {
                Id = dto.Id,
                DateTime = dto.DateTime,
                Contenu = dto.Contenu,
                UserId = dto.UserId,
                TaskId = dto.TaskId,
                AlbumId = dto.AlbumId
            };
        }

    }
}
