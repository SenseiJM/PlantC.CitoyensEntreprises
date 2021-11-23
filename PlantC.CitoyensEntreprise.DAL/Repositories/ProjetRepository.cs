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
    }
}
