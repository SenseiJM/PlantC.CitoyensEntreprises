using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class CommentaireRepository {
        private NpgsqlConnection oConn;
        public CommentaireRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }
        public int Create(Commentaire c) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO  ";
                cmd.Parameters.AddWithValue("");
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw; //return e.Message
            } finally {
                oConn.Close();
            }
        }
        public IEnumerable<Commentaire> GetAllByIdTache() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Commentaire> result = new List<Commentaire>();
                while (reader.Read()) {
                    result.Add(new Commentaire {
                    });
                }
                return result;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }
        public bool UpdateTache(Tache t) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE tache SET" +
                                  "  id_participant = @p1" +
                                  " ,id_projet = @p2" +
                                  " ,date_debut = @p3" +
                                  " ,date_fin = @p4" +
                                  " ,description =@p5 " +
                                  " ,est_assigne = @p6" +
                                  " ,est_termine = @p7" +
                                  " ,_type = @p8" +
                                  " WHERE id = @Id ";
                cmd.Parameters.AddWithValue("Id", t.Id);
                cmd.Parameters.AddWithValue("@p1", (object)t.Id_Participant ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@p2", t.Id_Projet);
                cmd.Parameters.AddWithValue("@p3", t.Date_Debut);
                cmd.Parameters.AddWithValue("@p4", t.Date_Fin);
                cmd.Parameters.AddWithValue("@p5", t.Description);
                cmd.Parameters.AddWithValue("@p6", t.Est_Assigne);
                cmd.Parameters.AddWithValue("@p7", t.Est_Termine);
                cmd.Parameters.AddWithValue("@p8", t.Type);

                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }
        public bool DeleteTache(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM tache WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);
                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }
        public Tache GetByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Tache result = new Tache();
                if (reader.Read()) {
                    result = (new Tache {
                        Id = (int)reader["id"],
                        Id_Participant = reader["id_participant"] as int?,
                        Id_Projet = (int)reader["id_projet"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"]
                    });

                    return result;
                } else {
                    return null;
                }
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }
        public IEnumerable<Tache> GetByProjectId(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache WHERE id_projet = @id";
                cmd.Parameters.AddWithValue("id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Tache> result = new List<Tache>();
                while (reader.Read()) {
                    result.Add(new Tache {
                        Id = (int)reader["id"],
                        Id_Participant = reader["id_participant"] as int?,
                        Id_Projet = (int)reader["id_projet"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"]
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
