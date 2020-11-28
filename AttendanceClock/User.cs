using System;
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
            if (checkPassword(userName, password))
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("uspGetUserDetails", conn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // input
                        sqlCommand.Parameters.AddWithValue("@userName", userName);
                        // outputs
                        sqlCommand.Parameters.Add(new SqlParameter("@userUserName", SqlDbType.NVarChar, 16));
                        sqlCommand.Parameters.Add(new SqlParameter("@userFirstName", SqlDbType.NVarChar, 16));
                        sqlCommand.Parameters.Add(new SqlParameter("@userLastName", SqlDbType.NVarChar, 16));
                        sqlCommand.Parameters.Add(new SqlParameter("@accessLevel", SqlDbType.Int));
                        sqlCommand.Parameters["@userUserName"].Direction = ParameterDirection.Output;
                        sqlCommand.Parameters["@userFirstName"].Direction = ParameterDirection.Output;
                        sqlCommand.Parameters["@userLastName"].Direction = ParameterDirection.Output;
                        sqlCommand.Parameters["@accessLevel"].Direction = ParameterDirection.Output;

                        try
                        {
                            conn.Open();
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("something went wrong");
                        }
                        finally
                        {
                            conn.Close();
                        }
                        this.userName = sqlCommand.Parameters["@userUserName"].Value.ToString();
                        userFirstName = sqlCommand.Parameters["@userFirstName"].Value.ToString();
                        userLastName = sqlCommand.Parameters["@userLastName"].Value.ToString();
                        accessLevel = Int32.Parse(sqlCommand.Parameters["@accessLevel"].Value.ToString());
                    }
                }
            }
            else
            {

            }
        }
        public string getUserHashedPassword(string userName)
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
                    sqlCommand.Parameters.Add(new SqlParameter("@hashedPassword", SqlDbType.NVarChar, 255));
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
                    }
                    string hashedPassword = sqlCommand.Parameters["@hashedPassword"].Value != null ?
                        sqlCommand.Parameters["@hashedPassword"].Value.ToString()
                        : null;
                    return hashedPassword;
                }
            }
        }
        public static void addNewUserToDb(string userName, string firstName, string lastName, string password)
        {
            string hashedPassword = User.saltAndHashPassword(password);
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))

            {
                using (SqlCommand sqlCommand = new SqlCommand("uspCreateNewUser", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@userName", userName);
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                    sqlCommand.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                    sqlCommand.Parameters.AddWithValue("@accessLevel", 0);

                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
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
        private static string saltAndHashPassword(string rawPassword)
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
        public bool checkPassword(string userName, string password)
        {
            /* Fetch the stored value */
            string savedPasswordHash = getUserHashedPassword(userName);             // DBContext.GetUser(u => u.UserName == user).Password;
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
        public void setTimeStamp()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspLogTime", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@userName", userName);
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
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
        public DateTime? getOpenEntry()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspGetOpenEntry", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@userName", userName);
                    sqlCommand.Parameters.Add(new SqlParameter("@openEntry", SqlDbType.DateTime));
                    sqlCommand.Parameters["@openEntry"].Direction = ParameterDirection.Output;
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("something went wrong");
                    }
                    finally
                    {
                        conn.Close();
                    }
                    if (sqlCommand.Parameters["@openEntry"].Value != DBNull.Value)
                        return (DateTime)sqlCommand.Parameters["@openEntry"].Value;
                    return null;
                }
            }
        }
    }
}
