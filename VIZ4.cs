using System.Security.Cryptography;
using System.Text;

namespace Kazar_VIZ_N4
{
    // salt variable is characters when i express it as foreach (byte c in salt)
    // and giberish when i express it as foreach (char c in salt)
    public class VIZ4
    {
        public static byte[] getHash(int key, byte[] rawBytes)
        {
            byte[] hashBytes = null;
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
            return hashBytes;
        }
        public static byte[] getHash(byte[] rawBytes, int cost)
        {
            byte[] hashBytes = null;
            string rawString = Encoding.UTF8.GetString(rawBytes);
            string hashString = BCrypt.Net.BCrypt.HashPassword(rawString, cost);
            hashBytes = Encoding.UTF8.GetBytes(hashString);
            return hashBytes;
        }
        public static string FileTypeFromPath(string filePath)
        {
            int extentionIndex = filePath.LastIndexOf('.');
            if (extentionIndex != -1)
                return filePath.Substring(extentionIndex);
            else
                return ".idk";
        }
        public static byte[] salt(int byteSize)
        {
            byte[] salt = new byte[byteSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}
