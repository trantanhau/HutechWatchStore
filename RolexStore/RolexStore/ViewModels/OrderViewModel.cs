using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolexStore.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            ProductVm = new List<CartProductViewModel>();
        }
        public List<CartProductViewModel> ProductVm { get; set; }
        public int CartID { get; set; }
        public int Total { get; set; }
        public string CartStatus { get; set; }
    }
}