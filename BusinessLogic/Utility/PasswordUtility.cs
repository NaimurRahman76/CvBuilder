using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utility
{
    public static class PasswordUtility
    {
        public static string Key = "ajsd78y34ui2bjrk1";
        public static string Encrypt(string password)
        {
            if (String.IsNullOrEmpty(password)) { return ""; }
            password += Key;
            var passwordByte=Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordByte);
        }
        public static string Decrypt(string base64EncodedData)
        {
            if(string.IsNullOrEmpty(base64EncodedData)) { return ""; }
            var base64EncodeBytes = Convert.FromBase64String(base64EncodedData);
            var result=Encoding.UTF8.GetString(base64EncodeBytes);
            result=result.Substring(0, result.Length-Key.Length);
            return result;
        }
    }
}
