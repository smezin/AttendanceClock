﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AttendanceClock
{
    class Search
    {
        DateTime from { get; set; }
        DateTime upTo { get; set; }
        string userName { get; }
        public DataTable searchResult { get; }

        public Search (DateTime? from, DateTime? upTo, string userName)
        {
            this.from = from ?? DateTime.Parse("1/1/1754"); //sql min date
            this.upTo = upTo ?? DateTime.MaxValue;  
            this.userName = userName;
            this.searchResult = new DataTable();
            fillTable(from ?? DateTime.Parse("1/1/1754"), upTo ?? DateTime.MaxValue, userName);
        }

        private void fillTable (DateTime from, DateTime upTo, string userName)
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
                    dataAdapter.Fill(this.searchResult);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Something went wrong");
                }
            }
        }
        public static List<string> getAllUsers ()
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
                        MessageBox.Show("something went wrong");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return users;
        }
    }
}
