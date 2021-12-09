using PlantC.CitoyensEntreprise.DAL.Entities;
using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Enums;

namespace PlantC.CitoyensEntreprise.DAL.Mappers {
    public static class ParticipantMapperDAL
    {
        public static Participant ToParticipant(this NpgsqlDataReader reader)
        {
            return new Participant
            {
                Id = (int)reader["id"],
                Fonction = (Fonction)reader["fonction"],
                Nom = (string)reader["nom"],
                Prenom = (string)reader["prenom"],
                Email = (string)reader["mail"],
                Telephone = (string)reader["telephone"],
                Salt = (string)reader["salt"],
                MdpClient = (string)reader["mdp_client"],
                UserLevel = (string)reader["user_level"]
                //Adresse = new Adresse
                //{
                //    AdressLine1 = (string)reader["adressLine1"],
                //    AdressLine2 = (string)reader["adressLine2"],
                //    City = (string)reader["city"],
                //    Country = (string)reader["country"],
                //    Number = (int)reader["number"],
                //    ZipCode = (int)reader["zipCode"]
                //}
            };
        }
    }
}
