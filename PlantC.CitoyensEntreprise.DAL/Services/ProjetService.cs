﻿using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;

namespace PlantC.CitoyensEntreprises.API.Services {
    public class ProjetService {

        private NpgsqlConnection oConn;

        public ProjetService(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        public int Create(Projet nouvProjet) {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Projet OUTPUT inserted.Id VALUES (@p1)";
                cmd.Parameters.AddWithValue("p1", nouvProjet);
                return (int)cmd.ExecuteScalar();
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }
        }

        public IEnumerable<Projet> GetAll() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT Reference, Infrastructure, Quantite, UniteDeMesure, IDLocalisation, TonnesCO2,HeuresTravail, CoutDuProjet FROM Projet";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Projet> result = new List<Projet>();
                while (reader.Read()) {
                    result.Add(new Projet {
                        Reference = reader["Reference"].ToString(),
                        Infrastructure = reader["Infrastructure"].ToString(),
                        Quantite = (double)reader["Quantite"],
                        UniteDeMesure = reader["UniteDeMesure"].ToString(),
                        IDLocalisation = (int)reader["IDLocalisation"],
                        TonnesCO2 = (double)reader["TonnesCO2"],
                        HeuresTravail = (double)reader["HeuresTravail"],
                        CoutDuProjet = (double)reader["CoutDuProjet"]
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
