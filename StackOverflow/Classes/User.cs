using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflow.BusinessLayer;

namespace StackOverflow.Classes
{
    public class User
    {
        public int Id;
        public string Name;
        public string Email;
        public string Username;
        public string Password;

        public Question Ques;
        public Answer Ans;

        //using this constructor to make obj before login
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //using this constructor to make obj before sigh up
        public User(string username, string email, string password)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        //using this constructor to make obj before adding to session
        public User(string username)
        {
            LoginBL bl = new LoginBL();
            Id = bl.getID(username);
            Username = username;
            Name = bl.getName(Username);
        }

        public Enum Login(User user)
        {
            LoginBL lBL = new LoginBL();
            return lBL.GetData(user);
        }

        public void LogOut()
        {
            HttpContext.Current.Session.Abandon();
        }

        public Enum SignUp(User user)
        {
            SignUpBL sBL = new SignUpBL();
            return sBL.GetData(user);
        }
    }
}