

using System.Security.Cryptography;
using System.Text;

public static class Md5
{

    public static string ToMD5(this string sourceStr)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(sourceStr));
            string md5Str = "";
            for (int i = 0; i < hash.Length; i++)
                md5Str = md5Str + hash[i].ToString("x2");
            return md5Str;
        }
    }
}