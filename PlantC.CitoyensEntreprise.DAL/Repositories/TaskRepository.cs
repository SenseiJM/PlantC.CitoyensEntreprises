using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class TaskRepository
    {
        private NpgsqlConnection oConn;
        public TaskRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public int Create(Tasks t)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Task OUTPUT inserted.Id VALUES (@p1)";
                cmd.Parameters.AddWithValue("p1", t);
                return (int)cmd.ExecuteScalar();
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
        /// Fetches a full list of all existing Task Entities in the database
        /// </summary>
        /// <returns>IEnumerable of Task Entity</returns>
        public IEnumerable<Task> GetAll()
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Task";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Task> result = new List<Task>();
                while (reader.Read())
                {
                    result.Add(new Task
                    {
                        Id = (int)reader["Id"],
                        UserId = (int)reader["UserId"],
                        ProjetId = (int)reader["ProjetId"],
                        NomTache = reader["NomTache"].ToString(),
                        TaskType = (TaskType)reader["TaskType"],
                        DateTime = (DateTime)reader["Datetime"]
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
        /// Searches the database to find the Task corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be searched</param>
        /// <returns>Returns corresponding Task Entity</returns>
        public Task GetByID(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Task WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Task t = null;
                if (reader.Read()) {
                    t = new Task {
                        Id = (int)reader["Id"],
                        UserId = (int)reader["UserId"],
                        ProjetId = (int)reader["ProjetId"],
                        NomTache = reader["NomTache"].ToString(),
                        TaskType = (TaskType)reader["TaskType"],
                        DateTime = (DateTime)reader["Datetime"]
                    };
                    return t;
                } else {
                    return null;
                }
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        
        /// Searches the database to update the Task corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be updated</param>
        /// <param name="c">Task Entity to be updated</param>
        /// <returns>True if Task Entity has been updated, False if ID is not existing</returns>
        public bool Update(int id, Task c) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Task SET" +
                    "UserId = @p2," +
                    "ProjetId = @p3," +
                    "NomTache = @p4," +
                    "TaskType = @p5" +
                    "DateTime = @p6" +
                    "WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", id);
                cmd.Parameters.AddWithValue("p2", c.UserId);
                cmd.Parameters.AddWithValue("p3", c.ProjetId);
                cmd.Parameters.AddWithValue("p4", c.NomTache);
                cmd.Parameters.AddWithValue("p5", c.TaskType);
                cmd.Parameters.AddWithValue("p6", c.DateTime);

                return cmd.ExecuteNonQuery() != 0;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }


        /// <summary>
        /// Searches the database to delete the Task corresponding to the ID
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>True if Task Entity has been deleted, False if ID is not existing</returns>
        public bool Delete(int id) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Task WHERE Id = @p1";
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
