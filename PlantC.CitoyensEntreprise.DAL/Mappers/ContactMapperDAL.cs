using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PlantC.CitoyensEntreprise.DAL.Mappers
{
    public static class ContactMapperDAL
    {
        public static Contact ToContact(this NpgsqlDataReader reader)
        {
            return new Contact
            {
                Id = (int)reader["id"],
                Mail = (string)reader["mail"],
                Nom = (string)reader["nom"],
                Prenom = (string)reader["prenom"],
                Telephone = (string)reader["telephone"],
                UserLevel = (string)reader["userLevel"],
                Adresse = new Adresse
                {
                    AdressLine1 = (string)reader["adressLine1"],
                    AdressLine2 = (string)reader["adressLine2"],
                    City = (string)reader["city"],
                    Country = (string)reader["country"],
                    Number = (int)reader["number"],
                    ZipCode = (int)reader["zipCode"]
                }
            };
        }
    }
}
