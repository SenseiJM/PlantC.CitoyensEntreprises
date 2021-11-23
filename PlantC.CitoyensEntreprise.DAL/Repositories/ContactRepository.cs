using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class ContactRepository {

        private NpgsqlConnection oConn;

        public ContactRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        /// <summary>
        /// Adds a new Contact entity in the database
        /// </summary>
        /// <param name="c">New Contact Entity to be added in the database</param>
        /// <returns>ID of the created Entity</returns>
        public int Create(Contact c) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Contact OUTPUT inserted.Id VALUES (@p1)";
                cmd.Parameters.AddWithValue("p1", c);
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        /// <summary>
<<<<<<< HEAD
        /// Fetches a full list of all existing Contact Entities in the database
        /// </summary>
        /// <returns>IEnumerable of Contact Entity</returns>
        public IEnumerable<Contact> GettAllContacts()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Contact";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List < Contact > result = new List<Contact>();
                while (reader.Read())
                {
                    result.Add(new Contact
                    {
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Telephone = reader ["Telephone"].ToString(),
                        Adresse = (Adresse)reader["Adresse"]
                    }); 
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
=======
        /// Searches the database to update the Contact corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="c"></param>
        /// <returns>True if Contact Entity has been updated, False if ID is not existing</returns>
        public bool Update(int id, Contact c) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Contact SET" +
                    "Nom = @p2," +
                    "Prenom = @p3," +
                    "Mail = @p4," +
                    "Telephone = @p5" +
                    "AdressLine1 = @p6" +
                    "AdressLine2 = @p7" +
                    "AdressNumber = @p8" +
                    "AdressZipCode = @p9" +
                    "AdressCity = @p10" +
                    "AdressCountry = @p11" +
                    "WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", c.Nom);
                cmd.Parameters.AddWithValue("p3", c.Prenom);
                cmd.Parameters.AddWithValue("p4", c.Mail);
                cmd.Parameters.AddWithValue("p5", c.Telephone);
                cmd.Parameters.AddWithValue("p6", c.Adresse.AdressLine1);
                cmd.Parameters.AddWithValue("p7", c.Adresse.AdressLine2);
                cmd.Parameters.AddWithValue("p8", c.Adresse.Number);
                cmd.Parameters.AddWithValue("p9", c.Adresse.ZipCode);
                cmd.Parameters.AddWithValue("p10", c.Adresse.City);
                cmd.Parameters.AddWithValue("p11", c.Adresse.Country);

                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
>>>>>>> 08875cb14549968febbd8034a80d5b64b6f58f3e
                oConn.Close();
            }
        }

    }
}
