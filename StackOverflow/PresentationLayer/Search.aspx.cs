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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Question> SearchQuestions(string search)
        {
            SearchBL sBL = new SearchBL();
            return sBL.GetQuestions(search);
        }
    }
}