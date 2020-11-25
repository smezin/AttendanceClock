using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AttendanceClock
{
    class User
    {
        public string name { get; }

        public void getUserLastName (int userFirstName)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("uspGetUserLastName", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@userName", SqlDbType.Int));
                    sqlCommand.Parameters["@userName"].Value = userFirstName;

                    // Add the output parameter.
                    sqlCommand.Parameters.Add(new SqlParameter("@userLastName", SqlDbType.NVarChar, 16));
                    sqlCommand.Parameters["@userLastName"].Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();

                        // Run the stored procedure.
                        sqlCommand.ExecuteNonQuery();     
                    }
                    catch
                    {
                        MessageBox.Show("error executing shit");
                    }
                    finally
                    {
                        conn.Close();
                        MessageBox.Show(sqlCommand.Parameters["@userLastName"].Value.ToString());
     
                    }
                }
            }

        }
    }
}
