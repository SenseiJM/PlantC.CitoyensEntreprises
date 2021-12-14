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
        private readonly AdressRepository _adresseRepository;

        public UserService(UserRepository userRepository, HashService hashService, ParticipantService contactService, MailService mailService, JwtService jwt, AdressRepository adressRepository)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _contactService = contactService;
            _mailService = mailService;
            _jwtService = jwt;
            _adresseRepository = adressRepository;
        }

        public int Register(ParticipantModel contact)
        {
            if (_userRepository.GetByMail(contact.Email) != null)
            {
                throw new Exception();
            }
            string salt = Guid.NewGuid().ToString();
            string hashPassword = _hashService.Hash(contact.MdpContact, salt);
            using (TransactionScope scope = new TransactionScope())
            {
            int adresseIdTemp = _adresseRepository.AddAdress(
                new Adresse {
                    AdressLine1 = contact.Adress.AdressLine1,
                    AdressLine2 = contact.Adress.AdressLine2,
                    Number = contact.Adress.Number,
                    ZipCode = contact.Adress.ZipCode,
                    City = contact.Adress.City,
                    Country = contact.Adress.Country
            });
                ParticipantModel temp = new ParticipantModel
                {
                    Email = contact.Email,
                    MdpContact = hashPassword,
                    Nom = contact.Nom,
                    Prenom = contact.Prenom,
                    Telephone = contact.Telephone,
                    Salt = salt,
                    Userlevel = "USER",
                    IdAdresse = adresseIdTemp,
                    EstVerifie = false
                };
                temp.Id =_contactService.Create(temp);
                string token = _jwtService.CreateSimpleToken(temp.Email);
                string content = "<div><p>Veuillez cliquer sur le lien suivant pour activer votre compte <br>" +
                    $"<a href = 'http://localhost:3000/check?token={token}'>Activer votre compte<a/> " +
                    "<p/></div>";
                _mailService.SendEmail("Nouvelle inscription", content, contact.Email);
                scope.Complete();
            return temp.Id;
            }
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

        public int RegisterByPlantC(ParticipantModel contact)
        {
            if (_userRepository.GetByMail(contact.Email) != null)
            {
                throw new Exception();
            }
            string mdpTemp = Guid.NewGuid().ToString();
            mdpTemp = mdpTemp.Substring(0, 8);
            string salt = Guid.NewGuid().ToString();
            string hashPassword = _hashService.Hash(mdpTemp, salt);
            using (TransactionScope scope = new TransactionScope())
            {
                int adresseIdTemp = _adresseRepository.AddAdress(new Adresse
                {
                    AdressLine1 = contact.Adress.AdressLine1,
                    AdressLine2 = contact.Adress.AdressLine2,
                    Number = contact.Adress.Number,
                    ZipCode = contact.Adress.ZipCode,
                    City = contact.Adress.City,
                    Country = contact.Adress.Country
                });

                ParticipantModel temp = new ParticipantModel
                {
                Email = contact.Email,
                MdpContact = hashPassword,
                Nom = contact.Nom,
                Prenom = contact.Prenom,
                Telephone = contact.Telephone,
                Salt = salt,
                Userlevel = "USER",
                IdAdresse = adresseIdTemp,
                EstVerifie = true,
                Fonction = contact.Fonction,
                BCE = contact.BCE,
                NomEntreprise = contact.NomEntreprise
                };

                temp.Id = _contactService.Create(temp);
                string content = $"<div><p><H3>Bienvenue</H3><br>" +
                    $"Vous trouverez ci dessous votre login et votre mot de passe pour pouvoir accéder à notre site <br>" +
                    $"Login : <i>{contact.Email}</i><br>" +
                    $"Mot de passe : <i>{mdpTemp}</i><br>" +
                    $"<br>" +
                    $"l'équipe PlantC" +
                    "</p></div>";
                _mailService.SendEmail("Bienvenue chez PlantC", content, contact.Email);
                scope.Complete();
            return temp.Id;
            }
        }
    }
}

