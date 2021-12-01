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
                cmd.CommandText = "INSERT INTO tache "+
                    "(id_participant, intitule, date_debut, date_fin, id_projet, _type, id_localisation, description)"+
                    " VALUES (@p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9) returning id";
                cmd.Parameters.AddWithValue("p2", t.Id_Participant);
                cmd.Parameters.AddWithValue("p3", t.Intitule);
                cmd.Parameters.AddWithValue("p4", t.Date_Debut);
                cmd.Parameters.AddWithValue("p5", t.Date_Fin);
                cmd.Parameters.AddWithValue("p6", t.Id_Projet);
                cmd.Parameters.AddWithValue("p7", t.Type);
                cmd.Parameters.AddWithValue("p8", t.Id_localisation);
                cmd.Parameters.AddWithValue("p9", t.Description);
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
                    result.Add(new Tache()   /* code manquant*/  );
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
        public bool UpdateProjet(int id, Projet t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = ""; // commande a faire
                cmd.Parameters.AddWithValue("id", id);// suite des parametres a faire

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
        public bool DeleteProjet(int id)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM task WHERE Id = @id";
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
                cmd.CommandText = "SELECT * FROM task WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Tache t = null;
                if (reader.Read())
                {
                    t = new Tache();
                    return t;
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
        public IEnumerable<Tache> GetByProjetId()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = ""; // récuperation de id par projet a faire
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Tache> result = new List<Tache>();
                while (reader.Read())
                {
                    result.Add(new Tache()   /* code manquant*/  );
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
