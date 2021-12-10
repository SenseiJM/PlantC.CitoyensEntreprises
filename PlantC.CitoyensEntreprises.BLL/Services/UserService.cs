using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Transactions;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly HashService _hashService;
        private readonly ParticipantService _contactService;
        private readonly MailService _mailService;

        public UserService(UserRepository userRepository, HashService hashService, ParticipantService contactService, MailService mailService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _contactService = contactService;
            _mailService = mailService;
        }

        public int Register(ParticipantModel contact)
        {
            //if (_userRepository.GetByMail(contact.Email) != null)
            //{
            //    throw new Exception();
            //}
            //string salt = Guid.NewGuid().ToString();
            //string hashPassword = _hashService.Hash(contact.MdpContact, salt);
            //ParticipantModel temp = new ParticipantModel
            //{
            //    Email = contact.Email,
            //    MdpContact = hashPassword,
            //    Nom = contact.Nom,
            //    Prenom = contact.Prenom,
            //    Telephone = contact.Telephone,
            //    Salt = salt,
            //    Userlevel = "USER",
            //    IdAdresse = contact.IdAdresse,
            //    //EmailVerif = false
            //};
            using (TransactionScope scope = new TransactionScope())
            {
                //_contactService.Create(temp);
                _mailService.SendEmail("Nouvel inscription", "coucou", contact.Email);
                scope.Complete();
            }
            //return temp.Id;
            return 0;
        }
        public ParticipantModel Login(string mail, string password)
        {
            Participant contact = _userRepository.GetByMail(mail);
            if (contact != null /*&& contact.EmailVerif*/ && contact.MdpClient == _hashService.Hash(password, contact.Salt))
            {
                return new ParticipantModel //check Front end quel info renvoyer
                {
                    Email = contact.Email,
                    Nom = contact.Nom,
                    Prenom = contact.Prenom,
                };
            }
            return null;
        }
    }
}
