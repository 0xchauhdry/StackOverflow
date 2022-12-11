using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackOverflow.Classes;

namespace StackOverflow
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session["User"]!= null)
            {
                UserBtn.Visible = true;
                guestBtns.Visible = false;
            }else
            {
                UserBtn.Visible = false;
                guestBtns.Visible = true;
            }
        }

        public void movetoLogin(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void movetoSignup(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        public void Logout(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            user.LogOut();
            Response.Redirect("Default.aspx?vlogin=0");
        }
    }
}