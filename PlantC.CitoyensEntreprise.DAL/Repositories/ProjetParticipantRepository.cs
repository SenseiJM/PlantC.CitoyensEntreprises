using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class ProjetParticipantRepository {

        private NpgsqlConnection oConn;

        public ProjetParticipantRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        public int Create(Projet_Participant pp) {
            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO projet_participant(id_projet, id_participant, contribution) VALUES (@p1, @p2, @p3) RETURNING id";
                cmd.Parameters.AddWithValue("p1", pp.IdProjet);
                cmd.Parameters.AddWithValue("p2", pp.IdParticipant);
                cmd.Parameters.AddWithValue("p3", pp.Contribution);
                return (int)cmd.ExecuteScalar();

            } catch (Exception e) {

                throw;
            } finally {
                oConn.Close();
            }
        }

        public bool Update(int id, Projet_Participant pp) {
            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE projet_participant SET " +
                    "id_projet = @p2," +
                    "id_participant = @p3," +
                    "contribution = @p4," +
                    "date_contribution = @p5," +
                    "est_favori = @p6," +
                    "est_valide = @p7" +
                    "WHERE id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", pp.IdProjet);
                cmd.Parameters.AddWithValue("p3", pp.IdParticipant);
                cmd.Parameters.AddWithValue("p4", pp.Contribution);
                cmd.Parameters.AddWithValue("p5", pp.DateContribution);
                cmd.Parameters.AddWithValue("p6", pp.IsFavorite);
                cmd.Parameters.AddWithValue("p7", pp.IsValidated);

                return cmd.ExecuteNonQuery() != 0;

            } catch (Exception e) {

                throw;
            } finally {
                oConn.Close();
            }
        }

        public IEnumerable<Projet_Participant> GetAll() {
            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM projet_participant ORDER BY date_contribution DESC";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Projet_Participant> result = new();
                while (reader.Read()) {
                    result.Add(new Projet_Participant {
                        Contribution = (double)reader["contribution"],
                        DateContribution = (DateTime)reader["date_contribution"],
                        IdParticipant = (int)reader["id_participant"],
                        IdProjet = (int)reader["id_projet"],
                        IsFavorite = (bool)reader["est_favori"],
                        IsValidated = (bool)reader["est_valide"]
                    });
                }
                return result;

            } catch (Exception e) {

                throw;
            } finally {
                oConn.Close();
            }
        }

        public bool ValidateContribution(int id) {
            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE projet_participant SET " +
                    "est_valide = true " +
                    "WHERE id = @p1";
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
