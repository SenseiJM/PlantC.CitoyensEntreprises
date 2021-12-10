using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.BLL.Mappers
{
    static class ParticipantMapper
    {

        public static Participant ToEntity(this ParticipantModel model)
        {
            return new Participant
            {
                BCE = model.BCE,
                Fonction = model.Fonction,
                Id = model.Id,
                NomEntreprise = model.NomEntreprise,
                IdAdresse = model.IdAdresse,
                Telephone = model.Telephone,
                Prenom = model.Prenom,
                Nom = model.Nom,
                Email = model.Email,
                EstVerifie = model.EstVerifie
            };
        }

        public static ParticipantModel ToSimpleModel(this Participant p)
        {
            return new ParticipantModel
            {
                BCE = p.BCE,
                Fonction = p.Fonction,
                Id = p.Id,
                NomEntreprise = p.NomEntreprise,
                Email = p.Email,
                Nom = p.Nom,
                Prenom = p.Prenom,
                Telephone = p.Telephone,
                IdAdresse = p.IdAdresse,
                EstVerifie = p.EstVerifie
            };
        }

    }
}
