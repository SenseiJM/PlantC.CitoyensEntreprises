using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class ProjetRepository
    {

        private NpgsqlConnection oConn;

        public ProjetRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        /// <summary>
        /// Fetches a list of all existing Projet Entities in the database
        /// </summary>
        /// <returns>IEnumerable of ProjetResumeView Entity</returns>
        public IEnumerable<ProjetResumeView> GetAllResume() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM projet_resume";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<ProjetResumeView> result = new List<ProjetResumeView>();
                //On peut faire un mapper ici aussi (sur IDataRecord)
                while (reader.Read()) {
                    result.Add(new ProjetResumeView {
                        CoutDuProjet = (decimal)reader["cout_du_projet"],
                        Description = (string)reader["description"],
                        FirstImageUrl = reader["url_photo"] as string,
                        Id = (int)reader["id_projet"],
                        MontantRecolte = reader["tot"] as decimal? ?? 0,
                        NomLocalite = (string)reader["localite"],
                        Titre = (string)reader["titre"],
                        Infrastructure = (string)reader["infrastructure"]
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
                cmd.CommandText = "SELECT * FROM projet_resume WHERE id_projet = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                ProjetResumeView p = null;
                if (reader.Read()) {
                    p = new ProjetResumeView {
                        CoutDuProjet = (decimal)reader["cout_du_projet"],
                        Description = (string)reader["description"],
                        FirstImageUrl = reader["url_photo"] as string,
                        Id = (int)reader["id_projet"],
                        MontantRecolte = reader["tot"] as decimal? ?? 0,
                        NomLocalite = (string)reader["localite"],
                        Titre = (string)reader["titre"],
                        Infrastructure = (string)reader["infrastructure"]
                    };
                    return p;
                } else {
                    return null;
                }
            } catch (Exception e) {
                throw;
            }
            finally
            {
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
                        Latitude = (decimal)reader["latitude"],
                        Longitude = (decimal)reader["longitude"]
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
        /// Searches the database for a specific Projet ID
        /// </summary>
        /// <param name="id">ID of searched Projet Entity</param>
        /// <returns>A ProjetDetailsView of the corresponding ID if found. Returns null if ID does not exist.</returns>
        public ProjetDetailsView GetDetailsByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM projet_details WHERE id_projet = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                ProjetDetailsView p = null;
                if (reader.Read()) {
                    p = new ProjetDetailsView {
                        CoutDuProjet = (decimal)reader["cout_du_projet"],
                        Description = (string)reader["description"],
                        Localite = (string)reader["localite"],
                        MontantRecolte = reader["tot"] as decimal? ?? 0,
                        Titre = (string)reader["titre"],
                        TonnesCO2 = (decimal)reader["tonnes_co2"],
                        Id = id
                    };
                    if (reader["url_photo"] != DBNull.Value) {
                        p.ImagesURLs = new List<string> {
                            (string)reader["url_photo"]
                        };
                        while (reader.Read()) {
                            p.ImagesURLs.Add((string)reader["url_photo"]);
                        }
                    }
                    return p;
                } else {
                    return null;
                }
            } catch (Exception e) {
                throw;
            }
            finally
            {
                oConn.Close();
            }
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
                cmd.CommandText = "INSERT INTO Projet(id_localisation, reference, titre, description, infrastructure, nb_arbre, nb_fruits, metre, hectare, tonnes_co2, heures_travail, cout_du_projet, date_creation) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13) RETURNING id";
                cmd.Parameters.AddWithValue("p1", p.IDLocalisation);
                cmd.Parameters.AddWithValue("p2", p.Reference);
                cmd.Parameters.AddWithValue("p3", p.Titre);
                cmd.Parameters.AddWithValue("p4", p.Description);
                cmd.Parameters.AddWithValue("p5", p.Infrastructure);
                cmd.Parameters.AddWithValue("p6", (object)p.NbArbres??DBNull.Value);
                cmd.Parameters.AddWithValue("p7", (object)p.NbFruits??DBNull.Value);
                cmd.Parameters.AddWithValue("p8", (object)p.Metres??DBNull.Value);
                cmd.Parameters.AddWithValue("p9", (object)p.Hectares??DBNull.Value);
                cmd.Parameters.AddWithValue("p10", p.TonnesCO2);
                cmd.Parameters.AddWithValue("p11", p.HeuresTravail);
                cmd.Parameters.AddWithValue("p12", p.CoutDuProjet);
                cmd.Parameters.AddWithValue("p13", p.DateCreation);
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw; //Numeric field overflow
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
        public bool Update(int id, Projet p)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE projet SET " +
                    "id_localisation = @p2," +
                    "reference = @p3," +
                    "titre = @p4," +
                    "description = @p5," +
                    "infrastructure = @p6," +
                    "nb_arbre = @p7," +
                    "nb_fruits = @p8," +
                    "metre = @p9," +
                    "hectare = @p10," +
                    "tonnes_co2 = @p11," +
                    "heures_travail = @p12," +
                    "cout_du_projet = @p13 " +
                    "WHERE id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", p.IDLocalisation);
                cmd.Parameters.AddWithValue("p3", p.Reference);
                cmd.Parameters.AddWithValue("p4", p.Titre);
                cmd.Parameters.AddWithValue("p5", p.Description);
                cmd.Parameters.AddWithValue("p6", p.Infrastructure);
                cmd.Parameters.AddWithValue("p7", (object)p.NbArbres??DBNull.Value);
                cmd.Parameters.AddWithValue("p8", (object)p.NbFruits??DBNull.Value);
                cmd.Parameters.AddWithValue("p9", (object)p.Metres??DBNull.Value);
                cmd.Parameters.AddWithValue("p10", (object)p.Hectares ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p11", p.TonnesCO2);
                cmd.Parameters.AddWithValue("p12", p.HeuresTravail);
                cmd.Parameters.AddWithValue("p13", p.CoutDuProjet);

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
                cmd.CommandText = "DELETE FROM projet WHERE id = @p1";
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
        public Projet GetByID(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Projet WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Projet p = null;
                if (reader.Read())
                {
                    p = new Projet
                    {
                        Reference = reader["reference"].ToString(),
                        Infrastructure = reader["infrastructure"].ToString(),
                        Hectares = reader["hectare"] as decimal?,
                        Id = (int)reader["id"],
                        Metres = reader["metre"] as int?,
                        NbArbres = reader["nb_arbre"] as int?,
                        NbFruits = reader["nb_fruits"] as int?,
                        IDLocalisation = (int)reader["id_localisation"],
                        TonnesCO2 = (decimal)reader["tonnes_co2"],
                        HeuresTravail = (decimal)reader["heures_travail"],
                        CoutDuProjet = (decimal)reader["cout_du_projet"]
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

    }
}
