using RolexStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RolexStore.ViewModels
{
    public class IndexViewModel
    {   
        public List<ProductViewModel> ProductList { get; set; }
        public List<Size> Sizes { get; set; }
        public List<WatchType> WatchTypes { get; set; }
        public IndexViewModel()
        {
            ProductList = new List<ProductViewModel>();
            Sizes = new List<Size>();
            WatchTypes = new List<WatchType>();
        }
    }


    public class ProductViewModel
    {
        public string ProductID { get; set; }
        public string CollectionName { get; set; }
        public int Price { get; set; }
        public string ProductImg { get; set; }

    }
    

}