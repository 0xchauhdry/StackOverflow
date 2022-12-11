using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StackOverflow.Classes;
using StackOverflow.DataAccess;

namespace StackOverflow.BusinessLayer
{
    public class AnswerBL
    {
        public List<Answer> GetAllAnswers(int quesid)
        {
            List<Answer> Answers = new List<Answer>();
            AnswerDAL aDAL = new AnswerDAL();
            DataTable data = aDAL.GetAnswers(quesid);
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(data.Rows[i]["ID"]);
                    string body = data.Rows[i]["Body"].ToString();
                    int userid = Convert.ToInt32(data.Rows[i]["UserID"]);
                    string createTime = data.Rows[i]["CreateTime"].ToString();
                    int questionId = Convert.ToInt32(data.Rows[i]["QuestionID"]);
                    int ansStatus = Convert.ToInt32(data.Rows[i]["AnswerStatus"]);
                    Answer answer = new Answer(id, questionId, body, userid, createTime, ansStatus);

                    DataTable votedata = aDAL.VoteCount(id);
                    if (votedata.Rows.Count > 0)
                    {
                        if (!(votedata.Rows[0]["VoteCount"] is DBNull))
                        {
                            answer.voteCount = Convert.ToInt32(votedata.Rows[0]["VoteCount"]);
                        }
                    }

                    DataTable userdata = aDAL.GetUserbyID(userid);
                    if (userdata.Rows.Count > 0)
                    {
                        if (!(userdata.Rows[0]["Username"] is DBNull))
                        {
                            answer.username = userdata.Rows[0]["Username"].ToString();
                        }
                    }

                    Answers.Add(answer);
                }
            }
            return Answers;
        }

        public bool IfExists(string body)
        {
            AnswerDAL aDAL = new AnswerDAL();
            DataTable data = aDAL.CheckBody(body);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        public int UserVoteQuestion(int userid, int quesid)
        {
            AnswerDAL aDAL = new AnswerDAL();
            DataTable data = aDAL.UserVoteQuestion(quesid,userid);
            if (data.Rows.Count > 0)
            {
                if (!(data.Rows[0]["VoteValue"] is DBNull))
                {
                    return Convert.ToInt32(data.Rows[0]["VoteValue"]);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public int UserVoteAnswer(int userid, int ansid)
        {
            AnswerDAL aDAL = new AnswerDAL();
            DataTable data = aDAL.UserVoteAns(ansid, userid);
            if (data.Rows.Count > 0)
            {
                if (!(data.Rows[0]["VoteValue"] is DBNull))
                {
                    return Convert.ToInt32(data.Rows[0]["VoteValue"]);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public void AddAnswer(Answer answer)
        {
            AnswerDAL aDAL = new AnswerDAL();
            aDAL.AddAnswer(answer.UserId,answer.QuestionId,answer.body);
        }

        public void UpVoteAnswer(Answer answer, int userid)
        {
            AnswerDAL aDAL = new AnswerDAL();
            aDAL.UpdateAnswerVotes(answer.Id, userid, 1);
        }

        public void DownVoteAnswer(Answer answer, int userid)
        {
            AnswerDAL aDAL = new AnswerDAL();
            aDAL.UpdateAnswerVotes(answer.Id, userid, -1);
        }

        public void UpVoteQuestion(Question question, int userid)
        {
            AnswerDAL aDAL = new AnswerDAL();
            aDAL.UpdateQuestionVotes(question.Id, userid, 1);
        }

        public void DownVoteQuestion(Question question, int userid)
        {
            AnswerDAL aDAL = new AnswerDAL();
            aDAL.UpdateQuestionVotes(question.Id, userid, -1);
        }

        public void UpdateAnswerStatus(Answer answer)
        {
            AnswerDAL aDAL = new AnswerDAL();
            aDAL.UpdateAnswerStatus(answer.Id, answer.AnswerStatus);
        }
    }
}