using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class CommentaireRepository
    {
        private NpgsqlConnection oConn;
        public CommentaireRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public int Create(Commentaire t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Commentaire OUTPUT inserted.Id VALUES (@p1)";
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
        /// Fetches a full list of all existing Commentaire Entities in the database
        /// </summary>
        /// <returns>IEnumerable of Commentaire Entity</returns>
        public IEnumerable<Commentaire> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Commentaire";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Commentaire> result = new List<Commentaire>();
                while (reader.Read())
                {
                    result.Add(new Commentaire
                    {   
                        Id = (int)reader["Id"],
                        DateTime = (DateTime)reader["Datetime"],
                        Contenu = reader["Contenu"].ToString(),
                        UserId = (int)reader["UserId"],
                        TaskId = (int)reader["TaskId"],
                        AlbumId = (int)reader["AlbumId"]
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
        /// Searches the database to find the Commentaire corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Commentaire Entity</returns>
        public Commentaire GetByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * Commentaire Task WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Commentaire t = null;
                if (reader.Read()) {
                    t = new Commentaire {
                        Id = (int)reader["Id"],
                        DateTime = (DateTime)reader["Datetime"],
                        Contenu = reader["Contenu"].ToString(),
                        UserId = (int)reader["UserId"],
                        TaskId = (int)reader["TaskId"],
                        AlbumId = (int)reader["AlbumId"]
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

        
        /// Searches the database to update the Commentaire corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="c">Commentaire Entity to be updated</param>
        /// <returns>True if Commentaire Entity has been updated, False if ID is not existing</returns>
        public bool Update(int id, Commentaire c) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Commentaire SET" +
                    "DateTime = @p2," +
                    "Contenu = @p3," +
                    "UserId = @p4," +
                    "TaskId = @p5" +
                    "AlbumId = @p6" +
                    "WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", c.DateTime);
                cmd.Parameters.AddWithValue("p3", c.Contenu);
                cmd.Parameters.AddWithValue("p4", c.UserId);
                cmd.Parameters.AddWithValue("p5", c.TaskId);
                cmd.Parameters.AddWithValue("p6", c.AlbumId);

                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }


        /// <summary>
        /// Searches the database to delete the Commentaire corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>True if Commentaire Entity has been deleted, False if ID is not existing</returns>
        public bool Delete(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Commentaire WHERE Id = @p1";
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
