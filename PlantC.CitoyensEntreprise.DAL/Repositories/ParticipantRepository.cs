using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

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
                        BCE = (string)reader["BCE"],
                        Fonction = (Enums.Fonction)reader["Fonction"],
                        Id = (int)reader["Id"],
                        NomEntreprise = (string)reader["NomEntreprise"],
                        IdAdresse = (int)reader["IdAdresse"],
                        Mail = (string)reader["Mail"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"],
                        Telephone = (string)reader["Telephone"]
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

        // <summary>
        /// Searches the database to delete the Participant corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>True if Participant Entity has been deleted, False if ID is not existing</returns>
        public bool DeleteParticipant(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Participant WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                return cmd.ExecuteNonQuery() != 0;
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


        /// <summary>
        /// Fetches a full list of all existing Participant Entities in the database
        /// </summary>
        /// <returns>IEnumerable of Projet Entity</returns>
        public IEnumerable<Participant> GetAll() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Participant";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Participant> result = new List<Participant>();
                while (reader.Read()) {
                    result.Add(new Participant {
                        BCE = (string)reader["BCE"],
                        Fonction = (Enums.Fonction)reader["Fonction"],
                        Id = (int)reader["Id"],
                        NomEntreprise = (string)reader["NomEntreprise"],
                        Telephone = (string)reader["Telephone"],
                        Prenom = (string)reader["Prenom"],
                        Nom = (string)reader["Nom"],
                        Mail = (string)reader["Mail"],
                        IdAdresse = (int)reader["IdAdresse"]
                    });
                }
                return result;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        // <summary>
        /// Searches the database to update the Participant corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <returns>True if Participant Entity has been updated, False if ID is not existing</returns>
        public bool UpdateParticipant(int id, Participant p)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Participant SET" +
                    "Fonction = @p2," +
                    "NomEntreprise = @p3," +
                    "BCE = @p4," +
                    "Nom = @p5," +
                    "Prenom = @p6," +
                    "Telephone = @p7," +
                    "IdAdresse = @p8," +
                    "Mail = @p9";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", p.Fonction);
                cmd.Parameters.AddWithValue("p3", p.NomEntreprise);
                cmd.Parameters.AddWithValue("p4", p.BCE);
                cmd.Parameters.AddWithValue("p5", p.Nom);
                cmd.Parameters.AddWithValue("p6", p.Prenom);
                cmd.Parameters.AddWithValue("p7", p.Telephone);
                cmd.Parameters.AddWithValue("p8", p.IdAdresse);
                cmd.Parameters.AddWithValue("p9", p.Mail);

                return cmd.ExecuteNonQuery() != 0;
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
