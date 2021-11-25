using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;
using PlantC.CitoyensEntreprises.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly HashService _hashService;
        private readonly ContactService _contactService;

        public UserService(UserRepository userRepository, HashService hashService, ContactService contactService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _contactService = contactService;
        }

        public int Register(ContactModel contact)
        {
            if (_userRepository.GetByMail(contact.Email) != null)
            {
                throw new Exception();
            }
            string salt = Guid.NewGuid().ToString();
            string hashPassword = _hashService.Hash(contact.MdpContact, salt);
            ContactModel temp = new ContactModel
            {
                Email = contact.Email,
                MdpContact = hashPassword,
                Nom = contact.Nom,
                Prenom = contact.Prenom,
                Telephone = contact.Telephone,
                Salt = salt,
                Userlevel = "USER",
                Adresse = new Adresse
                {
                    AdressLine1 = contact.Adresse.AdressLine1,
                    AdressLine2 = contact.Adresse.AdressLine2,
                    City = contact.Adresse.City,
                    Country = contact.Adresse.Country,
                    Number = contact.Adresse.Number,
                    ZipCode = contact.Adresse.ZipCode
                }
            };
            _contactService.Create(temp);
            return temp.Id;
        }
        public ContactModel Login(string mail, string password)
        {
            Contact contact = _userRepository.GetByMail(mail);
            if(contact != null && contact.MdpClient == _hashService.Hash(password, contact.Salt))
            {
                return new ContactModel //check Front end quel info renvoyer
                {
                    Email = contact.Mail,
                    Nom = contact.Nom,
                    Prenom = contact.Prenom,
                };
            }
            return null;
        }
    }
}
