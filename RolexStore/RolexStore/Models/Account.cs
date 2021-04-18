using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RolexStore.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        [Required(ErrorMessage = "Please fill your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please fill your last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please fill your email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please fill your phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please fill your address")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string Note { get; set; }

        public Account() { }
    }
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