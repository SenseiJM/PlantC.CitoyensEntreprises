using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class TagRepository
    {
        private NpgsqlConnection oConn;

        public TagRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public IEnumerable<Tag> GetTagByProjet(int idprojet)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT id_tag,nom FROM projet_tag pt " +
                    "JOIN tag t ON pt.id_tag = t.id " +
                    "WHERE id_projet = @p1";
                cmd.Parameters.AddWithValue("p1", idprojet);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Tag> result = new List<Tag>();
                while (reader.Read())
                {
                    result.Add( new Tag
                    {
                        Id = (int)reader["id_tag"],
                        Nom = (string)reader["nom"]
                    });
                }
                return result;
            }
            catch (Exception e)
            {
                throw; //return e.message?
            }
            finally
            {
                oConn.Close();
            }
        }

        public IEnumerable<Marqueurs> GetMarqueursByTag(List<string> tags , int? codepostal = null )
        {
            try
            {
                string whereP = "WHERE t.nom IN (";
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                for (int i = 0; i < tags.Count; i++)
                {
                    cmd.Parameters.AddWithValue("p" + i, tags[i]);
                    if (i - 1 == tags.Count)
                    {
                        whereP = whereP + ("'@p" + i + "'");
                        whereP = whereP + ")";
                    }
                    else
                    {
                        whereP = whereP + ("'@p" + i + "',");
                    }
                }
                cmd.CommandText =
                    "SELECT latitude, longitude, infrastructure, p.id" +
                    "FROM projet p" +
                    "JOIN localisation ON p.id_localisation = localisation.id)" +
                    "WHERE p.id IN(" +
                    "   SELECT pt.id_projet FROM projet_tag pt" +
                    "   JOIN tag t ON t.id = pt.id_tag" +
                    whereP +
                    "AND ('@codepostal' is nuLL OR p.id IN (" +
                    "   SELECT p.id" +
                    "   FROM projet p" +
                    "    JOIN localisation l on l.id = p.id_localisation" +
                    "    WHERE code_postal LIKE '@codepostal'" +
                    "))";
                List<Marqueurs> result = new List<Marqueurs>();
                cmd.Parameters.AddWithValue("codepostal", (object)codepostal ?? DBNull.Value);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Marqueurs
                    {
                        Id = (int)reader["id"],
                        Infrastructure = reader["infrastructure"].ToString(),
                        Latitude = (decimal)reader["latitude"],
                        Longitude =(decimal)reader["longitude"]
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

        public void Insert(Tag item, int idProj)
        {
            oConn.Open();
            var cmd = oConn.CreateCommand();
            cmd.CommandText = "INSERT INTO projet_tag(id_projet, id_tag) VALUES (@p1, (SELECT id FROM tag WHERE nom LIKE @p2))";
            cmd.Parameters.AddWithValue("p1", idProj);
            cmd.Parameters.AddWithValue("p2", item.Nom);
            cmd.ExecuteNonQuery();
            oConn.Close();
        }

        public IEnumerable<Marqueurs> GetMarqueurs() {
            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT latitude, longitude, infrastructure, p.id FROM projet p JOIN localisation ON p.id_localisation = localisation.id";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Marqueurs> result = new();

                while (reader.Read()) {
                    result.Add(new Marqueurs {
                        Id = (int)reader["id"],
                        Infrastructure = (string)reader["infrastructure"],
                        Latitude = (decimal)reader["latitude"],
                        Longitude = (decimal)reader["longitude"]
                    });
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
