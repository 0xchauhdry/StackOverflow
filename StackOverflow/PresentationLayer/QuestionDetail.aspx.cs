using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackOverflow.Classes;
using StackOverflow.BusinessLayer;

namespace StackOverflow.PresentationLayer
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public int questionId;
        public int UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["QuestionID"] != null)
            {
                questionId = Convert.ToInt32(Request.QueryString["QuestionID"]);
            }
        }

        [WebMethod]
        public static int UserVoteStatusQ(int quesid)
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                User user = (User)HttpContext.Current.Session["User"];
                AnswerBL aBL = new AnswerBL();
                return aBL.UserVoteQuestion(user.Id, quesid);
            }
            return 0;
        }

        [WebMethod]
        public static int UserVoteStatusA(int ansid)
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                User user = (User)HttpContext.Current.Session["User"];
                AnswerBL aBL = new AnswerBL();
                return aBL.UserVoteQuestion(user.Id, ansid);
            }
            return 0;
        }

        [WebMethod]
        public static List<Answer> GetAllAnswers(int ID)
        {
            AnswerBL aBL = new AnswerBL();
            return aBL.GetAllAnswers(ID);
        }

        public void AddAnswer(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                User user = (User)Session["User"];
                int userid = user.Id;
                string body = textareaAnswer.Text;
                Answer answer = new Answer(questionId, body, userid);
                AnswerBL aBL = new AnswerBL();
                bool IfExists = aBL.IfExists(body);
                if (IfExists)
                {
                    lblAnswer.Visible = true;
                    lblAnswer.Text = "Same Answer already exists";
                }
                else
                {
                    lblAnswer.Visible = false;
                    answer.Add(answer);
                }
            }
            else
            {
                lblAnswer.Visible = true;
                lblAnswer.Text = "Please Login to Add Answer";
            }
        }

        [WebMethod]
        public static string UpVoteAnswer(int AnsID, int QuesID)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                return "Please Login to Vote";
            }
            else
            {
                User user = (User)HttpContext.Current.Session["User"];
                Answer answer = new Answer(AnsID, QuesID);
                answer.UpVote(answer,user.Id);
                return "Nothing";
            }
        }

        [WebMethod]
        public static string DownVoteAnswer(int AnsID, int QuesID)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                return "Please Login to Vote";
            }
            else
            {
                User user = (User)HttpContext.Current.Session["User"];
                Answer answer = new Answer(AnsID, QuesID);
                answer.DownVote(answer, user.Id);
                return "Nothing";
            }
        }

        [WebMethod]
        public static string UpVoteQuestion(int QuesID)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                return "Please Login to Vote";
            }
            else
            {
                User user = (User)HttpContext.Current.Session["User"];
                Question question = new Question(QuesID);
                question.UpVote(question, user.Id);
                return "Nothing";
            }
        }

        [WebMethod]
        public static string DownVoteQuestion(int QuesID)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                return "Please Login to Vote";
            }
            else
            {
                User user = (User)HttpContext.Current.Session["User"];
                Question question = new Question(QuesID);
                question.DownVote(question, user.Id);
                return "Nothing";
            }
        }

        [WebMethod]
        public static int CurrentUserID()
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                User user = (User)HttpContext.Current.Session["User"];
                return user.Id;
            }
            return 0;
        }

        [WebMethod]
        public static void UpdateAnswerStatus(int AnsID, int value)
        {
            User user = (User)HttpContext.Current.Session["User"];
            Answer answer = new Answer(AnsID, value, user.Id);
            answer.UpdateStatus(answer);
        }
    }
}