using System.Security.Cryptography;
using System.Text;

namespace MuaBanSanPhamSen_BabyLotus.Service
{
    public class MaHoaMD5
    {
        public static string GetMd5Hash(string input) 
        { 
            using (MD5 md5 = MD5.Create())
            { 
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                { 
                    sb.Append(hashBytes[i].ToString("X2"));
                } 
                return sb.ToString(); 
            }
        }
    }
}
