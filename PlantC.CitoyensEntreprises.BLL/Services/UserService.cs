using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Models;
using System;
using System.Transactions;
using System.Security.Claims;
using ToolBox.Security.Services;
using System.Linq;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly HashService _hashService;
        private readonly ParticipantService _contactService;
        private readonly MailService _mailService;
        private readonly JwtService _jwtService;

        public UserService(UserRepository userRepository, HashService hashService, ParticipantService contactService, MailService mailService, JwtService jwt)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _contactService = contactService;
            _mailService = mailService;
            _jwtService = jwt;
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
                    Userlevel = contact.UserLevel,
                    Id = contact.Id
                };
            }
            return null;
        }

        public bool Validate(string token) {

            _jwtService.TryGetClaims(token, out ClaimsPrincipal claims);
            if (claims != null) {
                string email = claims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                return _userRepository.ValidateMail(email);
            }
            return false;
        }
    }
}
