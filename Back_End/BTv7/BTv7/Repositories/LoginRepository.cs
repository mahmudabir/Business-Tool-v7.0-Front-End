﻿using BTv7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTv7.Repositories
{
    public class LoginRepository : Repository<Login>
    {
        //This method is used to check the user credentials
        public bool Login(string username, string password)
        {
            List<Login> userFromDB = this.GetAll();
            return userFromDB.Any(x => x.Username.Equals(username) && x.Password.Equals(password));
        }

        //This method is used to return the User Details
        public Login GetUserDetails(string username, string password)
        {
            List<Login> userFromDB = this.GetAll();
            return userFromDB.FirstOrDefault(x => x.Username.Equals(username) && x.Password == password);
        }
        //This method is used to get the User Details
        public Login GetUserByUsername(string username)
        {
            List<Login> userFromDB = this.GetAll();
            return userFromDB.FirstOrDefault(x => x.Username.Equals(username));
        }

        public Login GetLoginByID(int id)
        {
            List<Login> userFromDB = this.GetAll();
            return userFromDB.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateEmployeeLoginDetails(Login log)
        {
            using (var login = new BTv7DbContext())
            {
                int noOfLoginRowAffected = login.Database.ExecuteSqlCommand("UPDATE Logins SET Email = '" + log.Email + "', Mobile = '" + log.Mobile + "', UserDesignationID = '" + log.UserDesignationID + "' WHERE ID = " + log.ID + ";");
            }
        }

    }
}