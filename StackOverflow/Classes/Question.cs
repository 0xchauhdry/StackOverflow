using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StackOverflow.BusinessLayer;

namespace StackOverflow.Classes
{
    public class Question
    {
        public int Id;
        public int userId;
        public string username;
        public string body;
        public int voteCount = 0;
        public int ansCount = 0;
        public string title;
        public string createTime;
        public string updateTime;
        public List<Answer> answers = new List<Answer>();
        public List<Tag> Tags = new List<Tag>();

        //using this constructor for initial initialization
        public Question(int userid, string _title, string _body)
        {
            title = _title;
            body = _body;
            userId = userid;
        }

        //using this constructor to make obj of question after it has been added
        public Question(int userid, string _title)
        {
            AddQuestionBL aqBL = new AddQuestionBL();
            title = _title;
            Id = aqBL.GetID(title);
            body = aqBL.GetBody(title);
            userId = userid;
        }
        //using this constructor to make obj of question when we get info from database
        public Question(int _id, string _title, string _body, int _userid, string _createTime)
        {
            title = _title;
            Id = _id;
            body = _body;
            userId = _userid;
            createTime = _createTime;
        }
        //using this constructor for upvote
        public Question(int _id)
        {
            Id = _id;
        }

        public DataTable Add(Question question)
        {
            AddQuestionBL aqBL = new AddQuestionBL();
            return aqBL.AddQuestion(question);
        }

        public void Remove()
        {

        }

        public void Edit()
        {

        }

        public void UpVote(Question question, int userid)
        {
            AnswerBL aBL = new AnswerBL();
            aBL.UpVoteQuestion(question, userid);
        }

        public void DownVote(Question question, int userid)
        {
            AnswerBL aBL = new AnswerBL();
            aBL.DownVoteQuestion(question, userid);
        }
    }
}