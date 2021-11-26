using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class LocalisationRepository
    {
        private NpgsqlConnection oConn;
        public LocalisationRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public int Create(Localisation t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Localisation OUTPUT inserted.Id VALUES (@p1)";
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
        /// Fetches a full list of all existing Localisation Entities in the database
        /// </summary>
        /// <returns>IEnumerable of Localisation Entity</returns>
        public IEnumerable<Localisation> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Localisation";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Localisation> result = new List<Localisation>();
                while (reader.Read())
                {
                    result.Add(new Localisation
                    {
                        Id = (int)reader["Id"],
                        NomLocalite = reader["NomLocalite"].ToString(),
                        CodePostal = (uint)reader["CodePostal"],
                        Longitude = (double)reader["Longitude"],
                        Latitude = (double)reader["Latitude"]
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
        /// Searches the database to find the Localisation corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Localisation Entity</returns>
        public Localisation GetByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Localisation WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Localisation t = null;
                if (reader.Read()) {
                    t = new Localisation {
                        Id = (int)reader["Id"],
                        NomLocalite = reader["NomLocalite"].ToString(),
                        CodePostal = (uint)reader["CodePostal"],
                        Longitude = (double)reader["Longitude"],
                        Latitude = (double)reader["Latitude"]
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

        
        /// Searches the database to update the Localisation corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="c">Localisation Entity to be updated</param>
        /// <returns>True if Localisation Entity has been updated, False if ID is not existing</returns>
        public bool Update(int id, Localisation c) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Localisation SET" +
                    "NomeLocalite = @p2," +
                    "CodePostal = @p3," +
                    "Longitude = @p4," +
                    "Latitude = @p5" +
                    "WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", c.NomLocalite);
                cmd.Parameters.AddWithValue("p3", c.CodePostal);
                cmd.Parameters.AddWithValue("p4", c.Longitude);
                cmd.Parameters.AddWithValue("p5", c.Latitude);

                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }


        /// <summary>
        /// Searches the database to delete the Localisation corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>True if Localisation Entity has been deleted, False if ID is not existing</returns>
        public bool Delete(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Localisation WHERE Id = @p1";
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
