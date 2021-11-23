using PlantC.CitoyensEntreprises.API.DTO.Contact;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ContactMapper {

        public static ContactModel ToModel(this ContactAddDTO dto) {
            return new ContactModel {
                Adresse = dto.Adresse,
                Id = dto.Id,
                Mail = dto.Mail,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Telephone = dto.Telephone
            };
        }

<<<<<<< HEAD
        public static ContactIndexDTO ToIndexDTO(this ContactModel c)
        {
            return new ContactIndexDTO
            {
                Adresse = c.Adresse,
                Id = c.Id,
                Mail = c.Mail,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Telephone = c.Telephone
=======
        public static ContactModel UpdateRequestToModel(this ContactUpdateRequestDTO dto) {
            return new ContactModel {
                Adresse = dto.Adresse,
                Id = dto.Id,
                Mail = dto.Mail,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Telephone = dto.Telephone
>>>>>>> 08875cb14549968febbd8034a80d5b64b6f58f3e
            };
        }

    }
}
