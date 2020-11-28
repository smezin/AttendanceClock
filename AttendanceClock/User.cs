using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AttendanceClock
{
    public class User
    {
        public string userName { get; }
        public string userFirstName { get; }
        public string userLastName { get; }
        public int accessLevel { get; }

        public User(string userName, string password)
        {
            if (DataHandler.checkPassword(userName, password))
            {
                Dictionary<string, string> userDetails = DbAbstractionLayer.getUserDetails(userName);
                this.userName = userDetails["userName"];
                this.userFirstName = userDetails["firstName"];
                this.userLastName = userDetails["lastName"];
                this.accessLevel = Int32.Parse(userDetails["accessLevel"]);        
            }
        }       
    }
}
