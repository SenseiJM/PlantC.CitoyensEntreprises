using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.API.DTO;

namespace PlantC.CitoyensEntreprises.API.Services {
    public class ProjetService {

        private readonly PlantDBContext dBContext;

        public ProjetService(PlantDBContext dBContext) {
            this.dBContext = dBContext;
        }

        public void Create(ProjetAddDTO dto) {
            dBContext.Projets.Add(new Projet {
                CodePostal = dto.CodePostal,
                Description = dto.Description,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Localite = dto.Localite,
                NbArbresTotal = dto.NbArbresTotal,
                NbParticipantsTotal = dto.NbParticipantsTotal,
                ObjectifArbres = dto.ObjectifArbres,
                ObjectifMonetaire = dto.ObjectifMonetaire,
                SommeRecoltee = dto.SommeRecoltee,
                Statut = dto.StatutProjet,
                Titre = dto.Titre,
                TypeDeProjet = dto.TypeDeProjet
            });
            dBContext.SaveChanges();
        }

    }
}
