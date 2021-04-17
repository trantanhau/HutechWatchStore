using RolexStore.Models;
using RolexStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RolexStore.Controllers
{
    public class WatchController : Controller
    {
        WatchModel _db;
        public WatchController()
        {
            _db = new WatchModel();
        }
        // GET: Watch
        public ActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel();
            vm.Sizes = _db.Sizes.ToList<Size>();
            vm.WatchTypes = _db.WatchTypes.ToList<WatchType>();
            var list = _db.Products.ToList<Product>();
            list.ForEach(s =>
            {
                ProductViewModel productVm = new ProductViewModel()
                {
                    ProductID = s.ProductID,
                    CollectionName = s.Collection.CollectionName,
                    ProductImg = s.ProductImg,
                    Price = s.Price,
                };
                vm.ProductList.Add(productVm);
            });
            return View(vm);

        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}