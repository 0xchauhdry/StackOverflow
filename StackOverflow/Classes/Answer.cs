using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflow.BusinessLayer;

namespace StackOverflow.Classes
{
    public class Answer
    {
        public int Id;
        public int UserId;
        public string username;
        public int QuestionId;
        public string body;
        public int voteCount;
        public int AnswerStatus;
        public string creatTime;
        public string updateTime;

        //using this constructor while getting all answers
        public Answer(int _id, int _quesid, string _body, int _userid, string _createTime, int _ansStatus)
        {
            Id = _id;
            QuestionId = _quesid;
            UserId = _userid;
            body = _body;
            creatTime = _createTime;
            AnswerStatus = _ansStatus;
        }

        //using this constructor for initial initialization
        public Answer(int _quesid, string _body, int _userid)
        {
            QuestionId = _quesid;
            UserId = _userid;
            body = _body;
        }

        //using this constructor for upvote
        public Answer(int _id, int _quesid)
        {
            Id = _id;
            QuestionId = _quesid;
        }

        //using this constructor for approval
        public Answer(int _id, int value, int _userid)
        {
            Id = _id;
            AnswerStatus = value;
        }

        public void Add(Answer answer)
        {
            AnswerBL aBL = new AnswerBL();
            aBL.AddAnswer(answer);
        }

        public void Remove()
        {

        }

        public void Edit()
        {

        }

        public void UpVote(Answer answer, int userid)
        {
            AnswerBL aBL = new AnswerBL();
            aBL.UpVoteAnswer(answer, userid);
        }

        public void DownVote(Answer answer, int userid)
        {
            AnswerBL aBL = new AnswerBL();
            aBL.DownVoteAnswer(answer, userid);
        }

        public void UpdateStatus(Answer answer)
        {
            AnswerBL aBL = new AnswerBL();
            aBL.UpdateAnswerStatus(answer);
        }
    }
}