using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Mappers {
    static class ContactMapper {

        public static Contact ToEntity(this ContactModel model) {
            return new Contact {
                Adresse = model.Adresse,
                Id = model.Id,
                Mail = model.Email,
                Nom = model.Nom,
                Prenom = model.Prenom,
                Telephone = model.Telephone
            };
        }
        public static ContactModel ToSimpleModel(this Contact c)
        {
            return new ContactModel
            {
                Adresse = c.Adresse,
                Id = c.Id,
                Email = c.Mail,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Telephone = c.Telephone
            };
        }

    }
}
