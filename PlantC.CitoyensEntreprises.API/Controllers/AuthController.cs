using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprises.API.DTO.Login;
using PlantC.CitoyensEntreprises.API.DTO.Participant;
using PlantC.CitoyensEntreprises.BLL.Models;
using PlantC.CitoyensEntreprises.BLL.Services;
using PlantC.CitoyensEntreprises.BLL.Utils;
using System;
using ToolBox.Security.Services;

namespace PlantC.CitoyensEntreprises.API.Controllers {
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
                ParticipantModel contact = _userService.Login(login.Email, login.Password);
                if (contact == null) return Unauthorized();
                else return Ok(new ParticipantIndexDTO
                {
                    Id = contact.Id,
                    Email = contact.Email,
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
                int temp = _userService.Register(new ParticipantModel {
                    Email = register.Mail,
                    MdpContact = register.MdpContact,
                    Nom = register.Nom,
                    Prenom = register.Prenom,
                    Telephone = register.Telephone,
                    IdAdresse = register.IdAdresse

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
