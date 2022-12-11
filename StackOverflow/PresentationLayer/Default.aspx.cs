using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackOverflow.BusinessLayer;
using StackOverflow.Classes;

namespace StackOverflow.PresentationLayer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Question> ShowAllQuestions()
        {
            AllQuestionsBL aqBL = new AllQuestionsBL();
            return aqBL.GetAllQuestions();
        }

        [WebMethod]
        public static bool CheckSession()
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                return true;
            }
            else return false;
        }
    }
}