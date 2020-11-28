using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceClock
{
    class DataValidator
    {
        public static bool isValidUserName (string userName)
        {
            bool validString = (userName.Length >= 4 &&
                                userName.Length <= 16 &&
                                !userName.Contains("(") &&
                                !userName.Contains(")"));
            return validString;
        }
        public static bool isValidPassword (string password, string reTypedPassword)
        {
            return (password == reTypedPassword &&
                    password.Length >= 4 &&
                    password.Length <= 16);
        }
        public static bool isValidName(string name)
        {
            return (name.Length >= 4 &&
                    name.Length <= 16 &&
                    !name.Contains("(") &&
                    !name.Contains(")"));
        }
        public static bool isUserNameFree (string userName)
        {
            List<string> users = Search.getAllUsers();
            return !users.Contains(userName);
        }
    }
}
