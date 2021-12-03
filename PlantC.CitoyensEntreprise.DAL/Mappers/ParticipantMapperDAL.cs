using PlantC.CitoyensEntreprise.DAL.Entities;
using Npgsql;

namespace PlantC.CitoyensEntreprise.DAL.Mappers {
    public static class ParticipantMapperDAL
    {
        public static Participant ToParticipant(this NpgsqlDataReader reader)
        {
            return new Participant
            {
                Id = (int)reader["id"],
                Email = (string)reader["email"],
                Nom = (string)reader["nom"],
                Prenom = (string)reader["prenom"],
                Telephone = (string)reader["telephone"],
                UserLevel = (string)reader["userLevel"],
                IdAdresse = (int)reader["idAdresse"]
            };
        }
    }
}
