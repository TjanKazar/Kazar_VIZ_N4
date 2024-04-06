using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace Kazar_VIZ_N4
{
    public class VIZ4
    {
        public static void getHash(int key, byte[] rawBytes, out byte[] hashedBytes)
        {
            hashedBytes = null;
            switch (key)
            {
                case 1:
                    {
                        using (MD5 md5 = MD5.Create())
                        {
                            hashedBytes = md5.ComputeHash(rawBytes);
                        }
                    }; break;
                case 2:
                    {
                        using (SHA1 sha1 = SHA1.Create())
                        {
                            hashedBytes = sha1.ComputeHash(rawBytes);
                        }
                    }; break;
                case 3:
                    {
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            hashedBytes = sha256.ComputeHash(rawBytes);
                        }
                    }; break;
                case 4:
                    {
                        string rawString = Encoding.UTF8.GetString(rawBytes);
                        string hashedString = BCrypt.Net.BCrypt.HashPassword(rawString);
                        hashedBytes = Encoding.UTF8.GetBytes(hashedString);
                        
                    }; break;
            }
        }
        public static string FileTypeFromPath(string filePath)
        {
            int extentionIndex = filePath.LastIndexOf('.');
            if (extentionIndex != -1)
            {
                string result = filePath.Substring(extentionIndex);
                return result;
            }
            else
            {
                return ".idk";
            }
        }
    }
}
