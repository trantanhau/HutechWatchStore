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
            IndexViewModel vm = new IndexViewModel
            {
                SelectedSizeID = 1,
                SelectedCollectionID = 1,
                SelectedPriceID = 1,
            };
            var sizeList = _db.Sizes.ToList<Size>();
            var collectionList = _db.Collections.ToList<Collection>();

            vm.Sizes = new[]
            {
                new SelectListItem  {Value = sizeList[0].SizeID.ToString(), Text = sizeList[0].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[1].SizeID.ToString(), Text = sizeList[1].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[2].SizeID.ToString(), Text = sizeList[2].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[3].SizeID.ToString(), Text = sizeList[3].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[4].SizeID.ToString(), Text = sizeList[4].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[5].SizeID.ToString(), Text = sizeList[5].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[6].SizeID.ToString(), Text = sizeList[6].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[7].SizeID.ToString(), Text = sizeList[7].SizeValue.ToString() },
                new SelectListItem  {Value = sizeList[8].SizeID.ToString(), Text = sizeList[8].SizeValue.ToString() },
            };

            vm.Collections = new[]
            {
                new SelectListItem  {Value = collectionList[0].CollectionID.ToString(), Text = collectionList[0].CollectionName.ToString() },
                new SelectListItem  {Value = collectionList[1].CollectionID.ToString(), Text = collectionList[1].CollectionName.ToString() },
                new SelectListItem  {Value = collectionList[2].CollectionID.ToString(), Text = collectionList[2].CollectionName.ToString() },
                new SelectListItem  {Value = collectionList[3].CollectionID.ToString(), Text = collectionList[3].CollectionName.ToString() },
                new SelectListItem  {Value = collectionList[4].CollectionID.ToString(), Text = collectionList[4].CollectionName.ToString() },
                new SelectListItem  {Value = collectionList[5].CollectionID.ToString(), Text = collectionList[5].CollectionName.ToString() },
            };
            vm.Prices = new[]
            {
                new SelectListItem {Value = "1", Text = "Below 300"},
                new SelectListItem {Value = "2", Text = "300-700"},
                new SelectListItem {Value = "3", Text = "Above 700"},
            };
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
        //[HttpPost]
        //public ActionResult Index(IndexViewModel ivm)
        //{

        //}
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