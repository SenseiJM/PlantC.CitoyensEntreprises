using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprises.API.DTO.Participant {
    public class ParticipantIndexDTO {

        public int Id { get; set; }
        public Fonction Fonction { get; set; }
        public string NomEntreprise { get; set; }
        public uint? BCE { get; set; }
        public int IdContact { get; set; }

    }
}
