using RolexStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolexStore.ViewModels
{
    public class CheckoutViewModel
    {
        public CheckoutViewModel()
        {
            ProductVm = new List<CartProductViewModel>();
        }
        public Customer Customer { get; set; }
        public int CartID { get; set; }
        public int Total { get; set; }
        public List<CartProductViewModel> ProductVm { get; set; }

    }
}