using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class ParticipantRepository {

        private NpgsqlConnection oConn;
        public ParticipantRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        /// <summary>
        /// Adds a new Participant Entity in the database
        /// </summary>
        /// <param name="p">New Participant Entity to be added in the database</param>
        /// <returns>ID of the created Entity</returns>
        public int Create(Participant p) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Participant OUTPUT inserted.Id VALUES (@p1)";
                cmd.Parameters.AddWithValue("p1", p);
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        /// <summary>
        /// Searches the database to find the Participant corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Participant Entity</returns>
        public Participant GetByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Participant WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Participant p = null;
                if (reader.Read()) {
                    p = new Participant {
                        BCE = (uint?)reader["BCE"],
                        Fonction = (Enums.Fonction)reader["Fonction"],
                        Id = (int)reader["Id"],
                        IdContact = (int)reader["IdContact"],
                        NomEntreprise = (string)reader["NomEntreprise"]
                    };
                    return p;
                } else {
                    return null;
                }
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

    }
}
