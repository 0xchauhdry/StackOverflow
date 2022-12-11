using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace StackOverflow.DataAccess
{
    public class LoginDAL
    {
        static string conString = @"Server= CMDLHRLT938; Data Source=CMDLHRLT938;Initial Catalog=StackOverFlow;Integrated Security=True";
        SqlConnection conn = new SqlConnection(conString);

        public DataTable getUserData(string username)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CheckUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", username));
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}