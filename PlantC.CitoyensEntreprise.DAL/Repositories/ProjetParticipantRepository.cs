using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class ProjetParticipantRepository
    {
        private NpgsqlConnection oConn;
        public TaskRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public int Create(ProjetParticipant t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO ProjetParticipant OUTPUT inserted.Id VALUES (@p1)";
                cmd.Parameters.AddWithValue("p1", t);
                return (int)cmd.ExecuteScalar();
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
        /// Fetches a full list of all existing ProjetParticipant Entities in the database
        /// </summary>
        /// <returns>IEnumerable of ProjetParticipant Entity</returns>
        public IEnumerable<ProjetParticipant> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ProjetParticipant";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<ProjetParticipant> result = new List<ProjetParticipant>();
                while (reader.Read())
                {
                    result.Add(new ProjetParticipant
                    {
                        Id = (int)reader["Id"],
                        ParticipantId = (int)reader["ParticipantId"],
                        ProjetId = (int)reader["ProjetId"],
                        Contribution = (double)reader["Contribution"],
                        DateContribution = (DateTime)reader["DateContribution"]
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


        /// <summary>
        /// Searches the database to find the ProjetParticipant corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding ProjetParticipant Entity</returns>
        public ProjetParticipant GetByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ProjetParticpant WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Task t = null;
                if (reader.Read()) {
                    t = new ProjetParticipant {
                        Id = (int)reader["Id"],
                        ParticipantId = (int)reader["ParticipantId"],
                        ProjetId = (int)reader["ProjetId"],
                        Contribution = (double)reader["Contribution"],
                        DateContribution = (DateTime)reader["DateContribution"]
                    };
                    return t;
                } else {
                    return null;
                }
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        
        /// Searches the database to update the ProjetParticipant corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="c">ProjetParticipant Entity to be updated</param>
        /// <returns>True if ProjetParticipant Entity has been updated, False if ID is not existing</returns>
        public bool Update(int id, ProjetParticipant c) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE ProjetParticipant SET" +
                    "ParticipantId = @p2," +
                    "ProjetId = @p3," +
                    "Contribution = @p4," +
                    "DateContribution = @p5" +
                    "WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", c.ParticipantId);
                cmd.Parameters.AddWithValue("p3", c.ProjetId);
                cmd.Parameters.AddWithValue("p4", c.Contribution);
                cmd.Parameters.AddWithValue("p6", c.DateContribution);

                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }


        /// <summary>
        /// Searches the database to delete the ProjetParticipant corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>True if projetParticipant Entity has been deleted, False if ID is not existing</returns>
        public bool Delete(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM ProjetParticipant WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

    }
}
