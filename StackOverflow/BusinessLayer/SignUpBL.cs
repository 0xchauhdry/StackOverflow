using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StackOverflow.DataAccess;
using StackOverflow.Classes;

namespace StackOverflow.BusinessLayer
{
    public enum enumSignup
    {
        UsernameExist,
        EmailExist,
        SignUp
    }
    public class SignUpBL
    {
        public enumSignup GetData(User user)
        {
            DataTable data = new SignUpDAL().CheckUser(user.Username);
            if (data.Rows.Count > 0)
            {
                return enumSignup.UsernameExist;
            }
            else
            {
                DataTable datae = new SignUpDAL().CheckEmail(user.Email);
                if (datae.Rows.Count > 0)
                {
                    return enumSignup.EmailExist;
                }
                else
                {
                    return enumSignup.SignUp;
                }
            }
        }

        public void addUserData(string name, string email, string username, string password)
        {
            SignUpDAL sDAL = new SignUpDAL();
            sDAL.AddNewUser(name, email, username, password);
        }
    }
}