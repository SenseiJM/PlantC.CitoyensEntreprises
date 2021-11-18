using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using PlantC.CitoyensEntreprises.API.DTO.Projet;
using System;
using System.Collections.Generic;
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

        public IEnumerable<ProjetIndexDTO> GetAll() {
            try {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT Titre, Localite, TypeProjet, StatutProjet, ObjectifMonetaire, SommeRecoltee FROM Projet";
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProjetIndexDTO> result = new List<ProjetIndexDTO>();
                while (reader.Read()) {
                    result.Add(new ProjetIndexDTO {
                        Localite = reader["Localite"].ToString(),
                        ObjectifMonetaire = (double)reader["ObjectifMonetaire"],
                        SommeRecoltee = (double)reader["SommeRecoltee"],
                        StatutProjet = (StatutProjet)reader["StatutProjet"],
                        Titre = reader["Titre"].ToString(),
                        TypeProjet = (TypeProjet)reader["TypeProjet"]
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
