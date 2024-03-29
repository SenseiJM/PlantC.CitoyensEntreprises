﻿using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using PlantC.CitoyensEntreprise.DAL.Mappers;
using System;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class UserRepository
    {
        private NpgsqlConnection oConn;

        public UserRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public Participant GetByMail(string mail)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Participant Where mail = @p1";
                cmd.Parameters.AddWithValue("p1", mail);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader.ToParticipant();
                };
                return null;
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

        public bool ValidateMail(string email) {
            try {

                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE participant SET est_verifie = true WHERE mail = @p1";
                cmd.Parameters.AddWithValue("p1", email);
                return cmd.ExecuteNonQuery() == 1;

            } catch (Exception) {
                throw;
            } finally {
                oConn.Close();
            }
        }
    }
}
