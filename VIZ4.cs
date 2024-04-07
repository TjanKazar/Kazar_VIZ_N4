using System.Security.Cryptography;
using System.Text;

namespace Kazar_VIZ_N4
{
    
    public class VIZ4
    {
        public static string getHash(int key, string raw)
        {
            byte[] hashBytes = null;
            byte[] rawBytes = Encoding.UTF8.GetBytes(raw);
            switch (key)
            {
                case 1:
                    hashBytes = MD5.HashData(rawBytes);
                    break;
                case 2:
                    hashBytes = SHA1.HashData(rawBytes);
                    break;
                case 3:
                    hashBytes = SHA256.HashData(rawBytes);
                    break;
            }
            string hashString = Encoding.UTF8.GetString(hashBytes);
            return hashString;
        }
        public static string GetHashBCrypt(string raw, int cost)
        {
            string hashString = BCrypt.Net.BCrypt.HashPassword(raw, cost);
            return hashString;
        }

        public static string FileTypeFromPath(string filePath)
        {
            int extentionIndex = filePath.LastIndexOf('.');
            if (extentionIndex != -1)
                return filePath.Substring(extentionIndex);
            else
                return ".idk";
        }
        public static int salt()
        {
            byte[] randomNumberBytes = new byte[4]; // Assuming you want a 32-bit integer

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomNumberBytes);
            }

            // Convert bytes to an integer
            int randomNumber = BitConverter.ToInt32(randomNumberBytes, 0);

            // Make sure the random number falls within the specified range
            return Math.Abs(randomNumber);
        }
    }
}
