using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
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
                    "(id_participant, intitule, date_debut, date_fin, id_projet, _type, id_localisation, description)" +
                    " VALUES (@Id_Participant, @Intitule, @Date_Debut, @Date_Fin, @Id_Projet, @Type, @Id_localisation, @Description) returning id";
                cmd.Parameters.AddWithValue("Id_Participant", t.Id_Participant);
                cmd.Parameters.AddWithValue("Intitule", t.Intitule);
                cmd.Parameters.AddWithValue("Date_Debut", (object)t.Date_Debut ?? DBNull.Value);
                cmd.Parameters.AddWithValue("Date_Fin", (object)t.Date_Fin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("Id_Projet", t.Id_Projet);
                cmd.Parameters.AddWithValue("Type", t.Type);
                cmd.Parameters.AddWithValue("Id_localisation", t.Id_localisation);
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
        public IEnumerable<Tache> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Tache> result = new List<Tache>();
                while (reader.Read())
                {
                    result.Add(new Tache
                    {
                        Id = (int)reader["id"],
                        Id_localisation = (int)reader["id_localisation"],
                        Id_Participant = (int)reader["id_participant"],
                        Id_Projet = (int)reader["id_projet"],
                        Intitule = (string)reader["intitule"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"]
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
                cmd.CommandText = "UPDATE tache" +
                                  " SET id_localisation = " + t.Id_localisation +
                                  " ,id_participant = " + t.Id_Participant +
                                  " ,id_projet = " +t.Id_Projet+
                                  " ,intitule = " +"'"+t.Intitule+"'"+
                                  " ,date_debut = " + "'" + t.Date_Debut.Value.ToString("yyyy-MM-dd") + "'" +
                                  " ,date_fin = " + "'" + t.Date_Fin.Value.ToString("yyyy-MM-dd") + "'" +
                                  " ,description = " + "'" + t.Description + "'" +
                                  " ,est_assigne = " +t.Est_Assigne +
                                  " ,est_termine = " +t.Est_Termine +
                                  " ,_type = " + "'" + t.Type+ "'" +
                                  " WHERE id = @Id "; 
                cmd.Parameters.AddWithValue("Id", t.Id);

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
        public Tache GetByID(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Tache result = new Tache();
                if (reader.Read())
                {
                    result = (new Tache
                    {
                        Id = (int)reader["id"],
                        Id_localisation = (int)reader["id_localisation"],
                        Id_Participant = (int)reader["id_participant"],
                        Id_Projet = (int)reader["id_projet"],
                        Intitule = (string)reader["intitule"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"]
                    });

                    return result;
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

        /// <summary>
        /// Collects all the tasks related to a project
        /// </summary>
        /// <returns>IEnumerable of Task Entity</returns>
        public IEnumerable<Tache> GetByProjectId(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tache WHERE id_projet = @id";
                cmd.Parameters.AddWithValue("id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Tache> result = new List<Tache>();
                while (reader.Read())
                {
                    result.Add(new Tache
                    {
                        Id = (int)reader["id"],
                        Id_localisation = (int)reader["id_localisation"],
                        Id_Participant = (int)reader["id_participant"],
                        Id_Projet = (int)reader["id_projet"],
                        Intitule = (string)reader["intitule"],
                        Type = (string)reader["_type"],
                        Description = (string)reader["description"],
                        Date_Debut = reader["date_debut"] as DateTime?,
                        Date_Fin = reader["date_fin"] as DateTime?,
                        Est_Assigne = (bool)reader["est_assigne"],
                        Est_Termine = (bool)reader["est_termine"]
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
    }
}
