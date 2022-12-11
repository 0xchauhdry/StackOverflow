using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace StackOverflow.DataAccess
{
    public class MyQuestionsDAL
    {
        static string conString = @"Server= CMDLHRLT938; Data Source=CMDLHRLT938;Initial Catalog=StackOverflow;Integrated Security=True";
        SqlConnection conn = new SqlConnection(conString);

        public DataTable GetQuestions(int userid)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getQuestionsbyUserID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SDA = new SqlDataAdapter();
                cmd.Parameters.Add(new SqlParameter("@userid",userid));
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

        public DataTable VoteCount(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("VoteCountQuestion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
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

        public DataTable AnswerCount(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AnswerCount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
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

        public DataTable GetUserbyID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getUserbyID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
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

        public DataTable GetQuestionTags(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getQuestionTags", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
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

        public DataTable GetTagsbyID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getTagsbyID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
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