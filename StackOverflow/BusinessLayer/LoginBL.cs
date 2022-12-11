using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StackOverflow.DataAccess;
using StackOverflow.Classes;

namespace StackOverflow.BusinessLayer
{
    public enum enumAuthenticate
    {
        InvalidUser,
        IncorrectPassword,
        Authenticated
    }
    public class LoginBL
    {
        public enumAuthenticate GetData(User user)
        {
            DataTable data = new LoginDAL().getUserData(user.Username);
            if (data.Rows.Count > 0)
            {
                if (user.Password != data.Rows[0]["Password"].ToString())
                {
                    return enumAuthenticate.IncorrectPassword;
                }
                else
                {
                    return enumAuthenticate.Authenticated;
                }
            }
            else
            {
                return enumAuthenticate.InvalidUser;
            }
        }
        public int getID(string username)
        {
            DataTable data = new LoginDAL().getUserData(username);
            return Convert.ToInt32(data.Rows[0]["ID"]);
        }

        public string getName(string username)
        {
            DataTable data = new LoginDAL().getUserData(username);
            return data.Rows[0]["Name"].ToString();
        }
    }
}