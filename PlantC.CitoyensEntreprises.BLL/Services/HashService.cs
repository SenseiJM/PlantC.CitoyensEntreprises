using System.Security.Cryptography;
using System.Text;

namespace PlantC.CitoyensEntreprises.BLL.Services {
    public class HashService
    {
        public string Hash(string password, string salt = null)
        {
            SHA512CryptoServiceProvider algo = new SHA512CryptoServiceProvider();
            byte[] toHash = Encoding.UTF8.GetBytes(password + (salt ?? string.Empty));
            return Encoding.UTF8.GetString(algo.ComputeHash(toHash));
        }
    }
}
