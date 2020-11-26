﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace AttendanceClock
{
    class User
    {
        public string name { get; }

        public void getUserHashedPassword (string userName)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspGetUserHashedPassword", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.AddWithValue("@userName", userName);
                  //  sqlCommand.Parameters["@userName"].Value = userName;

                    // Add the output parameter.
                    sqlCommand.Parameters.Add(new SqlParameter("@hashedPassword", SqlDbType.NVarChar, 16));
                    sqlCommand.Parameters["@hashedPassword"].Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        // Run the stored procedure.
                        sqlCommand.ExecuteNonQuery();     
                    }
                    catch
                    {
                        MessageBox.Show("something went wrong");
                    }
                    finally
                    {
                        conn.Close();
                        MessageBox.Show(sqlCommand.Parameters["@hashedPassword"].Value.ToString());     
                    }
                }
            }
        }
        public void addNewUser (string userName, string firstName, string lastName, string password)
        {
            string hashedPassword = saltAndHashPassword(password);
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspCreateNewUser", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;      
                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.AddWithValue("@userName", userName);
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                    sqlCommand.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                    MessageBox.Show("1so far so good");                 

                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("2so far so good");
                    }
                    catch
                    {
                        MessageBox.Show("something went wrong");
                    }
                    finally
                    {
                        conn.Close();        
                    }
                }
            }
        }
        private string saltAndHashPassword (string rawPassword)
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
        public bool validatePassword (string password, string hashed)
        {
            /* Fetch the stored value */
            string savedPasswordHash = hashed;// DBContext.GetUser(u => u.UserName == user).Password;
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