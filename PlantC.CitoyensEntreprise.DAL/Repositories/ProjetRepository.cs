using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class ProjetRepository {

        private NpgsqlConnection oConn;

        public ProjetRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        /// <summary>
        /// Adds a new Projet entity in the database
        /// </summary>
        /// <param name="p">New Projet Entity to be added in the database</param>
        /// <returns>ID of the created Entity</returns>
        public int Create(Projet p) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Projet OUTPUT inserted.Id VALUES (@p1)";
                cmd.Parameters.AddWithValue("p1", p);
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        /// <summary>
        /// Fetches a full list of all existing Projet Entities in the database
        /// </summary>
        /// <returns>IEnumerable of Projet Entity</returns>
        public IEnumerable<Projet> GetAll() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Projet";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Projet> result = new List<Projet>();
                //On peut faire un mapper ici aussi (sur IDataRecord)
                while (reader.Read()) {
                    result.Add(new Projet {
                        Reference = reader["Reference"].ToString(),
                        Infrastructure = reader["Infrastructure"].ToString(),
                        Quantite = (double)reader["Quantite"],
                        UniteDeMesure = reader["UniteDeMesure"].ToString(),
                        IDLocalisation = (int)reader["IDLocalisation"],
                        TonnesCO2 = (double)reader["TonnesCO2"],
                        HeuresTravail = (double)reader["HeuresTravail"],
                        CoutDuProjet = (double)reader["CoutDuProjet"]
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
        /// Searches the database to update the Projet corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <returns>True if Projet Entity has been updated, False if ID is not existing</returns>
        public bool UpdateProjet(int id, Projet p)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Fishs SET" +
                    "Reference = @p2," +
                    "Infrastructure = @p3," +
                    "Quantite = @p4," +
                    "UniteDeMesure = @p5," +
                    "IDLocalisation = @p6," +
                    "TonnesCO2 = @p7," +
                    "HeuresTravail = @p8," +
                    "CoutDuProjet = @p9," +
                    "WHERE Id = id";
                cmd.Parameters.AddWithValue("p2", p.Reference);
                cmd.Parameters.AddWithValue("p3", p.Infrastructure);
                cmd.Parameters.AddWithValue("p4", p.Quantite);
                cmd.Parameters.AddWithValue("p5", p.UniteDeMesure);
                cmd.Parameters.AddWithValue("p6", p.IDLocalisation);
                cmd.Parameters.AddWithValue("p7", p.TonnesCO2);
                cmd.Parameters.AddWithValue("p8", p.HeuresTravail);
                cmd.Parameters.AddWithValue("p9", p.CoutDuProjet);

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
            /// Searches the database to delete the Projet corresponding to the ID
            /// </summary>
            /// <param name="id">ID to be deleted</param>
            /// <returns>True if Projet Entity has been deleted, False if ID is not existing</returns>
            public bool DeleteProjet(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Projet WHERE Id = @p1";
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
        /// Searches the database to find the Projet corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Projet Entity</returns>
        public Projet GetByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Projet WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Projet p = null;
                if (reader.Read()) {
                    p = new Projet {
                        CoutDuProjet = (double)reader["CoutDuProjet"],
                        HeuresTravail = (double)reader["HeuresTravail"],
                        Id = (int)reader["Id"],
                        IDLocalisation = (int)reader["IDLocalisation"],
                        Infrastructure = (string)reader["Infrastructure"],
                        Quantite = (double)reader["Quantite"],
                        Reference = (string)reader["Reference"],
                        TonnesCO2 = (double)reader["TonnesCO2"],
                        UniteDeMesure = (string)reader["UniteDeMesure"]
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
