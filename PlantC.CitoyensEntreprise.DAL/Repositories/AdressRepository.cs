using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Repositories
{
    public class AdressRepository
    {
        private NpgsqlConnection oConn;

        public AdressRepository(NpgsqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public int AddAdress(Adresse adress)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "Insert INTO adresse" +
                    " (ligne_adresse_1,ligne_adresse_2,numero,code_postal,localite,pays)" +
                    "VALUES (@p1, @p2, @p3, @p4, @p5, @p6) RETURNING id";
                cmd.Parameters.AddWithValue("p1", adress.AdressLine1);
                cmd.Parameters.AddWithValue("p2", (object)adress.AdressLine2??DBNull.Value );
                cmd.Parameters.AddWithValue("p3", adress.Number);
                cmd.Parameters.AddWithValue("p4", adress.ZipCode);
                cmd.Parameters.AddWithValue("p5", adress.City);
                cmd.Parameters.AddWithValue("p6", adress.Country ?? "");
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

        public void UpdateAdress(Adresse adress)
        {
            try
            {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE adresse SET " +
                    "ligne_adresse_1 = @p1, " +
                    "ligne_adresse_2 = @p2, " +
                    "numero = @p3, " +
                    "code_postal = @p4, " +
                    "localite = @p5, " +
                    "pays = @p6 " +
                    "WHERE id = @p7"
                    ;
                cmd.Parameters.AddWithValue("p1", adress.AdressLine1);
                cmd.Parameters.AddWithValue("p2", adress.AdressLine2);
                cmd.Parameters.AddWithValue("p3", adress.Number);
                cmd.Parameters.AddWithValue("p4", adress.ZipCode);
                cmd.Parameters.AddWithValue("p5", adress.City);
                cmd.Parameters.AddWithValue("p6", adress.Country);
                cmd.Parameters.AddWithValue("p7", adress.Id);
                cmd.ExecuteNonQuery();
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
    }
}
