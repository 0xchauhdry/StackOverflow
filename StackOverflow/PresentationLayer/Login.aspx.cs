using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackOverflow.BusinessLayer;
using StackOverflow.Classes;

namespace StackOverflow.PresentationLayer
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblusernameLogin.Visible = false;
        }

        public void login(object sender, EventArgs e)
        {
            string username = usernameLogin.Text;
            string password = passwordLogin.Text;

            User user = new User(username, password);
            var userStatus = user.Login(user);

            if (Convert.ToInt32(userStatus) == 0)
            {
                lblusernameLogin.Text = "username is incorrect!";
                lblusernameLogin.Visible = true;
            }
            else if (Convert.ToInt32(userStatus) == 1)
            {
                lblusernameLogin.Text = "Password is incorrect!";
                lblusernameLogin.Visible = true;
            }
            else if (Convert.ToInt32(userStatus) == 2)
            {
                lblusernameLogin.Visible = false;
                User newUser = new User(username);
                Session["User"] = newUser;
                Response.Redirect("Default.aspx?vlogin=1");
            }
        }
    }
}