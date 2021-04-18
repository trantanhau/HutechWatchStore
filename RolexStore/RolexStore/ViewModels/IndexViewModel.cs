using RolexStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RolexStore.ViewModels
{
    public class IndexViewModel
    {

        public int SelectedSizeID { get; set; }
        public int SelectedCollectionID { get; set; }
        public int SelectedPriceID { get; set; }
        public List<ProductViewModel> ProductList { get; set; }
        public IEnumerable<SelectListItem> Sizes { get; set; }
        public IEnumerable<SelectListItem> Collections { get; set; }
        public IEnumerable<SelectListItem> Prices { get; set; }
        public IndexViewModel()
        {
            ProductList = new List<ProductViewModel>();
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