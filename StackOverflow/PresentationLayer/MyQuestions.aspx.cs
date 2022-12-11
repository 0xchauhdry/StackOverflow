using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using StackOverflow.BusinessLayer;
using StackOverflow.Classes;

namespace StackOverflow.PresentationLayer
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        [WebMethod]
        public static List<Question> MyQuestions()
        {
            User user = (User)HttpContext.Current.Session["User"];
            MyQuestionsBL mBL = new MyQuestionsBL();
            return mBL.GetQuestions(user.Id);
        }
    }
}