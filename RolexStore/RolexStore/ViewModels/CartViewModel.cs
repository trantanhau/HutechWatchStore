using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int CartID { get; set; }
        public int Total { get; set; }
    }

    public class CartProductViewModel
    {

        [Display(Name = "ID Sản phẩm")]
        public string ProductID { get; set; }
        [Display(Name = "Tên bộ sưu tập")]
        public string CollectionName { get; set; }

        [Display(Name = "Số lượng mua")]
        public int BuyingQuantity { get; set; }
        [Display(Name = "Đơn giá")]
        public int Price { get; set; }
    }
}