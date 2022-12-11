using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StackOverflow.DataAccess;
using StackOverflow.Classes;

namespace StackOverflow.BusinessLayer
{
    public class AddQuestionBL
    {
        public bool CheckTitle(Question question)
        {
            DataTable data = new AddQuestionDAL().CheckTitle(question.title);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        public DataTable AddQuestion(Question question)
        {
            AddQuestionDAL adDAL = new AddQuestionDAL();
            return adDAL.AddQuestion(question.userId,question.title,question.body);
        }

        public int GetID(string title)
        {
            DataTable data = new AddQuestionDAL().CheckTitle(title);
            return Convert.ToInt32(data.Rows[0]["ID"]);
        }

        public string GetBody(string title)
        {
            DataTable data = new AddQuestionDAL().CheckTitle(title);
            return (data.Rows[0]["Body"]).ToString();
        }

        public List<Tag> GetTags(string search)
        {
            List<Tag> Tags = new List<Tag>();
            DataTable data = new AddQuestionDAL().GetTags(search);
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(data.Rows[i]["ID"]);
                    string name = data.Rows[i]["Name"].ToString();
                    Tag tag = new Tag(id, name);
                    Tags.Add(tag);
                }
                return Tags;
            }
            return Tags;
        }

        public DataTable AddTag(string name)
        {
            AddQuestionDAL adDAL = new AddQuestionDAL();
            return adDAL.AddTag(name);
        }

        public void AddQuestionTags(int questionId, int Id)
        {
            AddQuestionDAL adDAL = new AddQuestionDAL();
            adDAL.AddQuestionTag(questionId, Id);
        }
    }
}