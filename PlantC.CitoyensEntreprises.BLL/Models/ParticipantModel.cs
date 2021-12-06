using PlantC.CitoyensEntreprise.DAL.Enums;
using System.Collections.Generic;
using ToolBox.Security.Models;

namespace PlantC.CitoyensEntreprises.BLL.Models
{
    public class ParticipantModel : IPayload
    {
        public int Id { get; set; }
        public Fonction Fonction { get; set; }
        public string NomEntreprise { get; set; }
        public string BCE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int? IdAdresse { get; set; }
        public string Userlevel { get; set; }
        public string Identifier { get { return Id.ToString(); } }
        public IEnumerable<string> Roles { get { yield return Userlevel; } }
        public string MdpContact { get; set; }
        public string Salt { get; set; }
    }
}
