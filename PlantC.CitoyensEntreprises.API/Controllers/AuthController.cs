using Microsoft.AspNetCore.Mvc;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.API.DTO;
using PlantC.CitoyensEntreprises.API.DTO.Login;
using PlantC.CitoyensEntreprises.API.DTO.Participant;
using PlantC.CitoyensEntreprises.BLL.Models;
using PlantC.CitoyensEntreprises.BLL.Services;
using PlantC.CitoyensEntreprises.BLL.Utils;
using System;
using System.Threading.Tasks;
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
        public IActionResult Login([FromBody]LoginDTO login)
        {
            try
            {
                ParticipantModel contact = _userService.Login(login.Email, login.Password);
                if (contact == null) return Unauthorized();
                else return Ok(new ParticipantLoginDTO
                {
                    Token = _jwtService.CreateToken(contact),
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterDTO register)
        {
            try
            {
                int temp = _userService.Register(new ParticipantModel
                {
                    Email = register.Mail,
                    MdpContact = register.MdpContact,
                    Nom = register.Nom,
                    Prenom = register.Prenom,
                    Telephone = register.Telephone,
                    Adress = new AdresseModel
                    {
                        AdressLine1 = register.AdressLine1,
                        AdressLine2 = register.AdressLine2,
                        Number = register.Number,
                        City = register.City,
                        ZipCode = register.ZipCode,
                        Country = register.Country
                    }

                });
                return Ok(temp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("Validate")]
        public IActionResult Validate([FromQuery]string token) {
            bool result = _userService.Validate(token);
            if(result) { return Ok(); }
            return BadRequest();
        }

        [HttpPost("RegisterByPlantC")]
        public IActionResult RegisterByPlantC([FromBody] RegisterPlantCDTO register)
        {
            try
            {
                int temp = _userService.RegisterByPlantC(new ParticipantModel
                {
                    Email = register.Mail,
                    Nom = register.Nom,
                    Prenom = register.Prenom,
                    Telephone = register.Telephone,
                    Fonction = register.Fonction,
                    BCE = register.BCE,
                    NomEntreprise = register.NomEntreprise,
                    Adress = new AdresseModel
                    {
                        AdressLine1 = register.AdressLine1,
                        AdressLine2 = register.AdressLine2,
                        Number = register.Number,
                        City = register.City,
                        ZipCode = register.ZipCode,
                        Country = register.Country
                    }
                });
                return Ok(temp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("OauthLogin")]
        public async Task<IActionResult> OauthLogin([FromBody] ParticipantLoginDTO token)
        {
            try
            {
                return Ok( await _userService.LoginWithGoogle(token.Token));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
