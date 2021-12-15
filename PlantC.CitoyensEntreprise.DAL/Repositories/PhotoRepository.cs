using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class PhotoRepository {

        private NpgsqlConnection oConn;
        public PhotoRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        public int Create(Photo p) {
            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO photo(id_projet, est_publique, url_photo, est_principale) VALUES (@p1, @p2, @p3, @p4)";
                cmd.Parameters.AddWithValue("p1", p.IdProjet);
                cmd.Parameters.AddWithValue("p2", p.IsPublic);
                cmd.Parameters.AddWithValue("p3", p.URLPhoto);
                cmd.Parameters.AddWithValue("p4", p.IsPrincipale);
                return (int)cmd.ExecuteScalar();

            } catch (Exception e) {

                throw;
            } finally {
                oConn.Close();
            }
        }

        public IEnumerable<Photo> GetByProject(int id) {
            oConn.Open();
            NpgsqlCommand cmd = oConn.CreateCommand();
            cmd.CommandText = "SELECT * FROM photo WHERE id_projet = @id";
            cmd.Parameters.AddWithValue("id", id);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                yield return new Photo() {
                    Id = (int)reader["id"],
                    IdProjet = (int)reader["id_projet"],
                    IsPrincipale = (bool)reader["est_principale"],
                    IsPublic = (bool)reader["est_publique"],
                    URLPhoto = (string)reader["url_photo"]
                };
            }
            oConn.Close();
        }

    }
}
