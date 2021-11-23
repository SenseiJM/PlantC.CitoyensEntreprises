using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;

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

    }
}
