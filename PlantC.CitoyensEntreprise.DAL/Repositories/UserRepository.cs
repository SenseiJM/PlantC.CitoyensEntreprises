using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Mappers;
using System;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class UserRepository 
    {
        private NpgsqlConnection oConn;

        public UserRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public Participant GetByMail(string mail) 
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Participant Where mail = @p1";
                cmd.Parameters.AddWithValue("p1", mail);
                NpgsqlDataReader reader = cmd.ExecuteReader();
  
                if (reader.Read())
                {
                    return reader.ToParticipant();
                    //return  new Contact
                    //{
                    //    Id = (int)reader["id"],
                    //    Mail = (string)reader["mail"],
                    //    Nom = (string)reader["nom"],
                    //    Prenom = (string)reader["prenom"],
                    //    Telephone = (string)reader["telephone"],
                    //    UserLevel = (string)reader["userLevel"],
                    //    Adresse = new Adresse
                    //    {
                    //        AdressLine1 = (string)reader["adressLine1"],
                    //        AdressLine2 = (string)reader["adressLine2"],
                    //        City = (string)reader["city"],
                    //        Country = (string)reader["country"],
                    //        Number = (int)reader["number"],
                    //        ZipCode = (int)reader["zipCode"]
                    //    }
                    //};
                    
                };
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                oConn.Close();
            }
        }
    }
}
