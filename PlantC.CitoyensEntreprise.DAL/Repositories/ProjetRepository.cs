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
                        Hectares = (double)reader["Hectares"],
                        Id = (int)reader["Id"],
                        Metres = (int)reader["Metres"],
                        NbArbres = (int)reader["NbArbres"],
                        NbFruits = (int)reader["NbFruits"],
                        IDLocalisation = (int)reader["IDLocalisation"],
                        TonnesCO2 = (double)reader["TonnesCO2"],
                        HeuresTravail = (double)reader["HeuresTravail"],
                        CoutDuProjet = (double)reader["CoutDuProjet"],
                        Contribution = (double)reader["Contribution"]
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


        public IEnumerable<ProjetListing> GetListing() {

            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT p.id AS id_projet, p.reference, ph.url_photo, p.description, l.localite, p.cout_du_projet, p.infrastructure, p.est_nouveau, pp.est_favori, l.latitude, l.longitude FROM projet p LEFT JOIN photo ph ON ph.id_projet = p.id AND ph.est_publique = true LEFT JOIN localisation l ON p.id_localisation = l.id LEFT JOIN projet_participant ON p.id = pp.id_projet AND pp.est_favori = true LIMIT 1";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<ProjetListing> result = new List<ProjetListing> ();
                while (reader.Read()) {
                    result.Add(new ProjetListing {
                        CoutDuProjet = (double)reader["cout_du_projet"],
                        Description = (string)reader["description"],
                        EstFavori = (bool)reader["est_favori"],
                        EstNouveau = (bool)reader["est_nouveau"],
                        Id = (int)reader["id_projet"],
                        imageUrl = (string)reader["url_photo"],
                        Infrastructure = (string)reader["infrastructure"],
                        Latitude = (double)reader["latitude"],
                        Longitude = (double)reader["longitude"],
                        NomLocalite = (string)reader["localite"],
                        Reference = (string)reader["reference"]
                    });
                }

                foreach (ProjetListing listing in result) {

                    listing.MontantRecolte = 0;
                    cmd.CommandText = "SELECT pp.contribution AS montant FROM projet_participant pp WHERE pp.id_projet = @p1";
                    cmd.Parameters.AddWithValue("p1", listing.Id);
                    reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        listing.MontantRecolte += (double)reader["montant"];
                    }

                }

                return result;

            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }

        }

    }
}
