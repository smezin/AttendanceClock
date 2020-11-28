using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AttendanceClock
{
    class DataHandler
    {
        public static bool isValidUserName (string userName)
        {
            bool validString = (userName.Length >= 4 &&
                                userName.Length <= 16 &&
                                userName.All(c => Char.IsLetterOrDigit(c))
                                );
            return validString;
        }
        public static bool isValidPassword (string password, string reTypedPassword)
        {
            return (password == reTypedPassword &&
                    password.Length >= 4 &&
                    password.Length <= 16
                    );
        }
        public static bool isValidName(string name)
        {
            name.All(c => c == 'c');
            return (name.Length >= 4 &&
                    name.Length <= 16 &&
                    name.All(c => Char.IsLetterOrDigit(c))
                    );
        }
        public static bool isUserNameFree (string userName)
        {
            List<string> users = DbAbstractionLayer.getAllUserNames();
            return !users.Contains(userName);
        }
        public static string saltAndHashPassword(string rawPassword)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(rawPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }
        public static bool checkPassword(string userName, string password)
        {
            /* Fetch the stored value */
            string savedPasswordHash = DbAbstractionLayer.getUserHashedPassword(userName);             // DBContext.GetUser(u => u.UserName == user).Password;
            if (savedPasswordHash.Length == 0) return false;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            return true;
        }
    }
}
