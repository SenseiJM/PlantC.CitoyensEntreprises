using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
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
                cmd.CommandText = "INSERT INTO Projet(id_localisation, reference, infrastructure, nb_arbre, nb_fruits, metre, hectare, tonnes_co2, heures_travail, cout_du_projet) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10) RETURNING id";
                cmd.Parameters.AddWithValue("p1", p.IDLocalisation);
                cmd.Parameters.AddWithValue("p2", p.Reference);
                cmd.Parameters.AddWithValue("p3", p.Infrastructure);
                cmd.Parameters.AddWithValue("p4", p.NbArbres);
                cmd.Parameters.AddWithValue("p5", p.NbFruits);
                cmd.Parameters.AddWithValue("p6", p.Metres);
                cmd.Parameters.AddWithValue("p7", p.Hectares);
                cmd.Parameters.AddWithValue("p8", p.TonnesCO2);
                cmd.Parameters.AddWithValue("p9", p.HeuresTravail);
                cmd.Parameters.AddWithValue("p10", p.CoutDuProjet);
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        /// <summary>
        /// Fetches a list of all existing Projet Entities in the database
        /// </summary>
        /// <returns>IEnumerable of ProjetResumeView Entity</returns>
        public IEnumerable<ProjetResumeView> GetAllResume() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vue_projet";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<ProjetResumeView> result = new List<ProjetResumeView>();
                //On peut faire un mapper ici aussi (sur IDataRecord)
                while (reader.Read()) {
                    result.Add(new ProjetResumeView {
                        CoutDuProjet = (double)reader["cout_du_projet"],
                        Description = (string)reader["description"],
                        FirstImageUrl = (string)reader["image_url"],
                        Id = (int)reader["id"],
                        MontantRecolte = (double)reader["montant"],
                        NomLocalite = (string)reader["localite"],
                        Titre = (string)reader["titre"]
                    });
                }
                return result;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        /// <summary>
        /// Searches the database for a specific Projet ID
        /// </summary>
        /// <param name="id">ID of searched Projet Entity</param>
        /// <returns>A ProjetResumeView of the corresponding ID if found. Returns null if ID does not exist.</returns>
        public ProjetResumeView GetResumeByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM vue_projet WHERE id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                ProjetResumeView p = null;
                if (reader.Read()) {
                    p = new ProjetResumeView {
                        CoutDuProjet = (double)reader["cout_du_projet"],
                        Description = (string)reader["description"],
                        FirstImageUrl = (string)reader["image_url"],
                        Id = (int)reader["id"],
                        MontantRecolte = (double)reader["montant"],
                        NomLocalite = (string)reader["localite"],
                        Titre = (string)reader["titre"]
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

        /// <summary>
        /// Gets all markers for the Front-End Map
        /// </summary>
        /// <returns>A list of Markers</returns>
        public IEnumerable<MarqueurView> GetAllMarqueurs() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Marqueurs";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<MarqueurView> result = new List<MarqueurView>();
                while (reader.Read()) {
                    result.Add(new MarqueurView {
                        IdProjet = (int)reader["id"],
                        Infrastructure = (string)reader["infrastructure"],
                        Latitude = (double)reader["latitude"],
                        Longitude = (double)reader["longitude"]
                    });
                }
                return result;
            } catch (Exception) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        /// <summary>
        /// Searches the database to update the Projet corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="p"></param>
        /// <returns>True if Projet Entity has been updated, False if ID is not existing</returns>
        public bool UpdateProjet(int id, Projet p)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Projet SET" +
                    "Reference = @p2," +
                    "Infrastructure = @p3," +
                    "Hectares = @p4," +
                    "Metres = @p5," +
                    "IDLocalisation = @p6," +
                    "TonnesCO2 = @p7," +
                    "HeuresTravail = @p8," +
                    "CoutDuProjet = @p9," +
                    "NbFruits = @p10," +
                    "NbArbres = @p11," +
                    "Contribution = @p12," +
                    "WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", p.Reference);
                cmd.Parameters.AddWithValue("p3", p.Infrastructure);
                cmd.Parameters.AddWithValue("p4", p.Hectares);
                cmd.Parameters.AddWithValue("p5", p.Metres);
                cmd.Parameters.AddWithValue("p6", p.IDLocalisation);
                cmd.Parameters.AddWithValue("p7", p.TonnesCO2);
                cmd.Parameters.AddWithValue("p8", p.HeuresTravail);
                cmd.Parameters.AddWithValue("p9", p.CoutDuProjet);
                cmd.Parameters.AddWithValue("p10", p.NbFruits);
                cmd.Parameters.AddWithValue("p11", p.NbArbres);
                cmd.Parameters.AddWithValue("p12", p.Contribution);

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
                        Reference = (string)reader["Reference"],
                        TonnesCO2 = (double)reader["TonnesCO2"],
                        NbArbres = (int)reader["NbArbres"],
                        NbFruits = (int)reader["NbFruits"],
                        Metres = (int)reader["Metres"],
                        Hectares = (double)reader["Hectares"],
                        Contribution = (double)reader["Contribution"]
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
