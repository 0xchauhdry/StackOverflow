using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StackOverflow.DataAccess;
using StackOverflow.Classes;

namespace StackOverflow.BusinessLayer
{
    public class MyQuestionsBL
    {
        public List<Question> GetQuestions(int UserID)
        {
            List<Question> Questions = new List<Question>();
            MyQuestionsDAL mDAL = new MyQuestionsDAL();
            DataTable data = mDAL.GetQuestions(UserID);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                int id = Convert.ToInt32(data.Rows[i]["ID"]);
                string title = data.Rows[i]["Title"].ToString();
                string body = data.Rows[i]["Body"].ToString();
                int userid = Convert.ToInt32(data.Rows[i]["UserID"]);
                string createTime = data.Rows[i]["CreateTime"].ToString();
                Question question = new Question(id, title, body, userid, createTime);

                DataTable votedata = mDAL.VoteCount(id);
                if (votedata.Rows.Count > 0)
                {
                    if (!(votedata.Rows[0]["VoteCount"] is DBNull))
                    {
                        question.voteCount = Convert.ToInt32(votedata.Rows[0]["VoteCount"]);
                    }
                }

                DataTable ansdata = mDAL.AnswerCount(id);
                if (ansdata.Rows.Count > 0)
                {
                    if (!(ansdata.Rows[0]["AnswerCount"] is DBNull))
                    {
                        question.ansCount = Convert.ToInt32(ansdata.Rows[0]["AnswerCount"]);
                    }
                }
                DataTable userdata = mDAL.GetUserbyID(userid);
                if (userdata.Rows.Count > 0)
                {
                    if (!(userdata.Rows[0]["Username"] is DBNull))
                    {
                        question.username = userdata.Rows[0]["Username"].ToString();
                    }
                }
                DataTable tagdata = mDAL.GetQuestionTags(id);
                if (tagdata.Rows.Count > 0)
                {
                    for (int j = 0; j < tagdata.Rows.Count; j++)
                    {
                        if (!(tagdata.Rows[j]["TagID"] is DBNull))
                        {
                            int tagid = Convert.ToInt32(tagdata.Rows[j]["TagID"]);
                            DataTable tdata = mDAL.GetTagsbyID(tagid);
                            if (tdata.Rows.Count > 0)
                            {
                                if (!(tdata.Rows[0]["Name"] is DBNull))
                                {
                                    string tagName = tdata.Rows[0]["Name"].ToString();
                                    Tag tag = new Tag(tagid, tagName);
                                    question.Tags.Add(tag);
                                }
                            }
                        }
                    }
                }
                Questions.Add(question);
            }
            return Questions;
        }
    }
}