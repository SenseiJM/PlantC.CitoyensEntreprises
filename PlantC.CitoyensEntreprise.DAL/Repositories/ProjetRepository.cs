using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Entities;
using PlantC.CitoyensEntreprise.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprise.DAL.Repositories {
    public class ProjetRepository {

        private NpgsqlConnection oConn;

        public ProjetRepository(NpgsqlConnection oConn) {
            this.oConn = oConn;
        }

        public IEnumerable<Projet> GetAll() {
            try {
                oConn.Open();
                NpgsqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "SELECT Titre, Localite, TypeProjet, StatutProjet, ObjectifMonetaire, SommeRecoltee FROM Projet";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Projet> result = new List<Projet>();
                while (reader.Read()) {
                    result.Add(new Projet {
                        Localite = reader["Localite"].ToString(),
                        ObjectifMonetaire = (double)reader["ObjectifMonetaire"],
                        SommeRecoltee = (double)reader["SommeRecoltee"],
                        Statut = (StatutProjet)reader["StatutProjet"],
                        Titre = reader["Titre"].ToString(),
                        TypeDeProjet = (TypeProjet)reader["TypeProjet"],
                        CodePostal = (ushort)reader["CodePostal"],
                        Description = reader["Description"].ToString(),
                        Id = (uint)reader["Id"],
                        Latitude = (double)reader["Latitude"],
                        Longitude = (double)reader["Longitude"],
                        NbArbresTotal = (uint)reader["NbArbresTotal"],
                        NbParticipantsTotal = (uint)reader["NbParticipantsTotal"],
                        ObjectifArbres = (uint)reader["ObjectifArbres"]
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
