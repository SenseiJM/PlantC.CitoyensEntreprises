using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class AlbumRepository
    {
        private NpgsqlConnection oConn;
        public AlbumRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public int Create(Album t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Album OUTPUT inserted.Id VALUES (@p1)";
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
        /// Fetches a full list of all existing Album Entities in the database
        /// </summary>
        /// <returns>IEnumerable of Album Entity</returns>
        public IEnumerable<Album> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Album";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Album> result = new List<Album>();
                while (reader.Read())
                {
                    result.Add(new Album
                    {
                        Id = (int)reader["Id"],
                        ProjetId = (int)reader["ProjetId"],
                        URLPhoto = reader["URLPhoto"].ToString(),
                        IsPublic = (bool)reader["IsPublic"]
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
        /// Searches the database to find the Album corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Album Entity</returns>
        public Album GetByID(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * Album Task WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Album t = null;
                if (reader.Read())
                {
                    t = new Album
                    {
                        Id = (int)reader["Id"],
                        ProjetId = (int)reader["ProjetId"],
                        URLPhoto = reader["URLPhoto"].ToString(),
                        IsPublic = (bool)reader["IsPublic"]
                    };
                    return t;
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


        /// Searches the database to update the Album corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="c">Album Entity to be updated</param>
        /// <returns>True if Album Entity has been updated, False if ID is not existing</returns>
        public bool Update(int id, Album c)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Album SET" +
                    "ProjetId = @p2," +
                    "URLPhoto = @p3," +
                    "IsPublic = @p4," +
                    "WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", c.ProjetId);
                cmd.Parameters.AddWithValue("p3", c.URLPhoto);
                cmd.Parameters.AddWithValue("p4", c.IsPublic);

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
        /// Searches the database to delete the Album corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>True if Album Entity has been deleted, False if ID is not existing</returns>
        public bool Delete(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Album WHERE Id = @p1";
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

    }
}
