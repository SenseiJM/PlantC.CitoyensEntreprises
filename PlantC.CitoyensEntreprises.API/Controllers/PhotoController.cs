using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Photo;
using PlantC.CitoyensEntreprises.BLL.Models;
using PlantC.CitoyensEntreprises.BLL.Services;
using System;

namespace PlantC.CitoyensEntreprises.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase {

        private readonly PhotoService _photoService;

        public PhotoController(PhotoService photoService) {
            _photoService = photoService;
        }

        [HttpPost]
        public IActionResult Create(PhotoAddDTO dto) {

            string fileExtension = dto.Blob.Split("/", 3)[1].Split(';')[0];
            string base64String = dto.Blob.Split(",")[1];
            byte[] base64 = Convert.FromBase64String(base64String);

            Guid guid = Guid.NewGuid();
            string filePath = "assets/images/" + guid + "." + fileExtension;

            System.IO.File.WriteAllBytes("wwwroot/" + filePath, base64);

            return Ok(_photoService.Create(new PhotoModel { IdProjet = dto.IdProjet, IsPublic = dto.IsPublic, URLPhoto = filePath }));
        }



    }
}
