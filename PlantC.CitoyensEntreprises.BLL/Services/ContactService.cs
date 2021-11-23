﻿using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Mappers;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class ContactService {

        private readonly ContactRepository _contactRepository;

        public ContactService(ContactRepository contactRepository) {
            _contactRepository = contactRepository;
        }

        public int Create(ContactModel model) {
            return _contactRepository.Create(model.ToEntity());
        }

<<<<<<< HEAD
        public IEnumerable<ContactModel> GetAllContacts()
        {
            return _contactRepository.GettAllContacts().Select(c => c.ToSimpleModel());
=======
        public bool Update(int id, ContactModel model) {
            return _contactRepository.Update(id, model.ToEntity());
>>>>>>> 08875cb14549968febbd8034a80d5b64b6f58f3e
        }

    }
}
