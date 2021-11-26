using PlantC.CitoyensEntreprises.API.DTO.Album;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class AlbumMapper {

        public static AlbumModel ToModel(this AlbumAddDTO dto) {
            return new AlbumModel {
                Id = dto.Id,
                ProjetId = dto.ProjetId,
                URLPhoto = dto.URLPhoto,
                IsPublic = dto.IsPublic
            };
        }


        public static AlbumIndexDTO ToIndexDTO(this AlbumModel c)
        {
            return new AlbumIndexDTO
            {
                Id = c.Id,
                ProjetId = c.ProjetId,
                URLPhoto = c.URLPhoto,
                IsPublic = c.IsPublic
            };
        }
        public static AlbumModel UpdateRequestToModel(this AlbumUpdateRequestDTO dto) {
            return new AlbumModel {
                Id = dto.Id,
                ProjetId = dto.ProjetId,
                URLPhoto = dto.URLPhoto,
                IsPublic = dto.IsPublic
            };
        }

    }
}
