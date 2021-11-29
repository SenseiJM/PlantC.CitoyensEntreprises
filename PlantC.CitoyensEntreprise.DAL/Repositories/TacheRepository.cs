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
                cmd.CommandText = "INSERT INTO tache OUTPUT inserted.Id VALUES (@t)";
                cmd.Parameters.AddWithValue("t", t);
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
