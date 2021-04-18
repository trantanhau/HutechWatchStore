using RolexStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RolexStore.DAL
{
    public class AccountQuery
    {
        WatchModel _db = new WatchModel();
        public bool TryLogin(string username, string password)
        {
            Customer acc = _db.Customers.Where(s => s.Email == username).FirstOrDefault<Customer>();
            if (acc != null)
            {
                if (acc.Password == password)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
        public Customer getAccount(string username)
        {
            Customer temp = new Customer();
            temp = _db.Customers.Where(s => s.Email == username).FirstOrDefault<Customer>();
            return temp;
        }
    }
}