using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace StackOverflow.DataAccess
{
    public class AnswerDAL
    {
        static string conString = @"Server= CMDLHRLT938; Data Source=CMDLHRLT938;Initial Catalog=StackOverflow;Integrated Security=True";
        SqlConnection conn = new SqlConnection(conString);

        public DataTable GetAnswers(int quesid)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getAllAnswers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@questionid", quesid));
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

        public DataTable VoteCount(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("VoteCountAnswer", conn);
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
        public DataTable UserVoteQuestion(int quesid, int userid)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UserVoteQuestion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userid", userid));
                cmd.Parameters.Add(new SqlParameter("@questionid", quesid));
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

        public DataTable UserVoteAns(int id, int userid)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UserVoteAnswer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userid", userid));
                cmd.Parameters.Add(new SqlParameter("@ansid", id));
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

        public DataTable CheckBody(string body)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getAnswerbyBody", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@body", body));
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

        public void AddAnswer(int userid, int quesid, string body)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddAnswer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userid", userid));
                cmd.Parameters.Add(new SqlParameter("@questionid", quesid));
                cmd.Parameters.Add(new SqlParameter("@body", body));
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                SDA.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateQuestionVotes( int quesid, int userid, int vote)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateQuestionVotes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Questionid", quesid));
                cmd.Parameters.Add(new SqlParameter("@Userid", userid));
                cmd.Parameters.Add(new SqlParameter("@Vote", vote));
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                SDA.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateAnswerVotes(int ansid, int userid, int vote)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateAnswerVotes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Ansid", ansid));
                cmd.Parameters.Add(new SqlParameter("@Userid", userid));
                cmd.Parameters.Add(new SqlParameter("@Vote", vote));
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                SDA.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateAnswerStatus(int ansid, int value)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateAnswerStatus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", ansid));
                cmd.Parameters.Add(new SqlParameter("@value", value));
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                SDA.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}