using System.Security.Cryptography;
using System.Text;

namespace Diplom1.Client
{
    public static class MD5Hash
    {
        public static string toString(string stroka)
        {
            byte[] massByte = Encoding.ASCII.GetBytes(stroka);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(massByte);
            return ByteArrayToString(tmpHash);
        }
        private static string ByteArrayToString(byte[] tmpHash)
        {
            StringBuilder OutPut = new(tmpHash.Length);
            for (int i = 0; i < tmpHash.Length; i++)
            {
                OutPut.Append(tmpHash[i].ToString("X2"));
            }
            return OutPut.ToString();
        }

    }
}
