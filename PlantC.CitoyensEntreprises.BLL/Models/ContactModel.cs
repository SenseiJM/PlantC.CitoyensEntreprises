using PlantC.CitoyensEntreprise.DAL.Entities;
using System.Collections.Generic;
using ToolBox.Security.Models;

namespace PlantC.CitoyensEntreprises.BLL.Models {
    public class ContactModel : IPayload {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MdpContact { get; set; }
        public string Salt { get; set; }
        public Adresse Adresse { get; set; }
        public string Userlevel { get; set; }
        public string Identifier { get { return Id.ToString(); } }
        public IEnumerable<string> Roles { get { yield return Userlevel; } }
    }
}
