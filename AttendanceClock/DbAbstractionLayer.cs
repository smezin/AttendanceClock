using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace AttendanceClock
{
    class DbAbstractionLayer
    {
        DateTime from { get; set; }
        DateTime upTo { get; set; }
        string userName { get; }
        public DataTable searchResult { get; }

        public DbAbstractionLayer(DateTime? from, DateTime? upTo, string userName)
        {
            DateTime fromNonNull = from ?? DateTime.Parse("1/1/1754"); //sql min date
            DateTime upToNonNull = upTo ?? DateTime.MaxValue.AddDays(-1);
            //normalize from day start to day end
            fromNonNull = fromNonNull.AddHours(-fromNonNull.Hour);
            fromNonNull = fromNonNull.AddMinutes(-fromNonNull.Minute);
            fromNonNull = fromNonNull.AddSeconds(-fromNonNull.Second);
            upToNonNull = upToNonNull.AddDays(1);
            upToNonNull = upToNonNull.AddHours(-upToNonNull.Hour);
            upToNonNull = upToNonNull.AddMinutes(-upToNonNull.Minute);
            upToNonNull = upToNonNull.AddSeconds(-upToNonNull.Second);
            //
            this.from = fromNonNull;
            this.upTo = upToNonNull;
            this.userName = userName;
            searchResult = new DataTable();
            fillTable(fromNonNull, upToNonNull, userName);
        }

        private void fillTable(DateTime from, DateTime upTo, string userName)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                BindingSource bindingSource1 = new BindingSource();
                DataTable searchResultTable = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                try
                {
                    string connectionString = Properties.Settings.Default.connString;
                    dataAdapter = new SqlDataAdapter("uspSearch", connectionString);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@userName", userName);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@entryTime", from);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@exitTime", upTo);
                    dataAdapter.Fill(searchResult);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Something went wrong on fillTable");
                }
            }
        }
        public static List<string> getAllUserNames()
        {
            List<string> users = new List<string>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspGetAllUsers", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        SqlDataReader reader;
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            users.Add(reader.GetValue(0).ToString());
                        }
                    }
                    catch
                    {
                        MessageBox.Show("something went wrong on getAllUserNames");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return users;
        }
        public static DateTime? getOpenEntry(string userName)
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
                        MessageBox.Show("something went wrong on getOpenEntry");
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
        public static void addNewUserToDb(string userName, string firstName, string lastName, string password)
        {
            string hashedPassword = DataHandler.saltAndHashPassword(password);
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
        public static void setTimeStamp(string userName)
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
                        MessageBox.Show("something went wrong ts");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static Dictionary<string, string> getUserDetails (string userName)
        {
            Dictionary<string, string> userDetails = new Dictionary<string, string>();
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
                    userDetails.Add("userName", sqlCommand.Parameters["@userUserName"].Value.ToString());
                    userDetails.Add("firstName", sqlCommand.Parameters["@userFirstName"].Value.ToString());
                    userDetails.Add("lastName", sqlCommand.Parameters["@userLastName"].Value.ToString());
                    userDetails.Add("accessLevel", sqlCommand.Parameters["@accessLevel"].Value.ToString());
                    return userDetails;
                }
            }
        }

        public static string getUserHashedPassword(string userName)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspGetUserHashedPassword", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;                   
                    sqlCommand.Parameters.AddWithValue("@userName", userName);
                    sqlCommand.Parameters.Add(new SqlParameter("@hashedPassword", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@hashedPassword"].Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("something went wrong on getUserHashedPassword");
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
        public static void setUpEntryLogTable()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspCreateEntryLogsTableIfNotExist", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;                  
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("something went wrong on setUpTables");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static void setUpUsersTable()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspCreateUsersTableIfNotExist", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("something went wrong on setUpTables");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
