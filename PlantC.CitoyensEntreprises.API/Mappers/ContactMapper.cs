﻿using PlantC.CitoyensEntreprises.API.DTO.Contact;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers {
    static class ContactMapper {

        public static ContactModel ToModel(this ContactAddDTO dto) {
            return new ContactModel {
                Adresse = dto.Adresse,
                Id = dto.Id,
                Email = dto.Mail,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Telephone = dto.Telephone
            };
        }


        public static ContactIndexDTO ToIndexDTO(this ContactModel c)
        {
            return new ContactIndexDTO
            {
                Adresse = c.Adresse,
                Id = c.Id,
                Mail = c.Email,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Telephone = c.Telephone
            };
        }
        public static ContactModel UpdateRequestToModel(this ContactUpdateRequestDTO dto) {
            return new ContactModel {
                Adresse = dto.Adresse,
                Id = dto.Id,
                Email = dto.Mail,
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Telephone = dto.Telephone
            };
        }

    }
}
