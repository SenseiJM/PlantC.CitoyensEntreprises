using PlantC.CitoyensEntreprises.API.DTO.Tache;
using PlantC.CitoyensEntreprises.BLL.Models;

namespace PlantC.CitoyensEntreprises.API.Mappers
{
    static class TacheMapper
    {
        public static TacheModel ToBLLAdd(this TacheAddDTO dto)
        {
            return new TacheModel
            {
                Id_Participant = dto.Id_Participant,
                Id_localisation = dto.Id_localisation,
                Id_Projet = dto.Id_Projet,
                Intitule = dto.Intitule,
                Date_Debut = dto.Date_Debut,
                Date_Fin = dto.Date_Fin,
                Type = dto.Type,
                Description = dto.Description,
            };
        }
    }
}
