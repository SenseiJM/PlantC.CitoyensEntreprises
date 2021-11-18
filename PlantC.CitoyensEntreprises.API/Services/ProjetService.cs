using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprises.API.DTO;
using System;
using System.Data.SqlClient;

namespace PlantC.CitoyensEntreprises.API.Services {
    public class ProjetService {

        private SqlConnection oConn;

        public ProjetService(SqlConnection oConn) {
            this.oConn = oConn;
        }

        public int Create(ProjetAddDTO dto) {
            try {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Projet OUTPUT inserted.Id VALUES (@p1)";
                cmd.Parameters.AddWithValue("p1", dto);
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

    }
}
