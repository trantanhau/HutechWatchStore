using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolexStore.ViewModels
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            ProductVm = new List<CartProductViewModel>();
        }
        public List<CartProductViewModel> ProductVm { get; set; }
    }

    public class CartProductViewModel
    {
        public string ProductID { get; set; }
        public string CollectionName { get; set; }
        public int BuyingQuantity { get; set; }
        public int Price { get; set; }
    }
}