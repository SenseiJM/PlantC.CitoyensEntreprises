using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class ParticipantRepository
    {

        private NpgsqlConnection oConn;
        public ParticipantRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        /// <summary>
        /// Adds a new Participant Entity in the database
        /// </summary>
        /// <param name="p">New Participant Entity to be added in the database</param>
        /// <returns>ID of the created Entity</returns>
        public int Create(Participant p)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO participant(fonction, nom_entreprise, bce, nom, prenom, mail, telephone, id_adresse, salt, mdp_client) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10) RETURNING id";
                cmd.Parameters.AddWithValue("p1", p.Fonction);
                cmd.Parameters.AddWithValue("p2", (object)p.NomEntreprise??DBNull.Value);
                cmd.Parameters.AddWithValue("p3", (object)p.BCE ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p4", p.Nom);
                cmd.Parameters.AddWithValue("p5", p.Prenom);
                cmd.Parameters.AddWithValue("p6", p.Email);
                cmd.Parameters.AddWithValue("p7", p.Telephone);
                cmd.Parameters.AddWithValue("p8", (object)p.IdAdresse??DBNull.Value);
                cmd.Parameters.AddWithValue("p9", p.Salt);
                cmd.Parameters.AddWithValue("p10", p.MdpClient);
                int newId = (int)cmd.ExecuteScalar();
                p.Id = newId;
                return newId;
            }
            catch (Exception e)
            {
                throw; //return e.Message
            }
            finally
            {
                oConn.Close();
            }
        }

        /// <summary>
        /// Searches the database to find the Participant corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Participant Entity</returns>
        public Participant GetByID(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Participant WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Participant p = null;
                if (reader.Read())
                {
                    p = new Participant
                    {
                        BCE = (string)reader["BCE"],
                        Fonction = (Fonction)reader["Fonction"],
                        Id = (int)reader["Id"],
                        NomEntreprise = (string)reader["NomEntreprise"],
                        IdAdresse = (int)reader["IdAdresse"],
                        Email = (string)reader["Email"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"],
                        Telephone = (string)reader["Telephone"],
                        EstVerifie = (bool)reader["est_verifie"]
                    };
                    return p;
                }
                else
                {
                    return null;
                }
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
        public IEnumerable<Participant> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM participant";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Participant> result = new List<Participant>();
                while (reader.Read()) {
                    result.Add(new Participant {
                        BCE = reader["bce"] as string,
                        Fonction = (Enums.Fonction)reader["fonction"],
                        Id = (int)reader["id"],
                        NomEntreprise = reader["nom_entreprise"] as string,
                        Telephone = (string)reader["telephone"],
                        Prenom = (string)reader["prenom"],
                        Nom = (string)reader["nom"],
                        Email = (string)reader["mail"],
                        IdAdresse = reader["id_adresse"] as int?,
                        EstVerifie = (bool)reader["est_verifie"]
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
                    "Email = @p9";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", p.Fonction);
                cmd.Parameters.AddWithValue("p3", p.NomEntreprise);
                cmd.Parameters.AddWithValue("p4", p.BCE);
                cmd.Parameters.AddWithValue("p5", p.Nom);
                cmd.Parameters.AddWithValue("p6", p.Prenom);
                cmd.Parameters.AddWithValue("p7", p.Telephone);
                cmd.Parameters.AddWithValue("p8", p.IdAdresse);
                cmd.Parameters.AddWithValue("p9", p.Email);

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
