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

        public static ContactModel UpdateRequestToModel(this ContactUpdateRequestDTO dto) {
            return new ContactModel {
                Adresse = dto.Adresse,
                Id = dto.Id,
                Mail = dto.Mail,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Telephone = dto.Telephone
            };
        }

    }
}
