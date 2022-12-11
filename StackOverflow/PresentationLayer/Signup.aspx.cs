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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblusernameSignup.Visible = false;
        }

        public void signup(object sender, EventArgs e)
        {
            var username = Username.Text;
            var password = Password.Text;
            var email = Email.Text;
            var name = Name.Text;

            User user = new User(username, email, password);
            var userStatus = user.SignUp(user);

            if (Convert.ToInt32(userStatus) == 0)
            {
                lblusernameSignup.Text = "Username Already Exists";
                lblusernameSignup.Visible = true;
            }
            else if (Convert.ToInt32(userStatus) == 1)
            {
                lblusernameSignup.Text = "Email Already Exists";
                lblusernameSignup.Visible = true;
            }
            else if (Convert.ToInt32(userStatus) == 2)
            {
                lblusernameSignup.Visible = false;
                SignUpBL sBL = new SignUpBL();
                sBL.addUserData(name, email, username, password);
                User newUser = new User(username);
                Session["User"] = newUser;
                Response.Redirect("Default.aspx?vlogin=1");
            }
        }
    }
}