using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackOverflow.Classes;
using StackOverflow.BusinessLayer;

namespace StackOverflow.PresentationLayer
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            lblTitle.Visible = false;
        }

        public void AddQuestion(object sender, EventArgs e)
        {
            var Qtitle = title.Text;
            var body = textarea.Text;
            User user = (User)Session["User"];
            var userid = user.Id;
            string tagValues = fieldTags.Text;
            string[] tags = tagValues.Split(',').ToArray();

            user.Ques = new Question(userid, Qtitle, body);
            AddQuestionBL aqBL = new AddQuestionBL();
            var status = aqBL.CheckTitle(user.Ques);
            if (status)
            {
                lblTitle.Visible = true;
                lblTitle.Text = "Question with same title already exists";
            } else
            {
                DataTable data = user.Ques.Add(user.Ques);
                int Id = Convert.ToInt32(data.Rows[0]["ID"]);
                new Question(userid,Qtitle);
                lblTitle.Visible = false;
                foreach (string tagVal in tags)
                {
                    Tag tag = new Tag(tagVal);
                    DataTable tagData = tag.AddTag(tag);
                    for (int i = 0; i < tagData.Rows.Count; i++)
                    {
                        int tagId = Convert.ToInt32(tagData.Rows[i]["ID"]);
                        Tag ttag = new Tag(Convert.ToInt32(data.Rows[i]["ID"]), tagVal);
                        user.Ques.Tags.Add(ttag);
                        aqBL.AddQuestionTags(Id, tagId);
                    }
                }
                Response.Redirect("Default.aspx");
            }
        }

        [WebMethod]
        public static List<Tag> SearchTag(string search)
        {
            Tag tag = new Tag(search);
            Console.WriteLine("csedx");
            return tag.Search(tag);
            
        }
    }
}