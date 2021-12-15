using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class TacheRepository
    {
        private NpgsqlConnection oConn;
        public TacheRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        /// <summary>
        /// Adds a new Task Entity in the database
        /// </summary>
        /// <params name="t">New Task Entity to be added in the database</param>
        /// <returns>ID of the created Entity</returns>
        public int Create(Tache t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO tache " +
                    "(id_participant, date_debut, date_fin, id_projet, _type, description)" +
                    " VALUES (@Id_Participant, @Date_Debut, @Date_Fin, @Id_Projet, @Type, @Description) returning id";
                cmd.Parameters.AddWithValue("Id_Participant", (object)t.Id_Participant?? DBNull.Value);
                cmd.Parameters.AddWithValue("Date_Debut", (object)t.Date_Debut ?? DBNull.Value);
                cmd.Parameters.AddWithValue("Date_Fin", (object)t.Date_Fin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("Id_Projet", t.Id_Projet);
                cmd.Parameters.AddWithValue("Type", t.Type);
                cmd.Parameters.AddWithValue("Description", t.Description);
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw; //return e.Message
            }
            finally
            {
                oConn.Close();
            }
        }

        /// <summary>
        /// Recover the complete list of Task 
        /// </summary>
        /// <returns>IEnumerable of Task Entity</returns>
        public IEnumerable<TacheDetails> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache_details";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<TacheDetails> result = new List<TacheDetails>();
                while (reader.Read())
                {
                    result.Add(new TacheDetails {
                        Id = (int)reader["id"],
                        Id_Participant = reader["id_participant"] as int?,
                        Id_Projet = (int)reader["id_projet"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"],
                        Email = reader["mail_participant"] as string,
                        Fonction = (reader["fonction_participant"] as Fonction ?) ?? default(Fonction),
                        Nom = reader["nom_participant"] as string,
                        Prenom = reader["prenom_participant"] as string,
                        Titre = reader["titre_projet"] as string,
                        Reference = (string)reader["reference_projet"],
                        AdressLine1 = reader["adresse_1"] as string,
                        AdressLine2 = reader["adresse_2"] as string,
                        City = reader["localite"] as string,
                        Number = reader["numero"] as string,
                        ZipCode = reader["code_postal"] as string,
                        Country = reader["pays"] as string
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
        /// Searches the database to update the Task corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="t">New Task values to be updated</param>
        /// <returns>True if Task Entity has been updated, False if ID is not existing or not updated </returns>
        public bool UpdateTache(Tache t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE tache SET" +
                                  "  id_participant = @p1" +
                                  " ,id_projet = @p2"+
                                  " ,date_debut = @p3" +
                                  " ,date_fin = @p4"+
                                  " ,description =@p5 "+
                                  " ,est_assigne = @p6" +
                                  " ,est_termine = @p7" +
                                  " ,_type = @p8" +
                                  " WHERE id = @Id "; 
                cmd.Parameters.AddWithValue("Id", t.Id);
                cmd.Parameters.AddWithValue("@p1", (object)t.Id_Participant?? DBNull.Value);
                cmd.Parameters.AddWithValue("@p2", t.Id_Projet);
                cmd.Parameters.AddWithValue("@p3", t.Date_Debut);
                cmd.Parameters.AddWithValue("@p4", t.Date_Fin);
                cmd.Parameters.AddWithValue("@p5", t.Description);
                cmd.Parameters.AddWithValue("@p6", t.Est_Assigne);
                cmd.Parameters.AddWithValue("@p7", t.Est_Termine);
                cmd.Parameters.AddWithValue("@p8", t.Type);

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
        /// Searches the database to delete the Task corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>True if Task Entity has been deleted, False if ID is not existing</returns>
        public bool DeleteTache(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM tache WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);
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
        /// Searches the database to find the Task corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Task Entity</returns>
        public TacheDetails GetByID(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache_details WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    return new TacheDetails {
                        Id = (int)reader["id"],
                        Id_Participant = reader["id_participant"] as int?,
                        Id_Projet = (int)reader["id_projet"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"],
                        Email = reader["mail_participant"] as string,
                        Fonction = (reader["fonction_participant"] as Fonction?) ?? default(Fonction),
                        Nom = reader["nom_participant"] as string,
                        Prenom = reader["prenom_participant"] as string,
                        Titre = reader["titre_projet"] as string,
                        Reference = (string)reader["reference_projet"],
                        AdressLine1 = reader["adresse_1"] as string,
                        AdressLine2 = reader["adresse_2"] as string,
                        City = reader["localite"] as string,
                        Number = reader["numero"] as string,
                        ZipCode = reader["code_postal"] as string,
                        Country = reader["pays"] as string
                    };
                }
                else {
                    return null;
                }
            }
            catch (Exception e) {
                throw;
            }
            finally {
                oConn.Close();
            }
        }

        /// <summary>
        /// Collects all the tasks related to a project
        /// </summary>
        /// <returns>IEnumerable of Task Entity</returns>
        public IEnumerable<TacheDetails> GetByProjectId(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache_details WHERE id_projet = @id";
                cmd.Parameters.AddWithValue("id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<TacheDetails> result = new();
                while (reader.Read())
                {
                    result.Add(new TacheDetails {
                        Id = (int)reader["id"],
                        Id_Participant = reader["id_participant"] as int?,
                        Id_Projet = (int)reader["id_projet"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"],
                        Email = reader["mail_participant"] as string,
                        Fonction = (reader["fonction_participant"] as Fonction?) ?? default(Fonction),
                        Nom = reader["nom_participant"] as string,
                        Prenom = reader["prenom_participant"] as string,
                        Titre = reader["titre_projet"] as string,
                        Reference = (string)reader["reference_projet"],
                        AdressLine1 = reader["adresse_1"] as string,
                        AdressLine2 = reader["adresse_2"] as string,
                        City = reader["localite"] as string,
                        Number = reader["numero"] as string,
                        ZipCode = reader["code_postal"] as string,
                        Country = reader["pays"] as string
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
        public IEnumerable<TacheDetails> GetByParticipantId(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache_details WHERE id_participant = @id";
                cmd.Parameters.AddWithValue("id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<TacheDetails> result = new List<TacheDetails>();
                while (reader.Read()) {
                    result.Add(new TacheDetails {
                        Id = (int)reader["id"],
                        Id_Participant = reader["id_participant"] as int?,
                        Id_Projet = (int)reader["id_projet"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"],
                        Email = reader["mail_participant"] as string,
                        Fonction = (reader["fonction_participant"] as Fonction?) ?? default(Fonction),
                        Nom = reader["nom_participant"] as string,
                        Prenom = reader["prenom_participant"] as string,
                        Titre = reader["titre_projet"] as string,
                        Reference = (string)reader["reference_projet"],
                        AdressLine1 = reader["adresse_1"] as string,
                        AdressLine2 = reader["adresse_2"] as string,
                        City = reader["localite"] as string,
                        Number = reader["numero"] as string,
                        ZipCode = reader["code_postal"] as string,
                        Country = reader["pays"] as string
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
