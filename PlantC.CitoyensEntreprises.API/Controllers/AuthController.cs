using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Contact;
using PlantC.CitoyensEntreprises.API.DTO.Login;
using PlantC.CitoyensEntreprises.BLL.Models;
using PlantC.CitoyensEntreprises.BLL.Services;
using PlantC.CitoyensEntreprises.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Security.Services;

namespace PlantC.CitoyensEntreprises.API.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;
        private readonly UserRepository _userRepository;

        public AuthController(UserService userService, JwtService jwtService, UserRepository userRepository)
        {
            _userService = userService;
            _jwtService = jwtService;
            _userRepository = userRepository;
        }
        [HttpPost("Login")]
        [Produces(typeof(LoginDTO))]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
                ContactModel contact = _userService.Login(login.Email, login.Password);
                if (contact == null) return Unauthorized();
                else return Ok(new ContactIndexDTO
                {
                    Id = contact.Id,
                    Mail = contact.Email,
                    Token = _jwtService.CreateToken(contact),
                    Nom = contact.Nom,
                    Prenom = contact.Prenom
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO register)
        {
            try
            {
                int temp = _userService.Register(new ContactModel
                {
                    Email = register.Mail,
                    MdpContact = register.MdpContact,
                    Nom = register.Nom,
                    Prenom = register.Prenom,
                    Telephone = register.Telephone,
                    Adresse = new CitoyensEntreprise.DAL.Entities.Adresse
                    {
                        AdressLine1 = register.Adresse.AdressLine1,
                        AdressLine2 = register.Adresse.AdressLine2,
                        City = register.Adresse.City,
                        Country = register.Adresse.Country,
                        Number = register.Adresse.Number,
                        ZipCode = register.Adresse.ZipCode
                    }

                });
                return Ok(temp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
