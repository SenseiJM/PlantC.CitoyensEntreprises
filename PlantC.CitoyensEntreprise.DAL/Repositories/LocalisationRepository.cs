using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class LocalisationRepository {

        private NpgsqlConnection oConn;

        public LocalisationRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        public IEnumerable<LocalisationZipView> GetAllLocalisationByZip() {

            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM localisation_zip";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<LocalisationZipView> result = new List<LocalisationZipView> ();
                while (reader.Read()) {
                    LocalisationZipView lzv = new LocalisationZipView {
                        Id = (int)reader["id"],
                        CodePostal = (string)reader["code_postal"],
                        Villes = new List<string>()
                    };
                    if (result.Count == 0 || lzv.CodePostal != result[result.Count - 1].CodePostal) {
                        lzv.Villes.Add((string)reader["localite"]);
                        result.Add(lzv);
                    } else if (result.Count != 0 && lzv.CodePostal == result[result.Count - 1].CodePostal) {
                        result.FirstOrDefault(l => l.CodePostal == lzv.CodePostal).Villes.Add((string)reader["localite"]);
                    }
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
