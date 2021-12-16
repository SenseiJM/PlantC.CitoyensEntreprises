using Newtonsoft.Json;
using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class LocalisationRepository {

        private NpgsqlConnection oConn;
        private readonly HttpClient _client;
        public LocalisationRepository(NpgsqlConnection oConn, HttpClient client) {
            this.oConn = oConn;
            _client = client;
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

        public IEnumerable<Localisation> GetAllLocalisation() {

            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT * FROM localisation_zip";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Localisation> result = new List<Localisation>();
                while (reader.Read()) {
                    Localisation lzv = new Localisation {
                        ZipCode = (string)reader["code_postal"],
                        City = (string)reader["localite"]
                    };
                    result.Add(lzv);
                }
                return result;
            } catch (Exception e) {
                throw;
            } finally {
                oConn.Close();
            }

        }

        public int Insert(Localisation l, decimal lat, decimal lng, int idAdd)
        {
            oConn.Open();
            var cmd = oConn.CreateCommand();
            cmd.CommandText = "INSERT INTO localisation(localite,code_postal, latitude, longitude, id_adresse) VALUES(@p1, @p2, @p3, @p4, @p5)  RETURNING id";
            cmd.Parameters.AddWithValue("p1", l.City);
            cmd.Parameters.AddWithValue("p2", l.ZipCode);
            cmd.Parameters.AddWithValue("p3", lat);
            cmd.Parameters.AddWithValue("p4", lng);
            cmd.Parameters.AddWithValue("p5", idAdd);
            int result = (int)cmd.ExecuteScalar();
            oConn.Close();
            return result;
        }

        public LocalisationGeoCode GetGeocodeByAddress(string adresse, string city) {
  
            adresse = adresse.Replace(" ", "%20");
            _client.DefaultRequestHeaders.Add("User-Agent", "Other");
            HttpResponseMessage message = _client.GetAsync("/search?street=" + adresse + "&city=" + city + "&format=json").Result;
            if (message.IsSuccessStatusCode) {
                string json = message.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<LocalisationGeoCode>>(json).FirstOrDefault();
            }
            throw new HttpRequestException();
        }

    }
}
